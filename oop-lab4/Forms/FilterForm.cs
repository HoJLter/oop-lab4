using oop_lab4.Controllers;
using oop_lab4.Models.ControlData;
using oop_lab4.Models.Data;

namespace oop_lab4.Forms;

public partial class FilterForm : Form
{
    private FilterController _controller;

    private FrmCompStr _namePanel;
    private FrmCompVal _dateInPanel;
    private FrmCompStr _countryPanel;
    private FrmCompStr _postIndexPanel;
    private FrmCompStr _regionPanel;
    private FrmCompStr _townPanel;
    private FrmCompStr _streetPanel;
    private FrmCompStr _webPanel;
    private FrmCompVal _dateBegPanel;
    private FrmCompVal _countPanel;

    private List<string> _userFieldNames;
    private List<FrmCompStr> _userPanels;

    public FilterForm(FilterController controller)
    {
        InitializeComponent();

        _controller = controller;

        _namePanel = new FrmCompStr(0, 10, "Название");
        _dateInPanel = new FrmCompVal(1, 50, "Дата ввода");
        _countryPanel = new FrmCompStr(2, 90, "Страна");
        _postIndexPanel = new FrmCompStr(3, 130, "Индекс");
        _regionPanel = new FrmCompStr(4, 170, "Регион");
        _townPanel = new FrmCompStr(5, 210, "Город");
        _streetPanel = new FrmCompStr(6, 250, "Улица");
        _webPanel = new FrmCompStr(7, 290, "Web");
        _dateBegPanel = new FrmCompVal(8, 330, "Дата начала");
        _countPanel = new FrmCompVal(9, 370, "Число контактов");

        Controls.Add(_namePanel);
        Controls.Add(_dateInPanel);
        Controls.Add(_countryPanel);
        Controls.Add(_postIndexPanel);
        Controls.Add(_regionPanel);
        Controls.Add(_townPanel);
        Controls.Add(_streetPanel);
        Controls.Add(_webPanel);
        Controls.Add(_dateBegPanel);
        Controls.Add(_countPanel);

        _userFieldNames = FirmFactory.Instance.GetFields();
        _userPanels = new List<FrmCompStr>();

        for (int i = 0; i < _userFieldNames.Count; i++)
        {
            FrmCompStr panel = new FrmCompStr(
                10 + i,
                410 + i * 40,
                _userFieldNames[i]
            );

            _userPanels.Add(panel);
            Controls.Add(panel);
        }

        applyButton.Click += ApplyButton_Click;
        applyButton.DialogResult = DialogResult.None;
        AcceptButton = applyButton;
    }

    private void ApplyButton_Click(object? sender, EventArgs e)
    {
        List<FilterRule> rules = new List<FilterRule>();

        try
        {
            if (_namePanel.IsActive())
            {
                NameRule rule = new NameRule();
                rule.Expression = _namePanel.GetExpression();
                rules.Add(rule);
            }

            if (_dateInPanel.IsActive())
            {
                DateInRule rule = new DateInRule();
                rule.Expression = _dateInPanel.GetDateExpression();
                rules.Add(rule);
            }

            if (_countryPanel.IsActive())
            {
                CountryRule rule = new CountryRule();
                rule.Expression = _countryPanel.GetExpression();
                rules.Add(rule);
            }

            if (_postIndexPanel.IsActive())
            {
                PostInxRule rule = new PostInxRule();
                rule.Expression = _postIndexPanel.GetExpression();
                rules.Add(rule);
            }

            if (_regionPanel.IsActive())
            {
                RegionRule rule = new RegionRule();
                rule.Expression = _regionPanel.GetExpression();
                rules.Add(rule);
            }

            if (_townPanel.IsActive())
            {
                TownRule rule = new TownRule();
                rule.Expression = _townPanel.GetExpression();
                rules.Add(rule);
            }

            if (_streetPanel.IsActive())
            {
                StreetRule rule = new StreetRule();
                rule.Expression = _streetPanel.GetExpression();
                rules.Add(rule);
            }

            if (_webPanel.IsActive())
            {
                WebRule rule = new WebRule();
                rule.Expression = _webPanel.GetExpression();
                rules.Add(rule);
            }

            if (_dateBegPanel.IsActive())
            {
                DateBegRule rule = new DateBegRule();
                rule.Expression = _dateBegPanel.GetDateExpression();
                rules.Add(rule);
            }

            if (_countPanel.IsActive())
            {
                ContCountRule rule = new ContCountRule();
                rule.Expression = _countPanel.GetIntExpression();
                rules.Add(rule);
            }

            for (int i = 0; i < _userPanels.Count; i++)
            {
                if (_userPanels[i].IsActive())
                {
                    UsrFieldRule rule = new UsrFieldRule(
                        _userFieldNames[i]
                    );

                    rule.Expression = _userPanels[i].GetExpression();
                    rules.Add(rule);
                }
            }
        }
        catch (FormatException exception)
        {
            MessageBox.Show(exception.Message, "Ошибка ввода");
            return;
        }

        foreach (FilterRule rule in rules)
        {
            _controller.AddRule(rule);
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}