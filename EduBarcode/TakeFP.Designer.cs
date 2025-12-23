
namespace EduBarcode
{
    partial class TakeFP
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOffCapture = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblNRollNo = new System.Windows.Forms.Label();
            this.lblNAdr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOffCapture);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.lblNRollNo);
            this.groupBox2.Controls.Add(this.lblNAdr);
            this.groupBox2.Location = new System.Drawing.Point(277, 48);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(338, 225);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finger Print";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnOffCapture
            // 
            this.btnOffCapture.Location = new System.Drawing.Point(29, 180);
            this.btnOffCapture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOffCapture.Name = "btnOffCapture";
            this.btnOffCapture.Size = new System.Drawing.Size(88, 23);
            this.btnOffCapture.TabIndex = 3;
            this.btnOffCapture.Text = "Capture";
            this.btnOffCapture.UseVisualStyleBackColor = true;
            this.btnOffCapture.Click += new System.EventHandler(this.btnOffCapture_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(29, 50);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 94);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblNRollNo
            // 
            this.lblNRollNo.AutoSize = true;
            this.lblNRollNo.Location = new System.Drawing.Point(83, 20);
            this.lblNRollNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNRollNo.Name = "lblNRollNo";
            this.lblNRollNo.Size = new System.Drawing.Size(45, 13);
            this.lblNRollNo.TabIndex = 1;
            this.lblNRollNo.Text = "RollNo";
            // 
            // lblNAdr
            // 
            this.lblNAdr.AutoSize = true;
            this.lblNAdr.Location = new System.Drawing.Point(26, 20);
            this.lblNAdr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNAdr.Name = "lblNAdr";
            this.lblNAdr.Size = new System.Drawing.Size(49, 13);
            this.lblNAdr.TabIndex = 0;
            this.lblNAdr.Text = "RollNo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(349, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Registration Desk";
            // 
            // TakeFP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 560);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TakeFP";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOffCapture;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblNRollNo;
        private System.Windows.Forms.Label lblNAdr;
        private System.Windows.Forms.Label label2;
    }
}

