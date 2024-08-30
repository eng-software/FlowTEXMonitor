/*
   This example code is in the Public Domain

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

namespace FlowTEX
{
    public partial class frmFlowTex : Form
    {
        cFlowTEX FlowTEX;
        cFlow Flow;

        const string defaultTemperatureFormat = "0.0";
        const string defaultTemperatureUnit = "°C";

        bool wasConnected = false;

        BindingSource FlowUnitSource; 
        Stopwatch Stopwatch = new Stopwatch();

        public frmFlowTex()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja-JP");
            InitializeComponent();
            FlowTEX = new cFlowTEX();
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

            FlowUnitSource = new BindingSource(FlowUnits.Names, null);
            comboFlowUnit.DataSource = FlowUnitSource;
            comboFlowUnit.ValueMember = "Key";
            comboFlowUnit.DisplayMember = "Value";
            comboFlowUnit.SelectedValue = eFlowUnit.eCCM;

            progressBar1.Value = 0;
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

                }

                Flow.Value = FlowTEX.getFlow();                
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

            if (Thread.CurrentThread.CurrentUICulture.Name == "pt-BR")
            {
                if (!FlowTEX.isConnected())
                {
                    btnAbrirFlowTEX.Text = "Abrir";
                }
                else
                {
                    btnAbrirFlowTEX.Text = "Fechar";
                }
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name == "ja-JP")
            {
                if (!FlowTEX.isConnected())
                {
                    btnAbrirFlowTEX.Text = "開く";
                }
                else
                {
                    btnAbrirFlowTEX.Text = "閉じる";
                }
            }
            else
            {
                if (!FlowTEX.isConnected())
                {
                    btnAbrirFlowTEX.Text = "Open";
                }
                else
                {
                    btnAbrirFlowTEX.Text = "Close";
                }
            }
        }

        private void comboFlowUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flow.Unit = (eFlowUnit)comboFlowUnit.SelectedValue;
            lblFlow.Text = Flow.ValueString;
            lblUnit.Text = Flow.UnitName;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            
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
                progressBar1.Value =  (int)((double)(Stopwatch.ElapsedMilliseconds / 3000.0) * 100.0);
            }

        }

        private void btnZero_MouseUp(object sender, MouseEventArgs e)
        {
            timerZero.Enabled = false;
            progressBar1.Value = 0;
        }

        private void btnClrZero_Click(object sender, EventArgs e)
        {
            FlowTEX.clearZero();
        }

        private void frmFlowTex_Load(object sender, EventArgs e)
        {
            

        }
    }
}
