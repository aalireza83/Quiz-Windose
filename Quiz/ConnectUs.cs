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
    public partial class ConnectUs : Form
    {
        public ConnectUs()
        {
            InitializeComponent();
        }

        StreamReader sr;
        string message;
        string messagecode;

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                try
                {
                    Random rd = new Random();
                    messagecode = (DateTime.Now.ToString("yyyyMMddHHmmss") + rd.Next(10000, 99999));
                    sr = Repository.StreamReader(@"C:\exam\Account.txt");
                    string Name = sr.ReadLine().Split('=')[1];
                    string Username = sr.ReadLine().Split('=')[1];
                    message = "Date = " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + Environment.NewLine + "Code = " + messagecode + Environment.NewLine + "From Name = " + Name + Environment.NewLine + "From UserName = " + Username + Environment.NewLine + "To = Admin" + Environment.NewLine + "Message = " + txt_Message.Text + Environment.NewLine + "Id = ";
                    sr.Close();
                    if (txt_Id.Text != "")
                    {
                        message += txt_Id.Text;
                    }
                    File.WriteAllText(@"C:\exam\Messages\" + "Admin-" + Username + "-" + messagecode + ".txt", message);
                    Repository.Uploader("Messages", @"C:\exam\Messages\" + "Admin-" + Username + "-" + messagecode + ".txt");
                    File.Delete(@"C:\exam\Messages\" + "Admin-" + Username + "-" + messagecode + ".txt");
                    MessageBox.Show("پیام با موفقیت ارسال شد", "ارسال شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("خطا در ارسال پیام", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        bool isvalid()
        {
            if (!Repository.IsConnectedToInternet())
            {
                return false;
            }
            else if (txt_Message.Text == "")
            {
                MessageBox.Show("پیام خود را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
