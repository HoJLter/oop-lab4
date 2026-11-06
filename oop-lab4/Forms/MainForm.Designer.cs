namespace oop_lab4.Forms
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
            topPanel = new Panel();
            firmsList = new ListView();
            filterButton = new Button();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(filterButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(800, 31);
            topPanel.TabIndex = 0;
            // 
            // firmsList
            // 
            firmsList.Dock = DockStyle.Fill;
            firmsList.Location = new Point(0, 31);
            firmsList.Name = "firmsList";
            firmsList.Size = new Size(800, 419);
            firmsList.TabIndex = 1;
            firmsList.UseCompatibleStateImageBehavior = false;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(12, 5);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(133, 23);
            filterButton.TabIndex = 0;
            filterButton.Text = "Фильтровать";
            filterButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(firmsList);
            Controls.Add(topPanel);
            Name = "MainForm";
            Text = "MainForm";
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Button filterButton;
        private ListView firmsList;
    }
}