#include <QCloseEvent>

#include "MaachetopLtzebuergesch.h"

MaachetopLtzebuergesch::MaachetopLtzebuergesch(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
}

void MaachetopLtzebuergesch::closeApp()
{
	QCoreApplication::quit();
}

void MaachetopLtzebuergesch::closeEvent(QCloseEvent *e)
{
	e->accept();
}

void MaachetopLtzebuergesch::about()
{

}
