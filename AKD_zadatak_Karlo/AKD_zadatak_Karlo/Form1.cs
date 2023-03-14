using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKD_zadatak_Karlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxIzvorni.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxOdredisni.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Glavni(textBoxIzvorni.Text, textBoxOdredisni.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
