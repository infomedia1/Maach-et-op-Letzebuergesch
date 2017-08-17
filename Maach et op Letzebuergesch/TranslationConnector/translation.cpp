#include "stdafx.h"
#include <iostream>
#include "translation.h"

using namespace std;

translation::translation()
{
	cout << "Translation created!" << endl;
}

translation::translation(std::wstring in, std::wstring out)
{
	this->TheSource = in;
	this->TheTarget = out;
	this->thelanguageCode = languageCode::de;
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

bool translation::operator==(translation & Source) const
{
	return this->TheSource == Source.TheSource;
}

