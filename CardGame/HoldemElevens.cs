using CardGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace CardGame
{
    public partial class HoldemElevens : Form
    {
        private HoldemCard[] cards = new HoldemCard[HoldemCardBoard.BOARD_SIZE + 9];
        HoldemCard[] cardStates = new HoldemCard[9];
        private int gamesWon = 0, gamesPlayed = 0;
        private int cardIndex = 0;
        List<int> indexes = new List<int>();
        String[] cardStateNames = new string[9];
        bool[] selected = { false, false, false, false, false, false, false, false, false };
        private int countSelected = 0;
        HoldemCardBoard board = new HoldemCardBoard();
        public HoldemElevens()  
        {

            InitializeComponent();
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            string[] resources = thisExe.GetManifestResourceNames();
            */
            cards = board.getCards();

            button1.Text = "Replace";

            button2.Text = "Restart";

            for (int i = 0; i < cardStates.Length; i++)
            {
                cardStates[i] = cards[cardIndex];
                cardStateNames[i] = cardStates[i].getName();
                cardIndex++;
            }

            label1.Text = cards.Length - cardIndex + " undealt cards remain.";
            label2.Text = "You have won " + gamesWon + " out of " + gamesPlayed + " games";

            /*
            pictureBox1.Image = (Image)CardGame.Properties.Resources.ResourceManager.GetObject("flag_" + cardStateNames[1]);
            pictureBox2.Image = (Image)CardGame.Properties.Resources.ResourceManager.GetObject("flag_" + cardStateNames[2]);
            pictureBox3.Image = (Image)CardGame.Properties.Resources.ResourceManager.GetObject("flag_" + cardStateNames[3]);
            */

            //pictureBox1.Image = (Image)CardGame.Properties.Resources.ResourceManager.GetObject(resources[0]);
            //pictureBox2.Image = (Image)CardGame.Properties.Resources.ResourceManager.GetObject(resources[0]);

            pictureBox1.Image = Image.FromFile(getPath() + cardStateNames[0] + ".GIF");
            pictureBox2.Image = Image.FromFile(getPath() + cardStateNames[1] + ".GIF");
            pictureBox3.Image = Image.FromFile(getPath() + cardStateNames[2] + ".GIF");
            pictureBox4.Image = Image.FromFile(getPath() + cardStateNames[3] + ".GIF");
            pictureBox5.Image = Image.FromFile(getPath() + cardStateNames[4] + ".GIF");
            pictureBox6.Image = Image.FromFile(getPath() + cardStateNames[5] + ".GIF");
            pictureBox7.Image = Image.FromFile(getPath() + cardStateNames[6] + ".GIF");
            pictureBox8.Image = Image.FromFile(getPath() + cardStateNames[7] + ".GIF");
            pictureBox9.Image = Image.FromFile(getPath() + cardStateNames[8] + ".GIF");
        }
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[2] == "back1")
            {
                return;
            }
            else if (cardStateNames[2].Equals("JO"))
            {
                pictureBox3.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[2])
            {
                pictureBox3.Image = Image.FromFile(getPath() + cardStateNames[2] + ".GIF");
                selected[2] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox3.Image = Image.FromFile(getPath() + cardStateNames[2] + "S.GIF");
                selected[2] = true;
                countSelected++;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[0] == "back1")
            {
                return;
            }
            else if (cardStateNames[0].Equals("JO"))
            {
                pictureBox1.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[0])
            {
                pictureBox1.Image = Image.FromFile(getPath() + cardStateNames[0] + ".GIF");
                selected[0] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox1.Image = Image.FromFile(getPath() + cardStateNames[0] + "S.GIF");
                selected[0] = true;
                countSelected++;
            }
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[3] == "back1")
            {
                return;
            }
            else if (cardStateNames[3].Equals("JO"))
            {
                pictureBox4.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[3])
            {
                pictureBox4.Image = Image.FromFile(getPath() + cardStateNames[3] + ".GIF");
                selected[3] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox4.Image = Image.FromFile(getPath() + cardStateNames[3] + "S.GIF");
                selected[3] = true;
                countSelected++;
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[1] == "back1")
            {
                return;
            }
            else if (cardStateNames[1].Equals("JO"))
            {
                pictureBox2.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[1])
            {
                pictureBox2.Image = Image.FromFile(getPath() + cardStateNames[1] + ".GIF");
                selected[1] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox2.Image = Image.FromFile(getPath() + cardStateNames[1] + "S.GIF");
                selected[1] = true;
                countSelected++;
            }
        }

        private void pictureBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[7] == "back1")
            {
                return;
            }
            else if (cardStateNames[7].Equals("JO"))
            {
                pictureBox8.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[7])
            {
                pictureBox8.Image = Image.FromFile(getPath() + cardStateNames[7] + ".GIF");
                selected[7] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox8.Image = Image.FromFile(getPath() + cardStateNames[7] + "S.GIF");
                selected[7] = true;
                countSelected++;
            }
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[6] == "back1")
            {
                return;
            }
            else if (cardStateNames[6].Equals("JO"))
            {
                pictureBox7.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[6])
            {
                pictureBox7.Image = Image.FromFile(getPath() + cardStateNames[6] + ".GIF");
                selected[6] = false;
                countSelected--;

            }
            else if (countSelected < 3)
            {
                pictureBox7.Image = Image.FromFile(getPath() + cardStateNames[6] + "S.GIF");
                selected[6] = true;
                countSelected++;
            }
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[5] == "back1")
            {
                return;
            }
            else if (cardStateNames[5].Equals("JO"))
            {
                pictureBox6.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[5])
            {
                pictureBox6.Image = Image.FromFile(getPath() + cardStateNames[5] + ".GIF");
                selected[5] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox6.Image = Image.FromFile(getPath() + cardStateNames[5] + "S.GIF");
                selected[5] = true;
                countSelected++;
            }
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[4] == "back1")
            {
                return;
            }
            else if (cardStateNames[4].Equals("JO"))
            {
                pictureBox5.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[4])
            {
                pictureBox5.Image = Image.FromFile(getPath() + "back1.GIF");
                selected[4] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox5.Image = Image.FromFile(getPath() + cardStateNames[4] + "S.GIF");
                selected[4] = true;
                countSelected++;
            }
        }

        private void pictureBox9_MouseClick(object sender, MouseEventArgs e)
        {
            if (cardStateNames[8] == "back1")
            {
                return;
            }
            else if (cardStateNames[8].Equals("JO"))
            {
                pictureBox9.Image = Image.FromFile(getPath() + "JOS.GIF");
                showWin();
            }
            cardSelectSound();
            if (selected[8])
            {
                pictureBox9.Image = Image.FromFile(getPath() + cardStateNames[8] + ".GIF");
                selected[8] = false;
                countSelected--;
            }
            else if (countSelected < 3)
            {
                pictureBox9.Image = Image.FromFile(getPath() + cardStateNames[8] + "S.GIF");
                selected[8] = true;
                countSelected++;
            }
        }
        private String getPath()
        {
            return "..\\..\\cards\\";
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(cardIndex);
            for (int i = 0; i < selected.Length; i++)
            {
                if (selected[i])
                {
                    indexes.Add(i);
                }
            }

            if ((board.containsPairSum11(indexes, cardStates)) || (indexes.Count == 3 && board.containsJQK(indexes, cardStates)))
            {
                foreach (int z in indexes)
                {
                    if (cards.Length - 1 - cardIndex < 0)
                    {
                        cardStates[z] = new HoldemCard("", "back1", 0);
                    }
                    else
                    {
                        cardStates[z] = cards[cardIndex];
                    }

                    cardStateNames[z] = cardStates[z].getName();
                    cardIndex++;
                }

                



                pictureBox1.Image = Image.FromFile(getPath() + cardStateNames[0] + ".GIF");
                pictureBox2.Image = Image.FromFile(getPath() + cardStateNames[1] + ".GIF");
                pictureBox3.Image = Image.FromFile(getPath() + cardStateNames[2] + ".GIF");
                pictureBox4.Image = Image.FromFile(getPath() + cardStateNames[3] + ".GIF");
                pictureBox5.Image = Image.FromFile(getPath() + cardStateNames[4] + ".GIF");
                pictureBox6.Image = Image.FromFile(getPath() + cardStateNames[5] + ".GIF");
                pictureBox7.Image = Image.FromFile(getPath() + cardStateNames[6] + ".GIF");
                pictureBox8.Image = Image.FromFile(getPath() + cardStateNames[7] + ".GIF");
                pictureBox9.Image = Image.FromFile(getPath() + cardStateNames[8] + ".GIF");

                if (checkWin())
                {
                    showWin();
                }
                else if (!(board.anotherPlayIsPossible(cardStates) || cardStateNames.Contains("JO")))
                {
                    gamesPlayed++;
                    MessageBox.Show("You Lost :(");
                }
            }
            updateValues();
        }
        public void updateValues()
        {
            indexes.Clear();
            if (cards.Length - cardIndex + 8 < 0)
            {
                label1.Text = "0 undealt cards remain.";
            }
            label1.Text = cards.Length - cardIndex + " undealt cards remain.";
            countSelected = 0;
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = false;
            }
        }
        public void showWin()
        {
            winSound();
            MessageBox.Show("You Won!!");
            gamesWon++;
        }
        public bool checkWin()
        {
            bool a = true;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                {
                    a = false;
                }
            }
            return (cards.Length == cardIndex && a);

        }

        private void cardSelectSound()
        {
            SoundPlayer sound1 = new SoundPlayer(@"C:\Windows\Media\ding.wav");
            sound1.Play();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            restart();
            Form1_Load(sender, e);
        }
        public void restart()
        {
            board = new HoldemCardBoard();
            cardIndex = 0;
            gamesPlayed++;
            for (int i = 0; i < selected.Length; i++)
            {
                selected[i] = false;
                cardStates[i] = null;
                cardStateNames[i] = null;
            }
        }

        private void winSound()
        {
            SoundPlayer sound1 = new SoundPlayer("..\\..\\Win_Sound.wav");
            sound1.Play();
        }
    }
}
