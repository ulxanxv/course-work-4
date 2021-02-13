namespace Railway {
    partial class Manipulation {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manipulation));
            this.infoStrip = new System.Windows.Forms.ToolStrip();
            this.autorName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autorGroup = new System.Windows.Forms.ToolStripLabel();
            this.studentPanel = new System.Windows.Forms.TabPage();
            this.manipulationControl = new System.Windows.Forms.TabControl();
            this.performancePanel = new System.Windows.Forms.TabPage();
            this.disciplinePanel = new System.Windows.Forms.TabPage();
            this.infoStrip.SuspendLayout();
            this.manipulationControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoStrip
            // 
            this.infoStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.infoStrip.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorName,
            this.toolStripSeparator1,
            this.autorGroup});
            this.infoStrip.Location = new System.Drawing.Point(0, 0);
            this.infoStrip.Name = "infoStrip";
            this.infoStrip.Size = new System.Drawing.Size(884, 25);
            this.infoStrip.TabIndex = 2;
            this.infoStrip.Text = "toolStrip1";
            // 
            // autorName
            // 
            this.autorName.ForeColor = System.Drawing.Color.White;
            this.autorName.Name = "autorName";
            this.autorName.Size = new System.Drawing.Size(210, 22);
            this.autorName.Text = "Ульянов А.В. и Аюбджанов Е.К.";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // autorGroup
            // 
            this.autorGroup.ForeColor = System.Drawing.Color.White;
            this.autorGroup.Name = "autorGroup";
            this.autorGroup.Size = new System.Drawing.Size(63, 22);
            this.autorGroup.Text = "ПКсп-117";
            // 
            // studentPanel
            // 
            this.studentPanel.Location = new System.Drawing.Point(4, 28);
            this.studentPanel.Name = "studentPanel";
            this.studentPanel.Padding = new System.Windows.Forms.Padding(3);
            this.studentPanel.Size = new System.Drawing.Size(852, 489);
            this.studentPanel.TabIndex = 2;
            this.studentPanel.Text = "Студент";
            this.studentPanel.UseVisualStyleBackColor = true;
            // 
            // manipulationControl
            // 
            this.manipulationControl.Controls.Add(this.studentPanel);
            this.manipulationControl.Controls.Add(this.performancePanel);
            this.manipulationControl.Controls.Add(this.disciplinePanel);
            this.manipulationControl.Location = new System.Drawing.Point(12, 28);
            this.manipulationControl.Name = "manipulationControl";
            this.manipulationControl.SelectedIndex = 0;
            this.manipulationControl.Size = new System.Drawing.Size(860, 521);
            this.manipulationControl.TabIndex = 3;
            // 
            // performancePanel
            // 
            this.performancePanel.Location = new System.Drawing.Point(4, 28);
            this.performancePanel.Name = "performancePanel";
            this.performancePanel.Padding = new System.Windows.Forms.Padding(3);
            this.performancePanel.Size = new System.Drawing.Size(852, 489);
            this.performancePanel.TabIndex = 3;
            this.performancePanel.Text = "Успеваемость";
            this.performancePanel.UseVisualStyleBackColor = true;
            // 
            // disciplinePanel
            // 
            this.disciplinePanel.Location = new System.Drawing.Point(4, 28);
            this.disciplinePanel.Name = "disciplinePanel";
            this.disciplinePanel.Padding = new System.Windows.Forms.Padding(3);
            this.disciplinePanel.Size = new System.Drawing.Size(852, 489);
            this.disciplinePanel.TabIndex = 4;
            this.disciplinePanel.Text = "Дисциплина";
            this.disciplinePanel.UseVisualStyleBackColor = true;
            // 
            // Manipulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.manipulationControl);
            this.Controls.Add(this.infoStrip);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Manipulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SGroup | Добавление и изменение";
            this.infoStrip.ResumeLayout(false);
            this.infoStrip.PerformLayout();
            this.manipulationControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip infoStrip;
        private System.Windows.Forms.ToolStripLabel autorName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel autorGroup;
        private System.Windows.Forms.TabPage studentPanel;
        private System.Windows.Forms.TabControl manipulationControl;
        private System.Windows.Forms.TabPage performancePanel;
        private System.Windows.Forms.TabPage disciplinePanel;
    }
}