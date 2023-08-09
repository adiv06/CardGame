using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    /**
 * The ElevensBoard class represents the board in a game of Elevens.
  ************************************************************************
 * This is the original AP Elevens Lab Java program code.
 * 03-26-15 slightly altered by Leon Schram 
 * who likes curly braces aligned.
 *************************************************************************
 * This is the only file that students alter for Lab16.
 * This is the student, starting file of Lab16.
 */
    public class HoldemCardBoard
    {

        /**
         * The size (number of cards) in the deck.
         */
        public const int BOARD_SIZE = 53;

        /**
         * The ranks of the cards for this game to be sent to the deck.
         */
        public static readonly String[] RANKS =
        {"2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"};

        /**
         * The suits of the cards for this game to be sent to the deck.
         */
        public static readonly String[] SUITS =
            {"spades", "hearts", "diamonds", "clubs"};

        /**
         * The values of the cards for this game to be sent to the deck.
         */
        private static readonly int[] POINT_VALUES =
            {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};


        /**
         * The cards on this board.
         */
        private HoldemCard[] cards;

        /**
         * The deck of cards being used to play the current game.
         */
        private HoldemDeck deck;

        /**
         * Flag used to control debugging print statements.
         */
        private const bool I_AM_DEBUGGING = false;

        private HoldemCard[] allCards;

        private HoldemCard[] playerHand = Holdem.playerHand;

        private HoldemCard[] computerHand = Holdem.computerHand;

        public static List<HoldemCard> playerValCheckCards = new List<HoldemCard>();

        public static List<HoldemCard> computerValCheckCards = new List<HoldemCard>();

        /**
         * Creates a new <code>ElevensBoard</code> instance.
         */
        public HoldemCardBoard()
        {
            cards = new HoldemCard[BOARD_SIZE];
            deck = new HoldemDeck(RANKS, SUITS, POINT_VALUES);
            if (I_AM_DEBUGGING)
            {
                Console.WriteLine(deck);
                Console.WriteLine("----------");
            }
            dealMyCards();
        }

        public HoldemCard[] getCards()
        {
            return cards;
        }
        /**
         * Start a new game by shuffling the deck and
         * dealing some cards to this board.
         */
        public void newGame()
        {
            deck.shuffle();
            dealMyCards();
        }

        /**
         * Accesses the size of the board.
         * Note that this is not the number of cards it contains,
         * which will be smaller near the end of a winning game.
         * @return the size of the board
         */
        public int size()
        {
            return cards.Length;
        }

        /**
         * Determines if the board is empty (has no cards).
         * @return true if this board is empty; false otherwise.
         */
        public bool isEmpty()
        {
            for (int k = 0; k < cards.Length; k++)
            {
                if (cards[k] != null)
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Deal a card to the kth position in this board.
         * If the deck is empty, the kth card is set to null.
         * @param k the index of the card to be dealt.
         */
        public void deal(int k)
        {
            cards[k] = deck.deal();
        }

        /**
         * Accesses the deck's size.
         * @return the number of undealt cards left in the deck.
         */
        public int deckSize()
        {
            return deck.size();
        }

        /**
         * Accesses a card on the board.
         * @return the card at position k on the board.
         * @param k is the board position of the card to return.
         */
        public HoldemCard cardAt(int k)
        {
            return cards[k];
        }

        /**
         * Replaces selected cards on the board by dealing new cards.
         * @param selectedCards is a list of the indices of the
         *        cards to be replaced.
         */
        public void replaceSelectedCards(List<int> selectedCards)
        {
            foreach (int k in selectedCards)
            {
                deal(k);
            }
        }

        /**
         * Gets the indexes of the actual (non-null) cards on the board.
         *
         * @return a List that contains the locations (indexes)
         *         of the non-null entries on the board.
         */
        public List<int> cardIndexes(HoldemCard[] cards)
        {
            List<int> selected = new List<int>();
            for (int k = 0; k < cards.Length; k++)
            {
                if (cards[k] != null)
                {
                    selected.Add(k);
                }
            }
            return selected;
        }

        /**
         * Generates and returns a string representation of this board.
         * @return the string version of this board.
         */
        public String toString()
        {
            String s = "";
            for (int k = 0; k < cards.Length; k++)
            {
                s = s + k + ": " + cards[k] + "\n";
            }
            return s;
        }

        /**
         * Determine whether or not the game has been won,
         * i.e. neither the board nor the deck has any more cards.
         * @return true when the current game has been won;
         *         false otherwise.
         */
        public bool gameIsWon()
        {
            if (deck.isEmpty())
            {
                foreach (HoldemCard c in cards)
                {
                    if (c != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /**
          * Deal cards to this board to start the game.
          */
        private void dealMyCards()
        {
            for (int k = 0; k < cards.Length; k++)
            {
                cards[k] = deck.deal();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////// DO NOT CHANGE ANY METHODS ABOVE THIS LINE.
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /////  ONLY ALTER THE METHODS BELOW THIS LINE.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void allCardsUpdate()
        {
            int c = 0;
            List<HoldemCard> cards = new List<HoldemCard>();
            for (int i = 0; i < Holdem.boardCards.Count; i++)
            {
                cards.Add(Holdem.boardCards[i]);
                c = i;
            }

            cards.Add(Holdem.playerHand[0]);
            cards.Add(Holdem.playerHand[1]);
            allCards = cards.ToArray();

        }

        /**
         * Determines if the selected cards form a valid group for removal.
         * In Elevens, the legal groups are (1) a pair of non-face cards
         * whose values add to 11, and (2) a group of three cards consisting of
         * a jack, a queen, and a king in some order.
         * @param selectedCards the list of the indices of the selected cards.
         * @return true if the selected cards form a valid group for removal;
         *         false otherwise.
         */
        public bool isLegal(List<int> selectedCards)
        {
            /* *** TO BE IMPLEMENTED IN LAB16 *** */
            if (selectedCards.Count == 2)
            {
                return containsPairSum11(selectedCards, cards);
            }
            else if (selectedCards.Count == 3)
            {
                return containsJQK(selectedCards, cards);
            }
            return false;
        }

        /**
         * Determine if there are any legal plays left on the board.
         * In Elevens, there is a legal play if the board contains
         * (1) a pair of non-face cards whose values add to 11, or (2) a group
         * of three cards consisting of a jack, a queen, and a king in some order.
         * @return true if there is a legal play left on the board;
         *         false otherwise.
         */
        public bool anotherPlayIsPossible(HoldemCard[] cards)
        {
            /* *** TO BE IMPLEMENTED IN LAB16 *** */
            List<int> selectedCards = cardIndexes(cards);

            return containsPairSum11(selectedCards, cards) || containsJQK(selectedCards, cards);
        }

        /**
          * Check for an 11-pair in the selected cards.
          * @param selectedCards selects a subset of this board.  It is list
          *                      of indexes into this board that are searched
          *                      to find an 11-pair.
          * @return true if the board entries in sedClecteards
          *              contain an 11-pair; false otherwise.
          */
        public bool containsPairSum11(List<int> selectedCards, HoldemCard[] cardsList)
        {
            /* *** TO BE IMPLEMENTED IN LAB16 *** */
            for (int i = 0; i < selectedCards.Count; i++)
            {
                for (int j = 0; j < selectedCards.Count; j++)
                {
                    if (cardsList[selectedCards[i]].getPointValue() + cardsList[selectedCards[j]].getPointValue() == 11)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /**
         * Check for a JQK in the selected cards.
         * @param selectedCards selects a subset of this board.  It is list
         *                      of indexes into this board that are searched
         *                      to find a JQK group.
         * @return true if the board entries in selectedCards
         *              include a jack, a queen, and a king; false otherwise.
         */
        public bool containsJQK(List<int> selectedCards, HoldemCard[] cards)
        {
            bool jcheck = false, qcheck = false, kcheck = false;
            /* *** TO BE IMPLEMENTED IN LAB16 *** */
            foreach (int index in selectedCards)
            {
                if (cards[index].getRank() == "jack")
                {
                    jcheck = true;
                }
                if (cards[index].getRank() == "queen")
                {
                    qcheck = true;
                }
                if (cards[index].getRank() == "king")
                {
                    kcheck = true;
                }
            }
            if (kcheck && qcheck && jcheck)
            {
                return true;
            }
            else return false;

        }

        public void printArray(List<HoldemCard> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].getRank());
            }
        }
        public HoldemCard[] ascendingOrder(List<HoldemCard> cardList)
        {
            for (int j = 0; j < cardList.Count; j++)
            {
                for (int i = 0; i < cardList.Count - 1; i++)
                {
                    if (cardList[i].getPointValue() > cardList[i + 1].getPointValue())
                    {
                        HoldemCard card = cardList[i];
                        cardList.RemoveAt(i);
                        cardList.Insert(i + 1, card);
                        i--;
                    }
                }
            }

            return cardList.ToArray();
        }

        public int valueOfHand(List<HoldemCard> boardCards, bool playerCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();

            allCards = boardCards.ToArray();
            allCards = ascendingOrder(allCards.ToList());

            if (royalFlush(allCards, playerHand, playerCards))
            {
                return 10;
            }
            else if (straightFlush(allCards, playerHand, playerCards))
            {
                return 9;
            }
            else if (pair(allCards, 4, playerCards))
            {
                return 8;
            }
            else if (fullHouse(allCards, playerCards))
            {
                return 7;
            }
            else if (flush(allCards, playerCards))
            {
                return 6;
            }
            else if (sequence(allCards, playerHand, playerCards))
            {
                return 5;
            }
            else if (pair(allCards, 3, playerCards))
            {
                return 4;
            }
            else if (twoPair(allCards, playerCards))
            {
                return 3;
            }
            else if (pair(allCards, 2, playerCards))
            {
                return 2;
            }

            printArray(allCards.ToList());


            return 0;
        }


        public bool flush(HoldemCard[] cardArray, bool pCards)
        {

            List<HoldemCard> temp = new List<HoldemCard>();

            if (cardArray.Where(s => s != null && (s.getSuit().Equals("clubs"))).Count() >= 5)
            {
                foreach(HoldemCard card in cardArray)
                {
                    if(card.getSuit().Equals("clubs"))
                    {
                        temp.Add(card);
                    }
                }
            }
            else if (cardArray.Where(s => s != null && (s.getSuit().Equals("hearts"))).Count() >= 5)
            {
                foreach (HoldemCard card in cardArray)
                {
                    if (card.getSuit().Equals("hearts"))
                    {
                        temp.Add(card);
                    }
                }
            }
            else if (cardArray.Where(s => s != null && (s.getSuit().Equals("spades"))).Count() >= 5)
            {
                foreach (HoldemCard card in cardArray)
                {
                    if (card.getSuit().Equals("spades"))
                    {
                        temp.Add(card);
                    }
                }
            }
            else if (cardArray.Where(s => s != null && (s.getSuit().Equals("diamonds"))).Count() >= 5)
            {
                foreach (HoldemCard card in cardArray)
                {
                    if (card.getSuit().Equals("diamonds"))
                    {
                        temp.Add(card);
                    }
                }
            }


            if (temp.Count() >= 5)
            {
                if (pCards)
                {
                    playerValCheckCards = temp;
                }
                else
                {
                    computerValCheckCards = temp;
                }
                return true;
            }

            return false;

        }

        public bool fullHouse(HoldemCard[] cardArray, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            bool pair = false;
            bool three = false;
            int count = 0;
            HoldemCard temp1 = new HoldemCard("", "JO", 0);
            HoldemCard temp2 = new HoldemCard("", "JO", 0);

            List<HoldemCard> counter = new List<HoldemCard>();

            for (int i = 0; i < cardArray.Count(); i++)
            {
                count += countOccurencesInBoard(cardArray, cardArray[i], pCards);

                if (count == 3)
                {
                    if (countOccurencesInBoard(counter.ToArray(), cardArray[i], pCards) == 0)
                    {
                        three = true;
                        counter.Add(cardArray[i]);
                        temp1 = cardArray[i];
                    }
                }
                else if (count == 2)
                {
                    if (countOccurencesInBoard(counter.ToArray(), cardArray[i], pCards) == 0)
                    {
                        pair = true;
                        counter.Add(cardArray[i]);
                        temp2 = cardArray[i];
                    }
                }
                else
                {
                    count = 0;
                }
            }

            if (counter.Count >= 2 && pair && three)
            {
                if (pCards)
                {
                    playerValCheckCards.Add(temp1);
                    playerValCheckCards.Add(temp1);
                    playerValCheckCards.Add(temp1);
                    playerValCheckCards.Add(temp2);
                    playerValCheckCards.Add(temp2);
                }
                else
                {
                    computerValCheckCards.Add(temp1);
                    computerValCheckCards.Add(temp1);
                    computerValCheckCards.Add(temp1);
                    computerValCheckCards.Add(temp2);
                    computerValCheckCards.Add(temp2);
                }
                return true;
            }
            return false;
        }
        public bool sequence(HoldemCard[] cardArray, HoldemCard[] hand, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            bool sequence = false;
            List<HoldemCard> sequenceCards = new List<HoldemCard>();
            cardArray = ascendingOrder(cardArray.ToList());
            //Console.WriteLine("Checking Sequence: " + "\n");
            //printArrray(cardArray.ToList());

            for (int i = 0; i < cardArray.Length - 1; i++)
            {
                if (cardArray[i].getPointValue() + 1 == cardArray[i + 1].getPointValue())
                {
                    sequenceCards.Add(cardArray[i]);

                    if (pCards)
                    {
                        playerValCheckCards.Add(cardArray[i]);
                    }
                    else
                    {
                        computerValCheckCards.Add(cardArray[i]);
                    }
                }
                else
                {
                    sequenceCards.Clear();

                }
            }

            if (sequenceCards.Count >= 5)
            {
                sequence = true;
            }


            return sequence;

        }

        public bool straightFlush(HoldemCard[] cardArray, HoldemCard[] hand, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            bool sequence = false;
            bool flush = false;
            List<HoldemCard> sequenceCards = new List<HoldemCard>();
            cardArray = ascendingOrder(cardArray.ToList());
            //Console.WriteLine("Checking straight flush: " + "\n");
            //printArrray(cardArray.ToList());

            for (int i = 0; i < cardArray.Length - 1; i++)
            {
                if (cardArray[i].getPointValue() + 1 == cardArray[i + 1].getPointValue())
                {
                    sequenceCards.Add(cardArray[i]);

                    if (pCards)
                    {
                        playerValCheckCards.Add(cardArray[i]);
                    }
                    else
                    {
                        computerValCheckCards.Add(cardArray[i]);
                    }
                }
                else
                {
                    sequenceCards.Clear();
                }
            }

            if (sequenceCards.Count >= 5)
            {
                sequence = true;
            }

            flush = this.flush(sequenceCards.ToArray(), pCards);

            return flush && sequence;

        }

        public bool royalFlush(HoldemCard[] cardArray, HoldemCard[] hand, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            bool sequence = false;
            bool flush = false;
            List<HoldemCard> sequenceCards = new List<HoldemCard>();
            cardArray = ascendingOrder(cardArray.ToList());
            //Console.WriteLine("Checking royal flush: " + "\n");
            //printArrray(cardArray.ToList());

            for (int i = 0; i < cardArray.Length - 1; i++)
            {
                if (cardArray[i].getPointValue() + 1 == cardArray[i + 1].getPointValue())
                {
                    sequenceCards.Add(cardArray[i]);
                }
                else
                {
                    sequenceCards.Clear();
                }
            }

            if (sequenceCards.Count >= 5)
            {
                sequence = true;
            }

            flush = this.flush(sequenceCards.ToArray(), pCards);


            return sequence && flush && checkRoyalflush(cardArray.ToList(), pCards);

        }

        public bool checkRoyalflush(List<HoldemCard> royals, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            int count = 0;
            royals = ascendingOrder(royals).ToList();
            HoldemCard[] rfCards = royals.GetRange(royals.Count - 5, 5).ToArray();

            //Console.WriteLine("Checking Royal Flush: " + "\n");
            //printArrray(rfCards.ToList());

            for (int i = 0; i < rfCards.Length; i++)
            {
                count += rfCards[i].getPointValue();
            }

            if (count == 60)
            {
                if (pCards)
                {
                    playerValCheckCards = rfCards.ToList();
                }
                else
                {
                    computerValCheckCards = rfCards.ToList();
                }
                return true;
            }
            return false;
        }

        public bool pair(HoldemCard[] cardArray, int pairNum, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            int count = 0;

            for (int i = 0; i < cardArray.Count(); i++)
            {
                count += countOccurencesInBoard(cardArray, cardArray[i], pCards);
                if (count >= pairNum)
                {
                    for (int j = 0; j < pairNum; j++)
                    {
                        if (pCards)
                        {
                            playerValCheckCards.Add(cardArray[i]);
                        }
                        else
                        {
                            computerValCheckCards.Add(cardArray[i]);
                        }
                    }
                    return true;
                }
                else
                {
                    count = 0;
                }
            }
            return false;
        }

        public bool twoPair(HoldemCard[] cardArray, bool pCards)
        {
            playerValCheckCards.Clear();
            computerValCheckCards.Clear();
            int count = 0;
            List<HoldemCard> counter = new List<HoldemCard>();

            for (int i = 0; i < cardArray.Count(); i++)
            {
                count += countOccurencesInBoard(cardArray, cardArray[i], pCards);
                if (count == 2)
                {
                    if (countOccurencesInBoard(counter.ToArray(), cardArray[i], pCards) == 0)
                    {
                        counter.Add(cardArray[i]);
                        if (pCards)
                        {
                            playerValCheckCards.Add(cardArray[i]);
                        }
                        else
                        {
                            computerValCheckCards.Add(cardArray[i]);
                        }
                    }
                }
                else
                {
                    count = 0;
                }
            }

            if (counter.Count >= 2)
            {
                return true;
            }
            return false;
        }

        public int countOccurencesInBoard(HoldemCard[] cardArray, HoldemCard card, bool pCards)
        {
            int a = cardArray.Where(s => s != null && s.getPointValue() == card.getPointValue()).Count();
            //Console.WriteLine("The Occurences of " + card.getRank() + " in the array is " + a + "\n");
            //printArrray(cardArray.ToList());
            return a;

        }
    }
}
