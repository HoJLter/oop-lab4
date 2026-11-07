using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using oop_lab4.Models.ControlData;

namespace oop_lab4.Forms;

public class FrmCompVal : Panel
{
    private Label _fieldLabel;
    private TextBox _valueInput;
    private CheckBox _disabledCheck;

    private RadioButton _equalRadio;
    private RadioButton _notEqualRadio;
    private RadioButton _lessRadio;
    private RadioButton _greaterRadio;

    public FrmCompVal(int index, int y, string title)
    {
        Name = "valuePanel" + index;
        Location = new Point(10, y);
        Size = new Size(860, 40);

        _fieldLabel = new Label
        {
            Name = "valueFieldLabel" + index,
            Text = title,
            AutoSize = true,
            Location = new Point(18, 13)
        };

        _valueInput = new TextBox
        {
            Name = "valueInput" + index,
            Location = new Point(171, 10),
            Size = new Size(242, 23)
        };

        _disabledCheck = new CheckBox
        {
            Name = "disabledCheck" + index,
            Text = "нет",
            AutoSize = true,
            Location = new Point(479, 12),
            Checked = true
        };

        _equalRadio = new RadioButton
        {
            Name = "equalRadio" + index,
            Text = "=",
            AutoSize = true,
            Location = new Point(541, 11),
            Checked = true
        };

        _notEqualRadio = new RadioButton
        {
            Name = "notEqualRadio" + index,
            Text = "!=",
            AutoSize = true,
            Location = new Point(595, 11)
        };

        _lessRadio = new RadioButton
        {
            Name = "lessRadio" + index,
            Text = "<",
            AutoSize = true,
            Location = new Point(650, 11)
        };

        _greaterRadio = new RadioButton
        {
            Name = "greaterRadio" + index,
            Text = ">",
            AutoSize = true,
            Location = new Point(750, 11)
        };

        Controls.AddRange(new Control[]
        {
            _fieldLabel,
            _valueInput,
            _disabledCheck,
            _equalRadio,
            _notEqualRadio,
            _lessRadio,
            _greaterRadio
        });

        _disabledCheck.CheckedChanged += DisabledCheck_CheckedChanged;

        UpdateInputs();
    }

    private void DisabledCheck_CheckedChanged(object? sender, EventArgs e)
    {
        UpdateInputs();
    }

    private void UpdateInputs()
    {
        bool enabled = !_disabledCheck.Checked;

        _fieldLabel.Enabled = enabled;
        _valueInput.Enabled = enabled;
        _equalRadio.Enabled = enabled;
        _notEqualRadio.Enabled = enabled;
        _lessRadio.Enabled = enabled;
        _greaterRadio.Enabled = enabled;
    }

    public bool IsActive()
    {
        return !_disabledCheck.Checked;
    }

    private LogExpEnum GetOperation()
    {
        if (_notEqualRadio.Checked)
            return LogExpEnum.NoEQ;

        if (_lessRadio.Checked)
            return LogExpEnum.LT;

        if (_greaterRadio.Checked)
            return LogExpEnum.GT;

        return LogExpEnum.EQ;
    }

    public DateFieldExpr GetDateExpression()
    {
        bool valid = DateTime.TryParseExact(
            _valueInput.Text.Trim(),
            "dd.MM.yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime date
        );

        if (!valid)
        {
            throw new FormatException(
                $"Поле «{_fieldLabel.Text}»: введите дату в формате ДД.ММ.ГГГГ."
            );
        }

        return new DateFieldExpr
        {
            Expected = date,
            Operation = LogExpFactory.Create<DateTime>(GetOperation())
        };
    }

    public IntFieldExpr GetIntExpression()
    {
        bool valid = int.TryParse(
            _valueInput.Text.Trim(),
            out int number
        );

        if (!valid || number < 0)
        {
            throw new FormatException(
                $"Поле «{_fieldLabel.Text}»: введите целое неотрицательное число."
            );
        }

        return new IntFieldExpr
        {
            Expected = number,
            Operation = LogExpFactory.Create<int>(GetOperation())
        };
    }
}