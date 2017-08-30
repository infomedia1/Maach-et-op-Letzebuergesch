using System;
using System.Collections.Generic;

namespace TranslatorClass
{
    public class ATranslator
    {
        public LanguageCodes SourceLanguage { get; set; }
        public LanguageCodes TargetLanguage { get; set; }


        public List<Translation> Translations = new List<Translation>();

        //Constructor
        public ATranslator()
        {
            this.SourceLanguage = LanguageCodes.nil;
            this.TargetLanguage = LanguageCodes.nil;
        }

        public ATranslator(string SLang, string TLang)
        {
            this.SourceLanguage = Languages.ToLanguage(SLang);
            this.TargetLanguage = Languages.ToLanguage(TLang);
        }

        public string TranslateToTargetString(string Input)
        {
            Translation tmpTranslation = null;
            tmpTranslation = this.Translations.Find(x => x.TheSourceWord.Equals(Input));
            if (tmpTranslation != null)
            { return tmpTranslation.TheReturnWord; } else { return null; }
        }
    }

}
