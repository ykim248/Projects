#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include<stack>
#include<vector>
#include "CLexor.h"
#include "SymbolTable.h"


struct Registar {
	string RegName;
	bool RegLiteral;
	int RegValue;
	
};

class PatheticParser {
public:
	ifstream ReadFile;
	CLex CLexor;
	CToken Token;
	bool Gotit;
	bool PassbyRef = false;
	SymbolTable StupidSymTab;
	stack<string> DumbDatatypeStack;
	stack<string> AssInstrucStack;
	stack<string> ParamintheAssInstrucStack;
	stack<string> ConditionStack;
	vector<string> VapidParamVarVector;	
	ofstream out;
	Registar RegistarArr[4];
	int ORCount = 1;
	string LastCompare;
	int IFCount = 1;
	int WhileCount = 1;
	bool ORUsed = false;
	int tmpSI1;
	int tmpEI1;
	int tmpSI2;
	int tmpEI2;	
	bool isArray = false;
	int ArrayNum; // 0 var , 1 oned, 2 twod
	bool Goddamnarray = false;
	

	int CurrentReg = 0;

	PatheticParser() {}

	void CreateHeader() {
		

		out.open("assembler.cpp");

		out << "#include <iostream>" << endl;
		out << "using namespace std;" << endl;
		out << "char DataSegment[65536];" << endl;
		out << "int *look;" << endl;
		out << "int main()" << endl;
		out << "{" << endl;

		out << "look = (int*)DataSegment;" << endl;

		out << "	_asm{" << endl;
		out << "		push eax         // Assembler header for all programs (Top)" << endl;
		out << "		push ebx" << endl;
		out << "		push ecx" << endl;
		out << "		push edx" << endl;
		out << "		push ebp" << endl;
		out << "		push edi" << endl;
		out << "		push esi" << endl;
		out << "		push esp" << endl << endl;
		out << "		lea ebp, DataSegment" << endl;
		out << "		jmp kmain       // Assembler header for all programs (Bottom)" << endl << endl << endl;

	}

	void CreateFooter() {
		out << "		pop esp    // Assembler footer for all programs (Top)" << endl;
		out << "		pop esi" << endl;
		out << "		pop edi" << endl;
		out << "		pop ebp" << endl;
		out << "		pop edx" << endl;
		out << "		pop ecx" << endl;
		out << "		pop ebx" << endl;
		out << "		pop eax    // Assembler footer for all programs (Bottom)" << endl;
		out << "	}" << endl;
		out << "return 0;" << endl;
		out << "}" << endl;

		out.close();
	}

	void CreateParamHeader()
	{
		//assembler to check how many local variable
		out << "		push edi" << endl;
		out << "		mov edi,esp" << endl;
		out << "		sub esp," << StupidSymTab.GetLocalVariableCount() << endl;
		out << "		push eax" << endl;
		out << "		push ebx" << endl;
		out << "		push ecx" << endl;
		out << "		push edx" << endl;
		out << "		push ebp" << endl;
		out << "		push edi" << endl;
		out << "		push esi" << endl;
		out << "		push esp" << endl << endl << endl;;
	}

	void CreateParamFooter()
	{
		out << "		pop esp" << endl;
		out << "		pop esi" << endl;
		out << "		pop edi" << endl;
		out << "		pop ebp" << endl;
		out << "		pop edx" << endl;
		out << "		pop ecx" << endl;
		out << "		pop ebx" << endl;
		out << "		pop eax" << endl << endl;
		out << "		add esp," << StupidSymTab.GetLocalVariableCount() << endl;
		out << "		pop edi" << endl;
		out << "		ret " << StupidSymTab.CurrentScope->ParamOrder.size() * 4 << endl << endl;
	}

	void GetToken() {
		if (CLexor.GetToken(Token)) {
			cout << Token.value + " ";
			Gotit = true;
		}
		else {
			Gotit = false;
		}

	}

	void StupidParser(string File) {
		CLexor.SetUpLexor(File);

		RegistarArr[0].RegName = "eax";
		RegistarArr[1].RegName = "ebx";
		RegistarArr[2].RegName = "ecx";
		RegistarArr[3].RegName = "edx";

		CreateHeader();

		GetToken();

		program();
		 
		if (Gotit == true) {
			cout << "Pathetic and Stupid code! 1" << endl;
			exit(0);
		}
		CreateFooter(); 
		cout << "Ok!" << endl;
		//system("pause");
 	}

