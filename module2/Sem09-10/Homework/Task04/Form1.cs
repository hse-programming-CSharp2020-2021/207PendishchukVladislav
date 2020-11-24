using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem09_10
{
    public partial class Form1 : Form
    {
        private string[] list = {"One", "Two", "Three", "Four", "Five"};

        public Form1()
        {
            InitializeComponent();
            button2.Visible = false;
            listBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            button2.Visible = true;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран элемент или список пуст!");
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
