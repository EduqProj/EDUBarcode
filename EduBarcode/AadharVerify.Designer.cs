namespace EduBarcode
{
    partial class AadharVerify
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppNo = new System.Windows.Forms.Label();
            this.btnVerifyAadhar = new System.Windows.Forms.Button();
            this.aadharStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.txtAppNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "App No:";
            // 
            // lblAppNo
            // 
            this.lblAppNo.AutoSize = true;
            this.lblAppNo.Location = new System.Drawing.Point(135, 103);
            this.lblAppNo.Name = "lblAppNo";
            this.lblAppNo.Size = new System.Drawing.Size(0, 20);
            this.lblAppNo.TabIndex = 1;
            // 
            // btnVerifyAadhar
            // 
            this.btnVerifyAadhar.Location = new System.Drawing.Point(64, 149);
            this.btnVerifyAadhar.Name = "btnVerifyAadhar";
            this.btnVerifyAadhar.Size = new System.Drawing.Size(134, 44);
            this.btnVerifyAadhar.TabIndex = 2;
            this.btnVerifyAadhar.Text = "Verify Aadhar";
            this.btnVerifyAadhar.UseVisualStyleBackColor = true;
            this.btnVerifyAadhar.Click += new System.EventHandler(this.btnVerifyAadhar_Click);
            // 
            // aadharStatus
            // 
            this.aadharStatus.AutoSize = true;
            this.aadharStatus.Location = new System.Drawing.Point(67, 27);
            this.aadharStatus.Name = "aadharStatus";
            this.aadharStatus.Size = new System.Drawing.Size(108, 20);
            this.aadharStatus.TabIndex = 3;
            this.aadharStatus.Text = "AadharStatus";
            this.aadharStatus.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(394, 135);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(390, 26);
            this.txtComment.TabIndex = 5;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(394, 177);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(139, 36);
            this.btnSkip.TabIndex = 6;
            this.btnSkip.Text = "Skip >>";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // txtAppNo
            // 
            this.txtAppNo.AutoSize = true;
            this.txtAppNo.Location = new System.Drawing.Point(126, 103);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(13, 20);
            this.txtAppNo.TabIndex = 7;
            this.txtAppNo.Text = ".";
            // 
            // AadharVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 467);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aadharStatus);
            this.Controls.Add(this.btnVerifyAadhar);
            this.Controls.Add(this.lblAppNo);
            this.Controls.Add(this.label1);
            this.Name = "AadharVerify";
            this.Text = "AadharVerify";
            this.Load += new System.EventHandler(this.AadharVerify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppNo;
        private System.Windows.Forms.Button btnVerifyAadhar;
        private System.Windows.Forms.Label aadharStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Label txtAppNo;
    }
}