﻿using Microsoft.VisualStudio.OLE.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmPluginRegExt.VSPackage.Helpers
{
    public static class PropertyBagExtensions
    {
        public static string Read(this IPropertyBag prop, string key, string defaultValue)
        {
            object pVar;
            try
            {
                prop.Read(key, out pVar, null, 0, null);
                return pVar.ToString();

            }
            catch (Exception)
            {
                // maybe someday we'll map propertybag instead of cataching errors -> https://github.com/pvginkel/VisualGit/blob/master/VisualGit.Package/VisualGitPackage.SolutionProperties.cs
                return defaultValue;
                throw;
            }
        }
        public static bool Read(this IPropertyBag prop, string key, bool defaultValue)
        {
            object pVar;
            try
            {
                prop.Read(key, out pVar, null, 0, null);
                return bool.Parse(pVar.ToString());

            }
            catch (Exception)
            {
                return defaultValue;
                throw;
            }
        }
        public static void Write(this IPropertyBag prop, String key, string value)
        {
            object obj = value;
            prop.Write(key, ref obj);
        }
        public static void WriteBool(this IPropertyBag prop, String key, bool value)
        {
            object obj = value.ToString();
            prop.Write(key, ref obj);
        }

    }
    class IDontCare : IErrorLog
    {
        public void AddError(string pszPropName, EXCEPINFO[] pExcepInfo)
        {
            return;
        }
    }
}
