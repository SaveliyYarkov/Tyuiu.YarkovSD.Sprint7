namespace Tyuiu.YarkovSD.Sprint7.Project.V12
{
    partial class AboutForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button buttonOK;
        private Panel panelInfo;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            buttonOK = new Button();
            panelInfo = new Panel();
            groupBox1 = new GroupBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label5 = new Label();
            groupBox2 = new GroupBox();
            label4 = new Label();
            label7 = new Label();
            panelInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonOK.Location = new Point(449, 358);
            buttonOK.Margin = new Padding(4, 3, 4, 3);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(88, 35);
            buttonOK.TabIndex = 6;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // panelInfo
            // 
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(groupBox2);
            panelInfo.Controls.Add(groupBox1);
            panelInfo.Controls.Add(buttonOK);
            panelInfo.Dock = DockStyle.Fill;
            panelInfo.Location = new Point(0, 0);
            panelInfo.Margin = new Padding(4, 3, 4, 3);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(575, 518);
            panelInfo.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(23, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(529, 243);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "О разработчике";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(188, 27);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(147, 15);
            label2.TabIndex = 5;
            label2.Text = "Разработчик: Ярков С.Д.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(18, 27);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(190, 76);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(145, 16);
            label3.TabIndex = 7;
            label3.Text = "Спринт 7  Project V12";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(188, 51);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 9;
            label5.Text = "Группа: РППб-25-1";
            label5.Click += label5_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(23, 260);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(529, 243);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "О программе";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(7, 60);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(428, 180);
            label4.TabIndex = 9;
            label4.Text = "Функционал:\r\n\r\nВвод\r\nРедактирование\r\nПоиск\r\nСортировка\r\nФильтрация \r\nУдаление ЭВМ.\r\n\r\nТакже реализованы статистики и Графики для полного анализа данных.\r\n\r\nВсе данные хранятся в CSV-файлах.";
            label4.Click += label4_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label7.Location = new Point(7, 32);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(180, 15);
            label7.TabIndex = 5;
            label7.Text = "\"Каталог персональных ЭВМ\"";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 518);
            Controls.Add(panelInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "О программе";
            Load += AboutForm_Load;
            panelInfo.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);

        }
        private GroupBox groupBox1;
        private Label label5;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label2;
        private GroupBox groupBox2;
        private Label label4;
        private Label label7;
    }
}