	void program() {
		block();
		if (Token.value == ".") {
			GetToken();
		}
		else {
			cout << "Pathetic and Stupid code 2" << endl;
			exit(0);
		}
	}
	void block() {
		PFV();
		if (Token.value == "begin") {
			if (!StupidSymTab.CurrentScope->PreviousScope) {
				out << "		kmain:" << endl << endl;
			}
			else {
				CreateParamHeader();
			}
			GetToken();
			Statement();
			MStatement();
			if (Token.value == "end") {
				GetToken();
				if (Token.value == ";") {
					CreateParamFooter();
				}
			}
			else {
				cout << "Pathetic and Stupid code 3" << endl;
				exit(0);
			}
		}
		else {
			cout << "Pathetic and Stupid code 4" << endl;
			exit(0);
		}
	}
	void Statement() {
		if (Token.type == "RWord") {
			if (Token.value == "begin") {
				
				GetToken();
				Statement();
				MStatement();
				if (Token.value == "end") {
					GetToken();
				}
				else {
					cout << "Pathetic and Stupid code 5" << endl;
					exit(0);
				}
			}
			if (Token.value == "if") {
				// add F and ifcount to stack (we can pop 2 at a time)
				ConditionStack.push("F");
				ConditionStack.push(to_string(IFCount));
				IFCount++;
				GetToken();
				E();
				if (DumbDatatypeStack.top() != "boolean") {
					cout << "Pathetic and Stupid code 7" << endl;
					exit(0);
				}
				if (Token.value == "then") {
					string tmpCondtion1 = ConditionStack.top();
					ConditionStack.pop();
					string tmpCondtion2 = ConditionStack.top();
					ConditionStack.pop();
					
					if (LastCompare == "=") {
						out << "		JE TOPIF" + tmpCondtion1 << endl;
					}
					else if (LastCompare == ">") {
						out << "		JG TOPIF" + tmpCondtion1 << endl;
					}
					else if (LastCompare == "<") {
						out << "		JL TOPIF" + tmpCondtion1 << endl;
					}
					if (ORUsed) {
						out << "OR" + to_string(ORCount) + ":" << endl;
						ORCount++;
						ORUsed = false;
					}
					
					out << "		JMP TOPELSE" + tmpCondtion1 << endl;
					
					ConditionStack.push(tmpCondtion2);
					ConditionStack.push(tmpCondtion1);
					
					
					out << "TOPIF" + tmpCondtion1 + ":" << endl;
					GetToken();
					Statement();
					out << "		JMP EndIF" + tmpCondtion1 << endl;
					// out <<  jmp ENDif1
					out << "TOPELSE" + tmpCondtion1 + ":" << endl;
					IFPrime();
					out << "ENDIF" + tmpCondtion1 + ":" << endl;
					ConditionStack.pop();
					ConditionStack.pop();
				}
				else {
					cout << "Pathetic and Stupid code 6" << endl;
					exit(0);
				}

			}

			if (Token.value == "while") {
				//out << while + count
				ConditionStack.push("W");
				ConditionStack.push(to_string(WhileCount));
				// add W and Whilecount to stack (we can pop 2 at a time)
				WhileCount++;

				string tmpCondtion1 = ConditionStack.top();
				ConditionStack.pop();
				string tmpCondtion2 = ConditionStack.top();
				ConditionStack.pop();

				out << "TOPWhile" + tmpCondtion1 + ":" << endl;

				ConditionStack.push(tmpCondtion2);
				ConditionStack.push(tmpCondtion1);
				GetToken();
				E();
				if (DumbDatatypeStack.top() != "boolean") {
					cout << "Pathetic and Stupid code 7" << endl;
					exit(0);
				}
				if (Token.value == "do") {
					//if last compare is true go into while loop
				
				if (LastCompare == "=") {
					out << "		JE InsideWhile" + tmpCondtion1 << endl;

				}
				else if (LastCompare == ">") {
					out << "		JG InsideWhile" + tmpCondtion1 << endl; //FIX THIS JG 

				}
				else if (LastCompare == "<") {
					out << "		JL InsideWhile" + tmpCondtion1 << endl; //JL

				}
				if (ORUsed) {
					out << "OR" + to_string(ORCount) + ":" << endl;
					ORCount++;
				}
				out << "		JMP EndWhile" + tmpCondtion1 << endl;
					//jump insdewhile + stack count
					//jump endwhile + stack count
					//label insidewhile + stack count
				out << "InsideWhile" + tmpCondtion1 + ":" << endl;
					GetToken();
					Statement();
 					//MStatement();
					out << "		JMP TOPWhile" + tmpCondtion1 << endl;
					out << "EndWhile" + tmpCondtion1 + ":" << endl;
					//jmp to top while +stack count
					//label endwhiole +stack count
					//pop the top
					ConditionStack.pop(); 
					ConditionStack.pop();

				}
			}
		}
		else if (Token.type == "Word") {
			int tmpOffset = INT_MIN;
			string DataType;
			int ProcFuncVar;
			string PFname = Token.value;
			bool isGlobal;
			int ThisArrayNum;
			// 8: Check to see if the word is in the symbol table. 
			if (StupidSymTab.FindVariable(PFname, DataType, ProcFuncVar, tmpOffset, isGlobal, ArrayNum)) {
				//(FindVariable) Push datatype onto the stack.
				ThisArrayNum = ArrayNum;
				if (ArrayNum == 0) {
					DumbDatatypeStack.push(DataType);
					AssInstrucStack.push("   ");
				}
				else if (ArrayNum == 1) {
					GetToken();
					if (Token.value == "[") {
						GetToken();
						E();
						//ass code here
						if (Token.value == "]") {
							StupidSymTab.GetArrayInfo(PFname, tmpSI1, tmpEI1, tmpSI2, tmpEI2);
							//ass code
							string tmpAssmInstruc1 = AssInstrucStack.top();
							out << tmpAssmInstruc1 << endl;
							AssInstrucStack.pop();
							out << "		sub " + RegistarArr[CurrentReg-1].RegName + "," + to_string(tmpSI1) << endl;
							if (DataType == "integer") {
								out << "		imul " + RegistarArr[CurrentReg-1].RegName + "," + to_string(4) << endl;
							}
							else if (DataType == "char" || DataType == "boolean") {

								out << "		imul " + RegistarArr[CurrentReg-1].RegName + "," + to_string(1) << endl;
							}
							out << "		add " + RegistarArr[CurrentReg-1].RegName + "," + to_string(tmpOffset) << endl;
							
							
						}
						else {
							cout << "StatementArray 1" << endl;
							exit(0);
						}
					}
					else {
						cout << "StatementArray 2" << endl;
						exit(0);
					}
				}
				else if (ArrayNum == 2) {
					GetToken();
					if (Token.value == "[") {
						GetToken();
						E();
						if (AssInstrucStack.size() == 1) {
							string tmpAssmInstruc1 = AssInstrucStack.top();
							AssInstrucStack.pop();
							out << tmpAssmInstruc1 << endl;
							AssInstrucStack.push("		");
						}
						if (Token.value == ",") {
							GetToken();
							E();
							
						}
						if (Token.value == "]") {
							StupidSymTab.GetArrayInfo(PFname, tmpSI1, tmpEI1, tmpSI2, tmpEI2);;
							//ass code here
							string tmpAssmInstruc1 = AssInstrucStack.top();
							AssInstrucStack.pop();
							string tmpAssmInstruc2 = AssInstrucStack.top();
							AssInstrucStack.pop();
							out << tmpAssmInstruc2 << endl;
							out << tmpAssmInstruc1 << endl;


							out << "		sub " + RegistarArr[CurrentReg - 2].RegName + ", " + to_string(tmpSI1) << endl;

							if (DataType == "integer") {
								out << "		imul " + RegistarArr[CurrentReg - 2].RegName + ", " + to_string(((tmpEI2 - tmpSI2) + 1) * 4) << endl;
							}
							else if (DataType == "char" || DataType == "boolean") {

								out << "		imul " + RegistarArr[CurrentReg - 2].RegName + ", " + to_string(((tmpEI2 - tmpSI2) + 1) * 1) << endl;
							}

							out << "		sub " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(tmpSI2) << endl;

							if (DataType == "integer") {
								out << "		imul " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(4) << endl;
							}
							else if (DataType == "char" || DataType == "boolean") {

								out << "		imul " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(1) << endl;
							}

							out << "		add " + RegistarArr[CurrentReg - 2].RegName + ", " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;

							out << "		add " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(tmpOffset) << endl;
						}
						else {
							cout << "StatementArray 3" << endl;
							exit(0);
						}
					}
					else {
						cout << "StatementArray 4" << endl;
						exit(0);
					}
				}
				
			}
			else {
				cout << "StatementStackerror 1" << endl;
				exit(0);
			}

			GetToken();

			if (Token.value == ":=") {
				GetToken();
				E();
				//10: Pop two datatypes off of the stack. 
				//Make sure the two datatypes are the same.
				string tmpFirstTop = DumbDatatypeStack.top();				
				DumbDatatypeStack.pop();

				string tmpSecondTop = DumbDatatypeStack.top();
				DumbDatatypeStack.pop();

				if (tmpFirstTop != tmpSecondTop) {
					cout << "StatementStackerror 2" << endl;
					exit(0);
				}
				/*string tmpAssmInstruc1 = AssInstrucStack.top();
				AssInstrucStack.pop();
				string tmpAssmInstruc2 = AssInstrucStack.top();
				AssInstrucStack.pop();
				if (CurrentReg > 0) {
					CurrentReg--;
				}	*/

				if (ThisArrayNum == 0) {
					while (AssInstrucStack.size() < 2) {
						AssInstrucStack.push("	");
					}
					string tmpAssmInstruc1 = AssInstrucStack.top();
					AssInstrucStack.pop();
					string tmpAssmInstruc2 = AssInstrucStack.top();
					AssInstrucStack.pop();
					if (CurrentReg > 0) {
						CurrentReg--;
					}
					if (isGlobal) {// this is for global varbirls
						out << tmpAssmInstruc2 << endl;
						out << tmpAssmInstruc1 << endl;
						out << "		mov [ebp+" << tmpOffset << "] , " << RegistarArr[CurrentReg].RegName << endl;
					}
					else { //local
						//variable if pfv ==0 -> var
						if (ProcFuncVar == 0) {
							out << "		mov[edi-" << tmpOffset + StupidSymTab.CurrentScope->Table[PFname].size << "], " << RegistarArr[CurrentReg].RegName << endl;
						}
						if (ProcFuncVar == 1) { //param pas by copy
							out << "		mov[edi-" << tmpOffset << "], " << RegistarArr[CurrentReg].RegName << endl; //go talk to scott dummy
						}
						else if (ProcFuncVar == 2) {//param pas by copy
							out << "		mov esi, dword ptr [edi+" << tmpOffset << "]" << endl;
							out << "		mov [esi], " << RegistarArr[CurrentReg].RegName << endl;
						}
					}
				}
				else if (ThisArrayNum == 1) {
					string tmpAssmInstruc2 = AssInstrucStack.top();
					AssInstrucStack.pop();
					out << tmpAssmInstruc2 << endl;
					out << "		mov [ebp + " + RegistarArr[CurrentReg - 2].RegName + "], " + RegistarArr[CurrentReg - 1].RegName << endl;
					CurrentReg -= 2;
				}
				else if (ThisArrayNum == 2) {
					if (AssInstrucStack.size() > 0) {
						string tmpAssmInstruc2 = AssInstrucStack.top();
						AssInstrucStack.pop();
						out << tmpAssmInstruc2 << endl;
					}
					
					out << "		mov [ebp + " + RegistarArr[CurrentReg - 2].RegName + "], " + RegistarArr[CurrentReg - 1].RegName << endl;
					CurrentReg -= 2;
				}

				//fix this issue later dumbass 
				
			}
			else if (Token.value == "(") {
				GetToken();
				ConsumeParam(PFname);
				if (Token.value == ")") {
					//gettoken
					GetToken();
				}
				else {
					cout << "Terrible Cowboys" << endl;
					exit(0);
				}
			}
			else {
				cout << "Pathetic and Stupid code 7" << endl;
				exit(0);
			}
		}
	}
	void MStatement() {
		if (Token.value == ";") {
			GetToken();
			Statement();
			MStatement();
		}
	}
	void IFPrime() {
		if (Token.value == "else") {
			GetToken();
			Statement();
			//out << endif
		}
	}
	void E() {
		SE();
	}
	void SE() {
		SER();
		SEP();
	}
	void SEP() {
		if (Token.value == "<" || Token.value == ">" || Token.value == "=") {
			string LastToken = Token.value;
			LastCompare = LastToken;
			GetToken();
			SER();
			//9:Pop two datatypes off of the stack.  
			string tmpFirstTop = DumbDatatypeStack.top();
			DumbDatatypeStack.pop();
			string tmpSecondTop = DumbDatatypeStack.top();
			DumbDatatypeStack.pop();
			//Make sure you can do the current operation on the two datatypes.
			if (tmpFirstTop == tmpSecondTop) {
			//Put the new datatype onto the stack.
				DumbDatatypeStack.push("boolean");
				string tmpAssmInstruc1 = AssInstrucStack.top();
				AssInstrucStack.pop();
				string tmpAssmInstruc2 = AssInstrucStack.top();
				AssInstrucStack.pop();

				out << tmpAssmInstruc2 << endl;
				out << tmpAssmInstruc1 << endl;
				AssInstrucStack.push("   ");
				out << "		cmp " + RegistarArr[CurrentReg - 2].RegName + ", " + RegistarArr[CurrentReg - 1].RegName << endl;
				CurrentReg -= 2;
				
			}
			else {
				cout << "SEPStackerror" << endl;
				exit(0);
			}
			
			SEP();
		}
	}
	void SER() {
		T();
	}
	void T() {
		TR();
		TP();
	}
	void TP() {
		if (Token.value == "+" || Token.value == "-" || Token.value == "or") {
			string LastToken = Token.value;
			
			if (LastToken == "or") {
				string tmpCondtion1 = ConditionStack.top();
				ConditionStack.pop();
				string tmpCondtion2 = ConditionStack.top();
				ConditionStack.pop();
				if (tmpCondtion2 == "F") {
					if (LastCompare == "=") {
						out << "		JE TOPIF" + tmpCondtion1 << endl;

					}
					else if (LastCompare == ">") {
						out << "		JG TOPIF" + tmpCondtion1 << endl; //FIX THIS JG 

					}
					else if (LastCompare == "<") {
						out << "		JL TOPIF" + tmpCondtion1 << endl; //JL

					}
				}
				else if (tmpCondtion2 == "W") {
					if (LastCompare == "=") {
						out << "		JE InsideWhile" + tmpCondtion1 << endl;

					}
					else if (LastCompare == ">") {
						out << "		JG InsideWhile" + tmpCondtion1 << endl; //FIX THIS JG 

					}
					else if (LastCompare == "<") {
						out << "		JL InsideWhile" + tmpCondtion1 << endl; //JL

					}
				}
				
				if (ORUsed) {
					out << "OR" + to_string(ORCount) + ":" << endl;
					ORUsed = false;
					ORCount++;
				}
				ConditionStack.push(tmpCondtion2);
				ConditionStack.push(tmpCondtion1);
			}
			
			// increment orcount here maybe
			GetToken();
			TR();
			//9:Pop two datatypes off of the stack.  
			string tmpFirstTop = DumbDatatypeStack.top();
			DumbDatatypeStack.pop();
			string tmpSecondTop = DumbDatatypeStack.top();
			DumbDatatypeStack.pop();
			//Make sure you can do the current operation on the two datatypes.
			if (tmpFirstTop == tmpSecondTop) {
				if (LastToken == "or") {
					string tmpCondtion1 = ConditionStack.top();
					ConditionStack.pop();
					string tmpCondtion2 = ConditionStack.top();
					ConditionStack.pop();
					DumbDatatypeStack.push("boolean");
					//if (ORUsed) {
					//	if (tmpCondtion2 == "F") {
					//		if (LastCompare == "=") {
					//			out << "		JE TOPIF" + tmpCondtion1 << endl;

					//		}
					//		else if (LastCompare == ">") {
					//			out << "		JG TOPIF" + tmpCondtion1 << endl; //JG

					//		}
					//		else if (LastCompare == "<") {
					//			out << "		JL TOPIF" + tmpCondtion1 << endl; //JL
					//		}
					//	}
					//	else if (tmpCondtion2 == "W") {
					//		if (LastCompare == "=") {
					//			out << "		JE InsideWhile" + tmpCondtion1 << endl;

					//		}
					//		else if (LastCompare == ">") {
					//			out << "		JG InsideWhile" + tmpCondtion1 << endl; //JG

					//		}
					//		else if (LastCompare == "<") {
					//			out << "		JL InsideWhile" + tmpCondtion1 << endl; //JL
					//		}
					//	}
					//	
					//}

					
					ConditionStack.push(tmpCondtion2);
					ConditionStack.push(tmpCondtion1);
				}
				//Put the new datatype onto the stack.
				else {
					DumbDatatypeStack.push("integer");

					string tmpAssmInstruc1 = AssInstrucStack.top();
					AssInstrucStack.pop();
					string tmpAssmInstruc2 = AssInstrucStack.top();
					AssInstrucStack.pop();

									
					if (RegistarArr[CurrentReg - 1].RegLiteral == false || RegistarArr[CurrentReg - 2].RegLiteral == false) {
						out << tmpAssmInstruc2 << endl;
						out << tmpAssmInstruc1 << endl;
						AssInstrucStack.push("   ");

						if (LastToken == "+") {
							out << "		add " + RegistarArr[CurrentReg - 2].RegName + " , " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;
						}
						else {
							out << "		sub " + RegistarArr[CurrentReg - 2].RegName + " , " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;
						}
						
					}
					else if (RegistarArr[CurrentReg - 1].RegLiteral == true && RegistarArr[CurrentReg - 2].RegLiteral == true && !Goddamnarray) {
						if (LastToken == "+") {
							RegistarArr[CurrentReg - 2].RegValue += RegistarArr[CurrentReg - 1].RegValue;							
							AssInstrucStack.push("		mov " + RegistarArr[CurrentReg - 2].RegName + " , " + to_string(RegistarArr[CurrentReg - 2].RegValue));
							CurrentReg--;
						}
						else {
							RegistarArr[CurrentReg - 2].RegValue -= RegistarArr[CurrentReg - 1].RegValue;							
							AssInstrucStack.push("		mov " + RegistarArr[CurrentReg - 2].RegName + " , " + to_string(RegistarArr[CurrentReg - 2].RegValue));
							CurrentReg--;
						}
						
					}
					else {
						out << tmpAssmInstruc2 << endl;
						out << tmpAssmInstruc1 << endl;
						AssInstrucStack.push("   ");

						if (LastToken == "+") {
							out << "		add " + RegistarArr[CurrentReg - 2].RegName + " , " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;
						}
						else {
							out << "		sub " + RegistarArr[CurrentReg - 2].RegName + " , " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;
						}
					}

				}
				
			}
			else {
				cout << "TPStackerror" << endl;
				exit(0);
			}
			TP();
		}
	}
	void TR() {
		F();
	}
	void F() {
		FR();
		FP();
	}
	void FP() {
		if (Token.value == "*" || Token.value == "/" || Token.value == "and") {
			string LastToken = Token.value;
			if (LastToken == "and") {
				//DumbDatatypeStack.push("boolean");
				if (LastCompare == "=") {
					out << "		JNE OR" + to_string(ORCount) << endl;
					ORUsed = true;
				}
				else if (LastCompare == ">") {
					out << "		JLE OR" + to_string(ORCount) << endl; 
					ORUsed = true;
				}
				else if (LastCompare == "<") {
					out << "		JGE OR" + to_string(ORCount) << endl;
					ORUsed = true;
				}
			}
			GetToken();
			FR();
			//9:Pop two datatypes off of the stack.  
			string tmpFirstTop = DumbDatatypeStack.top();
			DumbDatatypeStack.pop();
			string tmpSecondTop = DumbDatatypeStack.top();
			DumbDatatypeStack.pop();
			
			//Make sure you can do the current operation on the two datatypes.
			if (tmpFirstTop == tmpSecondTop) {
				if (LastToken == "and") {
					DumbDatatypeStack.push("boolean");
					
					
				}
				//Put the new datatype onto the stack.
				if (tmpFirstTop == "integer") {
					DumbDatatypeStack.push("integer");

					string tmpAssmInstruc1 = AssInstrucStack.top();
					AssInstrucStack.pop();
					string tmpAssmInstruc2 = AssInstrucStack.top();
					AssInstrucStack.pop();

					if (RegistarArr[CurrentReg - 1].RegLiteral == false || RegistarArr[CurrentReg - 2].RegLiteral == false) {
						out << tmpAssmInstruc2 << endl;
						out << tmpAssmInstruc1 << endl;
						AssInstrucStack.push("   ");

						if (LastToken == "*") {
							out << "		imul " + RegistarArr[CurrentReg - 2].RegName + " , " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;
						}
						else if (LastToken == "/") {
							if (CurrentReg - 2 == 0) {
								out << "		push edx" << endl << "		cdq" << endl << "		idiv " + RegistarArr[CurrentReg - 1].RegName << endl << "		pop edx" << endl;
								CurrentReg--;
							}
							else {
								out << "		push eax" << endl << "		push edx" << endl << "		mov eax, " + RegistarArr[CurrentReg - 2].RegName << endl << "		cdq" << endl << "		idiv " + RegistarArr[CurrentReg - 1].RegName << endl << "		mov " + RegistarArr[CurrentReg - 2].RegName + ", eax" << endl << "		pop edx" << endl << "		pop eax" << endl;
								CurrentReg--;
							}
						}
					}
					else if (RegistarArr[CurrentReg - 1].RegLiteral == true && RegistarArr[CurrentReg - 2].RegLiteral == true && !Goddamnarray) {
						if (LastToken == "*") {
							RegistarArr[CurrentReg - 2].RegValue *= RegistarArr[CurrentReg - 1].RegValue;
							AssInstrucStack.push("mov " + RegistarArr[CurrentReg - 2].RegName + " , " + to_string(RegistarArr[CurrentReg - 2].RegValue));

							CurrentReg--;
						}
					}
					else {
						out << tmpAssmInstruc2 << endl;
						out << tmpAssmInstruc1 << endl;
						AssInstrucStack.push("   ");

						if (LastToken == "*") {
							out << "		imul " + RegistarArr[CurrentReg - 2].RegName + " , " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;
						}
						else if (LastToken == "/") {
							if (CurrentReg - 2 == 0) {
								out << "		push edx" << endl << "		cdq" << endl << "		idiv " + RegistarArr[CurrentReg - 1].RegName << endl << "		pop edx" << endl;
								CurrentReg--;
							}
							else {
								out << "		push eax" << endl << "		push edx" << endl << "		mov eax, " + RegistarArr[CurrentReg - 2].RegName << endl << "		cdq" << endl << "		idiv " + RegistarArr[CurrentReg - 1].RegName << endl << "		mov " + RegistarArr[CurrentReg - 2].RegName + ", eax" << endl << "		pop edx" << endl << "		pop eax" << endl;
								CurrentReg--;
							}
						}
					}
				}
				else if (tmpFirstTop == "Real") {
					DumbDatatypeStack.push("Real");
				}
				
			}
			else {
				cout << "FPStackerror" << endl;
				exit(0);
			}
			FP();
		}
	}
	void FR() {
		if (Token.type == "integer") {
			//11:Push datatype onto the stack.
			DumbDatatypeStack.push("integer");
			RegistarArr[CurrentReg].RegLiteral = true;
			RegistarArr[CurrentReg].RegValue = stoi(Token.value);
			AssInstrucStack.push("		mov " + RegistarArr[CurrentReg].RegName + " ," + to_string(RegistarArr[CurrentReg].RegValue));

			CurrentReg++;	

			GetToken();
		}
		else if (Token.type == "Real") {
			//11:Push datatype onto the stack.
			DumbDatatypeStack.push("Real");
			GetToken();
		}
		else if (Token.type == "Word") {
			int tmpOffset = INT_MIN;
			string DataType;
			int ProcFuncVar;
			string PFname = Token.value;
			bool isGlobal;
			if (PFname == "true" || PFname == "false") {
				DumbDatatypeStack.push("boolean");
			}
			// 8: Check to see if the word is in the symbol table. 
			else if (StupidSymTab.FindVariable(Token.value, DataType, ProcFuncVar, tmpOffset, isGlobal, ArrayNum))
			{
				if (ArrayNum == 0) {// variable
					Goddamnarray = false;
					DumbDatatypeStack.push(DataType);
					if (!isGlobal) {//local
						if (StupidSymTab.CurrentScope->Table[PFname].IsParam == false) {


							RegistarArr[CurrentReg].RegLiteral = false;
							RegistarArr[CurrentReg].RegValue = NULL;
							//mov into ebp+offset
							AssInstrucStack.push("mov " + RegistarArr[CurrentReg].RegName + " , " + "[edi - " + to_string(tmpOffset + StupidSymTab.CurrentScope->Table[PFname].size) + "]");

							CurrentReg++;
						}
						else {
							//if its param check copy or ref 
							if (ProcFuncVar == 1) { //param in proc pass by copy
								RegistarArr[CurrentReg].RegLiteral = false;
								RegistarArr[CurrentReg].RegValue = NULL;
								AssInstrucStack.push("		mov " + RegistarArr[CurrentReg].RegName + " , " + "[edi + " + to_string(tmpOffset) + "]"); //FIX THIS!!!
								CurrentReg++;
							}
							else if (ProcFuncVar == 2) { //param in proc pass by ref
								RegistarArr[CurrentReg].RegLiteral = false;
								RegistarArr[CurrentReg].RegValue = NULL;
								AssInstrucStack.push("		mov esi , [edi + " + to_string(tmpOffset) + "]" + "\n" + "		mov [esi], " + RegistarArr[CurrentReg].RegName);
								CurrentReg++;
							}
						}

					}
					else {
						if (ProcFuncVar == 3) { // function
							GetToken();
							if (Token.value == "(") {
								GetToken();
								ConsumeParam(PFname);
								if (Token.value == ")") {
									//gettoken
									GetToken();
								}
								else {
									cout << "Terrible Cowboys in FR" << endl;
									exit(0);
								}
							}
							else {
								cout << "Terrible Cowboys in FR" << endl;
								exit(0);
							}
							DumbDatatypeStack.push(DataType);
						}
						else if (ProcFuncVar == 0) {

							RegistarArr[CurrentReg].RegLiteral = false;
							RegistarArr[CurrentReg].RegValue = NULL;
							//mov into ebp+offset
							AssInstrucStack.push("		mov " + RegistarArr[CurrentReg].RegName + " , " + "[ebp + " + to_string(tmpOffset) + "]");

							CurrentReg++;
						}
					}
				}
				else if (ArrayNum == 1) { // one d array
					Goddamnarray = true;
					GetToken();
					if (Token.value == "[") {
						GetToken();
						E();
						//ass code here
						if (Token.value == "]") {
							StupidSymTab.GetArrayInfo(PFname, tmpSI1, tmpEI1, tmpSI2, tmpEI2);					
							string tmpAssmInstruc1 = AssInstrucStack.top();
							out << tmpAssmInstruc1 << endl;
							AssInstrucStack.pop();
							out << "		sub " + RegistarArr[CurrentReg - 1].RegName + "," + to_string(tmpSI1) << endl;
							if (DataType == "integer") {
								out << "		imul " + RegistarArr[CurrentReg - 1].RegName + "," + to_string(4) << endl;
							}
							else if (DataType == "char" || DataType == "boolean") {

								out << "		imul " + RegistarArr[CurrentReg - 1].RegName + "," + to_string(1) << endl;
							}
							//out << "		add " + RegistarArr[CurrentReg - 1].RegName + "," + to_string(tmpOffset) << endl;

							out << "		mov " + RegistarArr[CurrentReg - 1].RegName + ", [ebp + " + RegistarArr[CurrentReg - 1].RegName + "]" << endl;
							AssInstrucStack.push("	");
						}
						else {
							cout << "FRArray 1" << endl;
							exit(0);
						}
					}
					else {
						cout << "FRArray 2" << endl;
						exit(0);
					}
				}
				else if (ArrayNum == 2) { // two d array
					Goddamnarray = true;
					GetToken();
					if (Token.value == "[") {
						GetToken();
						E();
						if (Token.value == ",") {
							GetToken();
							E();
						}
						if (Token.value == "]") {
							StupidSymTab.GetArrayInfo(PFname, tmpSI1, tmpEI1, tmpSI2, tmpEI2);;
							//ass code here
							string tmpAssmInstruc1 = AssInstrucStack.top();
							AssInstrucStack.pop();
							string tmpAssmInstruc2 = AssInstrucStack.top();
							AssInstrucStack.pop();
							out << tmpAssmInstruc2 << endl;
							out << tmpAssmInstruc1 << endl;


							out << "		sub " + RegistarArr[CurrentReg - 2].RegName + ", " + to_string(tmpSI1) << endl;

							if (DataType == "integer") {
								out << "		imul " + RegistarArr[CurrentReg - 2].RegName + ", " + to_string(((tmpEI2 - tmpSI2) + 1) * 4) << endl;
							}
							else if (DataType == "char" || DataType == "boolean") {

								out << "		imul " + RegistarArr[CurrentReg - 2].RegName + ", " + to_string(((tmpEI2 - tmpSI2) + 1) * 1) << endl;
							}

							out << "		sub " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(tmpSI2) << endl;

							if (DataType == "integer") {
								out << "		imul " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(4) << endl;
							}
							else if (DataType == "char" || DataType == "boolean") {

								out << "		imul " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(1) << endl;
							}

							out << "		add " + RegistarArr[CurrentReg - 2].RegName + ", " + RegistarArr[CurrentReg - 1].RegName << endl;
							CurrentReg--;

							out << "		add " + RegistarArr[CurrentReg - 1].RegName + ", " + to_string(tmpOffset) << endl;
							out << "		mov " + RegistarArr[CurrentReg - 1].RegName + ", [epb + " + RegistarArr[CurrentReg - 1].RegName + "]" << endl;
						}
						else {
							cout << "FRArray 3" << endl;
							exit(0);
						}
					}
					else {
						cout << "FRArray 4" << endl;
						exit(0);
					}
				}
			}
			else {
				cout << "FRStackerror 1" << endl;
				exit(0);
			}
			GetToken();
		}
		else if (Token.value == "(") {
			//gettoken
			GetToken();
			E();
			if (Token.value == ")") {
				//gettoken
				GetToken();
			}
			else {
				cout << "Terrible Cowboys" << endl;
				exit(0);
			}
		}
		else if (Token.value == "+") {
			//gettoken
			GetToken();
			TR();
		}
		else if (Token.value == "-") {
			//gettoken
			GetToken();
			TR();
		}
		else {
			cout << "Stupid Cowboys" << endl;
			exit(0);
		}
	}

