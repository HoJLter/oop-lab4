namespace oop_lab4
{
    partial class FiltersForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            controlPanel = new Panel();
            applyButton = new Button();
            filterTable = new TableLayoutPanel();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // controlPanel
            // 
            controlPanel.BorderStyle = BorderStyle.Fixed3D;
            controlPanel.Controls.Add(applyButton);
            controlPanel.Dock = DockStyle.Right;
            controlPanel.Location = new Point(793, 0);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(132, 450);
            controlPanel.TabIndex = 0;
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            applyButton.Location = new Point(17, 10);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(101, 23);
            applyButton.TabIndex = 0;
            applyButton.Text = "Применить";
            applyButton.UseVisualStyleBackColor = true;
            // 
            // filterTable
            // 
            filterTable.ColumnCount = 4;
            filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.1464214F));
            filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.219635F));
            filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.80958366F));
            filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.9571266F));
            filterTable.Dock = DockStyle.Fill;
            filterTable.Location = new Point(0, 0);
            filterTable.Name = "filterTable";
            filterTable.RowCount = 15;
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.RowStyles.Add(new RowStyle(SizeType.Percent, 6.666668F));
            filterTable.Size = new Size(793, 450);
            filterTable.TabIndex = 1;
            // 
            // FiltersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 450);
            Controls.Add(filterTable);
            Controls.Add(controlPanel);
            Name = "FiltersForm";
            Text = "Filters";
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel controlPanel;
        private Button applyButton;
        private TableLayoutPanel filterTable;
    }
}
