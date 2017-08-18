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
	std::string filename = "lod_DE_LB.csv";
	//std::string filename = "lod_DE_LB.utf8";
	std::wifstream wif(filename);
	wif.imbue(std::locale(std::locale::empty(), new std::codecvt_utf8<wchar_t, 0x10ffff, std::consume_header>));

	_setmode(_fileno(stdout), _O_U8TEXT);
	std::wstring wline;
	std::wstring InPut;
	std::wstring OutPut;
	std::wstring Comment;
	std::wstring Word;
	std::wstring SeX;

	while (std::getline(wif, wline))
	{
	
		InPut = L"";
		OutPut = L"";
		Word = L"";
		SeX = L"";
		wistringstream witems(wline);

		std::getline(witems, InPut, L'\t');
		std::getline(witems, OutPut, L'\t');
		std::getline(witems, Comment, L'\t');
		std::getline(witems, Word, L'\t');
		std::getline(witems, SeX, L'\t');
		
		//std::getline(witems, OutPut,'\t');

		translation theEmptyTranslation(InPut, OutPut, Comment, Word, SeX);
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
}

std::wstring TranslatorClass::getSentenceModules(std::wstring InputString)
{
	std::vector <translation>::iterator Posi;
	
	std::wstring result = L"";
	std::wstring TheDeterminer = L"";
	std::wstring theResWord = L"";
	std::wstring tmpRes = L"";
	std::wstring tmpTarget = L"";
	int counter = 0;
	// run through words
	wistringstream witems(InputString);
	while (std::getline(witems, theResWord,L' '))
	{
		//tmpRes = tmpRes + theResWord;

		//If there is a point or comma, remove it
		if (theResWord[theResWord.size() - 1] == L'.' || 
			theResWord[theResWord.size() - 1] == L',' || 
			theResWord[theResWord.size() - 1] == L';' || 
			theResWord[theResWord.size() - 1] == L':')
		{
			TheDeterminer = theResWord[theResWord.size() - 1];
			theResWord = theResWord.substr(0, theResWord.size() - 1);
		}
		else TheDeterminer = L"";

		//check if translation exists.
		Posi = find(this->translations.begin(), this->translations.end(), theResWord);
		if (Posi != this->translations.end())
		{
			tmpTarget = L"<" + Posi->returnWordType() + L">";

		}
		else {
			tmpTarget = L"<N#F>";
		}
		tmpRes = tmpRes  + tmpTarget + TheDeterminer + L" ";
	}
	result = tmpRes;

	//output result
	return result;
}

std::wstring TranslatorClass::translateSentenceEasy(std::wstring InputString)
{
	std::vector <translation>::iterator Posi;

	std::wstring result = L"";
	std::wstring TheDeterminer = L"";
	std::wstring theResWord = L"";
	std::wstring tmpRes = L"";
	std::wstring tmpTarget = L"";
	
	// run through words
	wistringstream witems(InputString);
	while (std::getline(witems, theResWord, L' '))
	{
		//tmpRes = tmpRes + theResWord;

		//If there is a point or comma, remove it
		if (theResWord[theResWord.size() - 1] == L'.' ||
			theResWord[theResWord.size() - 1] == L',' ||
			theResWord[theResWord.size() - 1] == L';' ||
			theResWord[theResWord.size() - 1] == L':')
		{
			TheDeterminer = theResWord[theResWord.size() - 1];
			theResWord = theResWord.substr(0, theResWord.size() - 1);
		}
		else TheDeterminer = L"";

		//check if translation exists.
		Posi = find(this->translations.begin(), this->translations.end(), theResWord);
		if (Posi != this->translations.end())
		{
			tmpTarget =Posi->returnTarget();

		}
		else {
			tmpTarget = L"<N#F>";
			tmpTarget = this->cunjunctToInfin(theResWord);
		}
		tmpRes = tmpRes + tmpTarget + TheDeterminer + L" ";
	}
	result = tmpRes;

	//output result
	return result;
}

std::wstring TranslatorClass::cunjunctToInfin(std::wstring InputString)
{
	std::wstring Infinitiv = L"";

	//default Rule (verbs ending with -en) -> -e, -st -> -t -> -en -> -t -> -en
	switch (InputString[InputString.size()-1])
	{
	case 'n':
		Infinitiv = InputString.substr(0, InputString.size() - 1) + L"en";
		if (is_verb_in_list(Infinitiv)) { return Infinitiv; }
		else { return L""; }
		break;
	case 'e':
		Infinitiv = InputString.substr(0, InputString.size() - 1) + L"en";
		if (is_verb_in_list(Infinitiv)) { return Infinitiv; }
		else { return L""; }
		break;
	case 't' :
		//default Rule (verbs ending with -en)
		Infinitiv = InputString.substr(0, InputString.size() - 1) + L"en";
		if (is_verb_in_list(Infinitiv)) { return Infinitiv; }
		else { 
			Infinitiv = InputString.substr(0, InputString.size() - 2) + L"en";
			if (is_verb_in_list(Infinitiv)) { return Infinitiv; }
			else { return L""; }
		}
		break;
	}
	
	if (InputString[InputString.size() - 1] ==L'e') {}
	if (InputString[InputString.size() - 2] == L's' && InputString[InputString.size() - 1] == L't') {}
	if (InputString[InputString.size() - 1] == L't') {}
	if (InputString[InputString.size() - 2] == L'e' && InputString[InputString.size() - 1] == L'n')
	{

	}

	return Infinitiv;
}


bool TranslatorClass::is_verb_in_list(const std::wstring theVerb)
{
	std::vector <translation>::iterator Posi;
	Posi = find(this->translations.begin(), this->translations.end(), theVerb);
	if (Posi != this->translations.end())
	{
		if (Posi->theWordType == WordType::verb) { return true; }
		else { return false; }
	}
	else {
		//Not Found
		return false;
	}
}

bool operator==(translation const & a, std::wstring const & b)
{
	std::wstring in = a.TheSource;
	std::wstring out = b;
	//transform(in.begin(), in.end(), in.begin(), towlower);
	//transform(out.begin(), out.end(), out.begin(), towlower);
	return in == out;
}
