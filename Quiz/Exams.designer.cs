namespace Quiz
{
    partial class Exams
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dg_exam = new System.Windows.Forms.DataGridView();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_exam)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dg_exam);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 196);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست آزمون ها";
            // 
            // dg_exam
            // 
            this.dg_exam.AllowUserToAddRows = false;
            this.dg_exam.AllowUserToDeleteRows = false;
            this.dg_exam.AllowUserToResizeColumns = false;
            this.dg_exam.AllowUserToResizeRows = false;
            this.dg_exam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_exam.ColumnHeadersHeight = 29;
            this.dg_exam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_exam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Names});
            this.dg_exam.Cursor = System.Windows.Forms.Cursors.Default;
            this.dg_exam.Location = new System.Drawing.Point(6, 22);
            this.dg_exam.MultiSelect = false;
            this.dg_exam.Name = "dg_exam";
            this.dg_exam.RowHeadersVisible = false;
            this.dg_exam.RowHeadersWidth = 51;
            this.dg_exam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_exam.RowTemplate.Height = 24;
            this.dg_exam.Size = new System.Drawing.Size(313, 168);
            this.dg_exam.TabIndex = 0;
            this.dg_exam.TabStop = false;
            // 
            // Names
            // 
            this.Names.HeaderText = "نام آزمون";
            this.Names.MinimumWidth = 6;
            this.Names.Name = "Names";
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(12, 214);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(106, 41);
            this.btn_download.TabIndex = 1;
            this.btn_download.Text = "دریافت سوالات";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(246, 214);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(91, 41);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "ورود";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // Exams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 267);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_login);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Exams";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "آزمون ها";
            this.Load += new System.EventHandler(this.Exams_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_exam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dg_exam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_login;
    }
}