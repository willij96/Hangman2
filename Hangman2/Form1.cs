using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Hangman2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string word = "";
        List<Label> labels = new List<Label>();
        int amount = 0;

        enum HangmanParts
        {
            HangPost1,
            HangPost2,
            HangPost3,
            HangPost4,
            Head,
            Body,
            LeftArm,
            RightArm,
            LeftLeg,
            RightLeg
        }

        // method used to draw the different hangman parts
        void DrawHangmanParts(HangmanParts hp)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);

            if (hp == HangmanParts.HangPost1)
            {
                graphics.DrawLine(pen, new Point(130, 200), new Point(220, 200));
            }
            else if (hp == HangmanParts.HangPost2)
            {
                graphics.DrawLine(pen, new Point(170, 200), new Point(170, 30));
            }
            else if (hp == HangmanParts.HangPost3)
            {
                graphics.DrawLine(pen, new Point(170, 30), new Point(240, 30));
            }
            else if (hp == HangmanParts.HangPost4)
            {
                graphics.DrawLine(pen, new Point(240, 30), new Point(240, 50));
            }
            else if (hp == HangmanParts.Head)
            {
                graphics.DrawEllipse(pen, 230, 50, 40, 40);
            }
            else if (hp == HangmanParts.Body)
            {
                graphics.DrawLine(pen, new Point(240, 90), new Point(240, 155));
            }
            else if (hp == HangmanParts.LeftArm)
            {
                graphics.DrawLine(pen, new Point(240, 120), new Point(200, 90));
            }
            else if (hp == HangmanParts.RightArm)
            {
                graphics.DrawLine(pen, new Point(240, 120), new Point(280, 90));
            }
            else if (hp == HangmanParts.LeftLeg)
            {
                graphics.DrawLine(pen, new Point(240, 155), new Point(210, 190));
            }
            else if (hp == HangmanParts.RightLeg)
            {
                graphics.DrawLine(pen, new Point(240, 155), new Point(270, 180));
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        string GetRandomWord()
        {
            WebClient wc = new WebClient();
            string wordList = wc.DownloadString("https://gist.githubusercontent.com/deekayen/4148741/raw/98d35708fa344717d8eee15d11987de6c8e26d7d/1-1000.txt");
            string[] words = wordList.Split('\n');
            Random random = new Random();
            return words[random.Next(0, words.Length - 1)];
        }

        void MakeLabels()
        {
            word = GetRandomWord();
            char[] chars = word.ToCharArray();
            int gap = 330 / chars.Length;

            for (int i = 0; i < chars.Length; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * gap) + 10, 30);
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MakeLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char letter = 'a';
            var btn = (Button)sender;
            switch (btn.Name)
            {
                case "buttonA":
                    letter = 'a';
                    buttonA.Enabled = false;
                    break;
                case "buttonB":
                    letter = 'b';
                    buttonB.Enabled = false;
                    break;
                case "buttonC":
                    letter = 'c';
                    buttonC.Enabled = false;
                    break;
                case "buttonD":
                    letter = 'd';
                    buttonD.Enabled = false;
                    break;
                case "buttonE":
                    letter = 'e';
                    buttonE.Enabled = false;
                    break;
                case "buttonF":
                    letter = 'f';
                    buttonF.Enabled = false;
                    break;
                case "buttonG":
                    letter = 'g';
                    buttonG.Enabled = false;
                    break;
                case "buttonH":
                    letter = 'h';
                    buttonH.Enabled = false;
                    break;
                case "buttonI":
                    letter = 'i';
                    buttonI.Enabled = false;
                    break;
                case "buttonJ":
                    letter = 'j';
                    buttonJ.Enabled = false;
                    break;
                case "buttonK":
                    letter = 'k';
                    buttonK.Enabled = false;
                    break;
                case "buttonL":
                    letter = 'l';
                    buttonL.Enabled = false;
                    break;
                case "buttonM":
                    letter = 'm';
                    buttonM.Enabled = false;
                    break;
                case "buttonN":
                    letter = 'n';
                    buttonN.Enabled = false;
                    break;
                case "buttonO":
                    letter = 'o';
                    buttonO.Enabled = false;
                    break;
                case "buttonP":
                    letter = 'p';
                    buttonP.Enabled = false;
                    break;
                case "buttonQ":
                    letter = 'q';
                    buttonQ.Enabled = false;
                    break;
                case "buttonR":
                    letter = 'r';
                    buttonR.Enabled = false;
                    break;
                case "buttonS":
                    letter = 's';
                    buttonS.Enabled = false;
                    break;
                case "buttonT":
                    letter = 't';
                    buttonT.Enabled = false;
                    break;
                case "buttonU":
                    letter = 'u';
                    buttonU.Enabled = false;
                    break;
                case "buttonV":
                    letter = 'v';
                    buttonV.Enabled = false;
                    break;
                case "buttonW":
                    letter = 'w';
                    buttonW.Enabled = false;
                    break;
                case "buttonX":
                    letter = 'x';
                    buttonX.Enabled = false;
                    break;
                case "buttonY":
                    letter = 'y';
                    buttonY.Enabled = false;
                    break;
                case "buttonZ":
                    letter = 'z';
                    buttonZ.Enabled = false;
                    break;
            }
            if (word.Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letter)
                        labels[i].Text = letter.ToString();
                }
                foreach (Label item in labels)
                    if (item.Text == "_") return;
                MessageBox.Show("You won!", "Congrats");
                ResetGame();
            }
            else
            {
                //MessageBox.Show("The letter that you guessed isn't in the word", "Sorry");
                DrawHangmanParts((HangmanParts)amount);
                amount++;

                if (amount == 10)
                {
                    MessageBox.Show("You lost!\nThe right word was " + word.ToUpper(), "Game Over");
                    ResetGame();
                }
            }
        }
        void ResetGame()
        {
            Graphics graphics = panel1.CreateGraphics();
            graphics.Clear(panel1.BackColor);
            amount = 0;
            ResetButtons();
            GetRandomWord();
            MakeLabels();
        }

        void ResetButtons()
        {
            buttonA.Enabled = true;
            buttonB.Enabled = true;
            buttonC.Enabled = true;
            buttonD.Enabled = true;
            buttonE.Enabled = true;
            buttonF.Enabled = true;
            buttonG.Enabled = true;
            buttonH.Enabled = true;
            buttonI.Enabled = true;
            buttonJ.Enabled = true;
            buttonK.Enabled = true;
            buttonL.Enabled = true;
            buttonM.Enabled = true;
            buttonN.Enabled = true;
            buttonO.Enabled = true;
            buttonP.Enabled = true;
            buttonQ.Enabled = true;
            buttonR.Enabled = true;
            buttonS.Enabled = true;
            buttonT.Enabled = true;
            buttonU.Enabled = true;
            buttonV.Enabled = true;
            buttonW.Enabled = true;
            buttonX.Enabled = true;
            buttonY.Enabled = true;
            buttonZ.Enabled = true;

        }
    }
}