
// MRNNEXUS.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "Resource.h"		// main symbols
#include "MRNAdminDialog.h"
#include "afxdb.h"

// CMRNNEXUSApp:
// See MRNNEXUS.cpp for the implementation of this class
//

class CMRNNEXUSApp : public CWinApp
{
public:
	HICON m_hIcon;
	CMRNAdminDialog dlg;
	CMRNNEXUSApp();
	CString currentDir;
	CString sFile;
	
// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
	
};

extern CMRNNEXUSApp theApp;
extern HICON m_hIcon;