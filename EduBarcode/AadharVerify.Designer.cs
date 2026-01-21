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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlReason = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "App No:";
            // 
            // lblAppNo
            // 
            this.lblAppNo.AutoSize = true;
            this.lblAppNo.Location = new System.Drawing.Point(149, 74);
            this.lblAppNo.Name = "lblAppNo";
            this.lblAppNo.Size = new System.Drawing.Size(0, 20);
            this.lblAppNo.TabIndex = 1;
            // 
            // btnVerifyAadhar
            // 
            this.btnVerifyAadhar.Location = new System.Drawing.Point(250, 207);
            this.btnVerifyAadhar.Name = "btnVerifyAadhar";
            this.btnVerifyAadhar.Size = new System.Drawing.Size(197, 44);
            this.btnVerifyAadhar.TabIndex = 2;
            this.btnVerifyAadhar.Text = "Verify Aadhar SYNC";
            this.btnVerifyAadhar.UseVisualStyleBackColor = true;
            this.btnVerifyAadhar.Visible = false;
            this.btnVerifyAadhar.Click += new System.EventHandler(this.btnVerifyAadhar_Click);
            // 
            // aadharStatus
            // 
            this.aadharStatus.AutoSize = true;
            this.aadharStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aadharStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.aadharStatus.Location = new System.Drawing.Point(23, 25);
            this.aadharStatus.Name = "aadharStatus";
            this.aadharStatus.Size = new System.Drawing.Size(153, 26);
            this.aadharStatus.TabIndex = 3;
            this.aadharStatus.Text = "AadharStatus";
            this.aadharStatus.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(87, 46);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(279, 26);
            this.txtComment.TabIndex = 5;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(87, 78);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(131, 48);
            this.btnSkip.TabIndex = 6;
            this.btnSkip.Text = "Continue >>";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // txtAppNo
            // 
            this.txtAppNo.AutoSize = true;
            this.txtAppNo.Location = new System.Drawing.Point(154, 74);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(13, 20);
            this.txtAppNo.TabIndex = 7;
            this.txtAppNo.Text = ".";
            // 
            // btnAadharVerifyASYNC
            // 
            this.btnAadharVerifyASYNC.Location = new System.Drawing.Point(149, 163);
            this.btnAadharVerifyASYNC.Name = "btnAadharVerifyASYNC";
            this.btnAadharVerifyASYNC.Size = new System.Drawing.Size(191, 44);
            this.btnAadharVerifyASYNC.TabIndex = 8;
            this.btnAadharVerifyASYNC.Text = "Verify Aadhar Async";
            this.btnAadharVerifyASYNC.UseVisualStyleBackColor = true;
            this.btnAadharVerifyASYNC.Click += new System.EventHandler(this.btnAadharVerifyASYNC_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(235, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(15, 23);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = " ";
            // 
            // lblAadharToken
            // 
            this.lblAadharToken.AutoSize = true;
            this.lblAadharToken.Location = new System.Drawing.Point(34, 114);
            this.lblAadharToken.Name = "lblAadharToken";
            this.lblAadharToken.Size = new System.Drawing.Size(109, 20);
            this.lblAadharToken.TabIndex = 10;
            this.lblAadharToken.Text = "Aadhar/Token";
            // 
            // txtCandAadharToken
            // 
            this.txtCandAadharToken.Location = new System.Drawing.Point(149, 111);
            this.txtCandAadharToken.Name = "txtCandAadharToken";
            this.txtCandAadharToken.Size = new System.Drawing.Size(194, 26);
            this.txtCandAadharToken.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(492, 74);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 24);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Bye Pass";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ddlReason);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.btnSkip);
            this.panel1.Location = new System.Drawing.Point(492, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 142);
            this.panel1.TabIndex = 13;
            this.panel1.Visible = false;
            // 
            // ddlReason
            // 
            this.ddlReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Items.AddRange(new object[] {
            "Aadhaar no. or token not available.",
            "Server is not responding.",
            "Candidate finger is having problem.",
            "Finger print sensor not detecting."});
            this.ddlReason.Location = new System.Drawing.Point(87, 12);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(279, 28);
            this.ddlReason.TabIndex = 7;
            // 
            // AadharVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtCandAadharToken);
            this.Controls.Add(this.lblAadharToken);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnAadharVerifyASYNC);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.aadharStatus);
            this.Controls.Add(this.btnVerifyAadhar);
            this.Controls.Add(this.lblAppNo);
            this.Controls.Add(this.label1);
            this.Name = "AadharVerify";
            this.Text = "AadharVerify";
            this.Load += new System.EventHandler(this.AadharVerify_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlReason;
    }
}