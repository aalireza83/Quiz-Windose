namespace Quiz
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_ConnectUs = new System.Windows.Forms.Button();
            this.btn_Exams = new System.Windows.Forms.Button();
            this.btn_messages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ConnectUs
            // 
            this.btn_ConnectUs.Location = new System.Drawing.Point(12, 77);
            this.btn_ConnectUs.Name = "btn_ConnectUs";
            this.btn_ConnectUs.Size = new System.Drawing.Size(159, 59);
            this.btn_ConnectUs.TabIndex = 2;
            this.btn_ConnectUs.Text = "ارتباط با ما";
            this.btn_ConnectUs.UseVisualStyleBackColor = true;
            this.btn_ConnectUs.Click += new System.EventHandler(this.btn_ConnectUs_Click);
            // 
            // btn_Exams
            // 
            this.btn_Exams.Location = new System.Drawing.Point(12, 12);
            this.btn_Exams.Name = "btn_Exams";
            this.btn_Exams.Size = new System.Drawing.Size(324, 59);
            this.btn_Exams.TabIndex = 1;
            this.btn_Exams.Text = "آزمون ها";
            this.btn_Exams.UseVisualStyleBackColor = true;
            this.btn_Exams.Click += new System.EventHandler(this.btn_Exams_Click);
            // 
            // btn_messages
            // 
            this.btn_messages.Location = new System.Drawing.Point(177, 77);
            this.btn_messages.Name = "btn_messages";
            this.btn_messages.Size = new System.Drawing.Size(159, 59);
            this.btn_messages.TabIndex = 3;
            this.btn_messages.Text = "پیام های دریافتی";
            this.btn_messages.UseVisualStyleBackColor = true;
            this.btn_messages.Click += new System.EventHandler(this.btn_messages_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 148);
            this.Controls.Add(this.btn_ConnectUs);
            this.Controls.Add(this.btn_messages);
            this.Controls.Add(this.btn_Exams);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه اصلی";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ConnectUs;
        private System.Windows.Forms.Button btn_Exams;
        private System.Windows.Forms.Button btn_messages;
    }
}