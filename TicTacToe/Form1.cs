using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        List<EventHandler> Clicks = new List<EventHandler>();
        Random rand = new Random();
        public int Spot = -1;
        String Winner;
        bool win = false;
        int playerWins;
        int CompWins;
        public Label[][] board1;
        Label[] Row1;
        Label[] Row2;
        Label[] Row3;
        Label[] diagonal1;
        Label[] diagonal2;
        Label[] Columun1;
        Label[] Columun2;
        Label[] Columun3;
        int x = 0;
        int y = 0;
        Label[] labels;
        bool draw = true;
        AI ai;

        public Form1()
        {
            InitializeComponent();
            Row1 = new Label[] { label1, label2, label3 };
            Row2 = new Label[] { label4, label5, label6 };
            Row3 = new Label[] { label7, label8, label9 };
            board1 = new Label[][] { Row1, Row2, Row3 };
            diagonal1 = new Label[] { label1, label5, label9 };
            diagonal2 = new Label[] { label3, label5, label7 };
            Columun1 = new Label[] {label1,label4,label7};
            Columun2 = new Label[] { label2, label5, label8 };
            Columun3 = new Label[] { label3, label6, label9 };

            labels = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9 };
            ai = new AI(board1,diagonal1,diagonal2,Columun1,Columun2,Columun3);


            Clicks.Add(label1_Click);
            Clicks.Add(label2_Click);
            Clicks.Add(label3_Click);
            Clicks.Add(label4_Click);
            Clicks.Add(label5_Click);
            Clicks.Add(label6_Click);
            Clicks.Add(label7_Click);
            Clicks.Add(label8_Click);
            Clicks.Add(label9_Click);

        }

        char[] Board = new char[9] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};

        Image X = Image.FromFile("X.png");
        Image O = Image.FromFile("O.png");

        char turn = 'X';

        // Player turn
        private void PlayerTurn(int x,int y,int pos)
        {
            Check();
            board1[x][y].Image = X;
            board1[x][y].Click -= Clicks[pos];
            board1[x][y].Refresh();
            board1[x][y].Text = "X";
            Board[pos] = 'X';
            turn = 'O';
            Check();
            Ai();
        }

        //Ai turn
        private void Ai()
        {
            if (!win)
            {
                Spot = ai.AICheck(Spot);
                if (turn == 'O')
                {
                    if (Spot != -1)
                    {
                        Check();
                        SplitSpot(Spot);
                        board1[x][y].Image = O;
                        board1[x][y].Click -= Clicks[Spot];
                        board1[x][y].Refresh();
                        board1[x][y].Text = "O";
                        Board[Spot] = 'O';
                        Spot = -1;
                        turn = 'X';
                        Check();
                    }
                    else
                    {
                        Check();
                        Spot = rand.Next(9);

                        while (Board[Spot] != ' ')
                        {
                            Spot = rand.Next(9);
                        }

                        SplitSpot(Spot);

                        board1[x][y].Image = O;
                        board1[x][y].Click -= Clicks[Spot];
                        board1[x][y].Refresh();
                        board1[x][y].Text = "O";
                        Board[Spot] = 'O';
                        turn = 'X';
                        Spot = -1;
                        Check();
                    }
                }
            }
            else ScoreBoard();
    }

        private void SplitSpot(int Spot)
        {
            if (Spot == 0)
            {
                x = 0;
                y = 0;
            }
            else if (Spot == 1)
            {
                x = 0;
                y = 1;
            }
            else if (Spot == 2)
            {
                x = 0;
                y = 2;
            }
            else if (Spot == 3)
            {
                x = 1;
                y = 0;
            }
            else if (Spot == 4)
            {
                x = 1;
                y = 1;
            }
            else if (Spot == 5)
            {
                x = 1;
                y = 2;
            }
            else if (Spot == 6)
            {
                x = 2;
                y = 0;
            }
            else if (Spot == 7)
            {
                x = 2;
                y = 1;
            }
            else
            {
                x = 2;
                y = 2;
            }
        }

        //Checking if someone has won/drawn
        private void Check()
        {
            draw = true;
            string prev = "null";
            bool same = true;
            string[] prev1 = new string[] { "null", "null", "null" };
            bool[] same1 = new bool[] { true, true, true };

            //Checks Rows
            foreach (Label[] labels in board1)
            {

                foreach (Label label in labels)
                {
                    if (prev == "null")
                        prev = label.Text;
                    else if (prev != label.Text || label.Text == "")
                        same = false;
                }

                if (same && prev != "null")
                {
                    win = true;
                    Winner = prev;
                    ScoreBoard();
                }
                same = true;
                prev = "null";


                //Checks Collumns
                if (prev1[0] == "null")
                    prev1[0] = labels[0].Text;
                else if (prev1[0] != labels[0].Text || labels[0].Text == "")
                    same1[0] = false;

                if (prev1[1] == "null")
                    prev1[1] = labels[1].Text;
                else if (prev1[1] != labels[1].Text || labels[1].Text == "")
                    same1[1] = false;

                if (prev1[2] == "null")
                    prev1[2] = labels[2].Text;
                else if (prev1[2] != labels[2].Text || labels[2].Text == "")
                    same1[2] = false;
            }
            if (same1[0] && prev1[0] != "null")
            {
                win = true;
                Winner = prev1[0];
                ScoreBoard();
            }

            if (same1[1] && prev1[01] != "null")
            {
                win = true;
                Winner = prev1[1];
                ScoreBoard();
            }


            if (same1[2] && prev1[2] != "null")
            {
                win = true;
                Winner = prev1[2];
                ScoreBoard();
            }


            //Checks Diagonals 1 and 2
            string prev2 = "null";
            bool same2 = true;
            foreach (Label label in diagonal1)
            {
                if (prev2 == "null")
                    prev2 = label.Text;
                else if (prev2 != label.Text || label.Text == "")
                    same2 = false;
            }

            if (same2 && prev2 != "null")
            {
                win = true;
                Winner = prev2;
                ScoreBoard();
            }

            prev2 = "null";
            same2 = true;
            foreach (Label label in diagonal2)
            {
                if (prev2 == "null")
                    prev2 = label.Text;
                else if (prev2 != label.Text || label.Text == "")
                    same2 = false;
            }

            if (same2 && prev2 != "null")
            {
                win = true;
                Winner = prev2;
                ScoreBoard();
            }

            foreach (Label label in labels)
            {
                if (label.Text == "")
                {
                    draw = false;
                }
                else
                    Console.WriteLine(label.Text);
            }
            Console.WriteLine("Next:");

            if (draw)
            {
                win = true;
                Console.WriteLine("Test");
                reset();
            }
        }

        //Updates Scoreboard and calls reset
        private void ScoreBoard()
        {
            if (Winner == "X")
            {
                playerWins++;
                label12.Text = $"{playerWins}";
            }
            else if (Winner== "O")
            {
                CompWins++;
                label13.Text = $"{CompWins}";
            }
            reset();
            
        }

        //Start button Click Events
        private void label1_Click(object sender, EventArgs e)
        {

            if (turn == 'X' && !win)
            {
                PlayerTurn(0,0,0);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(0, 1, 1);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(0, 2, 2);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(1, 0, 3);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(1,1,4);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(1,2,5);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(2,0,6);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(2, 1, 7);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && !win)
            {
                PlayerTurn(2, 2, 8);
            }
        }
        //End of Button Clicks

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //reset button at bottom of screen
        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        //Resets board and buttons.
        private void reset()
        {
            int i = 0;
            int j = 0;
            foreach (Label label1 in labels)
            {
                label1.Click -= Clicks[j];
                j++;
            }
            foreach (Label label in labels)
            {
                label.Image = null;
                label.Click += Clicks[i];
                label.Refresh();
                label.Text = "";
                Board[i] = ' ';
                i++;
                win = false;
                Winner = "null";
                turn = 'X';
            }
        }
    }
}

