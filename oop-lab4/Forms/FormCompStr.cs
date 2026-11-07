using System;
using System.Drawing;
using System.Windows.Forms;
using oop_lab4.Models.ControlData;

namespace oop_lab4.Forms;

public class FrmCompStr : Panel
{
    private Label fieldLabel;
    private TextBox valueInput;
    private CheckBox disabledCheck;
    private RadioButton equalRadio;
    private RadioButton notEqualRadio;
    private RadioButton containsRadio;
    private RadioButton notContainsRadio;

    public FrmCompStr(int index, int y, string title)
    {
        Name = "stringPanel" + index;
        Location = new Point(10, y);
        Size = new Size(900, 40);

        fieldLabel = new Label();
        fieldLabel.Name = "fieldLabel" + index;
        fieldLabel.Text = title;
        fieldLabel.AutoSize = true;
        fieldLabel.Location = new Point(18, 13);

        valueInput = new TextBox();
        valueInput.Name = "valueInput" + index;
        valueInput.Location = new Point(171, 10);
        valueInput.Size = new Size(242, 23);
        valueInput.Text = "";

        disabledCheck = new CheckBox();
        disabledCheck.Name = "disabledCheck" + index;
        disabledCheck.Text = "нет";
        disabledCheck.AutoSize = true;
        disabledCheck.Location = new Point(479, 12);
        disabledCheck.Checked = true;

        equalRadio = new RadioButton();
        equalRadio.Name = "equalRadio" + index;
        equalRadio.Text = "=";
        equalRadio.AutoSize = true;
        equalRadio.Location = new Point(541, 11);
        equalRadio.Checked = true;

        notEqualRadio = new RadioButton();
        notEqualRadio.Name = "notEqualRadio" + index;
        notEqualRadio.Text = "!=";
        notEqualRadio.AutoSize = true;
        notEqualRadio.Location = new Point(595, 11);

        containsRadio = new RadioButton();
        containsRadio.Name = "containsRadio" + index;
        containsRadio.Text = "Содержит";
        containsRadio.AutoSize = true;
        containsRadio.Location = new Point(650, 11);

        notContainsRadio = new RadioButton();
        notContainsRadio.Name = "notContainsRadio" + index;
        notContainsRadio.Text = "Не содержит";
        notContainsRadio.AutoSize = true;
        notContainsRadio.Location = new Point(750, 11);

        Controls.Add(fieldLabel);
        Controls.Add(valueInput);
        Controls.Add(disabledCheck);
        Controls.Add(equalRadio);
        Controls.Add(notEqualRadio);
        Controls.Add(containsRadio);
        Controls.Add(notContainsRadio);

        disabledCheck.CheckedChanged += DisabledCheck_CheckedChanged;

        UpdateInputs();
    }

    private void DisabledCheck_CheckedChanged(object sender, EventArgs e)
    {
        UpdateInputs();
    }

    private void UpdateInputs()
    {
        bool enabled = !disabledCheck.Checked;

        fieldLabel.Enabled = enabled;
        valueInput.Enabled = enabled;
        equalRadio.Enabled = enabled;
        notEqualRadio.Enabled = enabled;
        containsRadio.Enabled = enabled;
        notContainsRadio.Enabled = enabled;
    }

    public bool IsActive()
    {
        return !disabledCheck.Checked;
    }

    public StrFieldExpr GetExpression()
    {
        LogExpEnum operation;

        if (notEqualRadio.Checked)
        {
            operation = LogExpEnum.NoEQ;
        }
        else if (containsRadio.Checked)
        {
            operation = LogExpEnum.Contains;
        }
        else if (notContainsRadio.Checked)
        {
            operation = LogExpEnum.NoContains;
        }
        else
        {
            operation = LogExpEnum.EQ;
        }

        StrFieldExpr expression = new StrFieldExpr();
        expression.Expected = valueInput.Text;
        expression.Operation = LogExpFactory.CreateString(operation);

        return expression;
    }
}