namespace Railway {
    partial class SGroup {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SGroup));
            this.table = new System.Windows.Forms.DataGridView();
            this.infoStrip = new System.Windows.Forms.ToolStrip();
            this.autorName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autorGroup = new System.Windows.Forms.ToolStripLabel();
            this.manipulationButton = new System.Windows.Forms.Button();
            this.chooseTable = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deletedValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseTableLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.infoStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletedValue)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.AllowUserToAddRows = false;
            this.table.AllowUserToDeleteRows = false;
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.Color.White;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(13, 153);
            this.table.Margin = new System.Windows.Forms.Padding(4);
            this.table.Name = "table";
            this.table.ReadOnly = true;
            this.table.Size = new System.Drawing.Size(858, 395);
            this.table.TabIndex = 0;
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
            this.infoStrip.TabIndex = 1;
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
            // manipulationButton
            // 
            this.manipulationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.manipulationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manipulationButton.ForeColor = System.Drawing.Color.White;
            this.manipulationButton.Location = new System.Drawing.Point(480, 31);
            this.manipulationButton.Name = "manipulationButton";
            this.manipulationButton.Size = new System.Drawing.Size(294, 32);
            this.manipulationButton.TabIndex = 2;
            this.manipulationButton.Text = "Добавить/Изменить";
            this.manipulationButton.UseVisualStyleBackColor = false;
            // 
            // chooseTable
            // 
            this.chooseTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseTable.FormattingEnabled = true;
            this.chooseTable.Items.AddRange(new object[] {
            "Студенты",
            "Успеваемость",
            "Дисциплины"});
            this.chooseTable.Location = new System.Drawing.Point(654, 119);
            this.chooseTable.Name = "chooseTable";
            this.chooseTable.Size = new System.Drawing.Size(217, 27);
            this.chooseTable.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(780, 31);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 32);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // deletedValue
            // 
            this.deletedValue.Font = new System.Drawing.Font("Consolas", 13.4F);
            this.deletedValue.Location = new System.Drawing.Point(780, 68);
            this.deletedValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.deletedValue.Name = "deletedValue";
            this.deletedValue.Size = new System.Drawing.Size(90, 28);
            this.deletedValue.TabIndex = 4;
            this.deletedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "SGroup";
            // 
            // chooseTableLabel
            // 
            this.chooseTableLabel.AutoSize = true;
            this.chooseTableLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chooseTableLabel.ForeColor = System.Drawing.Color.White;
            this.chooseTableLabel.Location = new System.Drawing.Point(648, 107);
            this.chooseTableLabel.Name = "chooseTableLabel";
            this.chooseTableLabel.Size = new System.Drawing.Size(126, 19);
            this.chooseTableLabel.TabIndex = 8;
            this.chooseTableLabel.Text = "Выбор таблицы";
            // 
            // SGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.chooseTableLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deletedValue);
            this.Controls.Add(this.chooseTable);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.manipulationButton);
            this.Controls.Add(this.infoStrip);
            this.Controls.Add(this.table);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "SGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SGroup | Главное меню";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.infoStrip.ResumeLayout(false);
            this.infoStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletedValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.ToolStrip infoStrip;
        private System.Windows.Forms.ToolStripLabel autorName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel autorGroup;
        private System.Windows.Forms.Button manipulationButton;
        private System.Windows.Forms.ComboBox chooseTable;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.NumericUpDown deletedValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label chooseTableLabel;
    }
}

