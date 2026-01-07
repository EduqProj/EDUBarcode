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
            this.btnAadharVerifyASYNC = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAadharToken = new System.Windows.Forms.Label();
            this.txtCandAadharToken = new System.Windows.Forms.TextBox();
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
            this.btnVerifyAadhar.Location = new System.Drawing.Point(302, 208);
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
            this.label2.Location = new System.Drawing.Point(485, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(489, 135);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(390, 26);
            this.txtComment.TabIndex = 5;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(489, 177);
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
            // btnAadharVerifyASYNC
            // 
            this.btnAadharVerifyASYNC.Location = new System.Drawing.Point(95, 213);
            this.btnAadharVerifyASYNC.Name = "btnAadharVerifyASYNC";
            this.btnAadharVerifyASYNC.Size = new System.Drawing.Size(191, 35);
            this.btnAadharVerifyASYNC.TabIndex = 8;
            this.btnAadharVerifyASYNC.Text = "Verify Aadhar Async";
            this.btnAadharVerifyASYNC.UseVisualStyleBackColor = true;
            this.btnAadharVerifyASYNC.Click += new System.EventHandler(this.btnAadharVerifyASYNC_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(204, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = " ";
            // 
            // lblAadharToken
            // 
            this.lblAadharToken.AutoSize = true;
            this.lblAadharToken.Location = new System.Drawing.Point(64, 143);
            this.lblAadharToken.Name = "lblAadharToken";
            this.lblAadharToken.Size = new System.Drawing.Size(109, 20);
            this.lblAadharToken.TabIndex = 10;
            this.lblAadharToken.Text = "Aadhar/Token";
            // 
            // txtCandAadharToken
            // 
            this.txtCandAadharToken.Location = new System.Drawing.Point(179, 140);
            this.txtCandAadharToken.Name = "txtCandAadharToken";
            this.txtCandAadharToken.Size = new System.Drawing.Size(194, 26);
            this.txtCandAadharToken.TabIndex = 11;
            // 
            // AadharVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 467);
            this.Controls.Add(this.txtCandAadharToken);
            this.Controls.Add(this.lblAadharToken);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAadharVerifyASYNC);
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
        private System.Windows.Forms.Button btnAadharVerifyASYNC;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAadharToken;
        private System.Windows.Forms.TextBox txtCandAadharToken;
    }
}