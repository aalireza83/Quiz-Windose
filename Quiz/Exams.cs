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
    public partial class Exams : Form
    {
        public Exams()
        {
            InitializeComponent();
        }

        private void Exams_Load(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(@"C:\exam\quiz");
                List<string> Names = new List<string>(Directory.GetDirectories(@"C:\exam\quiz"));
                foreach (string folder in Names)
                {
                    DateTime Creationdate = Convert.ToDateTime(Directory.GetCreationTime(folder).ToString("yyyy/MM/dd HH:mm:ss"));
                    DateTime now = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    double diff = Convert.ToDouble((now - Creationdate).TotalMinutes.ToString());
                    int i = (int)diff;
                    if (i >= 30)
                    {
                        Directory.Delete(folder, true);
                    }
                }
                load();
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_exam.CurrentRow != null)
                {
                    this.Hide();
                    Questions questions = new Questions();
                    questions.exname = dg_exam.CurrentCell.Value.ToString();
                    questions.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("هیچ آزمونی انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Download download = new Download();
                if (download.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                    load();
                }
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load()
        {
            try
            {
                dg_exam.Rows.Clear();
                List<string> Names = new List<string>(Directory.GetDirectories(@"C:\exam\quiz"));
                foreach (string folder in Names)
                {
                    dg_exam.Rows.Add(folder.Replace("C:\\exam\\quiz\\", string.Empty));
                }
            }
            catch
            {
                MessageBox.Show("خطا در انجام عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
