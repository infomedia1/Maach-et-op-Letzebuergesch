#include <QCloseEvent>
#include <QApplication>

#include <iostream>
#include <string>
#include <Windows.h>
#include "MaachetopLtzebuergesch.h"
#include "ui_MaachetopLtzebuergesch.h"
#include "About.h"


MaachetopLtzebuergesch::MaachetopLtzebuergesch(QWidget *parent) : 
	QMainWindow(parent), ui(new Ui::MaachetopLtzebuergesch)
{
	ui->setupUi(this);
	//setWindowTitle(QCoreApplication::applicationName());
}
MaachetopLtzebuergesch::~MaachetopLtzebuergesch()
{
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