#pragma once
#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif

#include <iostream>
#include <map>
#include <string>
#include <unordered_map>
#include <vector>

using namespace std;

struct Scope;

struct VarData
{
	string type;
	int size;
	int offset;
	int LocalCopyRef; // 0 var, 1 copy, 2 ref
	int ArrayNum; // 0 var , 1 oned, 2 twod
	int StartIndex1;
	int EndIndex1;
	int StartIndex2;
	int EndIndex2;
	bool PassbyRef;
	bool IsParam = false;
	Scope* NextScope;
};

struct Scope
{
	unordered_map<string, VarData> Table;
	int offset;
	int paramoffset = 8;
	string ScopeName;
	Scope* PreviousScope;
	vector<string> ParamOrder;


};

class SymbolTable
{
public:
	Scope* CurrentScope;


	SymbolTable()
	{
		CurrentScope = new Scope;
		CurrentScope->offset = 0;
		CurrentScope->ScopeName = "";
		CurrentScope->PreviousScope = NULL;
	}

	bool AddVariable(string name, string type, int size)
	{
		if (CurrentScope->Table.find(name) != CurrentScope->Table.end())
		{
			return false;
		}
		CurrentScope->Table[name].type = type;
		CurrentScope->Table[name].size = size;
		CurrentScope->Table[name].offset = CurrentScope->offset;
		CurrentScope->Table[name].NextScope = NULL;
		CurrentScope->offset += size;
		CurrentScope->Table[name].LocalCopyRef = 0;
		CurrentScope->Table[name].ArrayNum = 0;
		CurrentScope->Table[name].StartIndex1 = -1;
		CurrentScope->Table[name].EndIndex1 = -2;
		CurrentScope->Table[name].StartIndex2 = -1;
		CurrentScope->Table[name].EndIndex2= -2;
		return true;
	}
	bool AddArray(string name, string type, int size, int arraynum, int tmpSI1, int tmpEI1, int tmpSI2, int tmpEI2)
	{
		if (CurrentScope->Table.find(name) != CurrentScope->Table.end())
		{
			return false;
		}
		CurrentScope->Table[name].type = type;
		CurrentScope->Table[name].size = size;
		CurrentScope->Table[name].offset = CurrentScope->offset;
		CurrentScope->Table[name].NextScope = NULL;
		CurrentScope->offset += size;
		CurrentScope->Table[name].LocalCopyRef = 0;
		CurrentScope->Table[name].ArrayNum = arraynum;
		CurrentScope->Table[name].StartIndex1 = tmpSI1;
		CurrentScope->Table[name].EndIndex1 = tmpEI1;
		CurrentScope->Table[name].StartIndex2 = tmpSI2;
		CurrentScope->Table[name].EndIndex2 = tmpEI2;

		return true;
	}
	void GetArrayInfo(string name, int& tmpSI1, int& tmpEI1, int& tmpSI2, int& tmpEI2) {
		Scope* TravScope = CurrentScope;
		while (TravScope != NULL)
		{
			if (TravScope->Table.find(name) == TravScope->Table.end())
			{
				TravScope = TravScope->PreviousScope;
			}
			else
			{
				tmpSI1 = TravScope->Table[name].StartIndex1;
				tmpEI1 = TravScope->Table[name].EndIndex1;
				tmpSI2 = TravScope->Table[name].StartIndex2;
				tmpEI2 = TravScope->Table[name].EndIndex2;
				break;				
			}
		}
	}

