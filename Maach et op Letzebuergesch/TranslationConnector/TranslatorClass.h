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
	std::wstring translateToTargets(std::wstring InputString);
	std::wstring getSentenceModules(std::wstring InputString);
	std::wstring translateSentenceEasy(std::wstring InputString);
	std::wstring cunjunctToInfin(std::wstring InputString);

	bool is_verb_in_list(const std::wstring theVerb);

	
};

bool operator==(translation const & a, std::wstring const & b);
