using System;
using System.Collections;

namespace CardGame
{
    public class HoldemDeck
    {

        /**
         * cards contains all the cards in the deck.
         */
        private ArrayList cards;

        /**
         * size is the number of not-yet-dealt cards.
         * Cards are dealt from the top (highest index) down.
         * The next card to be dealt is at size - 1.
         */
        private int deckSize;


        /**
         * Creates a new <code>Deck</code> instance.<BR>
         * It pairs each element of ranks with each element of suits,
         * and produces one of the corresponding card.
         * @param ranks is an array containing all of the card ranks.
         * @param suits is an array containing all of the card suits.
         * @param values is an array containing all of the card point values.
         */
        public HoldemDeck(String[] ranks, String[] suits, int[] values)
        {
            cards = new ArrayList();

            foreach (String suitString in suits)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    cards.Add(new HoldemCard(ranks[j], suitString, values[j]));
                }
            }

            cards.Add(new HoldemCard("", "JO", 0));
            deckSize = cards.Count;
            shuffle();
        }


        /**
         * Determines if this deck is empty (no undealt cards).
         * @return true if this deck is empty, false otherwise.
         */
        public bool isEmpty()
        {
            return deckSize == 0;
        }

        /**
         * Accesses the number of undealt cards in this deck.
         * @return the number of undealt cards in this deck.
         */
        public int size()
        {
            return deckSize;
        }

        /**
         * Randomly permute the given collection of cards
         * and reset the size to represent the entire deck.
         */
        public void shuffle()
        {
            Random random = new Random();
            for (int k = cards.Count - 1; k > 0; k--)
            {
                int howMany = k + 1;
                int start = 0;
                int randPos = (int)(random.NextDouble() * howMany) + start;
                HoldemCard temp = (HoldemCard)cards[k];
                cards[k] = cards[randPos];
                cards[randPos] = temp;
            }
            deckSize = cards.Count;
        }

        /**
         * Deals a card from this deck.
         * @return the card just dealt, or null if all the cards have been
         *         previously dealt.
         */
        public HoldemCard deal()
        {
            if (isEmpty())
            {
                return null;
            }
            deckSize--;
            HoldemCard c = (HoldemCard)cards[deckSize];
            return c;
        }

        /**
         * Generates and returns a string representation of this deck.
         * @return a string representation of this deck.
         */
        //@Override
        public String toString()
        {
            String rtn = "size = " + deckSize + "\nUndealt cards: \n";

            for (int k = deckSize - 1; k >= 0; k--)
            {
                rtn = rtn + cards[k];
                if (k != 0)
                {
                    rtn = rtn + ", ";
                }
                if ((deckSize - k) % 2 == 0)
                {
                    // Insert carriage returns so entire deck is visible on console.
                    rtn = rtn + "\n";
                }
            }

            rtn = rtn + "\nDealt cards: \n";
            for (int k = cards.Count - 1; k >= deckSize; k--)
            {
                rtn = rtn + cards[k];
                if (k != deckSize)
                {
                    rtn = rtn + ", ";
                }
                if ((k - cards.Count) % 2 == 0)
                {
                    // Insert carriage returns so entire deck is visible on console.
                    rtn = rtn + "\n";
                }
            }

            rtn = rtn + "\n";
            return rtn;
        }
    }
}
