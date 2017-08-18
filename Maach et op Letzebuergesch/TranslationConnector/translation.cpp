#include "stdafx.h"
#include <iostream>
#include "translation.h"

using namespace std;

translation::translation()
{
	cout << "Translation created!" << endl;
}

translation::translation(std::wstring in, std::wstring out, std::wstring comment, std::wstring word, std::wstring sexx)
{
	this->TheSource = in;
	this->TheTarget = out;
	this->thelanguageCode = languageCode::de;
	if (word == L"noun") { this->theWordType = WordType::noun; }
	if (word == L"verb") { this->theWordType = WordType::verb; }
	if (word == L"adjective") { this->theWordType = WordType::adjective; }
	if (word == L"adverb") { this->theWordType = WordType::adverb; }
	if (word == L"pronoun") { this->theWordType = WordType::pronoun; }
	if (word == L"conjunction") { this->theWordType = WordType::conjunction; }
	if (word == L"determiner") { this->theWordType = WordType::determiner; }
	if (word == L"excalamation") { this->theWordType = WordType::excalamation; }
	if (word == L"preposition") { this->theWordType = WordType::preposition; }

	if (word.size() == 0 || word.size() == 1)
	{
		this->theWordType = WordType::nil;
	}
	if (sexx == L"mas") { this->theSexe = sexe::mas; }
	if (sexx == L"fem") { this->theSexe = sexe::fem; }
	
	if (sexx.size() == 0 || sexx.size() == 1)
	{
		this->theSexe = sexe::nil;
	}
}

translation::~translation()
{
}

std::wstring translation::returnIt()
{
	std::wstring theReturn = L"";
	theReturn = L"Source: " + this->TheSource + L" Target: " + this->TheTarget;
	return theReturn;
}

std::wstring translation::returnSource()
{
	return TheSource;
}

std::wstring translation::returnTarget()
{
	return TheTarget;
}

std::wstring translation::returnWordType()
{

	return getWordTypeString(this->theWordType);
}

WordType translation::getWordType(std::wstring theWordTypeString)
{
	if (theWordTypeString == L"noun") { return WordType::noun; }
	if (theWordTypeString == L"verb") { return WordType::verb; }
	if (theWordTypeString == L"adjective") { return WordType::adjective; }
	if (theWordTypeString == L"adverb") { return WordType::adverb; }
	if (theWordTypeString == L"pronoun") { return WordType::pronoun; }
	if (theWordTypeString == L"conjunction") { return WordType::conjunction; }
	if (theWordTypeString == L"determiner") { return WordType::determiner; }
	if (theWordTypeString == L"excalamation") { return WordType::excalamation; }
	if (theWordTypeString == L"preposition") { return WordType::preposition; }

	if (theWordTypeString.size() == 0 || theWordTypeString.size() == 1)
	{
		return WordType::nil;
	}
}

std::wstring translation::getWordTypeString(WordType t_WordType)
{
	switch (t_WordType)
	{
		case WordType::noun: return L"noun"; break;
		case WordType::verb: return L"verb"; break;
		case WordType::adjective: return L"adjective"; break;
		case WordType::adverb: return L"adverb"; break;
		case WordType::pronoun: return L"pronoun"; break;
		case WordType::conjunction: return L"conjunction"; break;
		case WordType::determiner: return L"determiner"; break;
		case WordType::excalamation: return L"excalamation"; break;
		case WordType::preposition: return L"preposition"; break;

		default: return L"";
	}
}

bool translation::operator==(translation & Source) const
{
	return this->TheSource == Source.TheSource;
}

