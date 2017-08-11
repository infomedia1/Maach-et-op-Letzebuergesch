/********************************************************************************
** Form generated from reading UI file 'MaachetopLtzebuergesch.ui'
**
** Created by: Qt User Interface Compiler version 5.9.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAACHETOPLTZEBUERGESCH_H
#define UI_MAACHETOPLTZEBUERGESCH_H

#include <QtCore/QLocale>
#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MaachetopLtzebuergesch
{
public:
    QAction *action_import;
    QAction *action_close;
    QAction *action_about;
    QWidget *centralWidget;
    QWidget *gridLayoutWidget;
    QGridLayout *gridLayout;
    QTextEdit *edtInput;
    QWidget *gridLayoutWidget_2;
    QGridLayout *gridLayout_3;
    QTextEdit *edtOutput;
    QPushButton *btnTranslate;
    QMenuBar *mMenuBar;
    QMenu *mMenu;
    QMenu *mHelp;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MaachetopLtzebuergesch)
    {
        if (MaachetopLtzebuergesch->objectName().isEmpty())
            MaachetopLtzebuergesch->setObjectName(QStringLiteral("MaachetopLtzebuergesch"));
        MaachetopLtzebuergesch->resize(1099, 596);
        QSizePolicy sizePolicy(QSizePolicy::Preferred, QSizePolicy::Preferred);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(MaachetopLtzebuergesch->sizePolicy().hasHeightForWidth());
        MaachetopLtzebuergesch->setSizePolicy(sizePolicy);
        MaachetopLtzebuergesch->setLocale(QLocale(QLocale::Luxembourgish, QLocale::Luxembourg));
        action_import = new QAction(MaachetopLtzebuergesch);
        action_import->setObjectName(QStringLiteral("action_import"));
        action_close = new QAction(MaachetopLtzebuergesch);
        action_close->setObjectName(QStringLiteral("action_close"));
        action_about = new QAction(MaachetopLtzebuergesch);
        action_about->setObjectName(QStringLiteral("action_about"));
        centralWidget = new QWidget(MaachetopLtzebuergesch);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        gridLayoutWidget = new QWidget(centralWidget);
        gridLayoutWidget->setObjectName(QStringLiteral("gridLayoutWidget"));
        gridLayoutWidget->setGeometry(QRect(9, 9, 431, 451));
        gridLayout = new QGridLayout(gridLayoutWidget);
        gridLayout->setSpacing(6);
        gridLayout->setContentsMargins(11, 11, 11, 11);
        gridLayout->setObjectName(QStringLiteral("gridLayout"));
        gridLayout->setContentsMargins(0, 0, 0, 0);
        edtInput = new QTextEdit(gridLayoutWidget);
        edtInput->setObjectName(QStringLiteral("edtInput"));

        gridLayout->addWidget(edtInput, 0, 0, 1, 1);

        gridLayoutWidget_2 = new QWidget(centralWidget);
        gridLayoutWidget_2->setObjectName(QStringLiteral("gridLayoutWidget_2"));
        gridLayoutWidget_2->setGeometry(QRect(631, 9, 411, 461));
        gridLayout_3 = new QGridLayout(gridLayoutWidget_2);
        gridLayout_3->setSpacing(6);
        gridLayout_3->setContentsMargins(11, 11, 11, 11);
        gridLayout_3->setObjectName(QStringLiteral("gridLayout_3"));
        gridLayout_3->setContentsMargins(0, 0, 0, 0);
        edtOutput = new QTextEdit(gridLayoutWidget_2);
        edtOutput->setObjectName(QStringLiteral("edtOutput"));

        gridLayout_3->addWidget(edtOutput, 0, 0, 1, 1);

        btnTranslate = new QPushButton(centralWidget);
        btnTranslate->setObjectName(QStringLiteral("btnTranslate"));
        btnTranslate->setGeometry(QRect(500, 190, 75, 23));
        btnTranslate->setLocale(QLocale(QLocale::Luxembourgish, QLocale::Luxembourg));
        MaachetopLtzebuergesch->setCentralWidget(centralWidget);
        mMenuBar = new QMenuBar(MaachetopLtzebuergesch);
        mMenuBar->setObjectName(QStringLiteral("mMenuBar"));
        mMenuBar->setGeometry(QRect(0, 0, 1099, 21));
        mMenu = new QMenu(mMenuBar);
        mMenu->setObjectName(QStringLiteral("mMenu"));
        mHelp = new QMenu(mMenuBar);
        mHelp->setObjectName(QStringLiteral("mHelp"));
        MaachetopLtzebuergesch->setMenuBar(mMenuBar);
        mainToolBar = new QToolBar(MaachetopLtzebuergesch);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        MaachetopLtzebuergesch->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MaachetopLtzebuergesch);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        MaachetopLtzebuergesch->setStatusBar(statusBar);

        mMenuBar->addAction(mMenu->menuAction());
        mMenuBar->addAction(mHelp->menuAction());
        mMenu->addAction(action_import);
        mMenu->addSeparator();
        mMenu->addAction(action_close);
        mHelp->addAction(action_about);

        retranslateUi(MaachetopLtzebuergesch);

        QMetaObject::connectSlotsByName(MaachetopLtzebuergesch);
    } // setupUi

    void retranslateUi(QMainWindow *MaachetopLtzebuergesch)
    {
        MaachetopLtzebuergesch->setWindowTitle(QApplication::translate("MaachetopLtzebuergesch", "Maach et op Letzebuergesch", Q_NULLPTR));
        action_import->setText(QApplication::translate("MaachetopLtzebuergesch", "Import.../", Q_NULLPTR));
        action_close->setText(QApplication::translate("MaachetopLtzebuergesch", "Zou maachen", Q_NULLPTR));
        action_about->setText(QApplication::translate("MaachetopLtzebuergesch", "Iwwert d'App...", Q_NULLPTR));
        edtInput->setHtml(QApplication::translate("MaachetopLtzebuergesch", "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0//EN\" \"http://www.w3.org/TR/REC-html40/strict.dtd\">\n"
"<html><head><meta name=\"qrichtext\" content=\"1\" /><style type=\"text/css\">\n"
"p, li { white-space: pre-wrap; }\n"
"</style></head><body style=\" font-family:'MS Shell Dlg 2'; font-size:8.25pt; font-weight:400; font-style:normal;\">\n"
"<p style=\"-qt-paragraph-type:empty; margin-top:0px; margin-bottom:0px; margin-left:0px; margin-right:0px; -qt-block-indent:0; text-indent:0px;\"><br /></p></body></html>", Q_NULLPTR));
        edtInput->setPlaceholderText(QApplication::translate("MaachetopLtzebuergesch", "Input", Q_NULLPTR));
        btnTranslate->setText(QApplication::translate("MaachetopLtzebuergesch", "PushButton", Q_NULLPTR));
        mMenu->setTitle(QApplication::translate("MaachetopLtzebuergesch", "&Menu", Q_NULLPTR));
        mHelp->setTitle(QApplication::translate("MaachetopLtzebuergesch", "H\303\253llef", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class MaachetopLtzebuergesch: public Ui_MaachetopLtzebuergesch {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAACHETOPLTZEBUERGESCH_H
