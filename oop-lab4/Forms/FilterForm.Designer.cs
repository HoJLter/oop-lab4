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
            stringPanel = new Panel();
            fieldLabel = new Label();
            valueInput = new TextBox();
            disabledCheck = new CheckBox();
            equalRadio = new RadioButton();
            notEqualRadio = new RadioButton();
            containsRadio = new RadioButton();
            notContainsRadio = new RadioButton();
            stringPanel.SuspendLayout();
            SuspendLayout();
            // 
            // stringPanel
            // 
            stringPanel.Controls.Add(notContainsRadio);
            stringPanel.Controls.Add(containsRadio);
            stringPanel.Controls.Add(notEqualRadio);
            stringPanel.Controls.Add(equalRadio);
            stringPanel.Controls.Add(disabledCheck);
            stringPanel.Controls.Add(valueInput);
            stringPanel.Controls.Add(fieldLabel);
            stringPanel.Location = new Point(10, 10);
            stringPanel.Name = "stringPanel";
            stringPanel.Size = new Size(850, 40);
            stringPanel.TabIndex = 0;
            // 
            // fieldLabel
            // 
            fieldLabel.AutoSize = true;
            fieldLabel.Location = new Point(18, 13);
            fieldLabel.Name = "fieldLabel";
            fieldLabel.Size = new Size(40, 15);
            fieldLabel.TabIndex = 0;
            fieldLabel.Text = "Город";
            // 
            // valueInput
            // 
            valueInput.Enabled = false;
            valueInput.Location = new Point(171, 10);
            valueInput.Name = "valueInput";
            valueInput.Size = new Size(242, 23);
            valueInput.TabIndex = 1;
            valueInput.Text = "Пусто";
            // 
            // disabledCheck
            // 
            disabledCheck.AutoSize = true;
            disabledCheck.Checked = true;
            disabledCheck.CheckState = CheckState.Checked;
            disabledCheck.Location = new Point(479, 12);
            disabledCheck.Name = "disabledCheck";
            disabledCheck.Size = new Size(44, 19);
            disabledCheck.TabIndex = 2;
            disabledCheck.Text = "нет";
            disabledCheck.UseVisualStyleBackColor = true;
            // 
            // equalRadio
            // 
            equalRadio.AutoSize = true;
            equalRadio.Checked = true;
            equalRadio.Enabled = false;
            equalRadio.Location = new Point(541, 11);
            equalRadio.Name = "equalRadio";
            equalRadio.Size = new Size(33, 19);
            equalRadio.TabIndex = 3;
            equalRadio.TabStop = true;
            equalRadio.Text = "=";
            equalRadio.UseVisualStyleBackColor = true;
            // 
            // notEqualRadio
            // 
            notEqualRadio.AutoSize = true;
            notEqualRadio.Enabled = false;
            notEqualRadio.Location = new Point(580, 11);
            notEqualRadio.Name = "notEqualRadio";
            notEqualRadio.Size = new Size(36, 19);
            notEqualRadio.TabIndex = 4;
            notEqualRadio.Text = "!=";
            notEqualRadio.UseVisualStyleBackColor = true;
            // 
            // containsRadio
            // 
            containsRadio.AutoSize = true;
            containsRadio.Enabled = false;
            containsRadio.Location = new Point(621, 11);
            containsRadio.Name = "containsRadio";
            containsRadio.Size = new Size(80, 19);
            containsRadio.TabIndex = 5;
            containsRadio.Text = "Содержит";
            containsRadio.UseVisualStyleBackColor = true;
            // 
            // notContainsRadio
            // 
            notContainsRadio.AutoSize = true;
            notContainsRadio.Enabled = false;
            notContainsRadio.Location = new Point(707, 12);
            notContainsRadio.Name = "notContainsRadio";
            notContainsRadio.Size = new Size(96, 19);
            notContainsRadio.TabIndex = 6;
            notContainsRadio.Text = "Не содержит";
            notContainsRadio.UseVisualStyleBackColor = true;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 450);
            Controls.Add(stringPanel);
            Name = "FilterForm";
            Text = "FilterForm";
            stringPanel.ResumeLayout(false);
            stringPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel stringPanel;
        private TextBox valueInput;
        private Label fieldLabel;
        private RadioButton notContainsRadio;
        private RadioButton containsRadio;
        private RadioButton notEqualRadio;
        private RadioButton equalRadio;
        private CheckBox disabledCheck;
    }
}