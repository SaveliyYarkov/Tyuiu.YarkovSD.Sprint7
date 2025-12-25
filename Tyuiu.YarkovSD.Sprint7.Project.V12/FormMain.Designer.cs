namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    partial class FormMainYSD
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainYSD));
            dataGridViewComputersYSD = new DataGridView();
            ColumnModel = new DataGridViewTextBoxColumn();
            ColumnManufacturer = new DataGridViewTextBoxColumn();
            ColumnProcessor = new DataGridViewTextBoxColumn();
            ColumnClockSpeed = new DataGridViewTextBoxColumn();
            ColumnRAM = new DataGridViewTextBoxColumn();
            ColumnHDD = new DataGridViewTextBoxColumn();
            ColumnPrice = new DataGridViewTextBoxColumn();
            ColumnReleaseDate = new DataGridViewTextBoxColumn();
            statusStripMainYSD = new StatusStrip();
            toolStripStatusLabelInfoYSD = new ToolStripStatusLabel();
            toolStripStatusLabelCountYSD = new ToolStripStatusLabel();
            panelControls = new Panel();
            groupBoxSearch = new GroupBox();
            textBoxSearchYSD = new TextBox();
            buttonSearchYSD = new Button();
            groupBoxFilter = new GroupBox();
            comboBoxManufacturerYSD = new ComboBox();
            buttonFilterYSD = new Button();
            groupBoxSort = new GroupBox();
            comboBoxSortYSD = new ComboBox();
            buttonSortYSD = new Button();
            buttonLoadDataYSD = new Button();
            buttonSaveDataYSD = new Button();
            buttonAddComputerYSD = new Button();
            buttonEditComputerYSD = new Button();
            buttonDeleteComputerYSD = new Button();
            buttonStatisticsYSD = new Button();
            buttonChartYSD = new Button();
            buttonAboutYSD = new Button();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStripMainYSD = new MenuStrip();
            ((System.ComponentModel.ISupportInitialize)dataGridViewComputersYSD).BeginInit();
            statusStripMainYSD.SuspendLayout();
            panelControls.SuspendLayout();
            groupBoxSearch.SuspendLayout();
            groupBoxFilter.SuspendLayout();
            groupBoxSort.SuspendLayout();
            menuStripMainYSD.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewComputersYSD
            // 
            dataGridViewComputersYSD.AllowUserToAddRows = false;
            dataGridViewComputersYSD.AllowUserToDeleteRows = false;
            dataGridViewComputersYSD.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewComputersYSD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewComputersYSD.BackgroundColor = Color.OldLace;
            dataGridViewComputersYSD.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewComputersYSD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewComputersYSD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewComputersYSD.Columns.AddRange(new DataGridViewColumn[] { ColumnModel, ColumnManufacturer, ColumnProcessor, ColumnClockSpeed, ColumnRAM, ColumnHDD, ColumnPrice, ColumnReleaseDate });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewComputersYSD.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewComputersYSD.Location = new Point(14, 31);
            dataGridViewComputersYSD.Margin = new Padding(4, 3, 4, 3);
            dataGridViewComputersYSD.MultiSelect = false;
            dataGridViewComputersYSD.Name = "dataGridViewComputersYSD";
            dataGridViewComputersYSD.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewComputersYSD.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewComputersYSD.RowHeadersWidth = 25;
            dataGridViewComputersYSD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewComputersYSD.Size = new Size(845, 579);
            dataGridViewComputersYSD.TabIndex = 0;
            // 
            // ColumnModel
            // 
            ColumnModel.DataPropertyName = "Model";
            ColumnModel.FillWeight = 120F;
            ColumnModel.HeaderText = "Модель";
            ColumnModel.Name = "ColumnModel";
            ColumnModel.ReadOnly = true;
            // 
            // ColumnManufacturer
            // 
            ColumnManufacturer.DataPropertyName = "Manufacturer";
            ColumnManufacturer.FillWeight = 120F;
            ColumnManufacturer.HeaderText = "Производитель";
            ColumnManufacturer.Name = "ColumnManufacturer";
            ColumnManufacturer.ReadOnly = true;
            // 
            // ColumnProcessor
            // 
            ColumnProcessor.DataPropertyName = "Processor";
            ColumnProcessor.FillWeight = 120F;
            ColumnProcessor.HeaderText = "Процессор";
            ColumnProcessor.Name = "ColumnProcessor";
            ColumnProcessor.ReadOnly = true;
            // 
            // ColumnClockSpeed
            // 
            ColumnClockSpeed.DataPropertyName = "ClockSpeed";
            ColumnClockSpeed.FillWeight = 80F;
            ColumnClockSpeed.HeaderText = "Частота (ГГц)";
            ColumnClockSpeed.Name = "ColumnClockSpeed";
            ColumnClockSpeed.ReadOnly = true;
            // 
            // ColumnRAM
            // 
            ColumnRAM.DataPropertyName = "RAM";
            ColumnRAM.FillWeight = 70F;
            ColumnRAM.HeaderText = "ОЗУ (ГБ)";
            ColumnRAM.Name = "ColumnRAM";
            ColumnRAM.ReadOnly = true;
            // 
            // ColumnHDD
            // 
            ColumnHDD.DataPropertyName = "HDD";
            ColumnHDD.FillWeight = 70F;
            ColumnHDD.HeaderText = "ЖД (ГБ)";
            ColumnHDD.Name = "ColumnHDD";
            ColumnHDD.ReadOnly = true;
            // 
            // ColumnPrice
            // 
            ColumnPrice.DataPropertyName = "Price";
            ColumnPrice.FillWeight = 90F;
            ColumnPrice.HeaderText = "Цена (руб)";
            ColumnPrice.Name = "ColumnPrice";
            ColumnPrice.ReadOnly = true;
            // 
            // ColumnReleaseDate
            // 
            ColumnReleaseDate.DataPropertyName = "ReleaseDate";
            ColumnReleaseDate.FillWeight = 90F;
            ColumnReleaseDate.HeaderText = "Дата выпуска";
            ColumnReleaseDate.Name = "ColumnReleaseDate";
            ColumnReleaseDate.ReadOnly = true;
            // 
            // statusStripMainYSD
            // 
            statusStripMainYSD.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfoYSD, toolStripStatusLabelCountYSD });
            statusStripMainYSD.Location = new Point(0, 629);
            statusStripMainYSD.Name = "statusStripMainYSD";
            statusStripMainYSD.Padding = new Padding(1, 0, 16, 0);
            statusStripMainYSD.Size = new Size(1244, 22);
            statusStripMainYSD.TabIndex = 2;
            statusStripMainYSD.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfoYSD
            // 
            toolStripStatusLabelInfoYSD.Name = "toolStripStatusLabelInfoYSD";
            toolStripStatusLabelInfoYSD.Size = new Size(1162, 17);
            toolStripStatusLabelInfoYSD.Spring = true;
            toolStripStatusLabelInfoYSD.Text = "Готов к работе";
            toolStripStatusLabelInfoYSD.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelCountYSD
            // 
            toolStripStatusLabelCountYSD.Name = "toolStripStatusLabelCountYSD";
            toolStripStatusLabelCountYSD.Size = new Size(65, 17);
            toolStripStatusLabelCountYSD.Text = "Записей: 0";
            // 
            // panelControls
            // 
            panelControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelControls.BackColor = Color.OldLace;
            panelControls.BorderStyle = BorderStyle.FixedSingle;
            panelControls.Controls.Add(groupBoxSearch);
            panelControls.Controls.Add(groupBoxFilter);
            panelControls.Controls.Add(groupBoxSort);
            panelControls.Controls.Add(buttonLoadDataYSD);
            panelControls.Controls.Add(buttonSaveDataYSD);
            panelControls.Controls.Add(buttonAddComputerYSD);
            panelControls.Controls.Add(buttonEditComputerYSD);
            panelControls.Controls.Add(buttonDeleteComputerYSD);
            panelControls.Controls.Add(buttonStatisticsYSD);
            panelControls.Controls.Add(buttonChartYSD);
            panelControls.Controls.Add(buttonAboutYSD);
            panelControls.Location = new Point(866, 31);
            panelControls.Margin = new Padding(4, 3, 4, 3);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(365, 579);
            panelControls.TabIndex = 3;
            // 
            // groupBoxSearch
            // 
            groupBoxSearch.Controls.Add(textBoxSearchYSD);
            groupBoxSearch.Controls.Add(buttonSearchYSD);
            groupBoxSearch.Location = new Point(13, 13);
            groupBoxSearch.Margin = new Padding(4, 3, 4, 3);
            groupBoxSearch.Name = "groupBoxSearch";
            groupBoxSearch.Padding = new Padding(4, 3, 4, 3);
            groupBoxSearch.Size = new Size(338, 92);
            groupBoxSearch.TabIndex = 0;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "Поиск";
            // 
            // textBoxSearchYSD
            // 
            textBoxSearchYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxSearchYSD.Location = new Point(12, 29);
            textBoxSearchYSD.Margin = new Padding(4, 3, 4, 3);
            textBoxSearchYSD.Name = "textBoxSearchYSD";
            textBoxSearchYSD.Size = new Size(233, 21);
            textBoxSearchYSD.TabIndex = 0;
            textBoxSearchYSD.Text = "Введите модель...";
            // 
            // buttonSearchYSD
            // 
            buttonSearchYSD.Enabled = false;
            buttonSearchYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSearchYSD.Location = new Point(251, 27);
            buttonSearchYSD.Margin = new Padding(4, 3, 4, 3);
            buttonSearchYSD.Name = "buttonSearchYSD";
            buttonSearchYSD.Size = new Size(76, 29);
            buttonSearchYSD.TabIndex = 1;
            buttonSearchYSD.Text = "Найти";
            buttonSearchYSD.UseVisualStyleBackColor = true;
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(comboBoxManufacturerYSD);
            groupBoxFilter.Controls.Add(buttonFilterYSD);
            groupBoxFilter.Location = new Point(13, 115);
            groupBoxFilter.Margin = new Padding(4, 3, 4, 3);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Padding = new Padding(4, 3, 4, 3);
            groupBoxFilter.Size = new Size(338, 83);
            groupBoxFilter.TabIndex = 1;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Фильтр по производителю";
            // 
            // comboBoxManufacturerYSD
            // 
            comboBoxManufacturerYSD.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxManufacturerYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxManufacturerYSD.FormattingEnabled = true;
            comboBoxManufacturerYSD.Items.AddRange(new object[] { "Все производители" });
            comboBoxManufacturerYSD.Location = new Point(12, 29);
            comboBoxManufacturerYSD.Margin = new Padding(4, 3, 4, 3);
            comboBoxManufacturerYSD.Name = "comboBoxManufacturerYSD";
            comboBoxManufacturerYSD.Size = new Size(233, 23);
            comboBoxManufacturerYSD.TabIndex = 0;
            // 
            // buttonFilterYSD
            // 
            buttonFilterYSD.Enabled = false;
            buttonFilterYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonFilterYSD.Location = new Point(251, 27);
            buttonFilterYSD.Margin = new Padding(4, 3, 4, 3);
            buttonFilterYSD.Name = "buttonFilterYSD";
            buttonFilterYSD.Size = new Size(76, 29);
            buttonFilterYSD.TabIndex = 1;
            buttonFilterYSD.Text = "Фильтр";
            buttonFilterYSD.UseVisualStyleBackColor = true;
            // 
            // groupBoxSort
            // 
            groupBoxSort.Controls.Add(comboBoxSortYSD);
            groupBoxSort.Controls.Add(buttonSortYSD);
            groupBoxSort.Location = new Point(13, 204);
            groupBoxSort.Margin = new Padding(4, 3, 4, 3);
            groupBoxSort.Name = "groupBoxSort";
            groupBoxSort.Padding = new Padding(4, 3, 4, 3);
            groupBoxSort.Size = new Size(338, 77);
            groupBoxSort.TabIndex = 2;
            groupBoxSort.TabStop = false;
            groupBoxSort.Text = "Сортировка";
            // 
            // comboBoxSortYSD
            // 
            comboBoxSortYSD.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxSortYSD.FormattingEnabled = true;
            comboBoxSortYSD.Items.AddRange(new object[] { "По цене (возрастание)", "По цене (убывание)" });
            comboBoxSortYSD.Location = new Point(12, 29);
            comboBoxSortYSD.Margin = new Padding(4, 3, 4, 3);
            comboBoxSortYSD.Name = "comboBoxSortYSD";
            comboBoxSortYSD.Size = new Size(233, 23);
            comboBoxSortYSD.TabIndex = 0;
            // 
            // buttonSortYSD
            // 
            buttonSortYSD.Enabled = false;
            buttonSortYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSortYSD.Location = new Point(251, 27);
            buttonSortYSD.Margin = new Padding(4, 3, 4, 3);
            buttonSortYSD.Name = "buttonSortYSD";
            buttonSortYSD.Size = new Size(76, 29);
            buttonSortYSD.TabIndex = 1;
            buttonSortYSD.Text = "Сортировать";
            buttonSortYSD.UseVisualStyleBackColor = true;
            // 
            // buttonLoadDataYSD
            // 
            buttonLoadDataYSD.BackColor = SystemColors.ControlLight;
            buttonLoadDataYSD.FlatStyle = FlatStyle.Flat;
            buttonLoadDataYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonLoadDataYSD.Location = new Point(13, 287);
            buttonLoadDataYSD.Margin = new Padding(4, 3, 4, 3);
            buttonLoadDataYSD.Name = "buttonLoadDataYSD";
            buttonLoadDataYSD.Size = new Size(338, 40);
            buttonLoadDataYSD.TabIndex = 3;
            buttonLoadDataYSD.Text = "Загрузить данные";
            buttonLoadDataYSD.UseVisualStyleBackColor = false;
            // 
            // buttonSaveDataYSD
            // 
            buttonSaveDataYSD.BackColor = SystemColors.ControlLight;
            buttonSaveDataYSD.Enabled = false;
            buttonSaveDataYSD.FlatStyle = FlatStyle.Flat;
            buttonSaveDataYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSaveDataYSD.Location = new Point(13, 333);
            buttonSaveDataYSD.Margin = new Padding(4, 3, 4, 3);
            buttonSaveDataYSD.Name = "buttonSaveDataYSD";
            buttonSaveDataYSD.Size = new Size(338, 40);
            buttonSaveDataYSD.TabIndex = 4;
            buttonSaveDataYSD.Text = "Сохранить данные";
            buttonSaveDataYSD.UseVisualStyleBackColor = false;
            // 
            // buttonAddComputerYSD
            // 
            buttonAddComputerYSD.BackColor = Color.FromArgb(192, 255, 192);
            buttonAddComputerYSD.Enabled = false;
            buttonAddComputerYSD.FlatStyle = FlatStyle.Flat;
            buttonAddComputerYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddComputerYSD.Image = (Image)resources.GetObject("buttonAddComputerYSD.Image");
            buttonAddComputerYSD.Location = new Point(13, 379);
            buttonAddComputerYSD.Margin = new Padding(4, 3, 4, 3);
            buttonAddComputerYSD.Name = "buttonAddComputerYSD";
            buttonAddComputerYSD.Size = new Size(97, 114);
            buttonAddComputerYSD.TabIndex = 5;
            buttonAddComputerYSD.UseVisualStyleBackColor = false;
            // 
            // buttonEditComputerYSD
            // 
            buttonEditComputerYSD.BackColor = SystemColors.ControlLight;
            buttonEditComputerYSD.Enabled = false;
            buttonEditComputerYSD.FlatStyle = FlatStyle.Flat;
            buttonEditComputerYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonEditComputerYSD.Location = new Point(118, 379);
            buttonEditComputerYSD.Margin = new Padding(4, 3, 4, 3);
            buttonEditComputerYSD.Name = "buttonEditComputerYSD";
            buttonEditComputerYSD.Size = new Size(128, 114);
            buttonEditComputerYSD.TabIndex = 6;
            buttonEditComputerYSD.Text = "Редактировать";
            buttonEditComputerYSD.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteComputerYSD
            // 
            buttonDeleteComputerYSD.BackColor = Color.FromArgb(255, 192, 192);
            buttonDeleteComputerYSD.Enabled = false;
            buttonDeleteComputerYSD.FlatStyle = FlatStyle.Flat;
            buttonDeleteComputerYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonDeleteComputerYSD.Image = (Image)resources.GetObject("buttonDeleteComputerYSD.Image");
            buttonDeleteComputerYSD.Location = new Point(254, 379);
            buttonDeleteComputerYSD.Margin = new Padding(4, 3, 4, 3);
            buttonDeleteComputerYSD.Name = "buttonDeleteComputerYSD";
            buttonDeleteComputerYSD.Size = new Size(97, 114);
            buttonDeleteComputerYSD.TabIndex = 7;
            buttonDeleteComputerYSD.UseVisualStyleBackColor = false;
            // 
            // buttonStatisticsYSD
            // 
            buttonStatisticsYSD.BackColor = SystemColors.ControlLight;
            buttonStatisticsYSD.Enabled = false;
            buttonStatisticsYSD.FlatStyle = FlatStyle.Flat;
            buttonStatisticsYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonStatisticsYSD.Image = (Image)resources.GetObject("buttonStatisticsYSD.Image");
            buttonStatisticsYSD.Location = new Point(13, 499);
            buttonStatisticsYSD.Margin = new Padding(4, 3, 4, 3);
            buttonStatisticsYSD.Name = "buttonStatisticsYSD";
            buttonStatisticsYSD.Size = new Size(97, 66);
            buttonStatisticsYSD.TabIndex = 8;
            buttonStatisticsYSD.UseVisualStyleBackColor = false;
            buttonStatisticsYSD.Click += buttonStatisticsYSD_Click_1;
            // 
            // buttonChartYSD
            // 
            buttonChartYSD.BackColor = SystemColors.ControlLight;
            buttonChartYSD.Enabled = false;
            buttonChartYSD.FlatStyle = FlatStyle.Flat;
            buttonChartYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonChartYSD.Image = (Image)resources.GetObject("buttonChartYSD.Image");
            buttonChartYSD.Location = new Point(118, 499);
            buttonChartYSD.Margin = new Padding(4, 3, 4, 3);
            buttonChartYSD.Name = "buttonChartYSD";
            buttonChartYSD.Size = new Size(128, 66);
            buttonChartYSD.TabIndex = 9;
            buttonChartYSD.UseVisualStyleBackColor = false;
            // 
            // buttonAboutYSD
            // 
            buttonAboutYSD.BackColor = SystemColors.ControlLight;
            buttonAboutYSD.FlatStyle = FlatStyle.Flat;
            buttonAboutYSD.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAboutYSD.Image = (Image)resources.GetObject("buttonAboutYSD.Image");
            buttonAboutYSD.Location = new Point(254, 499);
            buttonAboutYSD.Margin = new Padding(4, 3, 4, 3);
            buttonAboutYSD.Name = "buttonAboutYSD";
            buttonAboutYSD.Size = new Size(97, 66);
            buttonAboutYSD.TabIndex = 10;
            buttonAboutYSD.UseVisualStyleBackColor = false;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(133, 22);
            loadToolStripMenuItem.Text = "Загрузить";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(133, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(133, 22);
            exitToolStripMenuItem.Text = "Выход";
            // 
            // menuStripMainYSD
            // 
            menuStripMainYSD.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStripMainYSD.Location = new Point(0, 0);
            menuStripMainYSD.Name = "menuStripMainYSD";
            menuStripMainYSD.Padding = new Padding(7, 2, 0, 2);
            menuStripMainYSD.Size = new Size(1244, 24);
            menuStripMainYSD.TabIndex = 1;
            menuStripMainYSD.Text = "menuStrip1";
            // 
            // FormMainYSD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 651);
            Controls.Add(panelControls);
            Controls.Add(statusStripMainYSD);
            Controls.Add(dataGridViewComputersYSD);
            Controls.Add(menuStripMainYSD);
            MainMenuStrip = menuStripMainYSD;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(931, 686);
            Name = "FormMainYSD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Каталог персональных ЭВМ - YarkovSD Sprint7 Project V12";
            ((System.ComponentModel.ISupportInitialize)dataGridViewComputersYSD).EndInit();
            statusStripMainYSD.ResumeLayout(false);
            statusStripMainYSD.PerformLayout();
            panelControls.ResumeLayout(false);
            groupBoxSearch.ResumeLayout(false);
            groupBoxSearch.PerformLayout();
            groupBoxFilter.ResumeLayout(false);
            groupBoxSort.ResumeLayout(false);
            menuStripMainYSD.ResumeLayout(false);
            menuStripMainYSD.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewComputersYSD;
        private System.Windows.Forms.StatusStrip statusStripMainYSD;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfoYSD;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCountYSD;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearchYSD;
        private System.Windows.Forms.Button buttonSearchYSD;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxManufacturerYSD;
        private System.Windows.Forms.Button buttonFilterYSD;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.ComboBox comboBoxSortYSD;
        private System.Windows.Forms.Button buttonSortYSD;
        private System.Windows.Forms.Button buttonLoadDataYSD;
        private System.Windows.Forms.Button buttonSaveDataYSD;
        private System.Windows.Forms.Button buttonAddComputerYSD;
        private System.Windows.Forms.Button buttonEditComputerYSD;
        private System.Windows.Forms.Button buttonDeleteComputerYSD;
        private System.Windows.Forms.Button buttonStatisticsYSD;
        private System.Windows.Forms.Button buttonChartYSD;
        private System.Windows.Forms.Button buttonAboutYSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProcessor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClockSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReleaseDate;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private MenuStrip menuStripMainYSD;
    }
}
