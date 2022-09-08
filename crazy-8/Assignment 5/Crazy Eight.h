#pragma once
#include "Player.h"

class CrazyEight
{
private:
	CPlayer* Players;
	Card TopCard;
	bool GameOver = false;
	Deck thedeck;
	int NumberOfPlayers;
	int CurrentPlayer = 0;
public:
	CrazyEight()
	{
		cout << "Welcome to Crazy 8" << endl << endl;
		cout << "How Many Players ->";
		cin >> NumberOfPlayers;
		Players = new CPlayer[NumberOfPlayers];
		Players[NumberOfPlayers - 1].IsComputer(true);
		Players[NumberOfPlayers - 1].ShowComputerHands(false);
	}

	~CrazyEight()
	{
		delete[] Players;
	}

	void DealAHand()
	{
		{
			for (int cardtally = 0; cardtally < 5; cardtally++)
			{
				for (int playernum = 0; playernum < NumberOfPlayers; playernum++)
				{
					Players[playernum].DrawACard(thedeck.DealACard());
				}
			}
		}
	}

	void Menu()
	{
		DealAHand();
		TopCard = thedeck.DealACard();
		do
		{
			int playernum;
			for (playernum = 0; playernum < NumberOfPlayers; playernum++)
			{
				
				if (playernum == (NumberOfPlayers - 1))
				{
					if (Players[playernum].Hal9000(TopCard))
					{
						Players[playernum].DrawACard(thedeck.DealACard());
					}


				}
				else
				{
					cout << "Player #" << playernum + 1 << endl;
					if (Players[playernum].PlayACard(TopCard))
					{
						Players[playernum].DrawACard(thedeck.DealACard());
					}
				}	

				if (Players[playernum].HowManyCards() == 0)
				{
					if (playernum == (NumberOfPlayers - 1))
					{
						cout << "Computer Wins" << endl;
					}
					else
					{
						cout << "Player# " << playernum + 1 << " Wins" << endl;
					}
					GameOver = true;
					break;

				}
				
			}
			
		} while (!GameOver);

	}

	
	void Run()
	{
		Menu();
	}
};
