namespace task
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.figureSwitch = new System.Windows.Forms.ComboBox();
            this.paintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // figureSwitch
            // 
            this.figureSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.figureSwitch.FormattingEnabled = true;
            this.figureSwitch.ItemHeight = 25;
            this.figureSwitch.Items.AddRange(new object[] { "Многоугольник с доп. отрезками", "Звезда с доп. отрезками внутрь", "Звезда с доп. отрезками по краям", "Многоугольник с горизонтальной растяжкой", "Многоугольник с вертикальной растяжкой", "Звезда с горизонтальной растяжкой", "Звезда с вертикальной растяжкой", "Орнамент а", "Орнамент б", "Орнамент в", "Орнамент г", "N-угольная звезда, N - четное", "N-угольная звезда, N - кратно 3" });
            this.figureSwitch.Location = new System.Drawing.Point(12, 12);
            this.figureSwitch.Name = "figureSwitch";
            this.figureSwitch.Size = new System.Drawing.Size(400, 33);
            this.figureSwitch.TabIndex = 0;
            this.figureSwitch.Text = "Выберите фигуру";
            // 
            // paintButton
            // 
            this.paintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.paintButton.Location = new System.Drawing.Point(418, 12);
            this.paintButton.Margin = new System.Windows.Forms.Padding(0);
            this.paintButton.Name = "paintButton";
            this.paintButton.Size = new System.Drawing.Size(150, 30);
            this.paintButton.TabIndex = 1;
            this.paintButton.Text = "Построить";
            this.paintButton.UseVisualStyleBackColor = true;
            this.paintButton.Click += new System.EventHandler(this.paintButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paintButton);
            this.Controls.Add(this.figureSwitch);
            this.Name = "MainForm";
            this.Text = "Фигуры из отрезков прямых";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button paintButton;

        private System.Windows.Forms.ComboBox figureSwitch;

        #endregion
    }
}