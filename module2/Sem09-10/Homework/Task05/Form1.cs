using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task05
{
    public partial class Form1 : Form
    {
        private string[] list = { "One", "Two", "Three", "Four", "Five" };
        private string[] newList = null;
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Lines = list;
            textBox1.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string res = "Результат изменений:\n" + string.Join(" ", newList);
            MessageBox.Show(res);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            newList = textBox1.Lines;
        }
    }
}
