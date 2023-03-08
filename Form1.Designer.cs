
namespace FaceDetect2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResBox = new System.Windows.Forms.PictureBox();
            this.FileButton = new System.Windows.Forms.ToolStripButton();
            this.MethodBox = new System.Windows.Forms.ToolStripComboBox();
            this.TemplateBox = new System.Windows.Forms.ToolStripComboBox();
            this.ResButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripButton();
            this.Methods = new System.Windows.Forms.ToolStripComboBox();
            this.Templates = new System.Windows.Forms.ToolStripComboBox();
            this.FindB = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ResBox);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 0;
            // 
            // ResBox
            // 
            this.ResBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResBox.Location = new System.Drawing.Point(0, 0);
            this.ResBox.Name = "ResBox";
            this.ResBox.Size = new System.Drawing.Size(800, 426);
            this.ResBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResBox.TabIndex = 0;
            this.ResBox.TabStop = false;
            // 
            // FileButton
            // 
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(23, 23);
            // 
            // MethodBox
            // 
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(121, 25);
            // 
            // TemplateBox
            // 
            this.TemplateBox.Name = "TemplateBox";
            this.TemplateBox.Size = new System.Drawing.Size(121, 25);
            // 
            // ResButton
            // 
            this.ResButton.Name = "ResButton";
            this.ResButton.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightCoral;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Methods,
            this.Templates,
            this.FindB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.SeaShell;
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.Image = ((System.Drawing.Image)(resources.GetObject("File.Image")));
            this.File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(49, 25);
            this.File.Text = "Файл";
            this.File.Click += new System.EventHandler(this.File_Click);
            // 
            // Methods
            // 
            this.Methods.Items.AddRange(new object[] {
            "Шаблоны",
            "Виола-Джонс",
            "Линии Сим"});
            this.Methods.Name = "Methods";
            this.Methods.Size = new System.Drawing.Size(121, 28);
            // 
            // Templates
            // 
            this.Templates.Items.AddRange(new object[] {
            "Брови",
            "Бровь(Л)",
            "Бровь(П)",
            "Глаза",
            "Глаз(Л)",
            "Глаз(П)",
            "Нос",
            "Рот",
            "Лицо"});
            this.Templates.Name = "Templates";
            this.Templates.Size = new System.Drawing.Size(121, 28);
            this.Templates.SelectedIndexChanged += new System.EventHandler(this.Templates_SelectedIndexChanged);
            // 
            // FindB
            // 
            this.FindB.BackColor = System.Drawing.Color.SeaShell;
            this.FindB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FindB.Image = ((System.Drawing.Image)(resources.GetObject("FindB.Image")));
            this.FindB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindB.Name = "FindB";
            this.FindB.Size = new System.Drawing.Size(56, 25);
            this.FindB.Text = "Найти";
            this.FindB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FindB.Click += new System.EventHandler(this.FindB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ResBox;
        private System.Windows.Forms.ToolStripButton FileButton;
        private System.Windows.Forms.ToolStripComboBox MethodBox;
        private System.Windows.Forms.ToolStripComboBox TemplateBox;
        private System.Windows.Forms.ToolStripButton ResButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton File;
        private System.Windows.Forms.ToolStripComboBox Methods;
        private System.Windows.Forms.ToolStripComboBox Templates;
        private System.Windows.Forms.ToolStripButton FindB;
    }
}

