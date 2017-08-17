// TranslationConnector.cpp : Defines the exported functions for the DLL application.
//
#include <STDIO.h>

#include <iostream>
#include <fstream>
#include <string>
#include <Windows.h>

#include "stdafx.h"
#include "TranslationConnector.h"


TRANSLATIONCONNECTOR_API std::wstring CTranslationConnector::Functions::EasyTranslate(std::wstring input, Language targetLanguage)
{
	std::wstring output = input;
	switch (targetLanguage)
	{
		case de: output = input;
	}
	return output;
}

CTranslationConnector::CTranslationConnector(void)
{
	return;
}

CTranslationConnector::~CTranslationConnector(void)
{
}

void CTranslationConnector::InitIt(void)
{
	
}

TRANSLATIONCONNECTOR_API int fnTranslationConnector_API(void)
{
	return 1;
}
CTranslationConnector::Words::Words(Language sourceLang, Language targetLang, WordType selWordType, std::wstring sourceword, std::wstring targetword)
{
	theSourceLanguage = sourceLang;
	theTargetLanguage = targetLang;
	theWordType = selWordType;
	theSourceWord = sourceword;
	theTargetWord = targetword;
}

CTranslationConnector::Words::~Words(void)
{
}
