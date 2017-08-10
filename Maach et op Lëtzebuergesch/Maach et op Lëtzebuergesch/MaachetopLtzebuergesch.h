#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_MaachetopLtzebuergesch.h"

class MaachetopLtzebuergesch : public QMainWindow
{
	Q_OBJECT

public:
	MaachetopLtzebuergesch(QWidget *parent = Q_NULLPTR);

private:
	Ui::MaachetopLtzebuergeschClass ui;
};
