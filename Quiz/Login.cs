using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        StreamReader sr;
        bool checke = false;
        int username;
        string UpdateVersion;
        string Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        private void Login_Load(object sender, EventArgs e)
        {
            MessageBox.Show("لطفا ابتدا اطمینان حاصل کنید آنتی ویروس شما قطع می باشد بعد روی اوکی کلیک کنید زیرا برخی از آنتی ویروس ها اجازه دانلود اطلاعات را به نرم افزار نمی دهند", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            try
            {
                if (!Directory.Exists(@"C:\exam"))
                {
                    Directory.CreateDirectory(@"C:\exam");
                }
                if (!File.Exists(@"C:\exam\Account.txt"))
                {
                    File.WriteAllText(@"C:\exam\Account.txt", "Name=" + Environment.NewLine + "UserName=" + Environment.NewLine + Version);
                }
                if (!Directory.Exists(@"C:\exam\Messages"))
                {
                    Directory.CreateDirectory(@"C:\exam\Messages");
                }
                else
                {
                    sr = Repository.StreamReader(@"C:\exam\Account.txt");
                    sr.ReadLine();
                    string UserName = sr.ReadLine();
                    sr.Close();
                    if (UserName.Split('=')[1] != "")
                    {
                        if (!Repository.IsConnectedToInternet())
                        {
                            Environment.Exit(0);
                        }
                        string[] names = Repository.List("").ToArray();
                        foreach (string name in names)
                        {
                            if (name.Split(':')[1].Trim().StartsWith("Version"))
                            {
                                UpdateVersion = name.Split(':')[1].Trim().Replace("Version", string.Empty);
                            }
                        }
                        if (UpdateVersion != Version)
                        {
                            if (MessageBox.Show("ورژن نرم افزار قدیمی می باشد آیا مایل به دریافت نسخه جدید هستید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Uri uri = new Uri("http://quiz24exam.parsaspace.com//Quiz.exe");
                                string filename = Path.GetFileName(uri.LocalPath);
                                WebClient webClient = new WebClient();
                                webClient.DownloadFile("http://quiz24exam.parsaspace.com//Quiz.exe", @"C:\exam\Quiz.exe");
                                if (MessageBox.Show("مسیر ذخیره سازی فایل را انتخاب کنید", "ورژن جدید", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        if (File.Exists(folderBrowserDialog.SelectedPath + "\\Quiz.exe"))
                                        {
                                            for (int i = 2; i > 1; i++)
                                            {
                                                if (!File.Exists(folderBrowserDialog.SelectedPath + "\\Quiz(" + i + ").exe"))
                                                {
                                                    File.Move(@"C:\exam\Quiz.exe", folderBrowserDialog.SelectedPath + "\\Quiz(" + i + ").exe");
                                                    MessageBox.Show("بروزرسانی نرم افزار با موفقیت انجام شد", "دانلود شد", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    i = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            File.Move(@"C:\exam\Quiz.exe", folderBrowserDialog.SelectedPath + "\\Quiz.exe");
                                            MessageBox.Show("بروزرسانی نرم افزار با موفقیت انجام شد", "دانلود شد", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                            }
                            this.Close();
                        }
                        else
                        {
                            sr = Repository.StreamReader(@"C:\exam\Account.txt");
                            sr.ReadLine();
                            sr.ReadLine();
                            if (sr.ReadLine() != "1.0.0.0")
                            {
                                sr.Close();
                                Directory.Delete(@"C:\exam", true);
                                MessageBox.Show("به علت تغییرات اساسی در نرم افزار اطلاعات شما پاک میشود و شما می بایست دوباره ثبت نام کنید");
                                this.Close();
                            }
                        }
                        string[] acc = Repository.List("Users/").ToArray();
                        foreach (string account in acc)
                        {
                            if (account.Split(':')[1].Split('=')[0].Trim() == UserName.Split('=')[1])
                            {
                                if (account.Split('=')[1].Split('.')[0].Trim() == "Blocked")
                                {
                                    txt_name.Enabled = false;
                                    btn_signup.Enabled = false;
                                    MessageBox.Show("متاسفانه شما توسط ادمین بلاک شدید");
                                }
                                else if (account.Split('=')[1].Split('.')[0].Trim() == "Verified")
                                {
                                    Main main = new Main();
                                    this.Hide();
                                    sr.Close();
                                    File.Delete(@"C:\exam\accs.txt");
                                    main.ShowDialog();
                                    this.Close();
                                    break;
                                }
                                else
                                {
                                    checke = true;
                                }
                            }
                        }
                        sr.Close();
                        File.Delete(@"C:\exam\accs.txt");
                        if (checke)
                        {
                            txt_name.Enabled = false;
                            btn_signup.Enabled = false;
                            btn_restart.Visible = true;
                            MessageBox.Show("شما قبلا ثبت نام کرده اید لطفا منتظر تایید باشید");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (isvald())
            {
                try
                {
                    Random rd = new Random();
                    username = rd.Next(100000000, 999999999);
                    File.WriteAllText(@"C:\exam\Account.txt", "Name=" + txt_name.Text + Environment.NewLine + "UserName=" + username + Environment.NewLine + Version);
                    send();
                    MessageBox.Show("ثبت نام انجام شد لطفا منتظر تایید توسط ادمین بمانید","ثبت نام",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void send()
        {
            File.Copy(@"C:\exam\Account.txt", @"C:\exam\" + username + "=.txt");
            Repository.Uploader("Users", @"C:\exam\" + username + "=.txt");
            File.Delete(@"C:\exam\" + username + "=.txt");
        }

        bool isvald()
        {
            if (!Repository.IsConnectedToInternet())
            {
                return false;
            }
            else if (txt_name.Text == "")
            {
                MessageBox.Show("لطفا نام و نام خانوادگی خود را وارد کنید");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("با این کار تمام اطلاعات شما در این نرم افزار پاک میشود هنوز هم میخواهید راه اندازی مجدد نمایید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var Directory = new DirectoryInfo(@"C:\exam");
                    sr = Repository.StreamReader(@"C:\exam\Account.txt");
                    sr.ReadLine();
                    Repository.Delete("Users/" + sr.ReadLine().Split('=')[1].Trim() + ".txt");
                    sr.Close();
                    Directory.Delete(true);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectUs_Click(object sender, EventArgs e)
        {
            ConnectUs connectUs = new ConnectUs();
            connectUs.ShowDialog();
        }
    }
}