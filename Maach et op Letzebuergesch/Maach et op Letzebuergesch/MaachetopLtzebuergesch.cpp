#include <QCloseEvent>
#include <QApplication>

#include <iostream>
#include <fstream>
#include <string>
#include <Windows.h>
#include "MaachetopLtzebuergesch.h"
#include "ui_MaachetopLtzebuergesch.h"
#include "About.h"



MaachetopLtzebuergesch::MaachetopLtzebuergesch(QWidget *parent) : 
	QMainWindow(parent), ui(new Ui::MaachetopLtzebuergesch)
{
	ui->setupUi(this);
	//TRANSLATIONCONNECTOR_API CTranslationConnector;
	//setWindowTitle(QCoreApplication::applicationName());
}
MaachetopLtzebuergesch::~MaachetopLtzebuergesch()
{
	//delete TRANSLATIONCONNECTOR_API CTranslationConnector;
	delete ui;
}

void MaachetopLtzebuergesch::closeApp()
{
	QCoreApplication::quit();
}

void MaachetopLtzebuergesch::closeEvent(QCloseEvent *e)
{
	e->accept();
}

void MaachetopLtzebuergesch::on_action_about_triggered()
{
	about();
	OutputDebugStringA("action_about triggered");

}

void MaachetopLtzebuergesch::on_btnTranslate_clicked()
{
	
		OutputDebugStringA("on_btnTranslate_clicked triggered!\n");

	
	//Catch InputWindow
	QString theInputString = ui->edtInput->toPlainText();
	QString theInputHtml = ui->edtInput->toHtml();
	/*
		std::wstring DebugStringstd = theInputString.toStdWString();
		LPCWSTR DebugString =  DebugStringstd.c_str();
		OutputDebugStringW(DebugString);
	*/
	//Catch OutputWindow
	
	//Magic Translation
	//std::wstring theOutputStringtemp = CTranslationConnector::Functions::EasyTranslate(theInputString.toStdWString(), CTranslationConnector::Language::de);
	QString theOutputString = theOutputString.fromStdWString(theOutputStringtemp);
	
	//Output
	ui->edtOutput->setText(theOutputString);
}

void MaachetopLtzebuergesch::on_btnInit_clicked()
{
	//INIT DB
	OutputDebugStringA("INIT DB STARTED\n");
	//std::wifstream file("lod_DE_LB.utf8", std::ios::binary);
	std::ifstream file(L"lod_DE_LB.utf8.ansi");
	//std::locale loc("en_DE.UTF-8");
	std::string str;
	if (file.is_open())
	{
		OutputDebugStringA("INIT DB: File is opened\n");
		while (std::getline(file, str))
		{
			
			std::string endline = "\n";
			std::string wsTmp(endline.begin(), endline.end());
			str = str + wsTmp;
			LPCSTR DebugString = str.c_str();
			OutputDebugStringA(DebugString);

			std::wstring theinputword;
			std::wstring theoutputword;

			///CTranslationConnector::Words newword = CTranslationConnector::Words::Words(CTranslationConnector::Language::de, CTranslationConnector::Language::lu,CTranslationConnector::WordType::noun,theinputword,theoutputword);
		}
		file.close();
	}

	//CTranslationConnector::InitIt();
	OutputDebugStringA("INIT DB ENDED\n");
}

void MaachetopLtzebuergesch::about()
{
	About *theAbout = new About(this);
	theAbout->setModal(true);
	theAbout->setAttribute(Qt::WA_DeleteOnClose);
	theAbout->show();
}

void MaachetopLtzebuergesch::on_action_close_triggered()
{
	OutputDebugStringA("action_close triggered!");
	closeApp();
}