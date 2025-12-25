using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    public partial class ChartForm : Form
    {
        private DataTable dataSource;
        private string currentChartType;
        private Random random = new Random();

        // Стили графиков
        private Color[] chartColors = new Color[]
        {
            Color.FromArgb(65, 105, 225),   // Royal Blue
            Color.FromArgb(220, 20, 60),    // Crimson
            Color.FromArgb(46, 139, 87),    // Sea Green
            Color.FromArgb(255, 140, 0),    // Dark Orange
            Color.FromArgb(148, 0, 211),    // Dark Violet
            Color.FromArgb(255, 69, 0),     // Red Orange
            Color.FromArgb(0, 139, 139),    // Dark Cyan
            Color.FromArgb(199, 21, 133)    // Medium Violet Red
        };

        public ChartForm(DataTable data)
        {
            InitializeComponent();
            this.dataSource = data;
            this.currentChartType = "Распределение по производителям";
            UpdateStatusStrip();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            comboBoxChartType.SelectedIndex = 0;
        }

        private void ChartPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawChart(e.Graphics);
        }

        private void DrawChart(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                DrawNoDataMessage(g);
                return;
            }

            Rectangle chartArea = new Rectangle(50, 50, chartPanel.Width - 100, chartPanel.Height - 100);

            switch (currentChartType)
            {
                case "Распределение по производителям":
                    DrawManufacturerDistribution(g, chartArea);
                    break;
                case "Диаграмма цен":
                    DrawPriceChart(g, chartArea);
                    break;
                case "Средние характеристики":
                    DrawAverageCharacteristics(g, chartArea);
                    break;
            }
        }

        private void DrawNoDataMessage(Graphics g)
        {
            string message = "Нет данных для построения графика";
            Font font = new Font("Arial", 14, FontStyle.Bold);
            SizeF textSize = g.MeasureString(message, font);

            PointF location = new PointF(
                (chartPanel.Width - textSize.Width) / 2,
                (chartPanel.Height - textSize.Height) / 2
            );

            g.DrawString(message, font, Brushes.DarkGray, location);
        }

        private void DrawManufacturerDistribution(Graphics g, Rectangle chartArea)
        {
            var manufacturerGroups = dataSource.AsEnumerable()
                .GroupBy(row => row.Field<string>("Manufacturer"))
                .Select(grp => new { Manufacturer = grp.Key, Count = grp.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            if (manufacturerGroups.Count == 0) return;

            // Рисуем круговую диаграмму
            float total = manufacturerGroups.Sum(x => x.Count);
            float startAngle = 0;

            // Рисуем секторы
            for (int i = 0; i < manufacturerGroups.Count; i++)
            {
                float sweepAngle = 360f * manufacturerGroups[i].Count / total;
                Brush brush = new SolidBrush(chartColors[i % chartColors.Length]);

                g.FillPie(brush, chartArea, startAngle, sweepAngle);
                g.DrawPie(Pens.Black, chartArea, startAngle, sweepAngle);

                startAngle += sweepAngle;
            }

            // Рисуем легенду в правом верхнем углу
            int legendX = chartArea.Right - 56; // Отступ от правого края
            int legendY = chartArea.Top - 10; // Отступ сверху

            DrawLegend(g, manufacturerGroups.Select(m => $"{m.Manufacturer} ({m.Count})").ToList(),
                      legendX, legendY);

            // Рисуем заголовок
            DrawChartTitle(g, "Распределение компьютеров по производителям", chartArea);
        }

        private void DrawPriceChart(Graphics g, Rectangle chartArea)
        {
            var prices = dataSource.AsEnumerable()
                .Select(row => Convert.ToDouble(row["Price"]))
                .OrderBy(p => p)
                .ToList();

            if (prices.Count == 0) return;

            double minPrice = prices.Min();
            double maxPrice = prices.Max();
            int barCount = 10;
            double range = maxPrice - minPrice;
            double interval = range / barCount;

            // Группируем данные
            var groups = new int[barCount];
            foreach (var price in prices)
            {
                int index = (int)Math.Min((price - minPrice) / interval, barCount - 1);
                groups[index]++;
            }

            // Находим максимальное количество в группе для масштабирования
            int maxCount = groups.Max();

            // Рисуем гистограмму
            float barWidth = chartArea.Width / (float)barCount * 0.8f;
            float spacing = chartArea.Width / (float)barCount * 0.2f;

            for (int i = 0; i < barCount; i++)
            {
                if (groups[i] == 0) continue;

                float barHeight = (groups[i] / (float)maxCount) * chartArea.Height;
                float x = chartArea.Left + i * (barWidth + spacing);
                float y = chartArea.Bottom - barHeight;

                Brush brush = new LinearGradientBrush(
                    new RectangleF(x, y, barWidth, barHeight),
                    chartColors[i % chartColors.Length],
                    ControlPaint.Dark(chartColors[i % chartColors.Length], 0.3f),
                    90f
                );

                g.FillRectangle(brush, x, y, barWidth, barHeight);
                g.DrawRectangle(Pens.Black, x, y, barWidth, barHeight);

                // Подписи ценового диапазона
                double startPrice = minPrice + i * interval;
                double endPrice = startPrice + interval;
                string label = $"{(int)startPrice}-{(int)endPrice} руб.";

                Font labelFont = new Font("Arial", 8);
                SizeF labelSize = g.MeasureString(label, labelFont);

                g.DrawString(label, labelFont, Brushes.Black,
                    x + barWidth / 2 - labelSize.Width / 2,
                    chartArea.Bottom + 5);

                // Количество в столбце
                g.DrawString(groups[i].ToString(), labelFont, Brushes.Black,
                    x + barWidth / 2 - 5, y - 20);
            }

            // Оси
            g.DrawLine(Pens.Black, chartArea.Left, chartArea.Bottom, chartArea.Right, chartArea.Bottom);
            g.DrawLine(Pens.Black, chartArea.Left, chartArea.Top, chartArea.Left, chartArea.Bottom);

            // Заголовок
            DrawChartTitle(g, "Распределение цен компьютеров", chartArea);
        }

        private void DrawAverageCharacteristics(Graphics g, Rectangle chartArea)
        {
            if (dataSource.Rows.Count == 0) return;

            // Вычисляем средние значения
            double avgRAM = dataSource.AsEnumerable()
                .Average(row => Convert.ToDouble(row["RAM"]));

            double avgHDD = dataSource.AsEnumerable()
                .Average(row => Convert.ToDouble(row["HDD"]));

            double avgPrice = dataSource.AsEnumerable()
                .Average(row => Convert.ToDouble(row["Price"]));

            // Нормализуем значения для отображения
            double maxValue = Math.Max(Math.Max(avgRAM, avgHDD), avgPrice / 1000);
            float scale = chartArea.Height / (float)maxValue;

            float barWidth = 60;
            float spacing = 40;
            float startX = chartArea.Left + (chartArea.Width - (3 * barWidth + 2 * spacing)) / 2;

            string[] labels = { "ОЗУ (ГБ)", "HDD (ГБ)", "Цена (тыс. руб.)" };
            float[] values = { (float)avgRAM, (float)avgHDD, (float)(avgPrice / 1000) };
            Color[] colors = { Color.Blue, Color.Green, Color.Red };

            for (int i = 0; i < 3; i++)
            {
                float x = startX + i * (barWidth + spacing);
                float height = values[i] * scale;
                float y = chartArea.Bottom - height;

                Brush brush = new LinearGradientBrush(
                    new RectangleF(x, y, barWidth, height),
                    colors[i],
                    ControlPaint.Dark(colors[i], 0.3f),
                    90f
                );

                g.FillRectangle(brush, x, y, barWidth, height);
                g.DrawRectangle(Pens.Black, x, y, barWidth, height);

                // Значение над столбцом
                string valueText = values[i].ToString("F1");
                if (i == 2) valueText = values[i].ToString("F0");

                Font valueFont = new Font("Arial", 9, FontStyle.Bold);
                SizeF valueSize = g.MeasureString(valueText, valueFont);

                g.DrawString(valueText, valueFont, Brushes.Black,
                    x + barWidth / 2 - valueSize.Width / 2,
                    y - valueSize.Height - 5);

                // Подпись
                g.DrawString(labels[i], new Font("Arial", 9), Brushes.Black,
                    x + barWidth / 2 - g.MeasureString(labels[i], new Font("Arial", 9)).Width / 2,
                    chartArea.Bottom + 10);
            }

            DrawChartTitle(g, "Средние характеристики компьютеров", chartArea);
        }

        private void DrawLegend(Graphics g, List<string> items, float x, float y)
        {
            if (items.Count == 0) return;

            Font legendFont = new Font("Arial", 9);
            float itemHeight = 20;
            float boxSize = 15;
            float maxTextWidth = 0;

            // Вычисляем максимальную ширину текста для правильного размещения
            foreach (string item in items)
            {
                float textWidth = g.MeasureString(item, legendFont).Width;
                if (textWidth > maxTextWidth)
                {
                    maxTextWidth = textWidth;
                }
            }

            // Рисуем фон легенды (опционально)
            float legendWidth = boxSize + 5 + maxTextWidth;
            float legendHeight = items.Count * itemHeight + 10;

            // Полупрозрачный фон
            using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(230, 255, 255, 255)))
            {
                g.FillRectangle(backgroundBrush, x - 5, y - 5, legendWidth + 10, legendHeight + 10);
            }

            // Рамка вокруг легенды
            g.DrawRectangle(Pens.LightGray, x - 5, y - 5, legendWidth + 10, legendHeight + 10);

            // Рисуем элементы легенды
            for (int i = 0; i < items.Count; i++)
            {
                Brush colorBrush = new SolidBrush(chartColors[i % chartColors.Length]);

                // Цветной квадрат
                g.FillRectangle(colorBrush, x, y + i * itemHeight, boxSize, boxSize);
                g.DrawRectangle(Pens.Black, x, y + i * itemHeight, boxSize, boxSize);

                // Текст
                g.DrawString(items[i], legendFont, Brushes.Black,
                    x + boxSize + 5, y + i * itemHeight);
            }

            // Заголовок легенды (опционально)
            if (currentChartType == "Распределение по производителям")
            {
                Font titleFont = new Font("Arial", 10, FontStyle.Bold);
                string legendTitle = "Производители:";
                SizeF titleSize = g.MeasureString(legendTitle, titleFont);

                g.DrawString(legendTitle, titleFont, Brushes.Black,
                    x, y - titleSize.Height - 5);
            }
        }

        private void DrawChartTitle(Graphics g, string title, Rectangle chartArea)
        {
            Font titleFont = new Font("Arial", 12, FontStyle.Bold);
            SizeF titleSize = g.MeasureString(title, titleFont);

            // Центрируем заголовок над диаграммой
            float titleX = chartArea.Left + (chartArea.Width - titleSize.Width) / 2;
            float titleY = chartArea.Top - titleSize.Height - 20;

            g.DrawString(title, titleFont, Brushes.Black, titleX, titleY);
        }

        private void UpdateStatusStrip()
        {
            if (dataSource != null)
            {
                toolStripStatusLabelData.Text = $"Данные: {dataSource.Rows.Count} записей";
                toolStripStatusLabelInfo.Text = $"Текущий график: {currentChartType}";
            }
        }

        private void ComboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChartType.SelectedItem != null)
            {
                currentChartType = comboBoxChartType.SelectedItem.ToString();
                UpdateStatusStrip();
                chartPanel.Invalidate();
            }
        }



        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}