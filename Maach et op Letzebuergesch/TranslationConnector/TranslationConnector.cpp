// TranslationConnector.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdlib.h>
#include <iostream>
#include <string>
#include <clocale>
#include <locale>
#include <codecvt>
#include <fcntl.h>
#include <io.h> 

#include "TranslatorClass.h"
#include "translation.h"
#include "languages.h"

using namespace std;


int main()
{
	//ios_base::sync_with_stdio(false);
	//std::setlocale(LC_ALL, "C.UTF-8");
	//wcin.imbue(std::locale(std::locale::empty(), new std::codecvt_utf8<wchar_t, 0x10ffff, std::consume_header>));
	//wcin.imbue(locale("iso_8859_15"));
	
	if (!setlocale(LC_CTYPE, "")) {
		fprintf(stderr, "Can't set the specified locale! "
			"Check LANG, LC_CTYPE, LC_ALL.\n");
		return 1;
	}

	//::std::locale d_Locale2("German");
	//::std::locale::global(d_Locale2);
	//_setmode(_fileno(stdout), _O_U8TEXT);
	_setmode(_fileno(stdin), _O_U16TEXT);

	int option;
	option = 99;

	TranslatorClass* theEmptyClass;
	theEmptyClass = new TranslatorClass;
	theEmptyClass->initTranslator(languageCode::de, languageCode::lu);
	while (option != 0)
	{
		if (option != 99) { system("cls"); }
		wcout << "         SuperTranslator Tool       " << endl;
		wcout << "------------------------------------" << endl;
		wcout << "1 : Get Init Values of TranslatorClass" << endl;
		wcout << "2 : Add a Translation TranslatorClass" << endl;
		wcout << "3 : Print Content of TranslatorClass" << endl;
		wcout << "4 : Easy Translate Tester" << endl;
		wcout << "5 : Sentence Analyzer" << endl;
		wcout << "6 : Sentence Easy Translate" << endl;
		wcout << "------------------------------------" << endl;
		wcout << "0 : to exit the program. \t" << endl;
		wcout << "#/> ";
		wcin >> option;
		wcin.clear();
		//wcin.ignore(numeric_limits<streamsize>::max(), '\n');
		switch (option)
		{
			case 1:
				wcout << "Source Language: ";
				theEmptyClass->getSourceLanguage();
				wcout << "Target Language: ";
				theEmptyClass->getTargetLanguage();
				system("pause");
				break;
			case 2:
			{
				/*
				cout << "select SourceLanguage: " << endl;
				cout << "1: DE (German)" << endl;
				cout << "2: LU (Luxemburgish" << endl;
				int selectSourceId;
				cin >> selectSourceId;
				cout << "select TargetLanguage: " << endl;
				cout << "1: DE (German)" << endl;
				cout << "2: LU (Luxemburgish" << endl;
				int selectTargetId;
				cin >> selectTargetId;
				*/
				wstring InPut;
				wstring OutPut;
				wstring Comment = L"";
				wstring Word;
				wstring SeX;
				wcout << L"Enter Source Word" << endl;
				wcin >> InPut;
				wcout << L"Enter Target Word" << endl;
				wcin >> OutPut;
				wcout << L"Enter WordType (noun, verb, adjective, adverb, pronoun, conjunction, determiner, excalamtion)" << endl;
				wcin >> Word;
				wcout << L"Enter Sexe (mas, fem)" << endl;
				wcin >> SeX;
				//getline(cin, OutPut);
				translation theEmptyTranslation(InPut, OutPut, Comment, Word, SeX);
				//theEmptyTranslation.addtranslation(InPut, OutPut);
				theEmptyClass->translations.push_back(theEmptyTranslation);
				int lastentry = 0;
				lastentry = theEmptyClass->translations.size() - 1;
				translation theNewTranslation;

				wcout << theEmptyClass->translations.at(lastentry).returnIt() << endl;

				//theEmptyClass->translations.at(theEmptyClass->translations.size() - 1).returnIt();
				system("pause");
				break;
			}
			case 3:
			{
				if (theEmptyClass->translations.size() > 0)
				{
					for (int counter = 0; counter < theEmptyClass->translations.size(); counter++)
					{
						wcout << theEmptyClass->translations.at(counter).returnIt() << endl;
					}
					system("pause");
				}
				break;
			}
			case 4:
			{
				std::wstring result;
				std::wstring theInputString;
				wcin.clear();
				wcin.ignore(1000, '\n');
				wcout << L"Enter the German Word: \t";
			
				getline(wcin,theInputString,L'\n');
				//wcin.get();
				
				result = theEmptyClass->translateToTarget(theInputString);
				if (result.size()==1)
				{
					wcout << L"Keng direkt passend Iwwersätzung fonnt" << endl;
				}
				else {
					wcout << L"Result: " << result << endl;
				}
				
				system("pause");
				break;
			}
			case 5:
			{
				std::wstring result;
				std::wstring theInputString;
				wcin.clear();
				wcin.ignore(1000, '\n');
				wcout << L"Enter your sentence: " << endl;
				wcout << L":\>";
				getline(wcin, theInputString, L'\n');
				result = theEmptyClass->getSentenceModules(theInputString);
				wcout << result << endl;
				system("pause");
				break;
			}
			case 6:
			{
				std::wstring result;
				std::wstring theInputString;
				wcin.clear();
				wcin.ignore(1000, '\n');
				wcout << L"Enter your sentence: " << endl;
				wcout << L":\>";
				getline(wcin, theInputString, L'\n');
				result = theEmptyClass->translateSentenceEasy(theInputString);
				wcout << result << endl;
				system("pause");
				break;
			}
		}
		
		

		
		//delete theEmptyTranslation;
	}
	
	delete theEmptyClass;
	return 0;
}

