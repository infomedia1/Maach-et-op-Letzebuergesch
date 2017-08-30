using System;
using System.Collections.Generic;
using System.Text;

namespace TranslatorClass
{
    public class Translation
    {
        public LanguageCodes SourceLanguage { get; set; }
        public LanguageCodes TargetLanguage { get; set; }

        public String TheSourceWord { get; set; }
        public String TheReturnWord { get; set; }

        //empty Translation Constructor
        public Translation()
        {
            this.SourceLanguage = LanguageCodes.nil;
            this.TargetLanguage = LanguageCodes.nil;
            this.TheSourceWord = null;
            this.TheReturnWord = null;
        }

        public Translation(string SLang, string TLang, string SWord, string RWord)
        {
            //Languages tmpLanguages;
            this.SourceLanguage = Languages.ToLanguage(SLang);
            this.TargetLanguage = Languages.ToLanguage(TLang);
            this.TheSourceWord = SWord;
            this.TheReturnWord = RWord;
        }
    }
}
