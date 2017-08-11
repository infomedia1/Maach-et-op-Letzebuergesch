#include <QPushButton>
#include <QButtonGroup>

#include <Windows.h>
#include "About.h"
#include "ui_About.h"

About::About(QWidget *parent)
	: QDialog(parent)
{
	ui = new Ui::About();
	ui->setupUi(this);
}

About::~About()
{
	delete ui;
}
void About::on_buttonBox_clicked(QAbstractButton *button)
{
	OutputDebugStringA("buttonBox_clicked triggered!");
	if (button == ui->buttonBox->button(QDialogButtonBox::Close)) {
		OutputDebugStringA("closebutton!");
		this->close();
	}
}