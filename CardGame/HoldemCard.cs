﻿using System;

namespace CardGame
{
	/**
  * Card.java
  *
  * <code>Card</code> represents a playing card.
   ************************************************************************
  * This is the original AP Elevens Lab Java program code.
  * 03-29-15 slightly altered by Leon Schram 
  * who likes curly braces aligned.
  *
  * DO NOT ALTER THIS CLASS FOR LAB16!!!!!
  */
	public class HoldemCard
	{

		/**
		 * String value that holds the suit of the card
		 */
		private String suit;

        /**
		 * String value that holds the rank of the card
		*/
		private String rank;

		/**
		 * int value that holds the point value.
		 */
        private int pointValue;


		/**
		  * Creates a new <code>Card</code> instance.
		  *
		  * @param cardRank  a <code>String</code> value
		  *                  containing the rank of the card
		  * @param cardSuit  a <code>String</code> value
		  *                  containing the suit of the card
		  * @param cardPointValue an <code>int</code> value
		  *                  containing the point value of the card
		  */
		public HoldemCard(String cardRank, String cardSuit, int cardPointValue)
		{
			//initializes a new Card with the given rank, suit, and point value
			rank = cardRank;
			suit = cardSuit;
			pointValue = cardPointValue;
		}


		/**
		 * Accesses this <code>Card's</code> suit.
		 * @return this <code>Card's</code> suit.
		 */
		public String getSuit()
		{
			return suit;
		}

		/**
		 * Accesses this <code>Card's</code> rank.
		 * @return this <code>Card's</code> rank.
		 */
		public String getRank()
		{
			return rank;
		}

		public String getName()
		{
			return getRank() + getSuit();
		}
		/**
		  * Accesses this <code>Card's</code> point value.
		  * @return this <code>Card's</code> point value.
		  */
		public int getPointValue()
		{
			return pointValue;
		}

		/** Compare this card with the argument.
		 * @param otherCard the other card to compare to this
		 * @return true if the rank, suit, and point value of this card
		 *              are equal to those of the argument;
		 *         false otherwise.
		 */
		public bool matches(HoldemCard otherCard)
		{
			return otherCard.getSuit().Equals(this.getSuit())
				&& otherCard.getRank().Equals(this.getRank())
				&& otherCard.getPointValue() == this.getPointValue();
		}

		/**
		 * Converts the rank, suit, and point value into a string in the format
		 *     "[Rank] of [Suit] (point value = [PointValue])".
		 * This provides a useful way of printing the contents
		 * of a <code>Deck</code> in an easily readable format or performing
		 * other similar functions.
		 *
		 * @return a <code>String</code> containing the rank, suit,
		 *         and point value of the card.
		 */

		//@Overide
		public String toString()
		{
			return rank + " of " + suit + " (point value = " + pointValue + ")";
		}

	}

}
