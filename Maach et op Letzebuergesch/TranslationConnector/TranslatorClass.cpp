#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <locale>
#include <codecvt>
#include <io.h> 
#include <fcntl.h>
#include "TranslatorClass.h"

using namespace std;

TranslatorClass::TranslatorClass()
{
	wcout << L"TranslatorClass Created!" << endl;
}


TranslatorClass::~TranslatorClass()
{
}

void TranslatorClass::getSourceLanguage()
{
	switch (this->SourceLang)
	{
		case languageCode::de: wcout << L"DE" << endl; break;
		case languageCode::lu: wcout << L"LU" << endl; break;
	}
}

void TranslatorClass::getTargetLanguage()
{
	switch (this->TargetLang)
	{
		case languageCode::de: wcout << L"DE" << endl; break;
		case languageCode::lu: wcout << L"LU" << endl; break;
	}
}

void TranslatorClass::initTranslator(languageCode Src, languageCode Trg)
{
	this->SourceLang = Src;
	this->TargetLang = Trg;
	
	//std::string filename = "lod_DE_LB - Kopie.utf8";
	std::string filename = "lod_DE_LB.utf8";
	std::wifstream wif(filename);
	wif.imbue(std::locale(std::locale::empty(), new std::codecvt_utf8<wchar_t, 0x10ffff, std::consume_header>));

	_setmode(_fileno(stdout), _O_U8TEXT);
	std::wstring wline;
	std::wstring InPut;
	std::wstring OutPut;

	while (std::getline(wif, wline))
	{
	
		wistringstream witems(wline);
		wstring token;
		std::getline(witems, InPut, L'\t');
		std::getline(witems, OutPut, L'\t');
		
		
		//std::getline(witems, OutPut,'\t');

		translation theEmptyTranslation(InPut, OutPut);
		this->translations.push_back(theEmptyTranslation);

		//wcout << InPut << L" / " << OutPut << endl;
	}
	wif.close();
	
	/*
	std::wstringstream wss;
	cout << wif.rdbuf();
	cout << wss.str();
	*/

}

std::wstring TranslatorClass::translateToTarget(std::wstring InputString)
{
	std::vector <translation>::iterator Posi;


	Posi = find(this->translations.begin(), this->translations.end(), InputString);
	if (Posi != this->translations.end())
	{
		return Posi->returnTarget();
	}
	else {
		return L" ";
	}
	/*
	if (std::find(this->translations.begin(), this->translations.end(), InputString) != this->translations.end())
	{
		return
	} else {
		return L" ";
	}
	*/
}


bool operator==(translation const & a, std::wstring const & b)
{
	return a.TheSource==b;
}
