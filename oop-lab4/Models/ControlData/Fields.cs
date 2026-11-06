using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lab4.Models.ControlData;

using oop_lab4.Models.Data;

public abstract class Field
{
    public abstract string GetValue(Firm firm);
    public abstract FilterRule CreateRule();

    public virtual Field Clone()
    {
        return (Field)MemberwiseClone();
    }
}

public class NameField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Name;
    }

    public override FilterRule CreateRule()
    {
        return new NameRule();
    }
}

public class CountryField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Country;
    }

    public override FilterRule CreateRule()
    {
        return new CountryRule();
    }
}

public class RegionField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Region;
    }

    public override FilterRule CreateRule()
    {
        return new RegionRule();
    }
}

public class TownField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Town;
    }

    public override FilterRule CreateRule()
    {
        return new TownRule();
    }
}

public class PostInxField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.PostInx;
    }

    public override FilterRule CreateRule()
    {
        return new PostInxRule();
    }
}

public class StreetField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Street;
    }

    public override FilterRule CreateRule()
    {
        return new StreetRule();
    }
}

public class EmailField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Email;
    }

    public override FilterRule CreateRule()
    {
        return new EmailRule();
    }
}

public class WebField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.Web;
    }

    public override FilterRule CreateRule()
    {
        return new WebRule();
    }
}

public class DateInField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.DateIn.ToString("dd.MM.yyyy");
    }

    public override FilterRule CreateRule()
    {
        return new DateInRule();
    }
}

public class DateBegField : Field
{
    public override string GetValue(Firm firm)
    {
        DateTime? date = firm.GetMain().GetLastContactBeginDate();

        if (date.HasValue)
        {
            return date.Value.ToString("dd.MM.yyyy");
        }

        return "";
    }

    public override FilterRule CreateRule()
    {
        return new DateBegRule();
    }
}

public class CountContField : Field
{
    public override string GetValue(Firm firm)
    {
        return firm.GetMain().CountCont.ToString();
    }

    public override FilterRule CreateRule()
    {
        return new ContCountRule();
    }
}

public class UsrField : Field
{
    private string _fieldName;

    public UsrField(string fieldName)
    {
        _fieldName = fieldName;
    }

    public override string GetValue(Firm firm)
    {
        return firm.GetField(_fieldName);
    }

    public override FilterRule CreateRule()
    {
        return new UsrFieldRule(_fieldName);
    }
}