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

namespace Quiz
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        StreamReader sr;

        private void btn_Exams_Click(object sender, EventArgs e)
        {
            this.Hide();
            Exams exams = new Exams();
            exams.ShowDialog();
            counter();
            this.Show();
        }

        private void btn_ConnectUs_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConnectUs connectUscs = new ConnectUs();
            connectUscs.ShowDialog();
            counter();
            this.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            counter();
        }

        private void counter()
        {
            string[] MessagesU = Repository.List("UsersMessages").ToArray();
            string[] Messages = Directory.GetFiles(@"C:\exam\Messages");
            int count = 0;
            sr = Repository.StreamReader(@"C:\exam\Account.txt"); sr.ReadLine();
            int username = int.Parse(sr.ReadLine().Split('=')[1]);
            sr.Close();
            for (int i = 0; i < MessagesU.Count(); i++)
            {
                int b = Array.FindIndex(Messages, row => row.EndsWith(MessagesU[i].Split(':')[1].Trim()));
                if (b < 0)
                {
                    if (MessagesU[i].Split(':')[1].Trim().StartsWith("All") || MessagesU[i].Split(':')[1].Trim().StartsWith(username.ToString()))
                        count++;
                }
            }
            for (int i = 0; i < Messages.Count(); i++)
            {
                if (Messages[i].Replace("C:\\exam\\Messages\\", string.Empty).StartsWith("N-"))
                {
                    count++;
                }
            }
            if (count != 0)
            {
                btn_messages.Text = count + " پیام جدید";
                btn_messages.TabIndex = 0;
            }
            else
            {
                btn_messages.Text = "پیام های دریافتی";
                btn_messages.TabIndex = 3;
            }
        }

        private void btn_messages_Click(object sender, EventArgs e)
        {
            this.Hide();
            Messages messages = new Messages();
            messages.ShowDialog();
            counter();
            this.Show();
        }
    }
}