	void ConsumeParam(string name) {
		//get total paramters from symbol table
		int TotalParam = StupidSymTab.CurrentScope->Table[name].NextScope->ParamOrder.size();
		int CurrentParam = 0;
		int tmpOffset = INT_MIN;
		string Datatype;
		while (CurrentParam < TotalParam) {
			StupidSymTab.GetParamInfo(name, CurrentParam, Datatype, PassbyRef, tmpOffset);
			if (PassbyRef) {
				if (Token.type == "Word") {
					string fucking;//Datatype
					int penis_in, vagina;//PFV, Offset......sorry scott lol
					bool AndButt;//IsGlobal
					if (StupidSymTab.FindVariable(Token.value, fucking, penis_in, vagina, AndButt, ArrayNum)){
						if (Datatype == fucking) {
							string ParamAssIntruc = "		mov " + RegistarArr[CurrentReg].RegName +", " + to_string(vagina) + "\n" + "		add " + RegistarArr[CurrentReg].RegName + ", ebp" + "\n" + "		push " + RegistarArr[CurrentReg].RegName;
							ParamintheAssInstrucStack.push(ParamAssIntruc);
							CurrentReg--;
							GetToken();
						}
						else {
							cout << "ComsumeParam 1" << endl;
								exit(0);
						}
					}
					else {
						cout << "ComsumeParam 2" << endl;
							exit(0);
					}
					
				}
				else {
					cout << "ComsumeParam 2" << endl;
					exit(0);
				}
			}
			else {
				E();
				if (Datatype != DumbDatatypeStack.top()) {
					cout << "ComsumeParam 3" << endl;
					exit(0);
				}
				ParamintheAssInstrucStack.push(AssInstrucStack.top() + "\n" + "		push " + RegistarArr[--CurrentReg].RegName);
				AssInstrucStack.pop();
			}
			CurrentParam++;
			if (CurrentParam < TotalParam) {
				if (Token.value == ",") {
					GetToken();
				}
				else {
					cout << "ComsumeParam 4" << endl;
					exit(0);
				}
			}			
		}
		for (int i = 0; i < TotalParam; i++) {
			out << ParamintheAssInstrucStack.top() << endl;
			ParamintheAssInstrucStack.pop();
		}
		out << endl;
		out << "		call " << name << endl;
	}
	
