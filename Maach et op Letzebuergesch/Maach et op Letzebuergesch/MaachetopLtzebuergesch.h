#pragma once

#ifndef MaachetopLtzebuergesch_H
#define MaachetopLtzebuergesch_H

#include <QMainWindow>
#include "About.h"

namespace Ui {
	class MaachetopLtzebuergesch;
}
class MaachetopLtzebuergesch : public QMainWindow
{
	Q_OBJECT

public:
	MaachetopLtzebuergesch(QWidget *parent = 0);
	virtual ~MaachetopLtzebuergesch();

protected:
	void closeEvent(QCloseEvent *e) override;

private slots:
	void on_action_close_triggered();
	void on_action_about_triggered();
	void about();

private:
	void closeApp();
	Ui::MaachetopLtzebuergesch *ui;
};

#endif // MaachetopLtzebuergesch_H