#pragma once

#include <QDialog>
#include <QPushButton>
#include <QDialogButtonBox>

namespace Ui { class About; };

class About : public QDialog
{
	Q_OBJECT

public:
	About(QWidget *parent);
	~About();

private slots:
	void on_buttonBox_clicked(QAbstractButton *button);

private:
	Ui::About *ui;
};