	void PFV() {
		if (Token.type == "PFVWord") {
			if (Token.value == "var") {
				GetToken();
				if (Token.type == "Word") {
					VapidParamVarVector.push_back(Token.value);
					//(1) Store word in parsers Vector
					GetToken();
					VARLIST();
					if (Token.value == ":") {
						GetToken();						
						DATATYPE();
						int counter = 0;
						while (VapidParamVarVector.size() != counter) {
							//(2) Take the words from the Vector and add them to the symbol table.
							//(AddVariable)
							if (!isArray) {
								if (!StupidSymTab.AddVariable(VapidParamVarVector[counter], DataTypeName, DataTypeSize)) {
									cout << "Error PFVVector 1" << endl;
								}
							}
							else {
								if (!StupidSymTab.AddArray(VapidParamVarVector[counter], DataTypeName, DataTypeSize, ArrayNum, tmpSI1, tmpEI1, tmpSI2, tmpEI2)) {
									cout << "Error PFVVector 2" << endl;
								}
							}
							isArray = false;
							counter++;
						}
						//Clear the vector.
						VapidParamVarVector.clear();
						if (Token.value == ";") {
							GetToken();
							MVAR();
							PFV();
						}
						else {
							cout << "PFVvar 1" << endl;
							exit(0);
						}
					}
					else {
						cout << "PFVvar 2" << endl;
						exit(0);
					}
				}
				else {
					cout << "PFVvar 3" << endl;
					exit(0);
				}
			}
			else if (Token.value == "procedure") {
				GetToken();
				if (Token.type == "Word") {
					//(3) Add Procedure or Function to symbol table.
					string tempProcLabel = Token.value;
					if (!StupidSymTab.AddProcFunc(Token.value, "proc")) {
						cout << "PFVProc error 1" << endl;
						exit(0);
					}
					out << tempProcLabel <<":"<<endl;
					GetToken();
					if (Token.value == "(") {
						GetToken();
						PARAM();
						if (Token.value == ")") {
							GetToken();
							if (Token.value == ";") {
								GetToken();
								block();
								if (Token.value == ";") {
									GetToken();
									//(6) Back out of Scope in symbol table.
									StupidSymTab.BackOut();
									PFV();
								}
								else {
									cout << "procedure 1" << endl;
									exit(0);
								}
							}
							else {
								cout << "procedure 2" << endl;
								exit(0);
							}

						}
						else {
							cout << "procedure 3" << endl;
							exit(0);
						}
					}
					else {
						cout << "procedure 4" << endl;
						exit(0);
					}
				}
				else {
					cout << "procedure 5" << endl;
					exit(0);
				}
			}
			else if (Token.value == "function") {
				GetToken();
				if (Token.type == "Word") {
					//(3) Add Procedure or Function to symbol table.
					string funcName = Token.value;
					if (!StupidSymTab.AddProcFunc(Token.value, "func")) {
						cout << "PFVProc error 1" << endl;
						exit(0);
					}
					GetToken();
					if (Token.value == "(") {
						GetToken();
						PARAM();
						if (Token.value == ")") {
							GetToken();
							if (Token.value == ":") {
								GetToken();
								DATATYPE();
								//(7) Set return type of Function in symbol table.
								StupidSymTab.CurrentScope->PreviousScope->Table[funcName].type = DataTypeName;
								//StupidSymTab.CurrentScope->Table[funcName].type = DataTypeName;
								if (Token.value == ";") {
									GetToken();
									block();
									if (Token.value == ";") {
										GetToken();
										//(6) Back out of Scope in symbol table.
										StupidSymTab.BackOut();
										PFV();
									}
									else {
										cout << "function 1" << endl;
										exit(0);
									}
								}
								else {
									cout << "function 2" << endl;
									exit(0);
								}
							}
							else {
								cout << "function 3" << endl;
								exit(0);
							}
						}
						else {
							cout << "function 4" << endl;
							exit(0);
						}
					}
					else {
						cout << "function 5" << endl;
						exit(0);
					}
				}
				else {
					cout << "function 6" << endl;
					exit(0);
				}
			}
		}
	}
	void VARLIST() {
		if (Token.value == ",") {
			GetToken();
			if (Token.type == "Word") {
				//(1) Store word in parsers Vector
				VapidParamVarVector.push_back(Token.value);
				GetToken();
				VARLIST();
			}
			else {
				cout << "VARLIST" << endl;
				exit(0);
			}
		}
	}

