using System.Drawing;

namespace webMANPad.Forms
{
    partial class ExceptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
            this.ERRORICON = new System.Windows.Forms.PictureBox();
            this.LBLEX = new System.Windows.Forms.Label();
            this.LBLMSG = new System.Windows.Forms.Label();
            this.LBLHR = new System.Windows.Forms.Label();
            this.BTN1 = new System.Windows.Forms.Button();
            this.LBLSOURCE = new System.Windows.Forms.Label();
            this.BTN2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ERRORICON)).BeginInit();
            this.SuspendLayout();
            // 
            // ERRORICON
            // 
            this.ERRORICON.Image = ((System.Drawing.Image)(resources.GetObject("ERRORICON.Image")));
            this.ERRORICON.Location = new System.Drawing.Point(12, 12);
            this.ERRORICON.Name = "ERRORICON";
            this.ERRORICON.Size = new System.Drawing.Size(32, 32);
            this.ERRORICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ERRORICON.TabIndex = 0;
            this.ERRORICON.TabStop = false;
            // 
            // LBLEX
            // 
            this.LBLEX.AutoSize = true;
            this.LBLEX.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LBLEX.Location = new System.Drawing.Point(49, 18);
            this.LBLEX.Name = "LBLEX";
            this.LBLEX.Size = new System.Drawing.Size(130, 21);
            this.LBLEX.TabIndex = 1;
            this.LBLEX.Text = "System.Exception";
            // 
            // LBLMSG
            // 
            this.LBLMSG.AutoSize = true;
            this.LBLMSG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LBLMSG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LBLMSG.Location = new System.Drawing.Point(0, 103);
            this.LBLMSG.Name = "LBLMSG";
            this.LBLMSG.Size = new System.Drawing.Size(69, 17);
            this.LBLMSG.TabIndex = 2;
            this.LBLMSG.Text = "Message:";
            // 
            // LBLHR
            // 
            this.LBLHR.AutoSize = true;
            this.LBLHR.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LBLHR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LBLHR.Location = new System.Drawing.Point(0, 86);
            this.LBLHR.Name = "LBLHR";
            this.LBLHR.Size = new System.Drawing.Size(62, 17);
            this.LBLHR.TabIndex = 3;
            this.LBLHR.Text = "HResult:";
            // 
            // BTN1
            // 
            this.BTN1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTN1.Location = new System.Drawing.Point(0, 120);
            this.BTN1.Name = "BTN1";
            this.BTN1.Size = new System.Drawing.Size(401, 23);
            this.BTN1.TabIndex = 4;
            this.BTN1.Text = "CONTINUE";
            this.BTN1.UseVisualStyleBackColor = true;
            this.BTN1.Click += new System.EventHandler(this.BTN1_Click);
            // 
            // LBLSOURCE
            // 
            this.LBLSOURCE.AutoSize = true;
            this.LBLSOURCE.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LBLSOURCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LBLSOURCE.Location = new System.Drawing.Point(0, 69);
            this.LBLSOURCE.Name = "LBLSOURCE";
            this.LBLSOURCE.Size = new System.Drawing.Size(57, 17);
            this.LBLSOURCE.TabIndex = 5;
            this.LBLSOURCE.Text = "Source:";
            this.LBLSOURCE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN2
            // 
            this.BTN2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTN2.Location = new System.Drawing.Point(0, 143);
            this.BTN2.Name = "BTN2";
            this.BTN2.Size = new System.Drawing.Size(401, 23);
            this.BTN2.TabIndex = 6;
            this.BTN2.Text = "EXIT";
            this.BTN2.UseVisualStyleBackColor = true;
            this.BTN2.Click += new System.EventHandler(this.BTN2_Click);
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(401, 166);
            this.Controls.Add(this.LBLSOURCE);
            this.Controls.Add(this.LBLHR);
            this.Controls.Add(this.LBLMSG);
            this.Controls.Add(this.LBLEX);
            this.Controls.Add(this.ERRORICON);
            this.Controls.Add(this.BTN1);
            this.Controls.Add(this.BTN2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExceptionForm";
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.ERRORICON)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ERRORICON;
        private System.Windows.Forms.Label LBLEX;
        private System.Windows.Forms.Label LBLMSG;
        private System.Windows.Forms.Label LBLHR;
        private System.Windows.Forms.Button BTN1;
        private System.Windows.Forms.Label LBLSOURCE;
        private System.Windows.Forms.Button BTN2;
    }
}