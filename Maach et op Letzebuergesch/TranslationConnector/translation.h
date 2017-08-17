#pragma once

#include "languages.h"

class translation
{
public:
	languageCode thelanguageCode;
	std::wstring TheSource;
	std::wstring TheTarget;
	translation();
	translation(std::wstring in, std::wstring out);
	//void addtranslation(std::string in, std::string out);
	virtual ~translation();
	std::wstring returnIt();
	std::wstring returnSource();
	std::wstring returnTarget();

	bool translation::operator == (translation &) const;
	
};

