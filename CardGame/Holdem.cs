using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Holdem : Form
    {
        private HoldemCard[] cards = new HoldemCard[HoldemCardBoard.BOARD_SIZE];
        private HoldemCardBoard board = new HoldemCardBoard();
        private HoldemCard[] cardStates = new HoldemCard[9];
        private String[] cardStateNames = new string[9];
        public static List<HoldemCard> boardCards = new List<HoldemCard>();
        public static HoldemCard[] playerHand = new HoldemCard[2];
        public static HoldemCard[] computerHand = new HoldemCard[2];
        private int cardIndex = 0;
        private int boardCardIndex = 0;
        private List<HoldemCard> selectedCards = new List<HoldemCard>();
        private List<HoldemCard> computerCards = new List<HoldemCard>();
        private List<HoldemCard> playerCards = new List<HoldemCard>();
        private Dictionary<PictureBox, HoldemCard> pictureBoxes = new Dictionary<PictureBox, HoldemCard>();
        public Holdem()
        {
            InitializeComponent();
        }

        private void loadGame()
        {
            cards = new HoldemCard[HoldemCardBoard.BOARD_SIZE];
            board = new HoldemCardBoard();
            cardStates = new HoldemCard[9];
            cardStateNames = new string[9];
            boardCards = new List<HoldemCard>();
            playerHand = new HoldemCard[2];
            computerHand = new HoldemCard[2];
            cardIndex = 0;
            boardCardIndex = 0;
            selectedCards = new List<HoldemCard>();
            computerCards = new List<HoldemCard>();
            playerCards = new List<HoldemCard>();
            pictureBoxes = new Dictionary<PictureBox, HoldemCard>();

            card1picture.Image = null;
            card2picture.Image = null;
            card3picture.Image = null;
            card4picture.Image = null;
            card5picture.Image = null;

            card1picture.BorderStyle = BorderStyle.None;
            card2picture.BorderStyle = BorderStyle.None;
            card3picture.BorderStyle = BorderStyle.None;
            card4picture.BorderStyle = BorderStyle.None;
            card5picture.BorderStyle = BorderStyle.None;
            playerPicture1.BorderStyle = BorderStyle.None;
            playerPicture2.BorderStyle = BorderStyle.None;

            cards = board.getCards();

            for (int i = 0; i < cardStates.Length; i++)
            {

                cardStates[i] = cards[cardIndex];
                if (cardStates[i].getName().Equals("JO"))
                {
                    cardIndex++;
                    cardStates[i] = cards[cardIndex];
                }
                if (i == 5 || i == 6)
                {
                    playerHand[i - 5] = cards[cardIndex];
                    playerCards.Add(cards[cardIndex]);
                }
                if (i == 7 || i == 8)
                {
                    computerHand[i - 7] = cards[cardIndex];
                    computerCards.Add(cards[cardIndex]);
                }
                cardStateNames[i] = cardStates[i].getName();
                cardIndex++;
            }

            pictureBoxes.Add(playerPicture1, playerHand[0]);
            pictureBoxes.Add(playerPicture2, playerHand[1]);

            deckPicture.Image = Image.FromFile(getPath() + "back1.GIF");
            playerPicture1.Image = Image.FromFile(getPath() + cardStateNames[5] + ".GIF");
            playerPicture2.Image = Image.FromFile(getPath() + cardStateNames[6] + ".GIF");
            //computerCard1.Image = Image.FromFile(getPath() + cardStateNames[7] + ".GIF");
            //computerCard2.Image = Image.FromFile(getPath() + cardStateNames[8] + ".GIF");

            whiteChip.Image = Image.FromFile(getPath() + "white_chip.GIF");
            redChip.Image = Image.FromFile(getPath() + "red_chip.GIF");
            blueChip.Image = Image.FromFile(getPath() + "blue_chip.GIF");
            blackChip.Image = Image.FromFile(getPath() + "black_chip.GIF");

            computerCard1.Image = Image.FromFile(getPath() + "back1.GIF");
            computerCard2.Image = Image.FromFile(getPath() + "back1.GIF");

            updateAllValues();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadGame();

            foreach (Control c in this.Controls)
            {
                if (c is Button && c == buttonDeal)
                {
                    c.MouseClick += new MouseEventHandler(dealButtonClick);
                }
                else if (c is Button && c == buttonBestHand)
                {
                    c.MouseClick += new MouseEventHandler(bestHandClick);
                }
                else if (c is Button && c == bet)
                {
                    c.MouseClick += new MouseEventHandler(betClick);
                }
                else if (c is Button && c == match)
                {
                    c.MouseClick += new MouseEventHandler(matchClick);
                }
                else if (c is Button && c == resetBet)
                {
                    c.MouseClick += new MouseEventHandler(resetBetClick);
                }
                else if (c is Button && (c == whiteChip || c == redChip || c == blueChip || c == blackChip))
                {
                    c.MouseClick += new MouseEventHandler(chipClick);
                }
                else if (c is Button && c == foldButton)
                {
                    c.MouseClick += new MouseEventHandler(foldClick);
                }
                else if (c is PictureBox)
                {
                    if (!c.Equals(computerCard1) && !c.Equals(computerCard2) && !c.Equals(deckPicture))
                    {
                        c.MouseClick += new MouseEventHandler(pbClick);
                    }
                }
            }
        }

        public void chipClick(Object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == whiteChip)
            {
                HoldembettingSystem.betAdd(5);
                updateAllValues();
            }
            else if (b == redChip)
            {
                HoldembettingSystem.betAdd(20);
                updateAllValues();
            }
            else if (b == blueChip)
            {
                HoldembettingSystem.betAdd(50);
                updateAllValues();
            }
            else if (b == blackChip)
            {
                HoldembettingSystem.betAdd(100);
                updateAllValues();
            }
        }
        public void betClick(Object sender, EventArgs e)
        {
            HoldembettingSystem.playerBet();
            if (HoldembettingSystem.getCurrentComputerBet() != HoldembettingSystem.getCurrentPlayerBet())
            {
                computerPlay();
            }
            updateAllValues();
            //now computer has to bet
            //update values
        }

        public void foldClick(Object sender, EventArgs e)
        {
            fold(true);
        }


        public void fold(bool pFold)
        {
            if (pFold)
            {
                HoldembettingSystem.moneyToWinner(2);
                HoldembettingSystem.resetFromFold();
                loadGame();
            }
            else
            {
                MessageBox.Show("Computer Has Folded");
                HoldembettingSystem.moneyToWinner(1);
                HoldembettingSystem.resetFromFold();
                loadGame();
            }
        }
        public void matchClick(Object sender, EventArgs e)
        {
            HoldembettingSystem.matchBet(true);
            updateAllValues();
        }

        public void resetBetClick(Object sender, EventArgs e)
        {
            HoldembettingSystem.resetBet();
            updateAllValues();
        }

        public void pbClick(Object sender, EventArgs e)
        {
            PictureBox temp = sender as PictureBox;
            cardClick(temp);
        }
        public void computerPlay()
        {
            Random rand = new Random();
            int val = board.valueOfHand(computerCards, false);
            HoldembettingSystem.matchBet(false);
            int normalBet = HoldembettingSystem.getCurrentBet();
            int x = rand.Next(10);
            if (x < 6)
            {
                HoldembettingSystem.matchBet(false);
            }
            else if (x < 7)
            {
                HoldembettingSystem.matchBet(false);
                HoldembettingSystem.betAdd(25);
            }
            else if (x < 8)
            {
                HoldembettingSystem.matchBet(false);
                HoldembettingSystem.betAdd(50);
            }
            else if (x < 9)
            {
                //change when adding the fold because, well, yk
                HoldembettingSystem.matchBet(false);
                HoldembettingSystem.betAdd(100);
            }
            else
            {
                fold(false);
                updateAllValues();

                //alert the player that the computer has folded

            }

            HoldembettingSystem.computerBet();
        }
        public void bestHandClick(Object sender, EventArgs e)
        {
            if (boardCardIndex >= 5 && selectedCards.Count > 1)
            {
                computerCard1.Image = Image.FromFile(getPath() + cardStateNames[7] + ".GIF");
                computerCard2.Image = Image.FromFile(getPath() + cardStateNames[8] + ".GIF");

                int playerVal = board.valueOfHand(selectedCards, true);
                List<HoldemCard> pValCheckCards = HoldemCardBoard.playerValCheckCards;
                int computerVal = board.valueOfHand(computerCards, false);
                List<HoldemCard> cValCheckCards = HoldemCardBoard.computerValCheckCards;

                Console.WriteLine("Player Hand Value: " + playerVal + "\nComputer Hand Value: " + computerVal);
                //int computerSameValCheck = 0;
                //int playerSameValCheck = 0;
                pValCheckCards = board.ascendingOrder(pValCheckCards).ToList();
                cValCheckCards = board.ascendingOrder(cValCheckCards).ToList();
                selectedCards = board.ascendingOrder(selectedCards).ToList();
                computerCards = board.ascendingOrder(computerCards).ToList();
                playerCards = board.ascendingOrder(playerCards).ToList();

                if (playerVal == computerVal)
                {

                    if (pValCheckCards.Count - 1 >= 0 && cValCheckCards.Count - 1 >= 0 && pValCheckCards[pValCheckCards.Count - 1].getPointValue() == cValCheckCards[cValCheckCards.Count - 1].getPointValue())
                    {
                        for (int i = 0; i < pValCheckCards.Count; i++)
                        {
                            selectedCards.Remove(pValCheckCards[i]);
                        }

                        for (int j = 0; j < cValCheckCards.Count; j++)
                        {
                            computerCards.Remove(cValCheckCards[j]);
                        }

                        selectedCards = board.ascendingOrder(selectedCards).ToList();
                        computerCards = board.ascendingOrder(computerCards).ToList();

                        if (pValCheckCards.Count - 1 >= 0 && cValCheckCards.Count - 1 >= 0 && playerCards[playerCards.Count - 1].getPointValue() == computerCards[computerCards.Count - 1].getPointValue())
                        {
                            MessageBox.Show("It was a tie, both hands were equal in value.");
                            HoldembettingSystem.moneyToWinner(0);
                            HoldembettingSystem.resetFromFold();
                            loadGame();
                            updateAllValues();
                        }
                        else if (pValCheckCards.Count - 1 >= 0 && cValCheckCards.Count - 1 >= 0 && playerCards[playerCards.Count - 1].getPointValue() > computerCards[computerCards.Count - 1].getPointValue())
                        {
                            MessageBox.Show("Player wins from high card!");
                            HoldembettingSystem.moneyToWinner(1);
                            HoldembettingSystem.resetFromFold();
                            loadGame();
                            updateAllValues();
                        }
                        else
                        {
                            MessageBox.Show("Computer wins from high card!");
                            HoldembettingSystem.moneyToWinner(2);
                            HoldembettingSystem.resetFromFold();
                            loadGame();
                            updateAllValues();
                        }
                    }
                    else if (pValCheckCards.Count - 1 >= 0 && cValCheckCards.Count - 1 >= 0 && pValCheckCards[pValCheckCards.Count - 1].getPointValue() < cValCheckCards[cValCheckCards.Count - 1].getPointValue())
                    {
                        MessageBox.Show("Computer had a stronger hand.");
                        HoldembettingSystem.moneyToWinner(2);
                        HoldembettingSystem.resetFromFold();
                        loadGame();
                        updateAllValues();
                    }
                    else
                    {
                        MessageBox.Show("Player had a stronger hand.");
                        HoldembettingSystem.moneyToWinner(1);
                        HoldembettingSystem.resetFromFold();
                        loadGame();
                        updateAllValues();
                    }

                }
                
                else if (playerVal > computerVal)
                {
                    MessageBox.Show("Player had a stronger hand.");
                    HoldembettingSystem.moneyToWinner(1);
                    HoldembettingSystem.resetFromFold();
                    loadGame();
                    updateAllValues();
                }
                else
                {
                    MessageBox.Show("Computer had a stronger hand.");
                    HoldembettingSystem.moneyToWinner(2);
                    HoldembettingSystem.resetFromFold();
                    loadGame();
                    updateAllValues();
                }

                //int bestPlayerHand = board.valueOfHand(playerCards, true);
                //if (playerVal >= bestPlayerHand)
                //{
                //    MessageBox.Show("You chose the best possible hand. Good Job!");
                //    //Show Alert saying that they had the best possible hand
                //}
                //else
                //{
                //    //show what their best move could have been... MAYBEEEE
                //}
            }

        }

        public void updateAllValues()
        {
            pot.Text = "Pot: " + HoldembettingSystem.getPotBalance();
            pBalance.Text = "Player Balance: " + HoldembettingSystem.getPlayerBalance();
            cBalance.Text = "Computer Balance: " + HoldembettingSystem.getComputerBalance();
            lastBet.Text = "This Round: " + HoldembettingSystem.getCurrentComputerBet();
            currentBet.Text = "Current Bet: " + HoldembettingSystem.getCurrentBet();
            fullBet.Text = "This Round: " + HoldembettingSystem.getCurrentPlayerBet();
        }
        public void dealButtonClick(Object sender, EventArgs e)
        {

            if (HoldembettingSystem.whenToDeal())
            {
                HoldembettingSystem.resetFromNewCard();

                if (boardCardIndex == 0)
                {
                    showCard();
                    showCard();
                    showCard();
                }
                else showCard();
            }

        }
        public void cardClick(PictureBox pb)
        {
            if (pb != null)
            {
                if (pb.BorderStyle == BorderStyle.Fixed3D)
                {
                    pb.BorderStyle = BorderStyle.None;
                    selectedCards.Remove(pictureBoxes[pb]);
                }
                else
                {
                    pb.BorderStyle = BorderStyle.Fixed3D;
                    selectedCards.Add(pictureBoxes[pb]);
                }
            }
        }
        private String getPath()
        {
            return "..\\..\\My_Resources\\";
        }
        private void showCard()
        {
            if (boardCardIndex < 5)
            {
                boardCards.Add(cardStates[boardCardIndex]);
                computerCards.Add(cardStates[boardCardIndex]);
                playerCards.Add(cardStates[boardCardIndex]);
            }
            board.allCardsUpdate();

            switch (boardCardIndex)
            {
                case 0:
                    card1picture.Image = Image.FromFile(getPath() + cardStateNames[0] + ".GIF");
                    pictureBoxes.Add(card1picture, cardStates[boardCardIndex]);
                    break;
                case 1:
                    card2picture.Image = Image.FromFile(getPath() + cardStateNames[1] + ".GIF");
                    pictureBoxes.Add(card2picture, cardStates[boardCardIndex]);
                    break;
                case 2:
                    card3picture.Image = Image.FromFile(getPath() + cardStateNames[2] + ".GIF");
                    pictureBoxes.Add(card3picture, cardStates[boardCardIndex]);
                    break;
                case 3:
                    card4picture.Image = Image.FromFile(getPath() + cardStateNames[3] + ".GIF");
                    pictureBoxes.Add(card4picture, cardStates[boardCardIndex]);
                    break;
                case 4:
                    card5picture.Image = Image.FromFile(getPath() + cardStateNames[4] + ".GIF");
                    pictureBoxes.Add(card5picture, cardStates[boardCardIndex]);
                    break;
            }
            boardCardIndex++;
        }
    }
}
