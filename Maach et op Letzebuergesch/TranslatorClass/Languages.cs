using System;
using System.Collections.Generic;
using System.Text;

namespace TranslatorClass
{
    public class Languages
    {

        public static LanguageCodes ToLanguage(string instr)
        {
            switch (instr)
            {
                case "nil": return LanguageCodes.nil;
                case "de":  return LanguageCodes.de;
                case "lb":  return LanguageCodes.lb;
                case "fr":  return LanguageCodes.fr;
                default:    return LanguageCodes.nil;
            }
        }

    }

    public enum LanguageCodes
    {
        nil,
        de,
        lb,
        fr
    }

    
}
