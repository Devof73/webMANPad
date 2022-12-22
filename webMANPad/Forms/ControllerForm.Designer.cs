namespace webMANPad
{
    partial class ControllerForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerForm));
            this.PANEL_CONTROLLER = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonModesReset = new System.Windows.Forms.ToolStripDropDownButton();
            this.LABEL_INFO = new System.Windows.Forms.Label();
            this.LABEL_MOUSEDIR = new System.Windows.Forms.Label();
            this.LABEL_CONT = new System.Windows.Forms.Label();
            this.MOUSE_HANDLER = new Guna.UI2.WinForms.Guna2MouseStateHandler(this.components);
            this.LBLKEYBOARDAS = new System.Windows.Forms.ToolStripStatusLabel();
            this.PANEL_CONTROLLER.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PANEL_CONTROLLER
            // 
            this.PANEL_CONTROLLER.Controls.Add(this.statusStrip1);
            this.PANEL_CONTROLLER.Controls.Add(this.LABEL_INFO);
            this.PANEL_CONTROLLER.Controls.Add(this.LABEL_MOUSEDIR);
            this.PANEL_CONTROLLER.Controls.Add(this.LABEL_CONT);
            this.PANEL_CONTROLLER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PANEL_CONTROLLER.Location = new System.Drawing.Point(0, 0);
            this.PANEL_CONTROLLER.Name = "PANEL_CONTROLLER";
            this.PANEL_CONTROLLER.Size = new System.Drawing.Size(587, 373);
            this.PANEL_CONTROLLER.TabIndex = 0;
            this.PANEL_CONTROLLER.Click += new System.EventHandler(this.PANEL_CONTROLLER_Click);
            this.PANEL_CONTROLLER.Enter += new System.EventHandler(this.PANEL_CONTROLLER_Enter);
            this.PANEL_CONTROLLER.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PANEL_CONTROLLER_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelConnection,
            this.ButtonModesReset,
            this.LBLKEYBOARDAS});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(587, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelConnection
            // 
            this.LabelConnection.Name = "LabelConnection";
            this.LabelConnection.Size = new System.Drawing.Size(85, 17);
            this.LabelConnection.Text = "NotConnected";
            // 
            // ButtonModesReset
            // 
            this.ButtonModesReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonModesReset.Image = ((System.Drawing.Image)(resources.GetObject("ButtonModesReset.Image")));
            this.ButtonModesReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonModesReset.Name = "ButtonModesReset";
            this.ButtonModesReset.Size = new System.Drawing.Size(93, 20);
            this.ButtonModesReset.Text = "Re-Set Modes";
            this.ButtonModesReset.ToolTipText = "Click Here To Reset: \r\n-Mouse Emulation Profile\r\n-Keyboard Press Profile\r\n-Mouse " +
    "Click Emulation Profile\r\n";
            this.ButtonModesReset.Click += new System.EventHandler(this.ButtonModesReset_Click);
            // 
            // LABEL_INFO
            // 
            this.LABEL_INFO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LABEL_INFO.AutoSize = true;
            this.LABEL_INFO.Location = new System.Drawing.Point(3, 26);
            this.LABEL_INFO.Name = "LABEL_INFO";
            this.LABEL_INFO.Size = new System.Drawing.Size(39, 13);
            this.LABEL_INFO.TabIndex = 2;
            this.LABEL_INFO.Text = "NoInfo";
            this.LABEL_INFO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LABEL_MOUSEDIR
            // 
            this.LABEL_MOUSEDIR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LABEL_MOUSEDIR.AutoSize = true;
            this.LABEL_MOUSEDIR.Location = new System.Drawing.Point(232, 47);
            this.LABEL_MOUSEDIR.Name = "LABEL_MOUSEDIR";
            this.LABEL_MOUSEDIR.Size = new System.Drawing.Size(117, 13);
            this.LABEL_MOUSEDIR.TabIndex = 1;
            this.LABEL_MOUSEDIR.Text = "Mouse Position: Debug";
            this.LABEL_MOUSEDIR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LABEL_CONT
            // 
            this.LABEL_CONT.AutoSize = true;
            this.LABEL_CONT.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.LABEL_CONT.Location = new System.Drawing.Point(3, 0);
            this.LABEL_CONT.Name = "LABEL_CONT";
            this.LABEL_CONT.Size = new System.Drawing.Size(149, 26);
            this.LABEL_CONT.TabIndex = 0;
            this.LABEL_CONT.Text = "Hold Escape + SHIFT To Exit\r\nClick for re-bound";
            // 
            // MOUSE_HANDLER
            // 
            this.MOUSE_HANDLER.IdleState += new System.EventHandler(this.MOUSE_HANDLER_IdleState);
            // 
            // LBLKEYBOARDAS
            // 
            this.LBLKEYBOARDAS.Name = "LBLKEYBOARDAS";
            this.LBLKEYBOARDAS.Size = new System.Drawing.Size(57, 17);
            this.LBLKEYBOARDAS.Text = "Keyboard";
            this.LBLKEYBOARDAS.Click += new System.EventHandler(this.LBLKEYBOARDAS_Click);
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 373);
            this.Controls.Add(this.PANEL_CONTROLLER);
            this.Name = "ControllerForm";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.ControllerForm_Activated);
            this.Deactivate += new System.EventHandler(this.ControllerForm_Deactivate);
            this.Load += new System.EventHandler(this.ControllerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Leave += new System.EventHandler(this.ControllerForm_Leave);
            this.Resize += new System.EventHandler(this.ControllerForm_Resize);
            this.PANEL_CONTROLLER.ResumeLayout(false);
            this.PANEL_CONTROLLER.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PANEL_CONTROLLER;
        private System.Windows.Forms.Label LABEL_CONT;
        private Guna.UI2.WinForms.Guna2MouseStateHandler MOUSE_HANDLER;
        private System.Windows.Forms.Label LABEL_MOUSEDIR;
        private System.Windows.Forms.Label LABEL_INFO;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelConnection;
        private System.Windows.Forms.ToolStripDropDownButton ButtonModesReset;
        private System.Windows.Forms.ToolStripStatusLabel LBLKEYBOARDAS;
    }
}

