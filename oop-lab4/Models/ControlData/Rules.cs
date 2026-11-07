using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab4.Models.ControlData;
using oop_lab4.Models.Data;

public abstract class FilterRule
{
    public abstract bool FirmRespond(Firm firm);
}

public class NameRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Name);
    }
}

public class CountryRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Country);
    }
}

public class RegionRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Region);
    }
}

public class TownRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Town);
    }
}

public class PostInxRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.PostInx);
    }
}

public class StreetRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Street);
    }
}

public class EmailRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Email);
    }
}

public class WebRule : FilterRule
{
    public StrFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.Web);
    }
}

public class DateInRule : FilterRule
{
    public DateFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.DateIn.Date);
    }
}

public class DateBegRule : FilterRule
{
    public DateFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        DateTime? date = firm.GetMain().GetLastContactBeginDate();

        if (!date.HasValue)
        {
            return false;
        }

        return Expression.Check(date.Value.Date);
    }
}

public class ContCountRule : FilterRule
{
    public IntFieldExpr Expression { get; set; }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.GetMain().CountCont);
    }
}

public class UsrFieldRule : FilterRule
{
    private string _fieldName;

    public StrFieldExpr Expression { get; set; }

    public UsrFieldRule(string fieldName)
    {
        _fieldName = fieldName;
    }

    public override bool FirmRespond(Firm firm)
    {
        return Expression.Check(firm.GetField(_fieldName));
    }
}