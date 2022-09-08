#pragma once

#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>

using namespace std;

class CToken {
public:
    string value;
    string type;
};

class CLex {

    int** DFA;
    ifstream ReadFile;
    ifstream DFAFile;


public:
    CLex() {

    }

    CLex(string file) {
        ReadFile.open(file);
        DFAFile.open("LexDFA(2).txt");

        DFA = new int* [128];

        for (int row = 0; row < 128; row++) {
            string FileInput;
            DFA[row] = new int[14];

            for (int col = 0; col < 14; col++) {
                DFAFile >> FileInput;
                int dfaState = stoi(FileInput);

                DFA[row][col] = dfaState;
            }
        }
        DFAFile.close();
    }

    ~CLex() {

        delete[] DFA;
        DFA = NULL;
    }

    void SetUpLexor(string file) {
        ReadFile.open(file);
        DFAFile.open("LexDFA(2).txt");

        DFA = new int* [128];

        for (int row = 0; row < 128; row++) {
            string FileInput;
            DFA[row] = new int[14];

            for (int col = 0; col < 14; col++) {
                DFAFile >> FileInput;
                 int dfaState = stoi(FileInput);

                DFA[row][col] = dfaState;
                //cout << DFA[row][col] << endl;
            }
        }
        DFAFile.close();
    }

     bool GetToken(CToken& Token) {

        int CurrState = 0;
        int PrevState = 0;
        char input;
        bool EndOFile;
        Token.type = "";
        Token.value = "";

        while (!ReadFile.eof()) {
            input = ReadFile.get();

            PrevState = CurrState;

            if (input == -1) {
                input = 10;
                break;
            }

            CurrState = DFA[input][CurrState];
            if (CurrState != 0 && CurrState != 55 && CurrState != 99) {
                Token.value += input;
            }
            else if (CurrState == 55 && input != 9 && input != 10 && input != 13 && input != 32) {
                ReadFile.unget();

            }
            if (CurrState == 55) {
                if (PrevState == 1) {
                    Token.type = "Word";
                    string word;
                    word = Token.value;
                    transform(word.begin(), word.end(), word.begin(), ::tolower);
                    if (word == "begin" || word == "end" || word == "if" || word == "else" || word == "then" || word == "while" || word == "do" || word == "and" || word == "or") {
                        Token.type = "RWord";
                        Token.value = word;
                        return true;
                    }
                    else if (word == "var" || word == "procedure" || word == "function") {
                        Token.type = "PFVWord";
                        Token.value = word;
                        return true;
                    }
                    else if (word == "integer" || word == "boolean" || word == "char" || word == "array") {
                        Token.type = "DTWord";
                        Token.value = word;
                        return true;
                    }
                    return true;
                }
                if (PrevState == 2) {
                    Token.type = "integer";
                    return true;
                }
                if (PrevState == 4) {
                    Token.type = "Real";
                    return true;
                }
                if (PrevState == 9) {
                    Token.type = "Real";
                    return true;
                }
                if (PrevState == 10 || PrevState == 11 || PrevState == 12) {
                    Token.type = "Special";
                    return true;
                }
                if (PrevState == 12) {
                    Token.type = ":=";
                    return true;
                }
               
            }
            else if (CurrState == 99) {
                cout << "Output Lex Error" << endl;
                return false;
            }
        }
        //ReadFile.close();

        if (PrevState == 1 || PrevState == 2 || PrevState == 4 || PrevState == 9 || PrevState == 10 || PrevState == 11 || PrevState == 12) {
            if (PrevState == 1) {
                Token.type = "Word";
                string word;
                word = Token.value;
                transform(word.begin(), word.end(), word.begin(), ::tolower);
                if (word == "begin" || word == "end" || word == "if" || word == "else" || word == "then" || word == "while" || word == "do" || word == "and" || word == "or") {
                    Token.type = "RWord";
                    Token.value = word;
                    return true;
                }
                else if (word == "var" || word == "procedure" || word == "function") {
                    Token.type = "PFVWord";
                    Token.value = word;
                    return true;
                }
                else if (word == "integer" || word == "boolean" || word == "char" || word =="array") {
                    Token.type = "DTWord";
                    Token.value = word;
                    return true;
                }
                return true;
            }
            if (PrevState == 2) {
                Token.type = "integer";
                return true;
            }
            if (PrevState == 4) {
                Token.type = "Real";
                return true;
            }
            if (PrevState == 9) {
                Token.type = "Real";
                return true;
            }
            if (PrevState == 10 || PrevState == 11 || PrevState == 12) {
                Token.type = "Special";
                return true;
                
            }
            if (PrevState == 12) {
                Token.type = ":=";
                return true;
            }
           
        }
        else {
            return false;
        }


        return true;
    }

};


