namespace Railway {
    partial class Railway {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Railway));
            this.table = new System.Windows.Forms.DataGridView();
            this.infoStrip = new System.Windows.Forms.ToolStrip();
            this.autorName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autorGroup = new System.Windows.Forms.ToolStripLabel();
            this.addChangeButton = new System.Windows.Forms.Button();
            this.chooseTable = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deletingNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.procedureArgument = new System.Windows.Forms.TextBox();
            this.procedureButton = new System.Windows.Forms.Button();
            this.chooseTableLabel = new System.Windows.Forms.Label();
            this.aboutProcedureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.infoStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletingNumber)).BeginInit();
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
            this.table.Size = new System.Drawing.Size(1158, 395);
            this.table.TabIndex = 0;
            // 
            // infoStrip
            // 
            this.infoStrip.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorName,
            this.toolStripSeparator1,
            this.autorGroup});
            this.infoStrip.Location = new System.Drawing.Point(0, 0);
            this.infoStrip.Name = "infoStrip";
            this.infoStrip.Size = new System.Drawing.Size(1184, 25);
            this.infoStrip.TabIndex = 1;
            this.infoStrip.Text = "toolStrip1";
            // 
            // autorName
            // 
            this.autorName.Name = "autorName";
            this.autorName.Size = new System.Drawing.Size(91, 22);
            this.autorName.Text = "Ульянов А.В.";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // autorGroup
            // 
            this.autorGroup.Name = "autorGroup";
            this.autorGroup.Size = new System.Drawing.Size(63, 22);
            this.autorGroup.Text = "ПКсп-117";
            // 
            // addChangeButton
            // 
            this.addChangeButton.BackColor = System.Drawing.Color.Teal;
            this.addChangeButton.Location = new System.Drawing.Point(544, 31);
            this.addChangeButton.Name = "addChangeButton";
            this.addChangeButton.Size = new System.Drawing.Size(294, 32);
            this.addChangeButton.TabIndex = 2;
            this.addChangeButton.Text = "Добавить/Изменить";
            this.addChangeButton.UseVisualStyleBackColor = false;
            // 
            // chooseTable
            // 
            this.chooseTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseTable.FormattingEnabled = true;
            this.chooseTable.Items.AddRange(new object[] {
            "Люди",
            "Поезда",
            "Типы поездов",
            "Железнодорожные билеты"});
            this.chooseTable.Location = new System.Drawing.Point(955, 119);
            this.chooseTable.Name = "chooseTable";
            this.chooseTable.Size = new System.Drawing.Size(217, 27);
            this.chooseTable.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Teal;
            this.deleteButton.Location = new System.Drawing.Point(1081, 31);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 32);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // deletingNumber
            // 
            this.deletingNumber.Font = new System.Drawing.Font("Consolas", 13.4F);
            this.deletingNumber.Location = new System.Drawing.Point(1081, 68);
            this.deletingNumber.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.deletingNumber.Name = "deletingNumber";
            this.deletingNumber.Size = new System.Drawing.Size(90, 28);
            this.deletingNumber.TabIndex = 4;
            this.deletingNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(41, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "RAILWAY TICKETS";
            // 
            // procedureArgument
            // 
            this.procedureArgument.Location = new System.Drawing.Point(844, 68);
            this.procedureArgument.Multiline = true;
            this.procedureArgument.Name = "procedureArgument";
            this.procedureArgument.Size = new System.Drawing.Size(212, 27);
            this.procedureArgument.TabIndex = 6;
            this.procedureArgument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // procedureButton
            // 
            this.procedureButton.BackColor = System.Drawing.Color.Teal;
            this.procedureButton.Location = new System.Drawing.Point(844, 31);
            this.procedureButton.Name = "procedureButton";
            this.procedureButton.Size = new System.Drawing.Size(173, 32);
            this.procedureButton.TabIndex = 7;
            this.procedureButton.Text = "Вызов процедуры";
            this.procedureButton.UseVisualStyleBackColor = false;
            // 
            // chooseTableLabel
            // 
            this.chooseTableLabel.AutoSize = true;
            this.chooseTableLabel.BackColor = System.Drawing.Color.Teal;
            this.chooseTableLabel.ForeColor = System.Drawing.Color.Black;
            this.chooseTableLabel.Location = new System.Drawing.Point(949, 107);
            this.chooseTableLabel.Name = "chooseTableLabel";
            this.chooseTableLabel.Size = new System.Drawing.Size(126, 19);
            this.chooseTableLabel.TabIndex = 8;
            this.chooseTableLabel.Text = "Выбор таблицы";
            // 
            // aboutProcedureButton
            // 
            this.aboutProcedureButton.BackColor = System.Drawing.Color.Teal;
            this.aboutProcedureButton.Location = new System.Drawing.Point(1023, 31);
            this.aboutProcedureButton.Name = "aboutProcedureButton";
            this.aboutProcedureButton.Size = new System.Drawing.Size(33, 32);
            this.aboutProcedureButton.TabIndex = 9;
            this.aboutProcedureButton.Text = "?";
            this.aboutProcedureButton.UseVisualStyleBackColor = false;
            // 
            // Railway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.aboutProcedureButton);
            this.Controls.Add(this.chooseTableLabel);
            this.Controls.Add(this.procedureButton);
            this.Controls.Add(this.procedureArgument);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deletingNumber);
            this.Controls.Add(this.chooseTable);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addChangeButton);
            this.Controls.Add(this.infoStrip);
            this.Controls.Add(this.table);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "Railway";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Железнодорожные билеты";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.infoStrip.ResumeLayout(false);
            this.infoStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deletingNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.ToolStrip infoStrip;
        private System.Windows.Forms.ToolStripLabel autorName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel autorGroup;
        private System.Windows.Forms.Button addChangeButton;
        private System.Windows.Forms.ComboBox chooseTable;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.NumericUpDown deletingNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox procedureArgument;
        private System.Windows.Forms.Button procedureButton;
        private System.Windows.Forms.Label chooseTableLabel;
        private System.Windows.Forms.Button aboutProcedureButton;
    }
}

