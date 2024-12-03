using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TEX.FlowUnit;
using TEX.PressureUnit;
using TEX.FlowUnit;
using TEX.XMLParameters;

namespace FlowTEXMonitor
{
    public class cApplicationParameters
    {
        private XMLParameters ParamFile = new XMLParameters();

        public bool FilterEnabled { get; set; } = false;
        public int FilterOrder { get; set; } = 10;
        public eFlowUnit SelectedFlowUnit { get; set; } = eFlowUnit.eCCM;

        public bool Save()
        {
            return ParamFile.Save(this, "config.xml");
        }

        public bool Load() 
        { 
            if(!ParamFile.Load(this,"config.xml"))
            {
                return Save();
            }

            return true;
        }
    }
}
