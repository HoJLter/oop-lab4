using System;
using System.Windows.Forms;
using oop_lab4.Controllers;
using oop_lab4.Models.ControlData;

namespace oop_lab4.Forms;

public partial class FilterForm : Form
{
    private FilterController _controller;
    private FrmCompStr _townPanel;
    private Button _applyButton;

    public FilterForm(FilterController controller)
    {
        InitializeComponent();

        _controller = controller;

        _townPanel = new FrmCompStr(0, 10, "Город");
        Controls.Add(_townPanel);

        _applyButton = new Button();
        _applyButton.Text = "Применить";
        _applyButton.Dock = DockStyle.Bottom;
        _applyButton.Height = 40;
        _applyButton.Click += ApplyButton_Click;

        Controls.Add(_applyButton);
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
        if (_townPanel.IsActive())
        {
            TownField field = new TownField();
            TownRule rule = (TownRule)field.CreateRule();

            rule.Expression = _townPanel.GetExpression();

            _controller.AddRule(rule);
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}