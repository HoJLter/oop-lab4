using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace oop_lab4.Models.ControlData;

public interface ILogExp<T>
{
    bool Compare(T actual, T expected);
}


//
//
//
// операции

public class ExpEQ<T> : ILogExp<T>
{
    public bool Compare(T actual, T expected)
    {
        return object.Equals(actual, expected);
    }
}

public class ExpNoEQ<T> : ILogExp<T>
{
    public bool Compare(T actual, T expected)
    {
        return !object.Equals(actual, expected);
    }
}

public class ExpGT<T> : ILogExp<T> where T : IComparable<T>
{
    public bool Compare(T actual, T expected)
    {
        return actual.CompareTo(expected) > 0;
    }
}

public class ExpLT<T> : ILogExp<T> where T : IComparable<T>
{
    public bool Compare(T actual, T expected)
    {
        return actual.CompareTo(expected) < 0;
    }
}

public class ExpGE<T> : ILogExp<T> where T : IComparable<T>
{
    public bool Compare(T actual, T expected)
    {
        return actual.CompareTo(expected) >= 0;
    }
}

public class ExpLE<T> : ILogExp<T> where T : IComparable<T>
{
    public bool Compare(T actual, T expected)
    {
        return actual.CompareTo(expected) <= 0;
    }
}

public class ExpContains : ILogExp<string>
{
    public bool Compare(string actual, string expected)
    {
        if (actual == null || expected == null)
        {
            return false;
        }

        return actual.Contains(expected);
    }
}

public class ExpNoContains : ILogExp<string>
{
    public bool Compare(string actual, string expected)
    {
        if (actual == null || expected == null)
        {
            return false;
        }

        return !actual.Contains(expected);
    }
}

//
//
//
// готовые выражения
//

public class StrFieldExpr
{
    public string Expected { get; set; }
    public ILogExp<string> Operation { get; set; }

    public bool Check(string actual)
    {
        return Operation.Compare(actual, Expected);
    }
}

public class DateFieldExpr
{
    public DateTime Expected { get; set; }
    public ILogExp<DateTime> Operation { get; set; }

    public bool Check(DateTime actual)
    {
        return Operation.Compare(actual, Expected);
    }
}

public class IntFieldExpr
{
    public int Expected { get; set; }
    public ILogExp<int> Operation { get; set; }

    public bool Check(int actual)
    {
        return Operation.Compare(actual, Expected);
    }
}