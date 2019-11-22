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
        Label[] labels;
        List<EventHandler> Clicks = new List<EventHandler>();
        Random rand = new Random();
        int Spot = -1;
        Char Winner;
        int playerWins;
        int CompWins;
        char[,] Board = new char[3,3] {
        };


        public Form1()
        {
            InitializeComponent();
            labels = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9 };
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

        private void PlayerTurn(int pos)
        {
            if (Check() == false)
            {
                labels[pos].Image = X;
                labels[pos].Refresh();
                labels[pos].Click -= Clicks[pos];
                Board[pos] = 'X';
                turn = '0';
                AI();
            }
            else
            {
                ScoreBoard();
                Console.WriteLine(playerWins);
            }

        }
        private void AI()
        {
            if (Check() == false)
            {
                AiCheck();
                if (Spot != -1)
                {
                    labels[Spot].Image = O;
                    labels[Spot].Refresh();
                    labels[Spot].Click -= Clicks[Spot];
                    Board[Spot] = 'O';
                    turn = 'X';
                    Spot = -1;
                }
                else
                {
                    Spot = rand.Next(9);

                    while (Board[Spot] != ' ')
                    {
                        Spot = rand.Next(9);
                    }

                    labels[Spot].Image = O;
                    labels[Spot].Refresh();
                    labels[Spot].Click -= Clicks[Spot];
                    Board[Spot] = 'O';
                    turn = 'X';
                    Spot = -1;
                }

            }
            else
            {
                ScoreBoard();
            }
        }

        private bool Check()
        {
            if (Board[0]=='X' && Board[1] == 'X' && Board[2] == 'X' || Board[3] == 'X' && Board[4] == 'X' && Board[5] == 'X' || Board[6] == 'X' && Board[7] == 'X' && Board[8] == 'X' ||
                Board[0] == 'X' && Board[3] == 'X' && Board[6] == 'X' || Board[1] == 'X' && Board[4] == 'X' && Board[7] == 'X' || Board[2] == 'X' && Board[5] == 'X' && Board[8] == 'X' ||
                Board[0] == 'X' && Board[4] == 'X' && Board[8] == 'X' || Board[6] == 'X' && Board[4] == 'X' && Board[2] == 'X')
            {
                Char Winner = 'X';
                return true;
            }
            else if (Board[0] == 'O' && Board[1] == 'O' && Board[2] == 'O' || Board[3] == 'O' && Board[4] == 'O' && Board[5] == 'O' || Board[6] == 'O' && Board[7] == 'O' && Board[8] == 'O' ||
                Board[0] == 'O' && Board[3] == 'O' && Board[6] == 'O' || Board[1] == 'O' && Board[4] == 'O' && Board[7] == 'O' || Board[2] == 'O' && Board[5] == 'O' && Board[8] == 'O' ||
                Board[0] == 'O' && Board[4] == 'O' && Board[8] == 'O' || Board[6] == 'O' && Board[4] == 'O' && Board[2] == 'O')
            {
                Char Winner = 'O';
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AiCheck()
        {
            if (Board[0] == 'X' && Board[1] == 'X' && Board[2] != 'O' || Board[5] == 'X' && Board[8] == 'X' && Board[2] != 'O' || Board[4] == 'X' && Board[6] == 'X' && Board[2] != 'O')
            {
                Spot = 2;

            }
            else if (Board[0] == 'X' && Board[2] == 'X' && Board[1] != 'O' || Board[4] == 'X' && Board[7] == 'X' && Board[1] != 'O')
            {
                Spot = 1;
            }
            else if (Board[1] == 'X' && Board[2] == 'X' && Board[0] != 'O' || Board[3] == 'X' && Board[6] == 'X' && Board[0] != 'O' || Board[4] == 'X' && Board[8] == 'X' && Board[0] != 'O')
            {
                Spot = 0;
            }
            else if (Board[0] == 'X' && Board[6] == 'X' && Board[3] != 'O' || Board[4] == 'X' && Board[5] == 'X' && Board[3] != 'O')
            {
                Spot = 3;
            }
            else if (Board[3] == 'X' && Board[5] == 'X' && Board[4] != 'O' || Board[0] == 'X' && Board[8] == 'X' && Board[4] != 'O' || Board[2] == 'X' && Board[6] == 'X' && Board[4] != 'O'||
                Board[1] == 'X' && Board[7] == 'X' && Board[4] != 'O')
            {
                Spot = 4;
            }
            else if (Board[2] == 'X' && Board[8] == 'X' && Board[5] != 'O' || Board[4] == 'X' && Board[3] == 'X' && Board[5] != 'O')
            {
                Spot = 5;
            }
            else if (Board[0] == 'X' && Board[3] == 'X' && Board[6] != 'O' || Board[7] == 'X' && Board[8] == 'X' && Board[6] != 'O' || Board[2] == 'X' && Board[4] == 'X' && Board[6] != 'O')
            {
                Spot = 6;
            }
            else if (Board[1] == 'X' && Board[4] == 'X' && Board[7] != 'O' || Board[6] == 'X' && Board[8] == 'X' && Board[7] != 'O')
            {
                Spot = 7;
            }
            else if (Board[5] == 'X' && Board[2] == 'X' && Board[8] != 'O' || Board[7] == 'X' && Board[6] == 'X' && Board[8] != 'O' || Board[0] == 'X' && Board[4] == 'X' && Board[8] != 'O')
            {
                Spot = 8;
            }
        }

        private void ScoreBoard()
        {
            if (Winner == 'X')
            {
                playerWins++;
            }
            else
            {
                CompWins++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(0);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(1);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(2);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(3);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(4);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(5);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(6);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(7);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (turn == 'X' && Check() == false)
            {
                PlayerTurn(8);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
