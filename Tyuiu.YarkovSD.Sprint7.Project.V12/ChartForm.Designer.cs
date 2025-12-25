namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    partial class ChartForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel chartPanel;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
            chartPanel = new Panel();
            statusStripChart = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
            toolStripStatusLabelData = new ToolStripStatusLabel();
            groupBoxChartType = new GroupBox();
            comboBoxChartType = new ComboBox();
            buttonClose = new Button();
            controlPanel = new Panel();
            statusStripChart.SuspendLayout();
            groupBoxChartType.SuspendLayout();
            controlPanel.SuspendLayout();
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
            chartPanel.Size = new Size(733, 669);
            chartPanel.TabIndex = 0;
            chartPanel.Paint += ChartPanel_Paint;
            // 
            // statusStripChart
            // 
            statusStripChart.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo, toolStripStatusLabelData });
            statusStripChart.Location = new Point(0, 669);
            statusStripChart.Name = "statusStripChart";
            statusStripChart.Padding = new Padding(1, 0, 16, 0);
            statusStripChart.Size = new Size(992, 22);
            statusStripChart.TabIndex = 2;
            statusStripChart.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            toolStripStatusLabelInfo.Size = new Size(866, 17);
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
            // buttonClose
            // 
            buttonClose.BackColor = Color.Black;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonClose.Image = (Image)resources.GetObject("buttonClose.Image");
            buttonClose.Location = new Point(7, 90);
            buttonClose.Margin = new Padding(4, 3, 4, 3);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(242, 574);
            buttonClose.TabIndex = 2;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += ButtonClose_Click;
            // 
            // controlPanel
            // 
            controlPanel.BackColor = Color.OldLace;
            controlPanel.BorderStyle = BorderStyle.FixedSingle;
            controlPanel.Controls.Add(buttonClose);
            controlPanel.Controls.Add(groupBoxChartType);
            controlPanel.Dock = DockStyle.Right;
            controlPanel.Location = new Point(733, 0);
            controlPanel.Margin = new Padding(4, 3, 4, 3);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(259, 669);
            controlPanel.TabIndex = 1;
            // 
            // ChartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 691);
            Controls.Add(chartPanel);
            Controls.Add(controlPanel);
            Controls.Add(statusStripChart);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(697, 571);
            Name = "ChartForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Графики и диаграммы - Каталог ПЭВМ";
            Load += ChartForm_Load;
            statusStripChart.ResumeLayout(false);
            statusStripChart.PerformLayout();
            groupBoxChartType.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
        private GroupBox groupBoxChartType;
        private ComboBox comboBoxChartType;
        private Button buttonClose;
        private Panel controlPanel;
    }
}