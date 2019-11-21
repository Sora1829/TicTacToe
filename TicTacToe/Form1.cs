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
        public Form1()
        {
            InitializeComponent();
            
        }


        Image X = Image.FromFile("C:/Users/rl146129/Desktop/C-Sharp-Projects/TicTacToe/TicTacToe/X.png");

        Char turn;

        private void label1_Click(object sender, EventArgs e)
        {
            if (turn == 'X')
            {
                label1.Image = X;
                label1.Refresh();
            }
            else if (turn == 'O')
            {

            }

        }
    }
}
