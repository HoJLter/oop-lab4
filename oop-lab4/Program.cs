
using oop_lab4.Models.Data;
using oop_lab4.Models.ControlData;

namespace oop_lab4.Forms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        FirmFactory.Initialize(
            new SbFirmType("Основное подразделение", true),
            new List<string>
            {
                "Field1", "Field2", "Field3",
                "Field4", "Field5"
            }
        );

        List<Firm> firms = new List<Firm>();

        Firm firm1 = FirmFactory.Instance.Create();
        firm1.Name = "Яндекс";
        firm1.Country = "Россия";
        firm1.Town = "Москва";
        firm1.DateIn = new DateTime(2024, 1, 15);
        firms.Add(firm1);

        Firm firm2 = FirmFactory.Instance.Create();
        firm2.Name = "Сбер";
        firm2.Country = "Россия";
        firm2.Town = "Нижний Новгород";
        firm2.DateIn = new DateTime(2023, 5, 20);
        firms.Add(firm2);

        Firm firm3 = FirmFactory.Instance.Create();
        firm3.Name = "Google";
        firm3.Country = "США";
        firm3.Town = "Маунтин-Вью";
        firm3.DateIn = new DateTime(2022, 9, 10);
        firms.Add(firm3);

        FirmView view = new FirmView(new List<Field>
        {
            new NameField(),
            new CountryField(),
            new TownField(),
            new DateInField()
        });

        FirmManager manager = new FirmManager(firms, view);

        Application.Run(new MainForm(manager));
    }
}
