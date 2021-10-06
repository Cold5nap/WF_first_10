using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_first_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Программа запущена.");
        }


        private void GetResultButton_Click(object sender, EventArgs e)
        {
            string strMtr = InputTextBox.Text;

            int [][]matrix = TextMatrix.getIntMatrixFromString(strMtr);
            ResultTextBox.Text = TextMatrix.getStringMatrix(PressedMatrix.getPressedMatrix(matrix));

        }

        private void LoadInputФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                    {
                        InputTextBox.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void buttonRandomGenerate_Click(object sender, EventArgs e)
        {
            int row = int.Parse(inputColsTextBox.Text);
            int col = int.Parse(inputRowsTextBox.Text);
            InputTextBox.Text =  TextMatrix.getStringMatrix(TextMatrix.getGeneratedRandomMatrix(row, col));
        }
    }
}
