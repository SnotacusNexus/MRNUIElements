// EagleViewImport.cpp : implementation file
//

#include "stdafx.h"
#include "MRNNEXUS.h"
#include <math.h>
#include "EagleViewImport.h"
#include "afxdialogex.h"
#include <stdio.h>
#include <string.h>
#include <assert.h>
#include "base64.h"
#include <io.h>
#include <fcntl.h> 
#include <cstdlib>
#include <queue>
#include <iostream>
#include <vector>
#include <fstream>
#include <iomanip>
#include <stdio.h>
#include <stdlib.h>
#include <cstdio>
#include <shlobj.h>
#include <shlwapi.h>
#include <objbase.h>
#include <cstdlib>
#include "GetDBInfo.h"
#include "PdfTextExtractor.h"



#ifdef _HAVE_CONFIG
#include <config.h>
#endif // _HAVE_CONFIG

// CEagleViewImport dialog

IMPLEMENT_DYNAMIC(CEagleViewImport, CDialogEx)

CEagleViewImport::CEagleViewImport(CWnd* pParent /*=NULL*/)
: CDialogEx(CEagleViewImport::IDD, pParent)
{
}

CEagleViewImport::~CEagleViewImport()
{
	
}

void CEagleViewImport::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_FILEDEDITDLGBOX, m_ctlFileToImportEV);
	DDX_Control(pDX, IDC_EVHIPS, CStatic);
}


BEGIN_MESSAGE_MAP(CEagleViewImport, CDialogEx)
	ON_BN_CLICKED(IDC_BROWSEBTN, &CEagleViewImport::OnBnClickedBrowsebtn)
	ON_EN_CHANGE(IDC_FILEDEDITDLGBOX, &CEagleViewImport::OnEnChangeFilededitdlgbox)
	ON_BN_CLICKED(IDC_MOED, &CEagleViewImport::OnBnClickedMoed)
END_MESSAGE_MAP()


// CEagleViewImport message handlers


