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
            string cleanedInput = null;
            string theDelimiter = null;

            switch (Input[Input.Length-1])
            {
                case '.':
                    theDelimiter = ".";
                    cleanedInput = Input.Substring(0, Input.Length - 1);
                    break;
                case ',':
                    theDelimiter = ",";
                    cleanedInput = Input.Substring(0, Input.Length - 1);
                    break;
                case ';':
                    theDelimiter = ";";
                    cleanedInput = Input.Substring(0, Input.Length - 1);
                    break;
                case ':':
                    theDelimiter = ":";
                    cleanedInput = Input.Substring(0, Input.Length - 1);
                    break;
                default:
                    cleanedInput = Input;
                    break;
            }

            tmpTranslation = this.Translations.Find(x => x.TheSourceWord.Equals(cleanedInput));
            if (tmpTranslation != null)
            {
                if (!string.IsNullOrEmpty(theDelimiter))
                {
                    return tmpTranslation.TheReturnWord + theDelimiter;
                } else
                {
                    return tmpTranslation.TheReturnWord;
                }
            } else { return null; }
        }

        public string TranslateSentenceToTargetStringEasy(string Input)
        {
            string[] Words;
            string ResultString = null;
            Words = Input.Split(' ');



            for (int i = 0; i <= Words.Length - 1; i++)
            {
                string tmpRes = null;
                tmpRes = this.TranslateToTargetString(Words[i]);
                if (string.IsNullOrEmpty(tmpRes)) { tmpRes = '\u04FF'+Words[i]; }
                if (!string.IsNullOrEmpty(tmpRes))
                {
                    if (i > 0) ResultString += " ";
                    ResultString += tmpRes;
                }
                
            }
            return ResultString;
        }
    }

}
