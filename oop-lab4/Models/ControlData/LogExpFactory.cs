using System;

namespace oop_lab4.Models.ControlData;

public enum LogExpEnum
{
    EQ,
    NoEQ,
    GT,
    LT,
    GE,
    LE,
    Contains,
    NoContains
}

public static class LogExpFactory
{
    public static ILogExp<T> Create<T>(LogExpEnum operation) where T : IComparable<T>
    {
        switch (operation)
        {
            case LogExpEnum.EQ:
                {
                    return new ExpEQ<T>();
                }

            case LogExpEnum.NoEQ:
                {
                    return new ExpNoEQ<T>();
                }

            case LogExpEnum.GT:
                {
                    return new ExpGT<T>();
                }

            case LogExpEnum.LT:
                {
                    return new ExpLT<T>();
                }

            case LogExpEnum.GE:
                {
                    return new ExpGE<T>();
                }

            case LogExpEnum.LE:
                {
                    return new ExpLE<T>();
                }

            default:
                {
                    throw new ArgumentException("операция неправильная");
                }
        }
    }

    public static ILogExp<string> CreateString(LogExpEnum operation)
    {
        switch (operation)
        {
            case LogExpEnum.Contains:
                {
                    return new ExpContains();
                }

            case LogExpEnum.NoContains:
                {
                    return new ExpNoContains();
                }

            default:
                {
                    return Create<string>(operation);
                }
        }
    }
}