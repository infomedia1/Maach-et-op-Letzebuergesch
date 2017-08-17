#pragma once

#include <vector>
#include <algorithm>
#include "languages.h"
#include "translation.h"

class TranslatorClass
{
public:
	languageCode SourceLang;
	languageCode TargetLang;
	TranslatorClass();				//constructor
	virtual ~TranslatorClass();		//destructor
	std::vector <translation> translations;
	void getSourceLanguage();
	void getTargetLanguage();

	void initTranslator(languageCode Src, languageCode Trg);
	std::wstring translateToTarget(std::wstring InputString);

	
};
bool operator==(translation const & a, std::wstring const & b);
