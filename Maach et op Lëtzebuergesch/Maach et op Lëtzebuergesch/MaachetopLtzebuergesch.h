#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_MaachetopLtzebuergesch.h"

class MaachetopLtzebuergesch : public QMainWindow
{
	Q_OBJECT

public:
	MaachetopLtzebuergesch(QWidget *parent = Q_NULLPTR);

protected:
	void closeEvent(QCloseEvent *e) override;

private slots:
	void closeApp();
	void about();

private:
	Ui::MaachetopLtzebuergeschClass ui;
};
