using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //this activates the "File/exit" menu strip button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //This activates the "About" menu strip button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Steven Adam Lawson.  Please contact me via JefferyD90@live.com if you have any questions.");
        }
        //This loads new webpage
        private void navigateToPage()
        {
            webBrowser1.Navigate(textBox1.Text);
            toolStripStatusLabel1.Text = "Navigation has started";
            button1.Enabled = false;
            textBox1.Enabled = false;
        }
        //This activates the "Go!" button
        private void button1_Click(object sender, EventArgs e)
        {
            navigateToPage();
        }
        //This ensure a keyboard press of "enter" will trigger the "Go!" button
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == (char)ConsoleKey.Enter)
            {
                navigateToPage();
            }
        }
        //This reenables additioanl navigation once the webpage is done loading
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation complete";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

    }
}
