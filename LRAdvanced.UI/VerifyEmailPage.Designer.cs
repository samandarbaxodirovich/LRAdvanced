namespace LRAdvanced.UI
{
    partial class VerifyEmailPage
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.thatsAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(203, 173);
            this.textBox1.MaxLength = 50;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 41);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Location = new System.Drawing.Point(155, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(492, 45);
            this.label4.TabIndex = 30;
            this.label4.Text = "Enter verification code";
            // 
            // thatsAll
            // 
            this.thatsAll.BackColor = System.Drawing.Color.SlateGray;
            this.thatsAll.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.thatsAll.ForeColor = System.Drawing.Color.White;
            this.thatsAll.Location = new System.Drawing.Point(272, 256);
            this.thatsAll.Name = "thatsAll";
            this.thatsAll.Size = new System.Drawing.Size(200, 59);
            this.thatsAll.TabIndex = 31;
            this.thatsAll.Text = "Verify";
            this.thatsAll.UseVisualStyleBackColor = false;
            this.thatsAll.Click += new System.EventHandler(this.thatsAll_Click);
            // 
            // VerifyEmailPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.thatsAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Name = "VerifyEmailPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyEmailPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VerifyEmailPage_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label label4;
        private Button thatsAll;
    }
}