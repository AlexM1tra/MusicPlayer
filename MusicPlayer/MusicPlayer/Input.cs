using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Input : Form
    {
        private static string result = "";
        private Input(string message)
        {
            InitializeComponent();
            textBox1.KeyDown += new KeyEventHandler(OnKeyDown);
            labelTitle.Text = message;
            labelTitle.Left = (this.Width - labelTitle.Width) / 2;
        }

        public static string Show(string message)
        {
            Input input = new Input(message);
            input.FormClosing += new FormClosingEventHandler((sender, e) => result = ((Input)sender).textBox1.Text);
            input.ShowDialog();
            return result;
        }

        public static string ShowWithAutoComplete(string message, AutoCompleteStringCollection collection)
        {
            Input input = new Input(message);
            input.textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            input.textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            input.textBox1.AutoCompleteCustomSource = collection;
            input.FormClosing += new FormClosingEventHandler((sender, e) => result = ((Input)sender).textBox1.Text);
            input.ShowDialog();
            return result;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
