namespace webMANPad.Forms
{
    partial class KeyboardAssignmentForm
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
            this.ListBoxAssignments = new System.Windows.Forms.ListBox();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CBX_KEY = new System.Windows.Forms.ComboBox();
            this.CBX_PS3KEY = new System.Windows.Forms.ComboBox();
            this.ButtonAddNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonDeleteSel = new System.Windows.Forms.Button();
            this.ButtonLoadByFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxAssignments
            // 
            this.ListBoxAssignments.FormattingEnabled = true;
            this.ListBoxAssignments.Location = new System.Drawing.Point(12, 12);
            this.ListBoxAssignments.Name = "ListBoxAssignments";
            this.ListBoxAssignments.Size = new System.Drawing.Size(282, 134);
            this.ListBoxAssignments.TabIndex = 0;
            this.ListBoxAssignments.SelectedIndexChanged += new System.EventHandler(this.LBXUSER_SelectedIndexChanged);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(223, 312);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSaveClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CBX_KEY
            // 
            this.CBX_KEY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_KEY.FormattingEnabled = true;
            this.CBX_KEY.Location = new System.Drawing.Point(12, 152);
            this.CBX_KEY.Name = "CBX_KEY";
            this.CBX_KEY.Size = new System.Drawing.Size(118, 21);
            this.CBX_KEY.TabIndex = 4;
            // 
            // CBX_PS3KEY
            // 
            this.CBX_PS3KEY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_PS3KEY.FormattingEnabled = true;
            this.CBX_PS3KEY.Location = new System.Drawing.Point(178, 152);
            this.CBX_PS3KEY.Name = "CBX_PS3KEY";
            this.CBX_PS3KEY.Size = new System.Drawing.Size(118, 21);
            this.CBX_PS3KEY.TabIndex = 5;
            // 
            // ButtonAddNew
            // 
            this.ButtonAddNew.Location = new System.Drawing.Point(12, 179);
            this.ButtonAddNew.Name = "ButtonAddNew";
            this.ButtonAddNew.Size = new System.Drawing.Size(284, 23);
            this.ButtonAddNew.TabIndex = 6;
            this.ButtonAddNew.Text = "Add New Assignment";
            this.ButtonAddNew.UseVisualStyleBackColor = true;
            this.ButtonAddNew.Click += new System.EventHandler(this.ButtonAddNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "➡";
            // 
            // ButtonDeleteSel
            // 
            this.ButtonDeleteSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDeleteSel.Location = new System.Drawing.Point(12, 208);
            this.ButtonDeleteSel.Name = "ButtonDeleteSel";
            this.ButtonDeleteSel.Size = new System.Drawing.Size(284, 28);
            this.ButtonDeleteSel.TabIndex = 8;
            this.ButtonDeleteSel.Text = "Delete Selected Assignment From List";
            this.ButtonDeleteSel.UseVisualStyleBackColor = true;
            this.ButtonDeleteSel.Click += new System.EventHandler(this.ButtonDeleteClicked);
            // 
            // ButtonLoadByFile
            // 
            this.ButtonLoadByFile.Location = new System.Drawing.Point(12, 242);
            this.ButtonLoadByFile.Name = "ButtonLoadByFile";
            this.ButtonLoadByFile.Size = new System.Drawing.Size(284, 23);
            this.ButtonLoadByFile.TabIndex = 9;
            this.ButtonLoadByFile.Text = "Load Assignments From File";
            this.ButtonLoadByFile.UseVisualStyleBackColor = true;
            this.ButtonLoadByFile.Click += new System.EventHandler(this.ButtonLoadByFile_Click);
            // 
            // KeyboardAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 347);
            this.Controls.Add(this.ButtonLoadByFile);
            this.Controls.Add(this.ButtonDeleteSel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonAddNew);
            this.Controls.Add(this.CBX_PS3KEY);
            this.Controls.Add(this.CBX_KEY);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ListBoxAssignments);
            this.Name = "KeyboardAssignmentForm";
            this.Text = "KeyboardAssignmentForm";
            this.Load += new System.EventHandler(this.KeyboardAssignmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxAssignments;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox CBX_KEY;
        private System.Windows.Forms.ComboBox CBX_PS3KEY;
        private System.Windows.Forms.Button ButtonAddNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonDeleteSel;
        private System.Windows.Forms.Button ButtonLoadByFile;
    }
}