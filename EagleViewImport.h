#pragma once
#include "afxwin.h"
#include "MRNNEXUS.h"
#include <sstream>
#include <fstream>
#include <string>
#include <stdlib.h>

// CEagleViewImport dialog

class CEagleViewImport : public CDialogEx
{
	DECLARE_DYNAMIC(CEagleViewImport)

public:
	CEagleViewImport(CWnd* pParent = NULL);   // standard constructor
	virtual ~CEagleViewImport();
	void ImportEagleView(CString Filename, char *filestream, bool inorout);
	bool seen2(const char* search, char* recent);
	size_t FindStringInBuffer(char* buffer, char* search, size_t buffersize);
	void count(std::string inf, int& _X);
	unsigned char* c;
	void DeleteWithTasks(CString fileName);
	// Dialog Data
	enum { IDD = IDD_EAGLEVIEWIMPORT };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedBrowsebtn();
	CEdit m_ctlFileToImportEV;
	afx_msg void OnEnChangeFilededitdlgbox();
	int fseekres = 0;
	long filelen = 0;
	char* buffer = "";
	size_t actualread = 0;
	char* buffertemp = "";
	CString areas = "";
	CString hipss = "";
	CString valleys = "";
	CString rakess = "";
	CString eavess = "";
	CString predpitchs = "";
	CString ridgess = "";
	CString flashings = "";
	CString stepflashings = "";
	CString parapetss = "";
	CString starter = "";
	CString waste = "";
	CString thelastpage = "";
	float u = 0;
	float f = 0;
	float farea = 0;
	float froofon = 0;
	float fhipridge = 0;
	float fridgevent = 0;
	float fflashing = 0;
	float fstepflashing = 0;
	float fdripedge = 0;
	float ficewater = 0;
	float fstarter = 0;
	float fparapets = 0;
	float ffelt = 0;
	float dumpsterfee = 0;
	int isqon = 0;
	float fshinglecost = 0;
	float flaborcosts = 0;
	int ifelt = 0;
	float fbuttoncaps = 0;
	int ibuttoncaps = 0;
	float fbuttoncapcost = 0;
	int iicewater = 0;
	float ficewatercost = 0;
	int ihipridge = 0;
	float fhipridgecost = 0;
	int idripedge = 0;
	float fdripedgecost = 0;
	int iridgevent = 0;
	float fridgeventcost = 0;
	int istarter = 0;
	float fstartershinglecost = 0;
	float froofnail = 0;
	int iroofnail = 0;
	float fosbcosts = 0;
	int icanspaint = 0;
	float fcanspaint = 0;
	float ftubesofcaulk = 0;
	float fpaintcosts = 0;
	float fcaulkcosts = 0;
	float froofnailcost = 0;
	float ffeltcost = 0;
	float fdesignercolor = 0;
	float fduration = 0;
	float fsupreme = 0;
	float foakridge = 0;
	float foakridgetrudef = 0;
	float f3n1pipeboot = 0;
	float fmaterialcosts = 0;
	float ftotalcost = 0;
	float fpersquareactual = 0;
	float fprofit = 0;
	float fGrandTotal = 0;
	float overhead = 0;
	float fsplit = 0;
	CStatic CStatic;
	afx_msg void OnBnClickedMoed();

};

