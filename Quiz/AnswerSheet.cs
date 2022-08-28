using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class AnswerSheet : Form
    {
        public AnswerSheet()
        {
            InitializeComponent();
        }
        public string[] Questions;
        int i = 0;
        int count = 0;
        int page = 1;
        private void AnswerSheet_Load(object sender, EventArgs e)
        {
            loader();
            counter();
        }
        private void loader()
        {
            bool q1 = true;
            bool q2 = true;
            bool q3 = true;
            bool q4 = true;
            bool q5 = true;
            bool q6 = true;
            bool q7 = true;
            bool q8 = true;
            bool q9 = true;
            bool q10 = true;
            lbl_1.Text = count + 1 + " -";
            lbl_2.Text = count + 2 + " -";
            lbl_3.Text = count + 3 + " -";
            lbl_4.Text = count + 4 + " -";
            lbl_5.Text = count + 5 + " -";
            lbl_6.Text = count + 6 + " -";
            lbl_7.Text = count + 7 + " -";
            lbl_8.Text = count + 8 + " -";
            lbl_9.Text = count + 9 + " -";
            lbl_10.Text = count + 10 + " -";
            while (Questions.Count() > i)
            {
                count++;
                if (q1)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p11.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p12.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p13.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p14.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q1 = false;
                }
                else if (q2)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p21.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p22.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p23.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p24.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q2 = false;
                }
                else if (q3)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p31.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p32.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p33.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p34.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q3 = false;
                }
                else if (q4)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p41.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p42.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p43.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p44.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q4 = false;
                }
                else if (q5)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p51.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p52.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p53.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p54.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q5 = false;
                }
                else if (q6)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p61.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p62.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p63.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p64.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q6 = false;
                }
                else if (q7)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p71.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p72.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p73.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p74.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q7 = false;
                }
                else if (q8)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p81.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p82.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p83.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p84.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q8 = false;
                }
                else if (q9)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p91.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p92.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p93.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p94.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q9 = false;
                }
                else if (q10)
                {
                    if (int.Parse(Questions[i].Split(',')[0].Trim()) == count)
                    {
                        if (Questions[i].Split(',')[1].Trim() == "1")
                        {
                            p101.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "2")
                        {
                            p102.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "3")
                        {
                            p103.Image = Quiz.Properties.Resources._checked;
                        }
                        else if (Questions[i].Split(',')[1].Trim() == "4")
                        {
                            p104.Image = Quiz.Properties.Resources._checked;
                        }
                        i++;
                    }
                    q10 = false;
                    break;
                }
            }
        }

        private void Reset()
        {
            p11.Image = Quiz.Properties.Resources.number1;
            p21.Image = Quiz.Properties.Resources.number1;
            p31.Image = Quiz.Properties.Resources.number1;
            p41.Image = Quiz.Properties.Resources.number1;
            p51.Image = Quiz.Properties.Resources.number1;
            p61.Image = Quiz.Properties.Resources.number1;
            p71.Image = Quiz.Properties.Resources.number1;
            p81.Image = Quiz.Properties.Resources.number1;
            p91.Image = Quiz.Properties.Resources.number1;
            p101.Image = Quiz.Properties.Resources.number1;
            p12.Image = Quiz.Properties.Resources.number2;
            p22.Image = Quiz.Properties.Resources.number2;
            p32.Image = Quiz.Properties.Resources.number2;
            p42.Image = Quiz.Properties.Resources.number2;
            p52.Image = Quiz.Properties.Resources.number2;
            p62.Image = Quiz.Properties.Resources.number2;
            p72.Image = Quiz.Properties.Resources.number2;
            p82.Image = Quiz.Properties.Resources.number2;
            p92.Image = Quiz.Properties.Resources.number2;
            p102.Image = Quiz.Properties.Resources.number2;
            p13.Image = Quiz.Properties.Resources.number3;
            p23.Image = Quiz.Properties.Resources.number3;
            p33.Image = Quiz.Properties.Resources.number3;
            p43.Image = Quiz.Properties.Resources.number3;
            p53.Image = Quiz.Properties.Resources.number3;
            p63.Image = Quiz.Properties.Resources.number3;
            p73.Image = Quiz.Properties.Resources.number3;
            p83.Image = Quiz.Properties.Resources.number3;
            p93.Image = Quiz.Properties.Resources.number3;
            p103.Image = Quiz.Properties.Resources.number3;
            p14.Image = Quiz.Properties.Resources.number4;
            p24.Image = Quiz.Properties.Resources.number4;
            p34.Image = Quiz.Properties.Resources.number4;
            p44.Image = Quiz.Properties.Resources.number4;
            p54.Image = Quiz.Properties.Resources.number4;
            p64.Image = Quiz.Properties.Resources.number4;
            p74.Image = Quiz.Properties.Resources.number4;
            p84.Image = Quiz.Properties.Resources.number4;
            p94.Image = Quiz.Properties.Resources.number4;
            p104.Image = Quiz.Properties.Resources.number4;
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            page--;
            count = page * 10 - 10;
            int b = 0;
            while (b < 10)
            {
                int p = page * 10 - 9 + b;
                if (Array.FindIndex(Questions, row => row.StartsWith(p.ToString() + ",")) != -1)
                {
                    i = Array.FindIndex(Questions, row => row.StartsWith(p.ToString()));
                    break;
                }
                b++;
            }
            Reset();
            loader();
            counter();
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            page++;
            count = page * 10 - 10;
            int b = 0;
            while (b < 10)
            {
                int p = page * 10 - 9 + b;
                if (Array.FindIndex(Questions, row => row.StartsWith(p.ToString() + ",")) != -1)
                {
                    i = Array.FindIndex(Questions, row => row.StartsWith(p.ToString()));
                    break;
                }
                b++;
            }
            Reset();
            loader();
            counter();
        }

        private void counter()
        {
            if (int.Parse(Questions.Last().Split(',')[0].Trim()) > page * 10)
            {
                btn_next.Enabled = true;
            }
            else
            {
                btn_next.Enabled = false;
            }
            if (page == 1)
            {
                btn_Previous.Enabled = false;
            }
            else
            {
                btn_Previous.Enabled = true;
            }
        }
    }
}
