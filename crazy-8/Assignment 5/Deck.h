#pragma once

#include "Card.h"
#include <time.h>

class Deck
{
private:
	Card TheCards[52];
	int TopCard = 0;

public:

	Deck()
	{
		srand(time(NULL));
		int index = 0;
		for (int x = Hearts; x <= Clubs; x = x + 1)
		{
			for (int y = 1; y <= 13; y++)
			{
				TheCards[index].SetCard(y, TSuit(x));
				index++;
			}
		}
		Shuffle();
	}
	void Shuffle()
	{
		for (int x = 0; x < 52000; x++)
		{
			int swaploc = rand() % 52;
			int swaploc2 = rand() % 52;
			Card tempCard;

			tempCard = TheCards[swaploc];
			TheCards[swaploc] = TheCards[swaploc2];
			TheCards[swaploc2] = tempCard;

		}
	}

	Card DealACard()
	{
		return TheCards[TopCard++];
	}

	int ReturnTopCard()
	{
		return TopCard;
	}
};
