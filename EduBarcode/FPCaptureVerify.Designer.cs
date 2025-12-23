namespace EduBarcode
{
    partial class FPCaptureVerify
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
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.comment = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNRollNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(45, 95);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(140, 50);
            this.btnVerify.TabIndex = 0;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(349, 110);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(127, 50);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "Continue >>";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(349, 65);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(277, 26);
            this.comment.TabIndex = 2;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(349, 39);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(86, 20);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "Comments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "RollNo: ";
            // 
            // lblNRollNo
            // 
            this.lblNRollNo.AutoSize = true;
            this.lblNRollNo.Location = new System.Drawing.Point(116, 39);
            this.lblNRollNo.Name = "lblNRollNo";
            this.lblNRollNo.Size = new System.Drawing.Size(0, 20);
            this.lblNRollNo.TabIndex = 5;
            // 
            // FPCaptureVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNRollNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnVerify);
            this.Name = "FPCaptureVerify";
            this.Text = "FPCaptureVerify";
            this.Load += new System.EventHandler(this.FPCaptureVerify_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNRollNo;
    }
}