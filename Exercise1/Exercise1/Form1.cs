using System;
using System.Windows.Forms;

namespace Exercise1
{
    public partial class Form1 : Form
    {

        private OwnCollection ownCollection;
        private string fileName1 = "file1.txt";
        private string fileName2 = "file2.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                FileFiller.FillFile(fileName1);
                FileFiller.FillFile(fileName2);

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ownCollection = new OwnCollection(fileName1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(ownCollection!=null)
                    ownCollection.AppendFrom(fileName1);
                else
                    MessageBox.Show("You cannot add a second file before opening the first one");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string textToSearch = textBox1.Text;
                if(textToSearch!="")
                    MessageBox.Show(ownCollection.Find(textToSearch));
                else
                MessageBox.Show("Text to search is empty");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