	int DataTypeSize;
	string DataTypeName;

	void DATATYPE() {
		if (Token.type == "DTWord") {
			DataTypeName = Token.value;
			if (DataTypeName == "integer") {
				ArrayNum = 0;
				DataTypeSize = 4;
			}
			else if (DataTypeName == "char" || DataTypeName == "boolean") {
				ArrayNum = 0;
				DataTypeSize = 1;
			}
			else if (DataTypeName == "array") {
				isArray = true;
				GetToken();
				DIM();
				if (Token.value == "]") {
					GetToken();
					if (Token.value == "of") {
						GetToken();
						SIMDATATYPE();
					}
				}
				else {
					cout << "DATATYPE DIMSUM" << endl;
					exit(0);
				}
			}
			GetToken();
		}
		else {
			cout << "DATATYPE" << endl;
			exit(0);
		}
	}
	void SIMDATATYPE() {
		if (Token.type == "DTWord") {
			DataTypeName = Token.value;
			if (DataTypeName == "integer") {
				if (tmpEI2 < tmpSI2) {
					DataTypeSize = 4 * ((tmpEI1 - tmpSI1) + 1);
				}
				else {
					DataTypeSize = 4 * ((tmpEI1 - tmpSI1) + 1) * ((tmpEI2 - tmpSI2) + 1);
				}

			}
			else if (DataTypeName == "char" || DataTypeName == "boolean") {
				DataTypeSize = (tmpEI1 - tmpSI1) + 1;
			}
		}
		else {
			cout << "SIMPLEDATATYPE" << endl;
			exit(0);
		}
	}
	void MVAR() {
		if (Token.type == "Word") {
			//(1) Store word in parsers Vector
			VapidParamVarVector.push_back(Token.value);
			GetToken();
			VARLIST();
			if (Token.value == ":") {
				GetToken();				
				DATATYPE();
				int counter = 0;
				while (VapidParamVarVector.size() != counter) {
					//(2) Take the words from the Vector and add them to the symbol table.
					//(AddVariable)
					if (!isArray) {
						if (!StupidSymTab.AddVariable(VapidParamVarVector[counter], DataTypeName, DataTypeSize)) {
							cout << "Error PFVVector 1" << endl;
						}
					}
					else {
						if (!StupidSymTab.AddArray(VapidParamVarVector[counter], DataTypeName, DataTypeSize, ArrayNum, tmpSI1, tmpEI1, tmpSI2, tmpEI2)) {
							cout << "Error PFVVector 2" << endl;
						}
					}

					isArray = false;
					counter++;
				}
				//Clear the vector.
				VapidParamVarVector.clear();
				

				if (Token.value == ";") {
					GetToken();
					MVAR();
				}
				else {
					cout << "MVAR 1" << endl;
					exit(0);
				}
			}
			else {
				cout << "MVAR 2" << endl;
				exit(0);
			}
		}
	}
	void PARAM() {
		OVAR();
		if (Token.type == "Word") {
			//(1) Store word in parsers Vector
			VapidParamVarVector.push_back(Token.value);
			GetToken();
			VARLIST();
			if (Token.value == ":") {
				GetToken();
				DATATYPE();
				int counter = 0;
				while (VapidParamVarVector.size() != counter) {
				//(5) Take the words from the Vector and add them to the symbol table.
				//(AddParam) 					
					if (!StupidSymTab.AddParam(VapidParamVarVector[counter], DataTypeName, PassbyRef)) {
						cout << "Error PFVVector 1" << endl;
					}
					counter++;
				}
				//Clear the vector. when done set Passbyref=false
				VapidParamVarVector.clear();
				PassbyRef = false;
				MPARAM();
			}
			else {
				cout << "PARAM 1" << endl;
				exit(0);
			}
		}/*
		else {
			cout << "PARAM 2" << endl;
			exit(0);
		}*/
	}
	void MPARAM() {
		if (Token.value == ";") {
			GetToken();
			OVAR();
			if (Token.type == "Word") {
				//(1) Store word in parsers Vector
				VapidParamVarVector.push_back(Token.value);
				GetToken();
				VARLIST();
				if (Token.value == ":") {
					GetToken();
					DATATYPE();
					int counter = 0;
					while (VapidParamVarVector.size() != counter) {
						//(5) Take the words from the Vector and add them to the symbol table.
						//(AddParam) 					
						if (!StupidSymTab.AddParam(VapidParamVarVector[counter], DataTypeName, PassbyRef)) {
							cout << "Error PFVVector 1" << endl;
						}
						counter++;
					}
					//Clear the vector. when done set Passbyref=false
					VapidParamVarVector.clear();
					PassbyRef = false;
					MPARAM();
				}
				else {
					cout << "PARAM 7" << endl;
					exit(0);
				}
			}
			else {
				cout << "PARAM 8" << endl;
				exit(0);
			}
			
			
		}
	}
	void OVAR() {
		if (Token.value == "var") {
			//(4) Set pass by ref to true.
			PassbyRef = true;
			GetToken();
		}
	}
	void DIM() {
		if (Token.value == "[") {
			GetToken();
			if (Token.type == "integer") {
				tmpSI1 = stoi(Token.value);
				GetToken();
				if (Token.value == "..") {
					GetToken();
					if (Token.type == "integer") {
						tmpEI1 = stoi(Token.value);
						ArrayNum = 1;
						GetToken();
						DIM2();
						if (ArrayNum != 2) {
							tmpSI2 = -1;
							tmpEI2 = -2;
						}
					}
					else {
						cout << "DIMSUM BITCH3!" << endl;
						exit(0);
					}
				}
				else {
					cout << "DIMSUM BITCH1!" << endl;
					exit(0);
				}
				
			}
			else {
				cout << "DIMSUM BITCH2!" << endl;
				exit(0);
			}

		}
	}
	void DIM2() {
		if (Token.value == ",") {
			GetToken();
			if (Token.type == "integer") {
				tmpSI2 = stoi(Token.value);
				GetToken();
				if (Token.value == "..") {
					GetToken();
					if (Token.type == "integer") {
						tmpEI2 = stoi(Token.value);
						ArrayNum = 2;
						GetToken();
					}
				}
				else {
					cout << "DIMSUM2 BITCH1!" << endl;
					exit(0);
				}

			}
			else {
				cout << "DIMSUM2 BITCH2!" << endl;
				exit(0);
			}
		}
	}
};