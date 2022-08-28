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
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
        }
        List<int> ids = new List<int>();
        List<string> question = new List<string>();
        public string exname;
        StreamReader sr;
        int i = 0;
        int count = 0;
        string ques;
        private void Questions_Load(object sender, EventArgs e)
        {
            try
            {
                txt_name.Text = exname;
                sr = Repository.StreamReader(@"C:\exam\quiz\" + exname + "\\Questions.txt");
                string line = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line.StartsWith("ID"))
                    {
                        ids.Add(int.Parse(line.Split('=')[1]));
                    }
                }
                sr.Close();
                ids.Sort();
                txt_Count.Text = ids.Count().ToString();
                loader();
                count++;
                Counter();
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            i++;
            loader();
            count++;
            Counter();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            i--;
            loader();
            count--;
            Counter();
        }

        private void loader()
        {
            sr = Repository.StreamReader(@"C:\exam\quiz\" + exname + "\\Questions.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Contains("ID") && int.Parse(line.Split('=')[1]) == int.Parse(ids[i].ToString()))
                {
                    txt_Id.Text = line.Split('=')[1];
                    txt_hard.Text = sr.ReadLine().Split('=')[1];
                    txt_key.Text = sr.ReadLine().Split('=')[1];
                    Uri QuestionImagename = new Uri(sr.ReadLine().Split('=')[1]);
                    pb_question.Image = Image.FromFile(@"C:\exam\quiz\" + txt_name.Text + "\\" + Path.GetFileName(QuestionImagename.LocalPath));
                    break;
                }
            }
            sr.Close();
        }

        private void Counter()
        {
            if (int.Parse(txt_Id.Text) > ids.Min())
            {
                btn_previous.Enabled = true;
            }
            else
            {
                btn_previous.Enabled = false;
            }
            if (int.Parse(txt_Id.Text) < ids.Max())
            {
                btn_next.Enabled = true;
            }
            else
            {
                btn_next.Enabled = false;
            }
        }
        private void btn_AnswerSheet_Click(object sender, EventArgs e)
        {
            sr = Repository.StreamReader(@"C:\exam\quiz\" + exname + "\\Questions.txt");
            int b = 0;
            while (b < ids.Count)
            {
                string line = sr.ReadLine();
                string id = "ID = " + ids[b];
                if (line == id)
                {
                    b++;
                    ques += line.Split('=')[1].Trim() + ",";
                    sr.ReadLine();
                    ques += sr.ReadLine().Split('=')[1].Trim();
                    question.Add(ques);
                    ques = string.Empty;
                    sr.Close();
                    sr = Repository.StreamReader(@"C:\exam\quiz\" + exname + "\\Questions.txt");
                }
            }
            sr.Close();
            this.Hide();
            AnswerSheet answerSheet = new AnswerSheet();
            answerSheet.Questions = question.ToArray();
            answerSheet.ShowDialog();
            this.Show();
        }
    }
}
