namespace webMANPad.Forms
{
    partial class ModeSetForm
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
            this.CBX1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonNo = new System.Windows.Forms.Button();
            this.CBX2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CBX3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CBX1
            // 
            this.CBX1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX1.FormattingEnabled = true;
            this.CBX1.Location = new System.Drawing.Point(12, 25);
            this.CBX1.Name = "CBX1";
            this.CBX1.Size = new System.Drawing.Size(121, 21);
            this.CBX1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Mouse Mode:";
            // 
            // ButtonOk
            // 
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.Location = new System.Drawing.Point(91, 160);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "Set";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonNo
            // 
            this.ButtonNo.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.ButtonNo.Location = new System.Drawing.Point(10, 160);
            this.ButtonNo.Name = "ButtonNo";
            this.ButtonNo.Size = new System.Drawing.Size(75, 23);
            this.ButtonNo.TabIndex = 5;
            this.ButtonNo.Text = "Cancel";
            this.ButtonNo.UseVisualStyleBackColor = true;
            this.ButtonNo.Click += new System.EventHandler(this.ButtonCancelClicked);
            // 
            // CBX2
            // 
            this.CBX2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX2.FormattingEnabled = true;
            this.CBX2.Location = new System.Drawing.Point(12, 71);
            this.CBX2.Name = "CBX2";
            this.CBX2.Size = new System.Drawing.Size(121, 21);
            this.CBX2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Keyboard Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Mouse Wheel Mode";
            // 
            // CBX3
            // 
            this.CBX3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX3.FormattingEnabled = true;
            this.CBX3.Location = new System.Drawing.Point(12, 120);
            this.CBX3.Name = "CBX3";
            this.CBX3.Size = new System.Drawing.Size(121, 21);
            this.CBX3.TabIndex = 6;
            // 
            // ModeSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 219);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBX3);
            this.Controls.Add(this.ButtonNo);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBX2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBX1);
            this.Name = "ModeSetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Set Modes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonNo;
        private System.Windows.Forms.ComboBox CBX2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBX3;
    }
}