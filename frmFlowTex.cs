/*
   Th/s example code is in the Public Domain

   This software is distributed on an "AS IS" BASIS, 
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
   either express or implied.

   Este código de exemplo é de uso publico,

   Este software é distribuido na condição "COMO ESTÁ",
   e NÃO SÃO APLICÁVEIS QUAISQUER GARANTIAS, implicitas 
   ou explicitas
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEX;
using System.IO;
using System.IO.Ports;
using TEX.FlowUnit;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using FlowTEXMonitor;
using FlowTEXMonitor.Properties;
using TEX.XMLParameters;

namespace FlowTEX
{
    public partial class frmFlowTex : Form
    {
        cFlowTEX FlowTEX;
        cEMAFilter FlowFilter;
        cFlow Flow;        
        cApplicationParameters ApplicationParameters;
        bool loadingParameters = false;

        const string defaultTemperatureFormat = "0.0";
        const string defaultTemperatureUnit = "°C";

        bool wasConnected = false;

        Binding I2CaddressBinding;
        public byte I2CAddress
        {
            get;
            set;
        }

        BindingSource FlowUnitSource; 
        Stopwatch Stopwatch = new Stopwatch();
        private ResourceManager TextosManager;
        private CultureInfo culture;

        public frmFlowTex()
        {
            TextosManager = new ResourceManager("FlowTEXMonitor.Textos", typeof(frmFlowTex).Assembly);
            culture = CultureInfo.CurrentUICulture;

            InitializeComponent();
            loadingParameters = true;
            FlowTEX = new cFlowTEX();
            FlowFilter = new cEMAFilter();
            Flow = new cFlow();
            lblFlow.Text = Flow.ValueString;
            lblUnit.Text = Flow.UnitName;
            lblTemperature.Text = FlowTEX.getTemperature().ToString(defaultTemperatureFormat) + defaultTemperatureUnit;

            comboSerialFlowTex.DropDown += ComboSerialFlowTex_DropDown;
            comboSerialFlowTex.Items.Add("AUTO");
            comboSerialFlowTex.SelectedIndex = 0;

            lblSerialNumber.Text = "";
            lblVersion.Text = "";
            lblModel.Text = "";

            I2CaddressBinding = edtI2CAddress.DataBindings.Add("Text", this, "I2CAddress");
            I2CaddressBinding.Format += I2CaddressBinding_Format;
            I2CaddressBinding.Parse += I2CaddressBinding_Parse;

            FlowUnitSource = new BindingSource(FlowUnits.Names, null);
            comboFlowUnit.ValueMember = "Key";
            comboFlowUnit.DisplayMember = "Value";
            comboFlowUnit.DataSource = FlowUnitSource;
            comboFlowUnit.SelectedValue = eFlowUnit.eCCM;

            chkEnableFilter.Checked = true;
            trackFilterOrder.Enabled = chkEnableFilter.Checked;
            trackFilterOrder.Value = 10;
            FlowFilter.Alpha = 0.6d;
            FlowFilter.Order = trackFilterOrder.Value;

            progbarZero.Value = 0;
                        
            ApplicationParameters = new cApplicationParameters();
            loadParameters();
        }

        void saveParameters()
        {
            if (!loadingParameters)
            {
                ApplicationParameters.FilterOrder = trackFilterOrder.Value;
                ApplicationParameters.FilterEnabled = chkEnableFilter.Checked;
                ApplicationParameters.SelectedFlowUnit = Flow.Unit;
                ApplicationParameters.Save();
            }
        }

        void loadParameters()
        {
            loadingParameters = true;
            ApplicationParameters.Load();            
            trackFilterOrder.Value = ApplicationParameters.FilterOrder;
            chkEnableFilter.Checked = ApplicationParameters.FilterEnabled;
            Flow.Unit = ApplicationParameters.SelectedFlowUnit;
            comboFlowUnit.SelectedValue = Flow.Unit;            
            lblFlow.Text = Flow.ValueString;
            lblUnit.Text = Flow.UnitName;
            loadingParameters = false;
        }


        private void I2CaddressBinding_Parse(object sender, ConvertEventArgs e)
        {
            string s = (string)e.Value;
            byte result = 0;
            bool bSuccess = false;

            if ((s != null) &&
                ((s.StartsWith("0x")) || (s.StartsWith("0X"))) &&
                byte.TryParse(s.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out result))
            {
                if ((result > 0) && (result <= 0x7F))
                {
                    e.Value = result;
                    bSuccess = true;
                }
                else
                {
                    e.Value = I2CAddress;
                }
            }
            else if (byte.TryParse(s, out result))
            {
                if ((result > 0) && (result <= 0x7F))
                {
                    e.Value = result;
                    bSuccess = true;
                }
                else
                {
                    e.Value = I2CAddress;
                }
            }

            if (!bSuccess)
            {
                
                //MessageBox.Show("Valor inválido!\n Valores permitidos 0x01 a 0x7F", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                MessageBox.Show(TextosManager.GetString("AlertaI2CAddrInvalido", culture),
                                TextosManager.GetString("TituloAlertaI2CAddrInvalido", culture), 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void I2CaddressBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string))
            {
                e.Value = "0x" + (string)((byte)e.Value).ToString("X2");
            }
        }

        private void ComboSerialFlowTex_DropDown(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            List<string> ComList = new List<string>();

            string value = "";
            if(combo.SelectedIndex >= 0)
            {
                value = combo.SelectedItem.ToString();
            }

            ComList.Clear();
            ComList.AddRange(SerialPort.GetPortNames());
            ComList.Sort();

            combo.Items.Clear();
            combo.Items.Add("AUTO");
            combo.Items.AddRange(ComList.ToArray());
            
            if(value != "")
            {
                foreach(object item in combo.Items)
                {
                    if(item.ToString() == value)
                    {
                        combo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if(FlowTEX.isConnected())
            {
                if(!wasConnected)
                {
                    wasConnected = true;

                    if(FlowTEX.getModel(out string model))
                    {
                        try
                        {
                            lblModel.Text = model;

                            /* 
                             *  Model Format
                             *       0         1
                             *       012345678901234567
                             *       FT02qqq/cpdagtipee
                            */
                            double range = ((((int)(model[4] - 0x30) * 1.0) +
                                             ((int)(model[5] - 0x30) * 0.1))) *
                                            Math.Pow(10.0, (int)(model[6] - 0x30));

                            switch (model[13])
                            {
                                case '0':
                                lblStandarization.Text = "0°C";
                                break;

                                case '1':
                                lblStandarization.Text = "15°C";
                                break;

                                case '2':
                                lblStandarization.Text = "20°C";
                                break;

                                default:
                                lblStandarization.Text = "21°C";
                                break;
                            }

                            Flow.SetRange(range);                            
                        }
                        catch
                        {
                            Flow.SetRange(0);
                            lblStandarization.Text = "21°C";
                        }

                    }

                    if(FlowTEX.getSerialNumber(out string serialNumber))
                    {
                        lblSerialNumber.Text = serialNumber;
                    }

                    if(FlowTEX.getVersion(out string version))
                    {
                        lblVersion.Text = version;
                    }

                    if (FlowTEX.getI2CAddress(out byte Address))
                    {
                        I2CAddress = Address;
                        I2CaddressBinding.ReadValue();
                    }

                }

                double sensorFlow = FlowTEX.getFlow();
                FlowFilter.filter(sensorFlow);

                if (trackFilterOrder.Enabled)
                { Flow.Value = FlowFilter.FilteredValue; }
                else
                { Flow.Value = sensorFlow;               }

                lblFlow.Text = Flow.ValueString;
                lblUnit.Text = Flow.UnitName;
                lblTemperature.Text = FlowTEX.getTemperature().ToString(defaultTemperatureFormat) + defaultTemperatureUnit;
            }
            else
            {
                wasConnected = false;
            } 

            if(FlowTEX.hasError())
                icoFlowTEX.Image = imgStatus.Images[1];
            else
                icoFlowTEX.Image = imgStatus.Images[0];
        }

        private void btnAbrirFlowTEX_Click(object sender, EventArgs e)
        {
            if (!FlowTEX.isConnected())
            {
                if (!FlowTEX.isActive())
                {
                    if ((comboSerialFlowTex.SelectedItem != null) && (comboSerialFlowTex.SelectedIndex > 0))
                    {
                        FlowTEX.setSerialPort(comboSerialFlowTex.SelectedItem.ToString());
                    }
                    else
                    {
                        FlowTEX.setSerialPort(null);
                    }

                    FlowTEX.init();
                    tmrRefresh.Enabled = true;
                }
                else
                {
                    if ((comboSerialFlowTex.SelectedItem != null) && (comboSerialFlowTex.SelectedIndex > 0))
                    {
                        FlowTEX.setSerialPort(comboSerialFlowTex.SelectedItem.ToString());
                    }
                    else
                    {
                        FlowTEX.setSerialPort(null);
                    }

                    FlowTEX.connect();
                }
            }
            else
            {
                FlowTEX.disconnect();
            }

            if (!FlowTEX.isConnected())
            {
                btnAbrirFlowTEX.Text = TextosManager.GetString("Abrir", culture);
            }
            else
            {
                btnAbrirFlowTEX.Text = TextosManager.GetString("Fechar", culture);
            }
        }

        private void edtI2CAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Validate();
            }
        }

        private void btnChangeI2CAddress_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(TextosManager.GetString("AlertaTrocaI2C", culture), TextosManager.GetString("TituloAlterarI2C", culture), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (FlowTEX.setI2CAddress(I2CAddress))
                { MessageBox.Show(TextosManager.GetString("SucessoTrocaI2C", culture) , TextosManager.GetString("TituloAlterarI2C", culture), MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                { MessageBox.Show(TextosManager.GetString("FalhaTrocaI2C", culture) , TextosManager.GetString("TituloAlterarI2C", culture), MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void comboFlowUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flow.Unit = (eFlowUnit)comboFlowUnit.SelectedValue;
            lblFlow.Text = Flow.ValueString;
            lblUnit.Text = Flow.UnitName;
            saveParameters();
        }

        private void btnZero_MouseDown(object sender, MouseEventArgs e)
        {
            timerZero.Enabled = true;
            Stopwatch.Restart();
        }

        private void timerZero_Tick(object sender, EventArgs e)
        {
            if(Stopwatch.ElapsedMilliseconds > 3000)
            {
                timerZero.Enabled=false;                
                FlowTEX.setZero();
            }
            else
            {
                progbarZero.Value =  (int)((double)(Stopwatch.ElapsedMilliseconds / 3000.0) * 100.0);
            }
        }

        private void btnZero_MouseUp(object sender, MouseEventArgs e)
        {
            timerZero.Enabled = false;
            progbarZero.Value = 0;
        }

        private void btnClrZero_Click(object sender, EventArgs e)
        {
            FlowTEX.clearZero();
        }

        void resourceApplyer( Control.ControlCollection ctrlCollection, ComponentResourceManager resources)
        {
            foreach (Control control in ctrlCollection)
            {
                resources.ApplyResources(control, control.Name);

                if(control.HasChildren)
                {
                    resourceApplyer(control.Controls, resources);
                }
            }
        }

        private void ApplyLanguage(string cultureCode)
        {
            culture = new CultureInfo(cultureCode);

            // Define a cultura atual
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);

            // Cria um ResourceManager para gerenciar os recursos do formulário
            ComponentResourceManager resources = new ComponentResourceManager(typeof(frmFlowTex));
            resourceApplyer(this.Controls, resources);

            // Também aplica os recursos ao próprio formulário (por exemplo, título)
            resources.ApplyResources(this, "$this");

            lblSerialNumber.Text = "";
            lblVersion.Text = "";
            lblModel.Text = "";
            lblTemperature.Text = "";

            lblFlow.Text = Flow.ValueString;
            lblUnit.Text = Flow.UnitName;
            lblTemperature.Text = FlowTEX.getTemperature().ToString(defaultTemperatureFormat) + defaultTemperatureUnit;
            trackFilterOrder.Enabled = chkEnableFilter.Checked;
            trackFilterOrder.Value = FlowFilter.Order;
        }

        private void btnJapan_Click(object sender, EventArgs e)
        {
            ApplyLanguage("ja-JP");
        }

        private void btnBrazil_Click(object sender, EventArgs e)
        {
            ApplyLanguage("pt-BR");
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            ApplyLanguage("en");
        }

        private void trackFilterOrder_Scroll(object sender, EventArgs e)
        {
            FlowFilter.Order = trackFilterOrder.Value;
            saveParameters();
        }

        private void chkEnableFilter_CheckedChanged(object sender, EventArgs e)
        {
            trackFilterOrder.Enabled = chkEnableFilter.Checked;
            saveParameters();
        }

        private void frmFlowTex_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
