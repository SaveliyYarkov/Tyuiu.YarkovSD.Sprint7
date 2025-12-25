using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Tyuiu.YarkovSD.Sprint7.Project.V12.Lib;

namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    public partial class FormMainYSD : Form
    {
        private DataServiceYSD dataService;
        private List<DataServiceYSD.ComputerYSD> computers;
        private string currentFilePath;

        public FormMainYSD()
        {
            InitializeComponent();
            InitializeApplication();
            SetupEventHandlers();
        }

        private void InitializeApplication()
        {
            dataService = new DataServiceYSD();
            computers = new List<DataServiceYSD.ComputerYSD>();
            currentFilePath = string.Empty;
            UpdateStatus("Готов к работе");
            UpdateButtonsState(false);
        }

        private void SetupEventHandlers()
        {
            // Меню
            loadToolStripMenuItem.Click += buttonLoadDataYSD_Click;
            saveToolStripMenuItem.Click += buttonSaveDataYSD_Click;
            exitToolStripMenuItem.Click += (s, e) => Application.Exit();

            // Кнопки
            buttonSearchYSD.Click += buttonSearchYSD_Click;
            buttonFilterYSD.Click += buttonFilterYSD_Click;
            buttonSortYSD.Click += buttonSortYSD_Click;
            buttonLoadDataYSD.Click += buttonLoadDataYSD_Click;
            buttonSaveDataYSD.Click += buttonSaveDataYSD_Click;
            buttonAddComputerYSD.Click += buttonAddComputerYSD_Click;
            buttonEditComputerYSD.Click += buttonEditComputerYSD_Click;
            buttonDeleteComputerYSD.Click += buttonDeleteComputerYSD_Click;
            buttonStatisticsYSD.Click += buttonStatisticsYSD_Click;
            buttonChartYSD.Click += buttonChartYSD_Click;
            buttonAboutYSD.Click += buttonAboutYSD_Click;

            // DataGridView
            dataGridViewComputersYSD.CellDoubleClick += dataGridViewComputersYSD_CellDoubleClick;
            dataGridViewComputersYSD.KeyDown += dataGridViewComputersYSD_KeyDown;
            dataGridViewComputersYSD.SelectionChanged += dataGridViewComputersYSD_SelectionChanged;

            // Поле поиска
            textBoxSearchYSD.ForeColor = Color.Gray;
            textBoxSearchYSD.Enter += textBoxSearchYSD_Enter;
            textBoxSearchYSD.Leave += textBoxSearchYSD_Leave;
        }

        private void UpdateStatus(string message)
        {
            toolStripStatusLabelInfoYSD.Text = message;
            toolStripStatusLabelCountYSD.Text = $"Записей: {computers.Count}";
        }

        private void UpdateButtonsState(bool enabled)
        {
            saveToolStripMenuItem.Enabled = enabled;
            buttonSaveDataYSD.Enabled = enabled;
            buttonAddComputerYSD.Enabled = enabled;

            bool hasSelection = dataGridViewComputersYSD.SelectedRows.Count > 0;
            buttonEditComputerYSD.Enabled = enabled && hasSelection;
            buttonDeleteComputerYSD.Enabled = enabled && hasSelection;

            buttonSearchYSD.Enabled = enabled;
            buttonFilterYSD.Enabled = enabled;
            buttonSortYSD.Enabled = enabled;
            buttonStatisticsYSD.Enabled = enabled;
            buttonChartYSD.Enabled = enabled;
        }

        // === ОБРАБОТЧИКИ СОБЫТИЙ ===

        private void buttonLoadDataYSD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dialog.Title = "Выберите файл с данными";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        computers = dataService.LoadComputersFromCsv(dialog.FileName);
                        currentFilePath = dialog.FileName;

                        DisplayComputers();
                        UpdateStatus($"Загружено {computers.Count} компьютеров");
                        UpdateButtonsState(true);
                        UpdateManufacturersList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateStatus("Ошибка загрузки данных");
                    }
                }
            }
        }

        private void DisplayComputers()
        {
            dataGridViewComputersYSD.Rows.Clear();

            foreach (var computer in computers)
            {
                dataGridViewComputersYSD.Rows.Add(
                    computer.Model,
                    computer.Manufacturer,
                    computer.Processor,
                    computer.ClockSpeed,
                    computer.RAM,
                    computer.HDD,
                    computer.Price,
                    computer.ReleaseDate.ToShortDateString()
                );
            }
        }

        private void UpdateManufacturersList()
        {
            comboBoxManufacturerYSD.Items.Clear();
            comboBoxManufacturerYSD.Items.Add("Все производители");

            var manufacturers = computers.Select(c => c.Manufacturer)
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            foreach (var manufacturer in manufacturers)
            {
                comboBoxManufacturerYSD.Items.Add(manufacturer);
            }
            comboBoxManufacturerYSD.SelectedIndex = 0;
        }

        private void buttonSaveDataYSD_Click(object sender, EventArgs e)
        {
            if (computers.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dialog.FileName = "computers_export.csv";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dataService.SaveComputersToCsv(dialog.FileName, computers);
                        MessageBox.Show($"Сохранено в файл: {dialog.FileName}",
                            "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatus($"Данные сохранены в {Path.GetFileName(dialog.FileName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateStatus("Ошибка сохранения данных");
                    }
                }
            }
        }

        private void buttonAddComputerYSD_Click(object sender, EventArgs e)
        {
            Form addForm = CreateAddEditForm("Добавить компьютер", null);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var controls = addForm.Controls;

                TextBox txtModel = FindControl<TextBox>(controls, "txtModel");
                TextBox txtManufacturer = FindControl<TextBox>(controls, "txtManufacturer");
                TextBox txtProcessor = FindControl<TextBox>(controls, "txtProcessor");
                NumericUpDown numClockSpeed = FindControl<NumericUpDown>(controls, "numClockSpeed");
                NumericUpDown numRAM = FindControl<NumericUpDown>(controls, "numRAM");
                NumericUpDown numHDD = FindControl<NumericUpDown>(controls, "numHDD");
                NumericUpDown numPrice = FindControl<NumericUpDown>(controls, "numPrice");
                DateTimePicker dtpRelease = FindControl<DateTimePicker>(controls, "dtpRelease");

                if (txtModel == null || txtManufacturer == null || txtProcessor == null ||
                    numClockSpeed == null || numRAM == null || numHDD == null ||
                    numPrice == null || dtpRelease == null)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModel.Text) ||
                    string.IsNullOrWhiteSpace(txtManufacturer.Text) ||
                    string.IsNullOrWhiteSpace(txtProcessor.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataServiceYSD.ComputerYSD newComputer = new DataServiceYSD.ComputerYSD();
                newComputer.Model = txtModel.Text.Trim();
                newComputer.Manufacturer = txtManufacturer.Text.Trim();
                newComputer.Processor = txtProcessor.Text.Trim();
                newComputer.ClockSpeed = (double)numClockSpeed.Value;
                newComputer.RAM = (int)numRAM.Value;
                newComputer.HDD = (int)numHDD.Value;
                newComputer.Price = numPrice.Value;
                newComputer.ReleaseDate = dtpRelease.Value;

                computers.Add(newComputer);
                DisplayComputers();
                UpdateManufacturersList();
                UpdateStatus("Компьютер добавлен в каталог");
            }

            addForm.Dispose();
        }

        private void buttonEditComputerYSD_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputersYSD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите компьютер для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = dataGridViewComputersYSD.SelectedRows[0].Index;
            var computer = computers[selectedIndex];

            Form editForm = CreateAddEditForm("Редактировать компьютер", computer);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var controls = editForm.Controls;

                TextBox txtModel = FindControl<TextBox>(controls, "txtModel");
                TextBox txtManufacturer = FindControl<TextBox>(controls, "txtManufacturer");
                TextBox txtProcessor = FindControl<TextBox>(controls, "txtProcessor");
                NumericUpDown numClockSpeed = FindControl<NumericUpDown>(controls, "numClockSpeed");
                NumericUpDown numRAM = FindControl<NumericUpDown>(controls, "numRAM");
                NumericUpDown numHDD = FindControl<NumericUpDown>(controls, "numHDD");
                NumericUpDown numPrice = FindControl<NumericUpDown>(controls, "numPrice");
                DateTimePicker dtpRelease = FindControl<DateTimePicker>(controls, "dtpRelease");

                if (txtModel == null || txtManufacturer == null || txtProcessor == null ||
                    numClockSpeed == null || numRAM == null || numHDD == null ||
                    numPrice == null || dtpRelease == null)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtModel.Text) ||
                    string.IsNullOrWhiteSpace(txtManufacturer.Text) ||
                    string.IsNullOrWhiteSpace(txtProcessor.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                computer.Model = txtModel.Text.Trim();
                computer.Manufacturer = txtManufacturer.Text.Trim();
                computer.Processor = txtProcessor.Text.Trim();
                computer.ClockSpeed = (double)numClockSpeed.Value;
                computer.RAM = (int)numRAM.Value;
                computer.HDD = (int)numHDD.Value;
                computer.Price = numPrice.Value;
                computer.ReleaseDate = dtpRelease.Value;

                DisplayComputers();
                UpdateManufacturersList();
                UpdateStatus("Данные компьютера обновлены");
            }

            editForm.Dispose();
        }

        private Form CreateAddEditForm(string title, DataServiceYSD.ComputerYSD computer)
        {
            Form form = new Form();
            form.Text = title;
            form.Size = new Size(400, 350);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;

            // Создание элементов управления
            TextBox txtModel = new TextBox();
            txtModel.Name = "txtModel";
            txtModel.Location = new Point(120, 20);
            txtModel.Size = new Size(200, 20);
            if (computer != null) txtModel.Text = computer.Model;

            TextBox txtManufacturer = new TextBox();
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.Location = new Point(120, 50);
            txtManufacturer.Size = new Size(200, 20);
            if (computer != null) txtManufacturer.Text = computer.Manufacturer;

            TextBox txtProcessor = new TextBox();
            txtProcessor.Name = "txtProcessor";
            txtProcessor.Location = new Point(120, 80);
            txtProcessor.Size = new Size(200, 20);
            if (computer != null) txtProcessor.Text = computer.Processor;

            NumericUpDown numClockSpeed = new NumericUpDown();
            numClockSpeed.Name = "numClockSpeed";
            numClockSpeed.Location = new Point(120, 110);
            numClockSpeed.Size = new Size(80, 20);
            numClockSpeed.DecimalPlaces = 1;
            numClockSpeed.Minimum = 1;
            numClockSpeed.Maximum = 10;
            numClockSpeed.Value = computer != null ? (decimal)computer.ClockSpeed : 2.5M;

            NumericUpDown numRAM = new NumericUpDown();
            numRAM.Name = "numRAM";
            numRAM.Location = new Point(120, 140);
            numRAM.Size = new Size(80, 20);
            numRAM.Minimum = 1;
            numRAM.Maximum = 128;
            numRAM.Value = computer != null ? computer.RAM : 8;

            NumericUpDown numHDD = new NumericUpDown();
            numHDD.Name = "numHDD";
            numHDD.Location = new Point(120, 170);
            numHDD.Size = new Size(80, 20);
            numHDD.Minimum = 128;
            numHDD.Maximum = 4000;
            numHDD.Value = computer != null ? computer.HDD : 500;

            NumericUpDown numPrice = new NumericUpDown();
            numPrice.Name = "numPrice";
            numPrice.Location = new Point(120, 200);
            numPrice.Size = new Size(120, 20);
            numPrice.Minimum = 1000;
            numPrice.Maximum = 1000000;
            numPrice.Value = computer != null ? computer.Price : 30000;

            DateTimePicker dtpRelease = new DateTimePicker();
            dtpRelease.Name = "dtpRelease";
            dtpRelease.Location = new Point(120, 230);
            dtpRelease.Size = new Size(120, 20);
            dtpRelease.Value = computer != null ? computer.ReleaseDate : DateTime.Now;

            // Создание меток
            CreateLabel(form, "Модель:", 20, 23);
            CreateLabel(form, "Производитель:", 20, 53);
            CreateLabel(form, "Процессор:", 20, 83);
            CreateLabel(form, "Частота (ГГц):", 20, 113);
            CreateLabel(form, "ОЗУ (ГБ):", 20, 143);
            CreateLabel(form, "ЖД (ГБ):", 20, 173);
            CreateLabel(form, "Цена (руб):", 20, 203);
            CreateLabel(form, "Дата выпуска:", 20, 233);

            // Кнопки
            Button btnOK = new Button();
            btnOK.Text = computer != null ? "Сохранить" : "Добавить";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(100, 270);
            btnOK.Size = new Size(80, 30);

            Button btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 270);
            btnCancel.Size = new Size(80, 30);

            // Добавление элементов на форму
            form.Controls.Add(txtModel);
            form.Controls.Add(txtManufacturer);
            form.Controls.Add(txtProcessor);
            form.Controls.Add(numClockSpeed);
            form.Controls.Add(numRAM);
            form.Controls.Add(numHDD);
            form.Controls.Add(numPrice);
            form.Controls.Add(dtpRelease);
            form.Controls.Add(btnOK);
            form.Controls.Add(btnCancel);

            form.AcceptButton = btnOK;
            form.CancelButton = btnCancel;

            return form;
        }

        private void CreateLabel(Form form, string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            form.Controls.Add(label);
        }

        private T FindControl<T>(Control.ControlCollection controls, string name) where T : Control
        {
            foreach (Control control in controls)
            {
                if (control.Name == name && control is T)
                {
                    return control as T;
                }
            }
            return null;
        }

        private void buttonDeleteComputerYSD_Click(object sender, EventArgs e)
        {
            if (dataGridViewComputersYSD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите компьютер для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = dataGridViewComputersYSD.SelectedRows[0].Index;
            var computer = computers[selectedIndex];

            var result = MessageBox.Show($"Удалить компьютер '{computer.Model}'?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                computers.RemoveAt(selectedIndex);
                DisplayComputers();
                UpdateManufacturersList();
                UpdateStatus("Компьютер удален из каталога");

                if (computers.Count == 0)
                {
                    UpdateButtonsState(false);
                }
            }
        }

        private void buttonSearchYSD_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchYSD.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText) || searchText == "введите модель...")
            {
                DisplayComputers();
                UpdateStatus("Отображены все записи");
            }
            else
            {
                var filtered = computers.Where(c =>
                    c.Model.ToLower().Contains(searchText) ||
                    c.Manufacturer.ToLower().Contains(searchText) ||
                    c.Processor.ToLower().Contains(searchText)).ToList();

                dataGridViewComputersYSD.Rows.Clear();
                foreach (var computer in filtered)
                {
                    dataGridViewComputersYSD.Rows.Add(
                        computer.Model, computer.Manufacturer, computer.Processor,
                        computer.ClockSpeed, computer.RAM, computer.HDD,
                        computer.Price, computer.ReleaseDate.ToShortDateString()
                    );
                }
                UpdateStatus($"Найдено {filtered.Count} записей по запросу '{searchText}'");
            }
        }

        private void buttonFilterYSD_Click(object sender, EventArgs e)
        {
            if (comboBoxManufacturerYSD.SelectedIndex == 0 || comboBoxManufacturerYSD.SelectedItem == null)
            {
                DisplayComputers();
                UpdateStatus("Все производители");
            }
            else
            {
                string manufacturer = comboBoxManufacturerYSD.SelectedItem.ToString();
                var filtered = computers.Where(c => c.Manufacturer == manufacturer).ToList();

                dataGridViewComputersYSD.Rows.Clear();
                foreach (var computer in filtered)
                {
                    dataGridViewComputersYSD.Rows.Add(
                        computer.Model, computer.Manufacturer, computer.Processor,
                        computer.ClockSpeed, computer.RAM, computer.HDD,
                        computer.Price, computer.ReleaseDate.ToShortDateString()
                    );
                }
                UpdateStatus($"Фильтр: {manufacturer} ({filtered.Count} зап.)");
            }
        }

        private void buttonSortYSD_Click(object sender, EventArgs e)
        {
            if (comboBoxSortYSD.SelectedIndex == 0)
            {
                computers = computers.OrderBy(c => c.Price).ToList();
                UpdateStatus("Сортировка по цене (возрастание)");
            }
            else if (comboBoxSortYSD.SelectedIndex == 1)
            {
                computers = computers.OrderByDescending(c => c.Price).ToList();
                UpdateStatus("Сортировка по цене (убывание)");
            }

            DisplayComputers();
        }

        private void buttonStatisticsYSD_Click(object sender, EventArgs e)
        {
            if (computers.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var stats = dataService.CalculateStatistics(computers);

            string message = $"Статистика по {computers.Count} компьютерам:\n\n" +
                           $"Общая стоимость: {stats.TotalPrice:C}\n" +
                           $"Средняя цена: {stats.AveragePrice:C}\n" +
                           $"Минимальная цена: {stats.MinPrice:C}\n" +
                           $"Максимальная цена: {stats.MaxPrice:C}\n" +
                           $"Средний объем ОЗУ: {stats.AverageRAM:F1} ГБ\n" +
                           $"Средний объем ЖД: {stats.AverageHDD:F0} ГБ\n" +
                           $"Средняя частота: {stats.AverageClockSpeed:F1} ГГц";

            MessageBox.Show(message, "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateStatus("Статистика отображена");
        }

        private void buttonChartYSD_Click(object sender, EventArgs e)
        {
            if (computers.Count == 0)
            {
                MessageBox.Show("Нет данных для построения графиков", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Создаем DataTable из списка компьютеров
            DataTable dataTable = CreateDataTableFromComputers();

            // Создаем и показываем форму с графиками
            ChartForm chartForm = new ChartForm(dataTable);
            chartForm.ShowDialog();
            UpdateStatus("Графики отображены");
        }

        private DataTable CreateDataTableFromComputers()
        {
            DataTable dataTable = new DataTable();

            // Создаем колонки
            dataTable.Columns.Add("Model", typeof(string));
            dataTable.Columns.Add("Manufacturer", typeof(string));
            dataTable.Columns.Add("Processor", typeof(string));
            dataTable.Columns.Add("ClockSpeed", typeof(double));
            dataTable.Columns.Add("RAM", typeof(int));
            dataTable.Columns.Add("HDD", typeof(int));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Columns.Add("ReleaseDate", typeof(DateTime));

            // Заполняем данными
            foreach (var computer in computers)
            {
                dataTable.Rows.Add(
                    computer.Model,
                    computer.Manufacturer,
                    computer.Processor,
                    computer.ClockSpeed,
                    computer.RAM,
                    computer.HDD,
                    computer.Price,
                    computer.ReleaseDate
                );
            }

            return dataTable;
        }

        private void buttonAboutYSD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Каталог персональных ЭВМ v1.0\n\n" +
                          "Разработчик: Ярков С.Д.\n" +
                          "Sprint 7 Project V12\n\n" +
                          "Программа для учета и анализа\n" +
                          "персональных компьютеров\n\n" +
                          "Функции:\n" +
                          "- Загрузка/сохранение данных\n" +
                          "- Добавление/редактирование/удаление\n" +
                          "- Поиск, фильтрация, сортировка\n" +
                          "- Статистический анализ\n" +
                          "- Визуализация данных (графики)",
                          "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Обработчики для текстового поля поиска
        private void textBoxSearchYSD_Enter(object sender, EventArgs e)
        {
            if (textBoxSearchYSD.Text == "Введите модель...")
            {
                textBoxSearchYSD.Text = "";
                textBoxSearchYSD.ForeColor = Color.Black;
            }
        }

        private void textBoxSearchYSD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchYSD.Text))
            {
                textBoxSearchYSD.Text = "Введите модель...";
                textBoxSearchYSD.ForeColor = Color.Gray;
            }
        }

        // Обработчик двойного клика по DataGridView
        private void dataGridViewComputersYSD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < computers.Count)
            {
                dataGridViewComputersYSD.Rows[e.RowIndex].Selected = true;
                buttonEditComputerYSD_Click(sender, e);
            }
        }

        // Обработчик нажатия клавиш в DataGridView
        private void dataGridViewComputersYSD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && buttonDeleteComputerYSD.Enabled)
            {
                buttonDeleteComputerYSD_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter && buttonEditComputerYSD.Enabled)
            {
                buttonEditComputerYSD_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F1)
            {
                buttonAboutYSD_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && buttonChartYSD.Enabled)
            {
                buttonChartYSD_Click(sender, e);
            }
        }

        // Обработчик изменения выделения в DataGridView
        private void dataGridViewComputersYSD_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState(computers.Count > 0);
        }

        // Новые методы для горячих клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                buttonLoadDataYSD_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                buttonSaveDataYSD_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                buttonAddComputerYSD_Click(this, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.F))
            {
                textBoxSearchYSD.Focus();
                return true;
            }
            else if (keyData == Keys.F12)
            {
                buttonChartYSD_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Метод для тестирования - создание демо-данных
        private void CreateDemoData()
        {
            if (computers.Count == 0)
            {
                computers = new List<DataServiceYSD.ComputerYSD>
                {
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "Inspiron 15 3000",
                        Manufacturer = "Dell",
                        Processor = "Intel Core i5",
                        ClockSpeed = 2.5,
                        RAM = 8,
                        HDD = 1000,
                        Price = 45000,
                        ReleaseDate = new DateTime(2023, 1, 15)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "ThinkPad E14",
                        Manufacturer = "Lenovo",
                        Processor = "Intel Core i7",
                        ClockSpeed = 3.2,
                        RAM = 16,
                        HDD = 512,
                        Price = 75000,
                        ReleaseDate = new DateTime(2023, 3, 20)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "Pavilion 15",
                        Manufacturer = "HP",
                        Processor = "AMD Ryzen 5",
                        ClockSpeed = 3.0,
                        RAM = 8,
                        HDD = 500,
                        Price = 40000,
                        ReleaseDate = new DateTime(2023, 2, 10)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "MacBook Air M2",
                        Manufacturer = "Apple",
                        Processor = "Apple M2",
                        ClockSpeed = 3.5,
                        RAM = 8,
                        HDD = 256,
                        Price = 120000,
                        ReleaseDate = new DateTime(2023, 6, 1)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "VivoBook 15",
                        Manufacturer = "ASUS",
                        Processor = "Intel Core i3",
                        ClockSpeed = 2.0,
                        RAM = 4,
                        HDD = 1000,
                        Price = 30000,
                        ReleaseDate = new DateTime(2022, 11, 15)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "Aspire 5",
                        Manufacturer = "Acer",
                        Processor = "Intel Core i5",
                        ClockSpeed = 2.8,
                        RAM = 12,
                        HDD = 1000,
                        Price = 50000,
                        ReleaseDate = new DateTime(2023, 4, 5)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "Legion 5",
                        Manufacturer = "Lenovo",
                        Processor = "Intel Core i9",
                        ClockSpeed = 4.0,
                        RAM = 32,
                        HDD = 2000,
                        Price = 150000,
                        ReleaseDate = new DateTime(2023, 7, 10)
                    },
                    new DataServiceYSD.ComputerYSD
                    {
                        Model = "XPS 13",
                        Manufacturer = "Dell",
                        Processor = "Intel Core i7",
                        ClockSpeed = 3.6,
                        RAM = 16,
                        HDD = 1000,
                        Price = 110000,
                        ReleaseDate = new DateTime(2023, 5, 25)
                    }
                };

                DisplayComputers();
                UpdateManufacturersList();
                UpdateStatus($"Создано {computers.Count} демо-записей");
                UpdateButtonsState(true);
            }
        }

        // Кнопка для демо-данных (можно добавить в интерфейс)
        private void buttonDemoDataYSD_Click(object sender, EventArgs e)
        {
            CreateDemoData();
        }

        private void buttonStatisticsYSD_Click_1(object sender, EventArgs e)
        {

        }
    }
}