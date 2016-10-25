namespace Chat_Cliente
{
    partial class Form1
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
            this.lstCnvs = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnEnvia = new System.Windows.Forms.Button();
            this.lstUsrs = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCnvs
            // 
            this.lstCnvs.FormattingEnabled = true;
            this.lstCnvs.Location = new System.Drawing.Point(12, 12);
            this.lstCnvs.Name = "lstCnvs";
            this.lstCnvs.Size = new System.Drawing.Size(442, 264);
            this.lstCnvs.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMsg);
            this.groupBox1.Location = new System.Drawing.Point(12, 282);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(6, 19);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(430, 20);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsg_KeyPress);
            // 
            // btnEnvia
            // 
            this.btnEnvia.Location = new System.Drawing.Point(460, 287);
            this.btnEnvia.Name = "btnEnvia";
            this.btnEnvia.Size = new System.Drawing.Size(99, 49);
            this.btnEnvia.TabIndex = 2;
            this.btnEnvia.Text = "Enviar";
            this.btnEnvia.UseVisualStyleBackColor = true;
            this.btnEnvia.Click += new System.EventHandler(this.btnEnvia_Click);
            // 
            // lstUsrs
            // 
            this.lstUsrs.FormattingEnabled = true;
            this.lstUsrs.Location = new System.Drawing.Point(460, 12);
            this.lstUsrs.Name = "lstUsrs";
            this.lstUsrs.Size = new System.Drawing.Size(99, 264);
            this.lstUsrs.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(571, 348);
            this.Controls.Add(this.lstUsrs);
            this.Controls.Add(this.btnEnvia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstCnvs);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCnvs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnEnvia;
        private System.Windows.Forms.ListBox lstUsrs;
    }
}