	bool FindVariable(string name, string& type, int& PFV, int& offset, bool& IsGlobal, int& ArrayNumber) //, bool& IsGlobal
	{
		Scope* TravScope = CurrentScope;

		
		while (TravScope != NULL)
		{
			if (TravScope->Table.find(name) == TravScope->Table.end())
			{
				TravScope = TravScope->PreviousScope;
			}
			else
			{
				//TravScope = TravScope->Table[name].NextScope;
				type = TravScope->Table[name].type;
				offset = TravScope->Table[name].offset;
				ArrayNumber = TravScope->Table[name].ArrayNum;
				if (TravScope->PreviousScope) {//local
					IsGlobal = false;
					if (TravScope->Table[name].LocalCopyRef == 0) {// 0 var, 1 copy, 2 ref
						PFV = 0;
						if (TravScope->Table[name].NextScope != NULL && TravScope->Table[name].type == "func") {
							PFV = 3; // func
						}

					}
					else if (TravScope->Table[name].LocalCopyRef == 1) { //&& TravScope->Table[name].NextScope != NULL
						PFV = 1;// proc pass by copy
						if (TravScope->Table[name].type == "func") {
							PFV = 3;  //func pass by copy
						}
					}
					else if (TravScope->Table[name].LocalCopyRef == 2) { //&& TravScope->Table[name].NextScope != NULL
						PFV = 2;// proc pass by ref
						if (TravScope->Table[name].type == "func") {
							PFV = 3;  //func pass by ref
						}
					}
				}
				else {//gobal
					IsGlobal = true;
					if (TravScope->Table[name].LocalCopyRef == 0) {// 0 var, 1 copy, 2 ref
						PFV = 0;
						if (TravScope->Table[name].NextScope != NULL && TravScope->Table[name].type == "func") {
							PFV = 3; // func
						}

					}
					else if (TravScope->Table[name].LocalCopyRef == 1) { //&& TravScope->Table[name].NextScope != NULL
						PFV = 1;// pass by copy
						if (TravScope->Table[name].type == "func") {
							PFV = 3;  //func
						}
					}
					else if (TravScope->Table[name].LocalCopyRef == 2) { //&& TravScope->Table[name].NextScope != NULL
						PFV = 2;//pass by ref
						if (TravScope->Table[name].type != "func") {
							PFV = 3;  //func
						}
					}
					
				}
				return true;				
			}
		}
		return false;
	}

	bool AddProcFunc(string name, string type)
	{
		if (CurrentScope->Table.find(name) != CurrentScope->Table.end())
		{
			return false;
		}
		CurrentScope->Table[name].type = type;
		CurrentScope->Table[name].size = 0;
		CurrentScope->Table[name].offset = 0 ;

		Scope* OldCurrent = CurrentScope;

		CurrentScope->Table[name].NextScope = new Scope;
		CurrentScope = CurrentScope->Table[name].NextScope;
		CurrentScope->offset = 0;
		CurrentScope->ScopeName = name;
		CurrentScope->PreviousScope = OldCurrent;

		return true;

	}

	bool AddParam(string name, string type, bool Ref) {
		if (CurrentScope->Table.find(name) != CurrentScope->Table.end())
		{
			return false;
		}
		CurrentScope->Table[name].type = type;
		CurrentScope->Table[name].size = 4;
		CurrentScope->Table[name].offset = CurrentScope->paramoffset;
		CurrentScope->paramoffset += 4;
		CurrentScope->Table[name].IsParam = true;
		CurrentScope->ParamOrder.push_back(name);
		if (Ref) {  
			CurrentScope->Table[name].LocalCopyRef = 2; // pass by ref
		}
		else {
			CurrentScope->Table[name].LocalCopyRef = 1; // pass by copy
		}
		

		return true;
	}

	void GetParamInfo(string name, int CurrentParam, string& type, bool& ref, int& offset) {

		Scope* TravScope = CurrentScope;
		while (TravScope != NULL)
		{
			if (TravScope->Table.find(name) == TravScope->Table.end())
			{
				TravScope = TravScope->PreviousScope;
			}
			else
			{
				TravScope = TravScope->Table[name].NextScope;
				type = TravScope->Table[TravScope->ParamOrder[CurrentParam]].type;
				offset = TravScope->Table[TravScope->ParamOrder[CurrentParam]].offset;
				if (TravScope->Table[TravScope->ParamOrder[CurrentParam]].LocalCopyRef == 2) {
					ref = true;
					break;
				}
				else {
					ref = false;
					break;
				}
			}
		}
 	}

	int GetLocalVariableCount() {
		return CurrentScope->offset;
	}

	void BackOut()
	{
		if (CurrentScope->PreviousScope) CurrentScope = CurrentScope->PreviousScope;
	}



};
