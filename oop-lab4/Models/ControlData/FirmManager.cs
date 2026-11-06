using System.Collections.Generic;
using oop_lab4.Models.Data;

namespace oop_lab4.Models.ControlData;

public class FirmView
{
    public List<Field> Fields { get; set; }

    public FirmView(List<Field> fields)
    {
        Fields = new List<Field>(fields);
    }
}

public class FirmManager
{
    public List<Firm> Firms { get; set; }
    public FirmView View { get; set; }

    public FirmManager(List<Firm> firms, FirmView view)
    {
        Firms = new List<Firm>(firms);
        View = view;
    }
}