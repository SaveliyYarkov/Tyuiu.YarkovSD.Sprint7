namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    partial class ChartForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel chartPanel;
        private Panel controlPanel;
        private GroupBox groupBoxChartType;
        private ComboBox comboBoxChartType;
        private Panel buttonPanel;
        private Button buttonSaveChart;
        private Button buttonRefresh;
        private Button buttonClose;
        private StatusStrip statusStripChart;
        private ToolStripStatusLabel toolStripStatusLabelInfo;
        private ToolStripStatusLabel toolStripStatusLabelData;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            chartPanel = new Panel();
            controlPanel = new Panel();
            buttonPanel = new Panel();
            buttonClose = new Button();
            buttonRefresh = new Button();
            buttonSaveChart = new Button();
            groupBoxChartType = new GroupBox();
            comboBoxChartType = new ComboBox();
            statusStripChart = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
            toolStripStatusLabelData = new ToolStripStatusLabel();
            controlPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            groupBoxChartType.SuspendLayout();
            statusStripChart.SuspendLayout();
            SuspendLayout();
            // 
            // chartPanel
            // 
            chartPanel.BackColor = Color.White;
            chartPanel.BorderStyle = BorderStyle.FixedSingle;
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(0, 0);
            chartPanel.Margin = new Padding(4, 3, 4, 3);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(684, 670);
            chartPanel.TabIndex = 0;
            chartPanel.Paint += ChartPanel_Paint;
            // 
            // controlPanel
            // 
            controlPanel.BackColor = SystemColors.Control;
            controlPanel.BorderStyle = BorderStyle.FixedSingle;
            controlPanel.Controls.Add(buttonPanel);
            controlPanel.Controls.Add(groupBoxChartType);
            controlPanel.Dock = DockStyle.Right;
            controlPanel.Location = new Point(684, 0);
            controlPanel.Margin = new Padding(4, 3, 4, 3);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(249, 670);
            controlPanel.TabIndex = 1;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(buttonClose);
            buttonPanel.Controls.Add(buttonRefresh);
            buttonPanel.Controls.Add(buttonSaveChart);
            buttonPanel.Location = new Point(4, 104);
            buttonPanel.Margin = new Padding(4, 3, 4, 3);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(239, 173);
            buttonPanel.TabIndex = 1;
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonClose.Location = new Point(7, 115);
            buttonClose.Margin = new Padding(4, 3, 4, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(228, 40);
            buttonClose.TabIndex = 2;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += ButtonClose_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonRefresh.Location = new Point(7, 63);
            buttonRefresh.Margin = new Padding(4, 3, 4, 3);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(228, 40);
            buttonRefresh.TabIndex = 1;
            buttonRefresh.Text = "Обновить график";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // buttonSaveChart
            // 
            buttonSaveChart.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonSaveChart.Location = new Point(7, 12);
            buttonSaveChart.Margin = new Padding(4, 3, 4, 3);
            buttonSaveChart.Name = "buttonSaveChart";
            buttonSaveChart.Size = new Size(228, 40);
            buttonSaveChart.TabIndex = 0;
            buttonSaveChart.Text = "Сохранить график";
            buttonSaveChart.UseVisualStyleBackColor = true;
            buttonSaveChart.Click += ButtonSaveChart_Click;
            // 
            // groupBoxChartType
            // 
            groupBoxChartType.Controls.Add(comboBoxChartType);
            groupBoxChartType.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxChartType.Location = new Point(4, 3);
            groupBoxChartType.Margin = new Padding(4, 3, 4, 3);
            groupBoxChartType.Name = "groupBoxChartType";
            groupBoxChartType.Padding = new Padding(4, 3, 4, 3);
            groupBoxChartType.Size = new Size(239, 81);
            groupBoxChartType.TabIndex = 0;
            groupBoxChartType.TabStop = false;
            groupBoxChartType.Text = "Тип графика";
            // 
            // comboBoxChartType
            // 
            comboBoxChartType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxChartType.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxChartType.FormattingEnabled = true;
            comboBoxChartType.Items.AddRange(new object[] { "Распределение по производителям", "Диаграмма цен", "Средние характеристики" });
            comboBoxChartType.Location = new Point(7, 35);
            comboBoxChartType.Margin = new Padding(4, 3, 4, 3);
            comboBoxChartType.Name = "comboBoxChartType";
            comboBoxChartType.Size = new Size(232, 23);
            comboBoxChartType.TabIndex = 0;
            comboBoxChartType.SelectedIndexChanged += ComboBoxChartType_SelectedIndexChanged;
            // 
            // statusStripChart
            // 
            statusStripChart.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo, toolStripStatusLabelData });
            statusStripChart.Location = new Point(0, 670);
            statusStripChart.Name = "statusStripChart";
            statusStripChart.Padding = new Padding(1, 0, 16, 0);
            statusStripChart.Size = new Size(933, 22);
            statusStripChart.TabIndex = 2;
            statusStripChart.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            toolStripStatusLabelInfo.Size = new Size(807, 17);
            toolStripStatusLabelInfo.Spring = true;
            toolStripStatusLabelInfo.Text = "Готов к построению графиков";
            toolStripStatusLabelInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelData
            // 
            toolStripStatusLabelData.Name = "toolStripStatusLabelData";
            toolStripStatusLabelData.Size = new Size(109, 17);
            toolStripStatusLabelData.Text = "Данные: 0 записей";
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 692);
            Controls.Add(chartPanel);
            Controls.Add(controlPanel);
            Controls.Add(statusStripChart);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(697, 571);
            Name = "ChartForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Графики и диаграммы - Каталог ПЭВМ";
            Load += ChartForm_Load;
            controlPanel.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            groupBoxChartType.ResumeLayout(false);
            statusStripChart.ResumeLayout(false);
            statusStripChart.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}