using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMMON
{
    public static class Common
    {
        public static string ConfigVariable(string param)
        {
            String temp = String.Empty; 
            try
            {
                temp = System.Configuration.ConfigurationSettings.AppSettings[param];
            }
            catch
            {
            }
            return temp;
        }
    }
}
