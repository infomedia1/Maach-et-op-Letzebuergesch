#pragma once

#include <string>

#ifdef TRANSLATIONCONNECTOR_EXPORTS  
#define TRANSLATIONCONNECTOR_API __declspec(dllexport)   
#else  
#define TRANSLATIONCONNECTOR_API __declspec(dllimport)   
#endif  


class TRANSLATIONCONNECTOR_API CTranslationConnector {
	public:
		enum Language { de, lu };
		enum WordType { noun, verb, adjective, adverb, pronoun, conjunction, determiner, excalamtion };
		CTranslationConnector(void);
		virtual ~CTranslationConnector(void) = 0;
		static void InitIt(void);
	class Functions
	{
		public:
			static TRANSLATIONCONNECTOR_API std::wstring EasyTranslate(std::wstring input, Language targetLanguage);
	};
	class Words
	{
		Language theSourceLanguage;
		Language theTargetLanguage;
		WordType theWordType;
		int theValue = 0;
		std::wstring theSourceWord;
		std::wstring theTargetWord;
	public:
		Words(Language sourceLang, Language targetLang, WordType selWordType, std::wstring sourceword, std::wstring targetword);
		~Words(void);
	};
	
};

extern TRANSLATIONCONNECTOR_API int nTranslationConnector_API;

TRANSLATIONCONNECTOR_API int fnTranslationConnector_API(void);