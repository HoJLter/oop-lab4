using System.Collections.Generic;
using oop_lab4.Models.Data;
using oop_lab4.Models.ControlData;

namespace oop_lab4.Controllers;

public class MainController
{
    private FirmManager _manager;

    public FirmManager Manager
    {
        get
        {
            return _manager;
        }
    }

    public MainController(FirmManager manager)
    {
        _manager = manager;
    }

    public FilterController CreateFilterController()
    {
        return new FilterController(_manager);
    }

    public void ApplyFilter(FilterController filterController)
    {
        _manager = filterController.Apply();
    }
}

public class FilterController
{
    private FirmManager _manager;
    private List<FilterRule> _rules;

    public FilterController(FirmManager manager)
    {
        _manager = manager;
        _rules = new List<FilterRule>();
    }

    public void AddRule(FilterRule rule)
    {
        _rules.Add(rule);
    }

    public FirmManager Apply()
    {
        List<Firm> result = new List<Firm>();

        foreach (Firm firm in _manager.Firms)
        {
            bool matches = true;

            foreach (FilterRule rule in _rules)
            {
                if (!rule.FirmRespond(firm))
                {
                    matches = false;
                    break;
                }
            }

            if (matches)
            {
                result.Add(firm);
            }
        }

        return new FirmManager(result, _manager.View);
    }
}