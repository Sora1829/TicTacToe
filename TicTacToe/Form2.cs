using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form2 : Form
    {
        static List<string> Names = new List<string>();
        static List<string> Scores = new List<string>();
        static List<string> CompScores = new List<string>();
        Label[] names;
        Label[] PlayerWins;
        Label[] CompWins;
        public Form2()
        {
            InitializeComponent();
            names = new Label[] {label4,label7,label10,label13,label16};
            PlayerWins = new Label[] {label5,label8,label11,label14,label17};
            CompWins = new Label[] {label6,label9,label12,label15,label18};
            ReadScores();
        }

