#include <iostream>
#include "Clexor.h"
#include "Parser.h"

using namespace std;

int main() {

	CLex Lex;
	CToken Token;
	
	/*Lex.SetUpLexor("code2.txt");

	if (Lex.GetToken(Token)) {
		cout << Token.value + " " << endl;
		cout << Token.type + " " << endl;
	}
	if (Lex.GetToken(Token)) {
		cout << Token.value + " " << endl;
		cout << Token.type + " " << endl;
	}
	if (Lex.GetToken(Token)) {
		cout << Token.value + " " << endl;
		cout << Token.type + " " << endl;
	}
	if (Lex.GetToken(Token)) {
		cout << Token.value + " " << endl;
		cout << Token.type + " " << endl;
	}
	if (Lex.GetToken(Token)) {
		cout << Token.value + " " << endl;
		cout << Token.type + " " << endl;
	}*/

	PatheticParser StupidParser;
 	StupidParser.StupidParser("code2.txt");


	return 0;
  }

