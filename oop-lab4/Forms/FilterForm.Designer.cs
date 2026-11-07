namespace oop_lab4.Forms
{
    partial class FilterForm
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
            applyButton = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // applyButton
            // 
            applyButton.Location = new Point(14, 10);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(123, 29);
            applyButton.TabIndex = 0;
            applyButton.Text = "Применить";
            applyButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(applyButton);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(924, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(144, 649);
            panel1.TabIndex = 1;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 649);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FilterForm";
            Text = "FilterForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button applyButton;
        private Panel panel1;
    }
}