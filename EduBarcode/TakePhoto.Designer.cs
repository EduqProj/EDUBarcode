
namespace EduBarcode
{
    partial class TakePhoto
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnTakePhoto = new System.Windows.Forms.Button();
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.picAppPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAppPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(18, 14);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(390, 36);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Please wait photo uploading";
            this.lblMsg.Visible = false;
            // 
            // btnTakePhoto
            // 
            this.btnTakePhoto.Location = new System.Drawing.Point(26, 506);
            this.btnTakePhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTakePhoto.Name = "btnTakePhoto";
            this.btnTakePhoto.Size = new System.Drawing.Size(147, 49);
            this.btnTakePhoto.TabIndex = 1;
            this.btnTakePhoto.Text = "Take Photo";
            this.btnTakePhoto.UseVisualStyleBackColor = true;
            this.btnTakePhoto.Click += new System.EventHandler(this.btnTakePhoto_Click);
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(26, 71);
            this.picCapture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(589, 399);
            this.picCapture.TabIndex = 2;
            this.picCapture.TabStop = false;
            // 
            // picAppPhoto
            // 
            this.picAppPhoto.Location = new System.Drawing.Point(689, 71);
            this.picAppPhoto.Name = "picAppPhoto";
            this.picAppPhoto.Size = new System.Drawing.Size(450, 399);
            this.picAppPhoto.TabIndex = 3;
            this.picAppPhoto.TabStop = false;
            // 
            // TakePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.ControlBox = false;
            this.Controls.Add(this.picAppPhoto);
            this.Controls.Add(this.picCapture);
            this.Controls.Add(this.btnTakePhoto);
            this.Controls.Add(this.lblMsg);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TakePhoto";
            this.Text = "TakePhoto";
            this.Load += new System.EventHandler(this.TakePhoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAppPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnTakePhoto;
        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.PictureBox picAppPhoto;
    }
}