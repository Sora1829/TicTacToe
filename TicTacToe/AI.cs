using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    class AI
    {

        Label[][] board;
        Label[] diagonal1;
        Label[] diagonal2;
        Label[] Columun1;
        Label[] Columun2;
        Label[] Columun3;
        int Spot;
        public AI(Label[][] board,Label[] diagonal, Label[] diagona2, Label[] Columun1,Label[] Columun2,Label[] Columun3)
        {
            this.board = board;
            diagonal1 = diagonal;
            diagonal2 = diagona2;
            this.Columun1 = Columun1;
            this.Columun2 = Columun2;
            this.Columun3 = Columun3;
        }

        //checks if it needs to stop you.
        public int AICheck(int Spot)
        {
            int Pos = -1;
            int j = 0;
            int i = 0;
            foreach (Label[] Labels in board)
            {
                Pos = -1;
                j = 0;
                foreach (Label label in Labels)
                {
                    if (label.Text == "X")
                    {
                        j++;
                        
                    }
                    else if (label.Text == "")
                    {
                        Pos = i;
                    }


                    if (j == 2 && Pos != -1)
                    {
                        Console.WriteLine("Spot found: " + i);
                        Spot = Pos;
                        return Spot;
                    }
                    i++;
                }
            }

            Pos = -1;
            j = 0;
            i = 0;
            foreach (Label label in diagonal1)
            {
                if (label.Text == "X")
                {
                    j++;

                }
                else if (label.Text == "")
                {
                    Pos = i;
                }

                if (j == 2 && Pos != -1)
                {
                    Console.WriteLine("Spot found: " + i);
                    Spot = Pos;
                    return Spot;
                }

                i = i + 4;
            }

            Pos = -1;
            j = 0;
            i = 2;
            foreach (Label label in diagonal2)
            {
                if (label.Text == "X")
                {
                    j++;

                }
                else if (label.Text == "")
                {
                    Pos = i;
                }

                if (j == 2 && Pos != -1)
                {
                    Console.WriteLine("Spot found: " + i);
                    Spot = Pos;
                    return Spot;
                }

                i = i + 2;
            }

            Pos = -1;
            j = 0;
            i = 0;
            foreach (Label label in Columun1)
            {
                if (label.Text == "X")
                {
                    j++;

                }
                else if (label.Text == "")
                {
                    Pos = i;
                }

                if (j == 2 && Pos != -1)
                {
                    Console.WriteLine("Spot found: " + i);
                    Spot = Pos;
                    return Spot;
                }

                i = i + 3;
            }

            Pos = -1;
            j = 0;
            i = 1;
            foreach (Label label in Columun2)
            {
                if (label.Text == "X")
                {
                    j++;

                }
                else if (label.Text == "")
                {
                    Pos = i;
                }

                if (j == 2 && Pos != -1)
                {
                    Console.WriteLine("Spot found: " + i);
                    Spot = Pos;
                    return Spot;
                }

                i = i + 3;
            }

            Pos = -1;
            j = 0;
            i = 2;
            foreach (Label label in Columun3)
            {
                if (label.Text == "X")
                {
                    j++;

                }
                else if (label.Text == "")
                {
                    Pos = i;
                }

                if (j == 2 && Pos != -1)
                {
                    Console.WriteLine("Spot found: " + i);
                    Spot = Pos;
                    return Spot;
                }

                i = i + 3;
            }



            return Spot;
        }
    }
}
