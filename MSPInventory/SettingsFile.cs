using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MSPInventory
{
    class SettingsFile
    {
        private string[]    m_arrSettings = null;
        private string      m_strFile = "";

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="strPath"></param>
        public SettingsFile(string strFile)
        {
            // open settings file
            m_strFile = strFile;
            if (File.Exists(m_strFile))
                m_arrSettings = File.ReadAllLines(m_strFile);                
        }

        /// <summary>
        /// deletes all parameters
        /// </summary>
        public void ClearParams()
        {
            // deletes all settings
            m_arrSettings = null;
        }

        /// <summary>
        /// gets the list of settings
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public string[] GetParams()
        {
            string strParams = "";
            try
            {
                // loop through settings
                foreach (string strTemp in m_arrSettings)
                {
                    // check parameter
                    if (strTemp != "")
                        strParams += String.Format("{0}\n", strTemp.Substring(0, strTemp.IndexOf("=")));
                }
            }
            catch {}
            return strParams.Trim().Split("\n".ToCharArray());
        }

        /// <summary>
        /// gets the setting of project
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public string GetParam(string strParam)
        {
            // check settings
            if ((m_arrSettings == null) || (strParam == "")) return "";
            try
            {
                // loop through settings
                foreach (string strTemp in m_arrSettings)
                {
                    // check parameter
                    if (strTemp.StartsWith(strParam))
                        return strTemp.Substring(strTemp.IndexOf("=") + 1);
                }
            }
            catch {}
            return "";
        }

        /// <summary>
        /// deletes the setting
        /// </summary>
        /// <param name="strParam"></param>
        /// <returns></returns>
        public void DeleteParam(string strParam)
        {
            // check settings
            if ((m_arrSettings == null) || (strParam == "")) return;
            try
            {
                // loop through settings
                for (int i = 0; i < m_arrSettings.Length; i++)
                {
                    // check parameter
                    if (m_arrSettings[i].StartsWith(strParam))
                    {
                        // clear params
                        m_arrSettings[i] = "";
                        return;
                    }
                }
            }
            catch {}
        }

        /// <summary>
        /// updates project settings
        /// </summary>
        /// <param name="strParam"></param>
        /// <param name="strValue"></param>
        public void SetParam(string strParam, object objValue)
        {
            try
            {
                // check settings
                string strValue = objValue.ToString();
                if (m_arrSettings != null)
                {
                    // loop through settings
                    for (int i = 0; i < m_arrSettings.Length; i++)
                    {
                        // check parameter
                        string strTemp = m_arrSettings[i];
                        if (strTemp.StartsWith(strParam))
                        {
                            // update settings
                            m_arrSettings[i] = String.Format("{0}={1}", strParam, strValue);
                            return;
                        }
                    }
                }

                // add settings
                int iCount = (m_arrSettings == null ? 0 : m_arrSettings.Length);
                Array.Resize<string>(ref m_arrSettings, iCount + 1);
                m_arrSettings[iCount] = String.Format("{0}={1}", strParam, strValue);
            }
            catch {}
        }

        /// <summary>
        /// saves the settings file
        /// </summary>
        public void Save()
        {
            // save on same settings file
            Save(m_strFile);
        }

        /// <summary>
        /// saves the settings file
        /// </summary>
        public void Save(string strFile)
        {
            // check settings
            if (m_arrSettings == null) return;
            try
            {
                // delete old file if existing
                if (File.Exists(m_strFile))
                    File.Delete(m_strFile);

                // delete new file if existing
                if (File.Exists(strFile))
                    File.Delete(strFile);
                
                // check directory
                if (!Directory.Exists(Path.GetDirectoryName(strFile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(strFile));
                
                // create file
                FileStream fStream = new FileStream(strFile, FileMode.Create, FileAccess.Write);
                StreamWriter fWriter = new StreamWriter(fStream);

                // loop through settings
                foreach (string strTemp in m_arrSettings)
                {
                    // save settings
                    if (strTemp.Trim() != "")
                        fWriter.WriteLine(strTemp);
                }

                // save file
                fWriter.Flush();
                fWriter.Close();
            }
            catch {}
        }
    }
}
