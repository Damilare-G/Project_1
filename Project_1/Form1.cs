using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Configuration;

namespace Project_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            if (ValidateCredentials(userName, password))
            {
                Game_page game_Page = new Game_page();
                game_Page.ShowDialog();
            }
            //else
            //{
            //    MessageBox.Show("Username not found or incorrect password");
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Take the text from the textBox1 and assign it to the UserName variable


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            if (UserExists(userName))
            {
                MessageBox.Show("Username exists");
            }
            else
            {
                string credentials = userName + " " + password;
                using (FileStream fs = new FileStream("credentials.txt", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(credentials);
                }
                MessageBox.Show("User Created");
            }
        }

        private bool UserExists(string userName)
        {
            string filePath = "credentials.txt";
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts[0] == userName)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool ValidateCredentials(string userName, string password)
        {
            string filePath = "credentials.txt";
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts[0] == userName)
                        {
                            if (parts[1] == password)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password. If forgot password, \nclick 'Forgot Password' button");
                                return false;
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Username not found");
            return false;
        }
    }
}
