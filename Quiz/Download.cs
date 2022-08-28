using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }
        StreamReader sr;
        private void btn_download_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                try
                {
                    MessageBox.Show($"این کار ممکن است با توجه به سرعت اینترنت شما زمان ببرد{Environment.NewLine} لطفا تا پایان دریافت پیام تایید و دریافت فایل ها صبور باشید");
                    string url = "http://quiz24exam.parsaspace.com//Exams//" + txt_code.Value.ToString() + ".txt";
                    Uri uri = new Uri(url);
                    WebClient webClient = new WebClient();
                    string path = @"C:\exam\quiz\" + Path.GetFileName(uri.LocalPath);
                    webClient.DownloadFile(url, path);
                    sr = Repository.StreamReader(path);
                    string ex_name = sr.ReadLine().Split('=')[1];
                    sr.Close();
                    if (!Directory.Exists(@"C:\exam\quiz\" + ex_name))
                    {
                        Directory.CreateDirectory(@"C:\exam\quiz\" + ex_name);
                        File.Move(path, @"C:\exam\quiz\" + ex_name + "\\Questions.txt");
                        imagedownloader(ex_name);
                        send(ex_name);
                        MessageBox.Show("آزمون دریافت شد", "عملیات با موفقیت انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("این آزمون تکراری می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    File.Delete(path);
                }
                catch
                {
                    MessageBox.Show("خطا در دانلود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void imagedownloader(string ex_name)
        {
            try
            {
                sr = Repository.StreamReader(@"C:\exam\quiz\" + ex_name + "\\Questions.txt");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    string site = sr.ReadLine().Split('=')[1];
                    Uri uri = new Uri(site);
                    WebClient webClient = new WebClient();
                    string path = @"C:\exam\quiz\" + ex_name + "\\" + Path.GetFileName(uri.LocalPath);
                    webClient.DownloadFile(site, @"C:\exam\quiz\" + ex_name + "\\" + Path.GetFileName(uri.LocalPath));
                    sr.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("خطا در دانلود تصاویر سوالات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sr.Close();
        }
        bool isvalid()
        {
            if (!Repository.IsConnectedToInternet())
            {
                return false;
            }
            try
            {
                HttpWebRequest request = WebRequest.Create("http://quiz24exam.parsaspace.com//Exams//" + txt_code.Value.ToString() + ".txt") as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                MessageBox.Show("کد وارد شده اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void send(string examname)
        {
            try
            {
                sr = Repository.StreamReader(@"C:\exam\Account.txt");
                string Name = sr.ReadLine().Split('=')[1] + Environment.NewLine;
                string UserName = sr.ReadLine().Split('=')[1];
                sr.Close();
                Random rd = new Random();
                int ran = rd.Next(10000, 99999);
                File.WriteAllText(@"C:\exam\" + txt_code.Value.ToString() + "-" + UserName + "-" + ran + ".txt", "ExamName=" + examname + Environment.NewLine + "ExamCode=" + txt_code.Value.ToString() + Environment.NewLine + "Name=" + Name + "UserName=" + UserName + Environment.NewLine +"Date=" + DateTime.Now.ToString("HH:mm:ss yyyy/MM/dd"));
                Repository.Uploader("Download", @"C:\exam\" + txt_code.Value.ToString() + "-" + UserName + "-" + ran + ".txt");
                File.Delete(@"C:\exam\" + txt_code.Value.ToString() + "-" + UserName + "-" + ran + ".txt");
            }
            catch
            {
                MessageBox.Show("Sending Report Error", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
