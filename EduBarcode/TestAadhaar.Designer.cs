namespace EduBarcode
{
    partial class TestAadhaar
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
            this.txtAppNo = new System.Windows.Forms.TextBox();
            this.btnTestInovativeAadhaar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCandAadharToken = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roll No";
            // 
            // txtAppNo
            // 
            this.txtAppNo.Location = new System.Drawing.Point(188, 49);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(246, 26);
            this.txtAppNo.TabIndex = 1;
            // 
            // btnTestInovativeAadhaar
            // 
            this.btnTestInovativeAadhaar.Location = new System.Drawing.Point(188, 140);
            this.btnTestInovativeAadhaar.Name = "btnTestInovativeAadhaar";
            this.btnTestInovativeAadhaar.Size = new System.Drawing.Size(176, 37);
            this.btnTestInovativeAadhaar.TabIndex = 2;
            this.btnTestInovativeAadhaar.Text = "Test Aadhaar";
            this.btnTestInovativeAadhaar.UseVisualStyleBackColor = true;
            this.btnTestInovativeAadhaar.Click += new System.EventHandler(this.btnTestInovativeAadhaar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(114, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 20);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Token/Aadhar No.";
            // 
            // txtCandAadharToken
            // 
            this.txtCandAadharToken.Location = new System.Drawing.Point(188, 92);
            this.txtCandAadharToken.Name = "txtCandAadharToken";
            this.txtCandAadharToken.Size = new System.Drawing.Size(246, 26);
            this.txtCandAadharToken.TabIndex = 6;
            // 
            // TestAadhaar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCandAadharToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnTestInovativeAadhaar);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.label1);
            this.Name = "TestAadhaar";
            this.Text = "TestAadhaar";
            this.Load += new System.EventHandler(this.TestAadhaar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAppNo;
        private System.Windows.Forms.Button btnTestInovativeAadhaar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCandAadharToken;
    }
}