void CEagleViewImport::ImportEagleView(CString Filename, char* filestream, bool dbd)
{
	CString str = "podofotxtextract.exe";

	CString ton = Filename;
	CString torr = Filename.Mid(Filename.ReverseFind('\\') + 1);
	int copiedcomplete = (int)CopyFile(ton, L".\\" + torr, FALSE);
	//if (copiedcomplete != 0){
	//	int nRet = (int)ShellExecute(P_WAIT, L"open", L"podofotxtextract.exe", torr, NULL, SW_HIDE);

		//if (nRet <= 32) {
	//		DWORD dw = GetLastError();
	//		char szMsg[250];
	//		FormatMessage(
	//			FORMAT_MESSAGE_FROM_SYSTEM,
//				0, dw, 0,
//				(LPWSTR)szMsg, sizeof(szMsg),
//				NULL
//				);
//			MessageBox((LPWSTR)szMsg, L"error launching TextExtractor");
	//	}
	//}
	CPdfTextExtractor ext;
	ext.ExtractText(Filename);

	FILE* fileo = fopen("output.txt", "w");
	if (fileo) fclose(fileo);
	fileo = fopen("output.txt", "a");

	int rsti = 0;
	FILE* filei = fopen((LPSTR)&torr, "rb");

	if (!IsDlgButtonChecked(IDC_MOED)){
		if (filei && fileo)
		{
			int fseekres = fseek(filei, 0, SEEK_END);   //fseek==0 if ok
			long filelen = ftell(filei);
			fseekres = fseek(filei, 0, SEEK_SET);
			char* buffer = new char[filelen];
			ZeroMemory(buffer, filelen);
			size_t actualread = fread(buffer, filelen, 1, filei);  //must return 1
			char* buffertemp = buffer;
			CString areas = buffertemp;
			CString hipss = buffertemp;
			CString valleys = buffertemp;
			CString rakess = buffertemp;
			CString eavess = buffertemp;
			CString predpitchs = buffertemp;
			CString ridgess = buffertemp;
			CString flashings = buffertemp;
			CString stepflashings = buffertemp;
			CString parapetss = buffertemp;
			CString starter = buffertemp;
			CString waste = buffertemp;
			CString thelastpage = buffertemp;
			areas = areas.Mid(areas.Find(L"MEASUREMENTS"));
			areas = areas.Mid(areas.Find(L"Area"));
			areas = areas.Mid(areas.FindOneOf(L"0123456789")), areas.Left(areas.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			areas = areas.Left(areas.Find('\r'));
			areas.Remove(',');
			float u = _tstoi(areas);
			areas.Format(L"%.2f", u / 100, 10);
			CEagleViewImport::SetDlgItemText(IDC_EVSQUARESOFF, areas);
			predpitchs = predpitchs.Mid(predpitchs.Find(L"Pitch"));
			predpitchs = predpitchs.Mid(predpitchs.FindOneOf(L"0123456789")), predpitchs.Left(predpitchs.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			predpitchs = predpitchs.Left(predpitchs.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_PREDOMPITCH, predpitchs);
			valleys = valleys.Mid(valleys.Find(L"Valleys"));
			valleys = valleys.Mid(valleys.FindOneOf(L"0123456789")), valleys.Left(valleys.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			valleys = valleys.Left(valleys.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EVVALLEY, valleys);
			rakess = rakess.Mid(rakess.Find(L"Rakes"));
			rakess = rakess.Mid(rakess.FindOneOf(L"0123456789")), rakess.Left(rakess.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			rakess = rakess.Left(rakess.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EVRAKES, rakess);
			eavess = eavess.Mid(eavess.Find(L"Eaves"));
			eavess = eavess.Mid(eavess.FindOneOf(L"0123456789")), eavess.Left(eavess.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			eavess = eavess.Left(eavess.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EAVES, eavess);
			ridgess = ridgess.Right(ridgess.Find(L"Lengths:"));
			ridgess = ridgess.Mid(ridgess.Find(L"Ridges"));
			ridgess = ridgess.Mid(ridgess.FindOneOf(L"0123456789")), ridgess.Left(ridgess.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			ridgess = ridgess.Left(ridgess.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EVRIDGES, ridgess);
			hipss = hipss.Right(hipss.Find(L"Lengths:"));
			hipss = hipss.Mid(hipss.Find(L"Hips"));
			hipss = hipss.Mid(hipss.FindOneOf(L"0123456789")), hipss.Left(hipss.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			hipss = hipss.Left(hipss.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EVHIPS, hipss);
			flashings = flashings.Right(flashings.Find(L"Lengths:"));
			flashings = flashings.Mid(flashings.Find(L"Flashing"));
			flashings = flashings.Mid(flashings.FindOneOf(L"0123456789")), flashings.Left(flashings.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			flashings = flashings.Left(flashings.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EVFLASHING, flashings);
			stepflashings = stepflashings.Right(stepflashings.Find(L"Lengths:"));
			stepflashings = stepflashings.Right(stepflashings.Find(L"Step"));
			stepflashings = stepflashings.Mid(stepflashings.Find(L"flashing"));
			stepflashings = stepflashings.Mid(stepflashings.FindOneOf(L"0123456789")), stepflashings.Left(stepflashings.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			stepflashings = stepflashings.Left(stepflashings.Find('\r'));
			CEagleViewImport::SetDlgItemText(IDC_EVSTEPFLASHING, stepflashings);
			parapetss = parapetss.Mid(parapetss.Find(L"Parapets"));
			parapetss = parapetss.Mid(parapetss.FindOneOf(L"0123456789")), parapetss.Left(parapetss.FindOneOf(L"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"));
			parapetss = parapetss.Left(parapetss.Find('\r'));

			areas = buffertemp;
			hipss = buffertemp;
			valleys = buffertemp;
			rakess = buffertemp;
			eavess = buffertemp;
			predpitchs = buffertemp;
			ridgess = buffertemp;
			flashings = buffertemp;
			stepflashings = buffertemp;
			parapetss = buffertemp;
			starter = buffertemp;
			waste = buffertemp;
			thelastpage = buffertemp;

			f = _tstoi(rakess) + _tstoi(eavess);
			CEagleViewImport::SetDlgItemInt(IDC_EVSTARTER, f);
			areas.Format(L"%.2f", u*1.15 / 100, 10);
			CEagleViewImport::SetDlgItemText(IDC_ONSQUARES, areas);
			fclose(filei);
			farea = u / 100;
			froofon = u*1.15 / 100;
			fhipridge = (_tstoi(hipss) + _tstoi(ridgess)) / 28;
			fridgevent = (_tstoi(ridgess) / 4)*1.1;
			fflashing = _tstoi(flashings);
			fstepflashing = _tstoi(stepflashings);
			fdripedge = (_tstoi(rakess) / 10)*1.1;
			ficewater = _tstoi(valleys);
			ficewater = ((ficewater / 68) * 1.1);
			fstarter = (_tstoi(eavess) + _tstoi(rakess)) / 100;
			fparapets = _tstoi(parapetss);
			ffelt = u / 400;
			dumpsterfee = 250;
			int isqon = froofon + 1;
			fshinglecost = isqon * 73;
			if (u > 44 && u < 55) dumpsterfee = 300;
			else if (u > 54) dumpsterfee = 500;
			flaborcosts = isqon * 50 + dumpsterfee;
			int ifelt = ffelt + 1;
			fbuttoncaps = farea / 20;
			int ibuttoncaps = fbuttoncaps + 1;
			fbuttoncapcost = ibuttoncaps * 21;
			int iicewater = ficewater + 1;
			ficewatercost = iicewater * 56.71;
			int ihipridge = fhipridge + 1;
			fhipridgecost = ihipridge * 38.44;
			int idripedge = fdripedge + 1;
			fdripedgecost = idripedge * 7.60;
			int iridgevent = fridgevent + 1;
			fridgeventcost = iridgevent * 6.5;
			int istarter = fstarter + 1;
			fstartershinglecost = istarter * 30;
			froofnail = froofon / 16;
			int iroofnail = froofnail + 1;
			fosbcosts = 2 * 11;
			int icanspaint = 3;//GetDlgItemInt(IDC_INTCANSPAINT);
			fcanspaint = icanspaint;
			ftubesofcaulk = 3;//GetDlgItemInt(IDC_INTTUBESCAULK);
			fpaintcosts = fcanspaint * 5.21;
			fcaulkcosts = ftubesofcaulk * 4.71;
			froofnailcost = iroofnail * 22;
			ffeltcost = ifelt * 32.67;
			fdesignercolor = froofon * 73;
			fduration = froofon * 73;
			fsupreme = froofon * 56;
			foakridge = froofon * 68;
			foakridgetrudef = froofon * 69;
			f3n1pipeboot = 4/*GetDlgItemInt(IDC_INT3N1PIPEBOOT)*/ * 4.12;
			UpdateData(FALSE);

			fprintf(fileo, "**********Specifications:****************\nSquares Off: %.2f (SQ)\n", farea);
			fprintf(fileo, "Squares On: %.2f (SQ) 15%% waste factor\n", froofon);
			fprintf(fileo, "Starter Shingles: %.2f bundles\n", fstarter);
			fprintf(fileo, "Drip Edge: %.2f (10' sticks)\n", fdripedge);
			fprintf(fileo, "Ridge Vent: %.2f (4' pieces)\n", fridgevent);
			fprintf(fileo, "Hip & Ridge: %.2f (bundles)\n", fhipridge);
			fprintf(fileo, "Weather Watch G: %.2f (Rolls) \n", ficewater);
			fprintf(fileo, "Gorilla Guard %.2f (4sq roll)\n", ffelt);
			fprintf(fileo, "Plastic caps: %.2f (3000 ct bucket)\n", fbuttoncaps);
			fprintf(fileo, "Roofing Nails:  %.2f (1-1/4'' 15 degree coil nails)\n\n", froofnail);

			fprintf(fileo, "**********Material Order:****************\nOrder %i bundles of starter shingles from supplier.\n", istarter);
			fprintf(fileo, "Order %i Squares from supplier.\n", isqon);
			fprintf(fileo, "Order %i pieces of drip edge from supplier.\n", idripedge);
			fprintf(fileo, "Order %i pieces of ridge vent from supplier.\n", iridgevent);
			fprintf(fileo, "Order %i bundles hip & ridge from supplier.\n", ihipridge);
			fprintf(fileo, "Order %i rolls ice and water shield from supplier.\n", iicewater);
			fprintf(fileo, "Order %i rolls of Gorilla Guard from supplier.\n", ifelt);
			fprintf(fileo, "Order %i buckets of button caps from supplier.\n", ibuttoncaps);
			fprintf(fileo, "Order %i boxes of roofing coil nails from supplier.\n\n", iroofnail);

			fprintf(fileo, "**********Accessory Costs****************\nFelt Cost: $%.2f\n", ffeltcost);
			fprintf(fileo, "Button Cap Cost: $%.2f\n", fbuttoncapcost);
			fprintf(fileo, "Ice & WaterCost: $%.2f\n", ficewatercost);
			fprintf(fileo, "Drip Edge Cost: $%.2f\n", fdripedgecost);
			fprintf(fileo, "Hip & Ridge Cost: $%.2f\n", fhipridgecost);
			fprintf(fileo, "Ridge Vent Cost: $%.2f\n", fridgeventcost);
			fprintf(fileo, "Starter Shingle Cost: $%.2f\n", fstartershinglecost);
			fprintf(fileo, "Roofing Nail Cost: $%.2f\n", froofnailcost);
			fprintf(fileo, "Paint Cost: $%.2f\n", fpaintcosts);
			fprintf(fileo, "Caulk Cost: $%.2f\n", fcaulkcosts);
			fprintf(fileo, "OSB Cost: $%.2f\n", fosbcosts);
			fprintf(fileo, "Labor Costs: $%.2f\n\n", flaborcosts);

			fprintf(fileo, "*************************************************************\nDuration Tru Def Designer Color Shingle Cost: $%.2f\n", fdesignercolor);
			float fmaterialcosts = ((fdesignercolor + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
			float ftotalcost = flaborcosts + fmaterialcosts;
			float fpersquareactual = ftotalcost / froofon;
			float fprofit = ftotalcost * .35;
			float fGrandTotal = ftotalcost + fprofit;
			float overhead = fGrandTotal * .1;
			float fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
			fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
			fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
			fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
			fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
			fprintf(fileo, "Overhead: $%.2f\n", overhead);
			fprintf(fileo, "Split: $%.2f\n", fsplit);
			fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));


			fprintf(fileo, "*************************************************************\nDuration Tru Definition Shingle Cost: $%.2f\n", fduration);
			fmaterialcosts = ((fduration + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
			ftotalcost = flaborcosts + fmaterialcosts;
			fpersquareactual = ftotalcost / froofon;
			fprofit = ftotalcost * .35;
			fGrandTotal = ftotalcost + fprofit;
			overhead = fGrandTotal * .1;
			fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
			fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
			fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
			fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
			fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
			fprintf(fileo, "Overhead: $%.2f\n", overhead);
			fprintf(fileo, "Split: $%.2f\n", fsplit);
			fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));


			fprintf(fileo, "*************************************************************\nOakridge Tru Definition Shingle Cost: $%.2f\n", foakridgetrudef);
			fmaterialcosts = ((foakridgetrudef + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
			ftotalcost = flaborcosts + fmaterialcosts;
			fpersquareactual = ftotalcost / froofon;
			fprofit = ftotalcost * .35;
			fGrandTotal = ftotalcost + fprofit;
			overhead = fGrandTotal * .1;
			fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
			fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
			fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
			fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
			fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
			fprintf(fileo, "Overhead: $%.2f\n", overhead);
			fprintf(fileo, "Split: $%.2f\n", fsplit);
			fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));


			fprintf(fileo, "*************************************************************\nOakridge Shingle Cost: $%.2f\n", foakridge);
			fmaterialcosts = ((foakridge + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
			ftotalcost = flaborcosts + fmaterialcosts;
			fpersquareactual = ftotalcost / froofon;
			fprofit = ftotalcost * .35;
			fGrandTotal = ftotalcost + fprofit;
			overhead = fGrandTotal * .1;
			fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
			fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
			fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
			fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
			fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
			fprintf(fileo, "Overhead: $%.2f\n", overhead);
			fprintf(fileo, "Split: $%.2f\n", fsplit);
			fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));

			fprintf(fileo, "*************************************************************\nSupreme Shingle Cost: $%.2f\n", fsupreme);
			fmaterialcosts = ((fsupreme + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
			ftotalcost = flaborcosts + fmaterialcosts;
			fpersquareactual = ftotalcost / froofon;
			fprofit = ftotalcost * .35;
			fGrandTotal = ftotalcost + fprofit;
			overhead = fGrandTotal * .1;
			fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
			fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
			fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
			fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
			fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
			fprintf(fileo, "Overhead: $%.2f\n", overhead);
			fprintf(fileo, "Split: $%.2f\n", fsplit);
			fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon)); 

		}
	}
	
	else{
		CString areas;
		CEagleViewImport::GetDlgItem(IDC_MOEDOFFSQ)->GetWindowTextW(areas);

		CString hipss;
		CEagleViewImport::GetDlgItem(IDC_MOEDHIPS)->GetWindowTextW(hipss);
		CString valleys;
		CEagleViewImport::GetDlgItem(IDC_MOEDVALLEYS)->GetWindowTextW(valleys);
		CString rakess;
		CEagleViewImport::GetDlgItem(IDC_MOEDRAKES)->GetWindowTextW(rakess);
		CString eavess;
		CEagleViewImport::GetDlgItem(IDC_MOEDEAVES)->GetWindowTextW(eavess);
		CString predpitchs;
		CEagleViewImport::GetDlgItem(IDC_MOEDPREDPITCH)->GetWindowTextW(predpitchs);
		CString ridgess;
		CEagleViewImport::GetDlgItem(IDC_MOEDRIDGES)->GetWindowTextW(ridgess);
		//CString flashings = buffertemp;

		//CString stepflashings = buffertemp;
		//CString parapetss = buffertemp;

		CString starter;
		CEagleViewImport::GetDlgItem(IDC_MOEDSTARTER)->GetWindowTextW(starter);
		//CString waste = buffertemp;

		//CString thelastpage = buffertemp;
		u = _tstoi(areas);
		f = _tstoi(rakess) + _tstoi(eavess);
		CEagleViewImport::SetDlgItemInt(IDC_EVSTARTER, f);
		areas.Format(L"%.2f", u*1.15 / 100, 10);
		CEagleViewImport::SetDlgItemText(IDC_ONSQUARES, areas);
		//fclose(filei);
		farea = u / 100;
		froofon = u*1.15 / 100;
		fhipridge = (_tstoi(hipss) + _tstoi(ridgess)) / 28;
		fridgevent = (_tstoi(ridgess) / 4)*1.1;
		//	 fflashing = _tstoi(flashings);
		// fstepflashing = _tstoi(stepflashings);
		fdripedge = (_tstoi(rakess) / 10)*1.1;
		ficewater = _tstoi(valleys);
		ficewater = ((ficewater / 68) * 1.1);
		fstarter = (_tstoi(eavess) + _tstoi(rakess)) / 100;
		//	 fparapets = _tstoi(parapetss);
		ffelt = u / 400;
		dumpsterfee = 250;
		int isqon = froofon + 1;
		fshinglecost = isqon * 73;
		if (u > 44 && u < 55) dumpsterfee = 300;
		else if (u > 54) dumpsterfee = 500;
		flaborcosts = isqon * 50 + dumpsterfee;
		int ifelt = ffelt + 1;
		fbuttoncaps = farea / 20;
		int ibuttoncaps = fbuttoncaps + 1;
		fbuttoncapcost = ibuttoncaps * 21;
		int iicewater = ficewater + 1;
		ficewatercost = iicewater * 56.71;
		int ihipridge = fhipridge + 1;
		fhipridgecost = ihipridge * 38.44;
		int idripedge = fdripedge + 1;
		fdripedgecost = idripedge * 7.60;
		int iridgevent = fridgevent + 1;
		fridgeventcost = iridgevent * 6.5;
		int istarter = fstarter + 1;
		fstartershinglecost = istarter * 30;
		froofnail = froofon / 16;
		int iroofnail = froofnail + 1;
		fosbcosts = 2 * 11;
		int icanspaint = 3;//GetDlgItemInt(IDC_INTCANSPAINT);
		fcanspaint = icanspaint;
		ftubesofcaulk = 3;//GetDlgItemInt(IDC_INTTUBESCAULK);
		fpaintcosts = fcanspaint * 5.21;
		fcaulkcosts = ftubesofcaulk * 4.71;
		froofnailcost = iroofnail * 22;
		ffeltcost = ifelt * 32.67;
		fdesignercolor = froofon * 73;
		fduration = froofon * 73;
		fsupreme = froofon * 56;
		foakridge = froofon * 68;
		foakridgetrudef = froofon * 69;
		f3n1pipeboot = 4/*GetDlgItemInt(IDC_INT3N1PIPEBOOT)*/ * 4.12;
		UpdateData(FALSE);

		fprintf(fileo, "**********Specifications:****************\nSquares Off: %.2f (SQ)\n", farea);
		fprintf(fileo, "Squares On: %.2f (SQ) 15%% waste factor\n", froofon);
		fprintf(fileo, "Starter Shingles: %.2f bundles\n", fstarter);
		fprintf(fileo, "Drip Edge: %.2f (10' sticks)\n", fdripedge);
		fprintf(fileo, "Ridge Vent: %.2f (4' pieces)\n", fridgevent);
		fprintf(fileo, "Hip & Ridge: %.2f (bundles)\n", fhipridge);
		fprintf(fileo, "Weather Watch G: %.2f (Rolls) \n", ficewater);
		fprintf(fileo, "Gorilla Guard %.2f (4sq roll)\n", ffelt);
		fprintf(fileo, "Plastic caps: %.2f (3000 ct bucket)\n", fbuttoncaps);
		fprintf(fileo, "Roofing Nails:  %.2f (1-1/4'' 15 degree coil nails)\n\n", froofnail);

		fprintf(fileo, "**********Material Order:****************\nOrder %i bundles of starter shingles from supplier.\n", istarter);
		fprintf(fileo, "Order %i Squares from supplier.\n", isqon);
		fprintf(fileo, "Order %i pieces of drip edge from supplier.\n", idripedge);
		fprintf(fileo, "Order %i pieces of ridge vent from supplier.\n", iridgevent);
		fprintf(fileo, "Order %i bundles hip & ridge from supplier.\n", ihipridge);
		fprintf(fileo, "Order %i rolls ice and water shield from supplier.\n", iicewater);
		fprintf(fileo, "Order %i rolls of Gorilla Guard from supplier.\n", ifelt);
		fprintf(fileo, "Order %i buckets of button caps from supplier.\n", ibuttoncaps);
		fprintf(fileo, "Order %i boxes of roofing coil nails from supplier.\n\n", iroofnail);

		fprintf(fileo, "**********Accessory Costs****************\nFelt Cost: $%.2f\n", ffeltcost);
		fprintf(fileo, "Button Cap Cost: $%.2f\n", fbuttoncapcost);
		fprintf(fileo, "Ice & WaterCost: $%.2f\n", ficewatercost);
		fprintf(fileo, "Drip Edge Cost: $%.2f\n", fdripedgecost);
		fprintf(fileo, "Hip & Ridge Cost: $%.2f\n", fhipridgecost);
		fprintf(fileo, "Ridge Vent Cost: $%.2f\n", fridgeventcost);
		fprintf(fileo, "Starter Shingle Cost: $%.2f\n", fstartershinglecost);
		fprintf(fileo, "Roofing Nail Cost: $%.2f\n", froofnailcost);
		fprintf(fileo, "Paint Cost: $%.2f\n", fpaintcosts);
		fprintf(fileo, "Caulk Cost: $%.2f\n", fcaulkcosts);
		fprintf(fileo, "OSB Cost: $%.2f\n", fosbcosts);
		fprintf(fileo, "Labor Costs: $%.2f\n\n", flaborcosts);

		fprintf(fileo, "*************************************************************\nDuration Tru Def Designer Color Shingle Cost: $%.2f\n", fdesignercolor);
		float fmaterialcosts = ((fdesignercolor + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
		float ftotalcost = flaborcosts + fmaterialcosts;
		float fpersquareactual = ftotalcost / froofon;
		float fprofit = ftotalcost * .35;
		float fGrandTotal = ftotalcost + fprofit;
		float overhead = fGrandTotal * .1;
		float fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
		fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
		fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
		fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
		fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
		fprintf(fileo, "Overhead: $%.2f\n", overhead);
		fprintf(fileo, "Split: $%.2f\n", fsplit);
		fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));


		fprintf(fileo, "*************************************************************\nDuration Tru Definition Shingle Cost: $%.2f\n", fduration);
		fmaterialcosts = ((fduration + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
		ftotalcost = flaborcosts + fmaterialcosts;
		fpersquareactual = ftotalcost / froofon;
		fprofit = ftotalcost * .35;
		fGrandTotal = ftotalcost + fprofit;
		overhead = fGrandTotal * .1;
		fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
		fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
		fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
		fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
		fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
		fprintf(fileo, "Overhead: $%.2f\n", overhead);
		fprintf(fileo, "Split: $%.2f\n", fsplit);
		fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));


		fprintf(fileo, "*************************************************************\nOakridge Tru Definition Shingle Cost: $%.2f\n", foakridgetrudef);
		fmaterialcosts = ((foakridgetrudef + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
		ftotalcost = flaborcosts + fmaterialcosts;
		fpersquareactual = ftotalcost / froofon;
		fprofit = ftotalcost * .35;
		fGrandTotal = ftotalcost + fprofit;
		overhead = fGrandTotal * .1;
		fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
		fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
		fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
		fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
		fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
		fprintf(fileo, "Overhead: $%.2f\n", overhead);
		fprintf(fileo, "Split: $%.2f\n", fsplit);
		fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));


		fprintf(fileo, "*************************************************************\nOakridge Shingle Cost: $%.2f\n", foakridge);
		fmaterialcosts = ((foakridge + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
		ftotalcost = flaborcosts + fmaterialcosts;
		fpersquareactual = ftotalcost / froofon;
		fprofit = ftotalcost * .35;
		fGrandTotal = ftotalcost + fprofit;
		overhead = fGrandTotal * .1;
		fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
		fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
		fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
		fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
		fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
		fprintf(fileo, "Overhead: $%.2f\n", overhead);
		fprintf(fileo, "Split: $%.2f\n", fsplit);
		fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));

		fprintf(fileo, "*************************************************************\nSupreme Shingle Cost: $%.2f\n", fsupreme);
		fmaterialcosts = ((fsupreme + ffeltcost + fbuttoncapcost + ficewatercost + fdripedgecost + fhipridgecost + fridgeventcost + fstartershinglecost + froofnailcost + fpaintcosts + fcaulkcosts + fosbcosts + f3n1pipeboot)*1.07);
		ftotalcost = flaborcosts + fmaterialcosts;
		fpersquareactual = ftotalcost / froofon;
		fprofit = ftotalcost * .35;
		fGrandTotal = ftotalcost + fprofit;
		overhead = fGrandTotal * .1;
		fsplit = (fGrandTotal - ftotalcost - overhead) / 2;
		fprintf(fileo, "Material Costs: $%.2f\n", fmaterialcosts);
		fprintf(fileo, "Total Cost: $%.2f (True Cost No Profit includes taxes.)\n", ftotalcost);
		fprintf(fileo, "35%% Profit: $%.2f\n", fprofit);
		fprintf(fileo, "Job Estimated Price Total: $%.2f\n", fGrandTotal);
		fprintf(fileo, "Overhead: $%.2f\n", overhead);
		fprintf(fileo, "Split: $%.2f\n", fsplit);
		fprintf(fileo, "Our cost per square $%.2f\n\n", (ftotalcost / froofon));
		//}
		if (fileo) fclose(fileo);

		int nRet1 = (int)ShellExecute(NULL, L"open", L"notepad.exe", L"output.txt", L".\\", SW_NORMAL);
		//int nRet4 = (int)ShellExecute(P_WAIT, L"open", L"cmd.exe", "/c print /d \\snotacus\"
		if (nRet1 <= 32) {
			DWORD dw = GetLastError();
			char szMsg[250];
			FormatMessage(
				FORMAT_MESSAGE_FROM_SYSTEM,
				0, dw, 0,
				(LPWSTR)szMsg, sizeof(szMsg),
				NULL
				);
			MessageBox((LPWSTR)szMsg, L"error launching notepad");
		}

	}
}




void CEagleViewImport::OnBnClickedBrowsebtn()
{

#define MAX_CFileDialog_FILE_COUNT 99

#define FILE_LIST_BUFFER_SIZE ((MAX_CFileDialog_FILE_COUNT * (MAX_PATH + 1)) + 1)

	CString fileName;
	int i = 0;
	wchar_t* p = fileName.GetBuffer(FILE_LIST_BUFFER_SIZE);
	CFileDialog dlgFile(TRUE);
	OPENFILENAME& ofn = dlgFile.GetOFN();
	ofn.Flags |= OFN_READONLY;
	ofn.lpstrFile = p;
	int nRet2 = (int)ShellExecute(P_WAIT, L"open", L"cmd.exe", L"/c Del .\\test.txt", L".\\", SW_NORMAL);
	int nRet3 = (int)ShellExecute(P_WAIT, L"open", L"cmd.exe", L"/c Del .\\output.txt", L".\\", SW_NORMAL);
	dlgFile.DoModal();
	
	
	

	ImportEagleView(ofn.lpstrFile, NULL, true);


	//ImportEagleView("", NULL, true);

}




void CEagleViewImport::OnEnChangeFilededitdlgbox()
{
	// TODO:  If this is a RICHEDIT control, the control will not
	// send this notification unless you override the CDialogEx::OnInitDialog()
	// function and call CRichEditCtrl().SetEventMask()
	// with the ENM_CHANGE flag ORed into the mask.

	// TODO:  Add your control notification handler code here
}


void CEagleViewImport::OnBnClickedMoed()
{
	if (IsDlgButtonChecked(IDC_MOED)){
		CEagleViewImport::GetDlgItem(IDC_MOEDRAKES)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDEAVES)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDRIDGES)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDHIPS)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDFLASHING)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDSTEPFLASH)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDONSQ)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDOFFSQ)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDVALLEYS)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDSTARTER)->EnableWindow();
		CEagleViewImport::GetDlgItem(IDC_MOEDPREDPITCH)->EnableWindow();
	}
	
	else{
		CEagleViewImport::GetDlgItem(IDC_MOEDRAKES)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDEAVES)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDRIDGES)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDHIPS)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDFLASHING)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDSTEPFLASH)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDONSQ)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDOFFSQ)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDVALLEYS)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDSTARTER)->EnableWindow(0);
		CEagleViewImport::GetDlgItem(IDC_MOEDPREDPITCH)->EnableWindow(0);
	}
	// TODO: Add your control notification handler code here
}
