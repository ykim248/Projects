#pragma once

#include <iostream>

using namespace std;

enum TSuit { Hearts, Diamonds, Spades, Clubs };
class Card
{
	friend ostream& operator <<(ostream& ls, Card rs);
private:
	int value;
	TSuit suit;
public:
	Card()
	{
		value = 1;
		suit = Hearts;
	}

	Card(int Newvalue, TSuit Newsuit)
	{
		value = Newvalue;
		suit = Newsuit;
	}

	int GetValue()
	{
		return value;
	}

	TSuit GetSuit()
	{
		return suit;
	}

	bool Crazy()
	{
		return (value == 8);
	}

	void SetCard(int Newvalue, TSuit Newsuit)
	{
		value = Newvalue;
		suit = Newsuit;
	}

	void SetSuit(TSuit Suit)
	{
		suit = Suit;		
	}
};

ostream& operator <<(ostream& ls, Card rs)
{
	if (rs.value == 1)
		ls << "Ace";
	else if (rs.value <= 10)
		ls << rs.value;
	else if (rs.value == 11)
		ls << "Jack";
	else if (rs.value == 12)
		ls << "Queen";
	else
		ls << "King";
	ls << " of";
	switch (rs.suit)
	{
	case Hearts:ls << " Hearts";
		break;
	case Diamonds:ls << " Diamonds";
		break;
	case Spades:ls << " Spades";
		break;
	case Clubs:ls << " Clubs";
		break;

	}


	return ls;
}