#pragma once

#include "languages.h"
#include "WordType.h"

class translation
{
public:
	languageCode thelanguageCode;
	std::wstring TheSource;
	std::wstring TheTarget;
	WordType theWordType;
	sexe theSexe;
	translation();
	translation(std::wstring in, std::wstring out, std::wstring comment, std::wstring word, std::wstring sexx);
	//void addtranslation(std::string in, std::string out);
	virtual ~translation();
	std::wstring returnIt();
	std::wstring returnSource();
	std::wstring returnTarget();
	std::wstring returnWordType();
	WordType getWordType(std::wstring theWordTypeString);
	std::wstring getWordTypeString(WordType t_WordType);

	bool translation::operator == (translation &) const;
	
};
