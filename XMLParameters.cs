using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace TEX.XMLParameters
{
    public class XMLParameters
    {
        public string ConfigurationFolder { get; set; }
        public XMLParameters()
        {
            ConfigurationFolder = "";
        }

        protected string GetConfigurationFolder()
        {
            if ((ConfigurationFolder == null) || (ConfigurationFolder == ""))
            { return Path.GetFullPath(".\\"); }
            else
            { return ConfigurationFolder; }

        }

        public bool Load(object ObjToLoad, string ConfigFileName) 
        {
            int retry = 3;

            do
            {
                try
                {
                    string ConfigFolder = GetConfigurationFolder();
                    string ConfigFilePath = ConfigFolder + "\\" + ConfigFileName;

                    if ((!Directory.Exists(ConfigFolder)) || (!File.Exists(ConfigFilePath)))
                    {
                        return false;
                    }
                    else
                    {
                        XmlSerializer xmlConfiguration = new XmlSerializer(ObjToLoad.GetType());

                        using (StreamReader rd = new StreamReader(ConfigFilePath))
                        {
                            XmlReaderSettings xmlSetting = new XmlReaderSettings() { CheckCharacters = false };
                            XmlReader xmlReader = XmlTextReader.Create(rd, xmlSetting);
                            Object Data = xmlConfiguration.Deserialize(xmlReader);
                            Type objectType = ObjToLoad.GetType();
                            Data = Convert.ChangeType(Data, objectType);

                            //Activator.CreateInstance(objectType);

                            //objectType LoadedObject = Data as objectType;
                            //ObjToLoad = Data as T;
                            CopyAllTo(Data, ObjToLoad);
                            return true;
                        }
                    }
                }
                catch
                { }

                retry--;
            }
            while (retry > 0);

            return false;
        }

        public bool Save(object ObjToSave, string ConfigFileName)
        {
            int retry = 3;
            do
            {
                try
                {
                    /*-------------------------------------------------------------
                     * Serialize data and save into a XML file
                     * ---------------------------------------------------------- */
                    string ConfigFolder = GetConfigurationFolder();
                    string ConfigFilePath = ConfigFolder + "\\" + ConfigFileName;

                    if (!Directory.Exists(ConfigFolder))
                    {
                        Directory.CreateDirectory(ConfigFolder);
                    }

                    XmlSerializer xmlConfiguration = new XmlSerializer(ObjToSave.GetType());

                    using (StreamWriter sw = new StreamWriter(ConfigFilePath))
                    {
                        xmlConfiguration.Serialize(sw, ObjToSave);
                    }


                    /*-------------------------------------------------------------
                     * Try to load file -  this will check if file is not currupted
                     * ---------------------------------------------------------- */
                    try
                    {
                        xmlConfiguration = new XmlSerializer(ObjToSave.GetType());

                        using (StreamReader rd = new StreamReader(ConfigFilePath))
                        {
                            XmlReaderSettings xmlSetting = new XmlReaderSettings() { CheckCharacters = false };
                            XmlReader xmlReader = XmlTextReader.Create(rd, xmlSetting);
                            Object Data = xmlConfiguration.Deserialize(xmlReader);
                        }

                        return true;
                    }
                    catch
                    { }
                    //-----------------------------------------------
                }
                catch
                { }

                retry--;

            }
            while (retry > 0);

            return false;
        }

        public void CopyAllTo(object source, object target) 
        {
            var type = source.GetType();
            foreach (var sourceProperty in type.GetProperties())
            {
                var targetProperty = type.GetProperty(sourceProperty.Name);
                targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
            }
            foreach (var sourceField in type.GetFields())
            {
                var targetField = type.GetField(sourceField.Name);
                targetField.SetValue(target, sourceField.GetValue(source));
            }
        }

        public void CopyBindingList(IList<object> source, IList<object> target)
        {
            target.Clear();
            foreach (object srcObj in source)
            { target.Add(srcObj); }
        }

    }
}
