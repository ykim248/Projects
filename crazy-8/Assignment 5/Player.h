#pragma once

#include "Deck.h"

class CPlayer
{
private:

	int NumberOfCards;
	Card Hand[26];
	int CardSelected;
	bool Computer;
	bool ShowWholeHands;
	
public:
	CPlayer()
	{
		NumberOfCards = 0;
		Computer = false;
	}

	void IsComputer(bool NPC)
	{
		Computer = NPC;
	}

	void ShowComputerHands(bool NewShowHands)
	{
		ShowWholeHands = NewShowHands;
	}


	void DrawACard(Card NewCard)
	{
		Hand[NumberOfCards++] = NewCard;
	}

	void ShowHand()
	{
		int i;
		for (i = 0; i < NumberOfCards; i++)
		{
			cout << "   " << (i + 1) << ") " << Hand[i] << endl;
		}
		cout << "   " << (i+1) << ") Draw a Card" << endl;
	}
	
	int HowManyCards()
	{
		return NumberOfCards;
	}

	bool PlayACard(Card& TopCard)
	{		
		int Pick;
		bool HandleChoice = true;		

		do
		{
			do
			{
				if (HandleChoice)
				{
					cout << "The Top Card is:" << endl;
					cout << TopCard << endl;
					ShowHand();

					cout << "Choice -> ";
					cin >> Pick;
					cout << endl;
					HandleChoice = false;

				}
				else
				{
					cout << "Wrong Choice" << endl << endl;
					HandleChoice = true;
				}

			} while (!(Pick >= 1 && Pick <= NumberOfCards + 1));
		} while (Pick != NumberOfCards + 1 && TopCard.GetValue() != Hand[Pick - 1].GetValue() && TopCard.GetSuit() != Hand[Pick - 1].GetSuit() && Hand[Pick - 1].GetValue() != 8);
					
		
		if (Pick == NumberOfCards + 1)
		{
			return true;
		}
		
		TopCard = Hand[Pick - 1];

		if (Hand[Pick - 1].GetValue() == 8)
		{
			int Choice;
			cout << "What is the new suit?" << endl;
			cout << "   1) Hearts" << endl;
			cout << "   2) Diamonds" << endl;
			cout << "   3) Spades" << endl;
			cout << "   4) Clubs" << endl;

			cout << "Choice -> ";
			cin >> Choice;


			switch (Choice)
			{
			case 1:
				TopCard.SetSuit(Hearts);
				break;
			case 2:
				TopCard.SetSuit(Diamonds);
				break;
			case 3:
				TopCard.SetSuit(Spades);
				break;
			case 4:
				TopCard.SetSuit(Clubs);
				break;

			}
		}
		
		Hand[Pick - 1] = Hand[NumberOfCards - 1];
		NumberOfCards--;

		

		return false;
	}
	
	bool Hal9000(Card& TopCard)
	{
		bool CardNotPlayed = true;
		if (Computer)
		{
			cout << "The Top Card is:" << endl;
			cout << TopCard << endl;
			for (int CardInHand = 0; CardInHand < NumberOfCards; CardInHand++)
			{
				
				if (TopCard.GetValue() == Hand[CardInHand].GetValue() || TopCard.GetSuit() == Hand[CardInHand].GetSuit() || Hand[CardInHand].GetValue() == 8)
				{										
					cout << "The Computer played " << Hand[CardInHand] << endl;
					cout << endl;

					TopCard = Hand[CardInHand];

					if (Hand[CardInHand].GetValue() == 8)
					{
						srand(time(NULL));
						int randNum = (rand() % 4) + 1;

						switch (randNum)
						{
						case 1:
							TopCard.SetSuit(Hearts);
							cout << "The Computer chose Hearts" << endl;
							break;
						case 2:
							TopCard.SetSuit(Diamonds);
							cout << "The Computer chose Diamonds" << endl;
							break;
						case 3:
							TopCard.SetSuit(Spades);
							cout << "The Computer chose Spades" << endl;
							break;
						case 4:
							TopCard.SetSuit(Clubs);
							cout << "The Computer chose Clubs" << endl;
							break;
						}
					}

					Hand[CardInHand] = Hand[NumberOfCards - 1];
					NumberOfCards--;
					CardNotPlayed = false;

					break;
				}	
				
			}
			if (CardNotPlayed)
			{
				cout << "The Computer drew a Card" << endl;
				return true;
			}
			



			return false;
		}
	}
};