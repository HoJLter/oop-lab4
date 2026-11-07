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

        // Демонстрационные данные, не реальные реквизиты компаний.

        Firm firm1 = FirmFactory.Instance.Create();
        firm1.Name = "Яндекс";
        firm1.Country = "Россия";
        firm1.Region = "Москва";
        firm1.Town = "Москва";
        firm1.PostInx = "119021";
        firm1.Street = "Льва Толстого";
        firm1.Email = "info@yandex.example";
        firm1.Web = "yandex.example";
        firm1.DateIn = new DateTime(2024, 1, 15);

        firm1.SetField("Field1", "Постоянный клиент");
        firm1.SetField("Field2", "IT");
        firm1.SetField("Field3", "Высокий приоритет");
        firm1.SetField("Field4", "Иван");
        firm1.SetField("Field5", "Договор подписан");

        firm1.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 10, 10, 10, 0, 0),
            EndDt = new DateTime(2026, 10, 10, 11, 0, 0),
            Descr = "Первое обсуждение"
        });

        firm1.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 11, 1, 14, 30, 0),
            EndDt = new DateTime(2026, 11, 1, 15, 0, 0),
            Descr = "Согласование договора"
        });

        firms.Add(firm1);

        Firm firm2 = FirmFactory.Instance.Create();
        firm2.Name = "Сбер";
        firm2.Country = "Россия";
        firm2.Region = "Нижегородская область";
        firm2.Town = "Нижний Новгород";
        firm2.PostInx = "603000";
        firm2.Street = "Большая Покровская";
        firm2.Email = "info@sber.example";
        firm2.Web = "sber.example";
        firm2.DateIn = new DateTime(2023, 5, 20);

        firm2.SetField("Field1", "Новый клиент");
        firm2.SetField("Field2", "Финансы");
        firm2.SetField("Field3", "Средний приоритет");
        firm2.SetField("Field4", "Анна");
        firm2.SetField("Field5", "Ожидается ответ");

        firm2.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 11, 5, 9, 0, 0),
            EndDt = new DateTime(2026, 11, 5, 10, 0, 0),
            Descr = "Обсуждение сотрудничества"
        });

        firms.Add(firm2);

        Firm firm3 = FirmFactory.Instance.Create();
        firm3.Name = "Google";
        firm3.Country = "США";
        firm3.Region = "Калифорния";
        firm3.Town = "Маунтин-Вью";
        firm3.PostInx = "94043";
        firm3.Street = "Амфитеатр-Паркуэй";
        firm3.Email = "info@google.example";
        firm3.Web = "google.example";
        firm3.DateIn = new DateTime(2022, 9, 10);

        firm3.SetField("Field1", "Потенциальный клиент");
        firm3.SetField("Field2", "IT");
        firm3.SetField("Field3", "Низкий приоритет");
        firm3.SetField("Field4", "Иван");
        firm3.SetField("Field5", "Контактов пока нет");

        firms.Add(firm3);

        Firm firm4 = FirmFactory.Instance.Create();
        firm4.Name = "Вектор";
        firm4.Country = "Россия";
        firm4.Region = "Москва";
        firm4.Town = "Москва";
        firm4.PostInx = "101000";
        firm4.Street = "Мясницкая";
        firm4.Email = "info@vector.example";
        firm4.Web = "vector.example";
        firm4.DateIn = new DateTime(2025, 3, 12);

        firm4.SetField("Field1", "Новый клиент");
        firm4.SetField("Field2", "Производство");
        firm4.SetField("Field3", "Высокий приоритет");
        firm4.SetField("Field4", "Олег");
        firm4.SetField("Field5", "Подготовка договора");

        firm4.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 9, 15, 12, 0, 0),
            EndDt = new DateTime(2026, 9, 15, 13, 0, 0),
            Descr = "Знакомство"
        });

        firm4.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 10, 20, 11, 0, 0),
            EndDt = new DateTime(2026, 10, 20, 12, 0, 0),
            Descr = "Обсуждение требований"
        });

        firm4.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 11, 6, 16, 0, 0),
            EndDt = new DateTime(2026, 11, 6, 17, 0, 0),
            Descr = "Согласование стоимости"
        });

        firms.Add(firm4);

        Firm firm5 = FirmFactory.Instance.Create();
        firm5.Name = "Волга";
        firm5.Country = "Россия";
        firm5.Region = "Нижегородская область";
        firm5.Town = "Нижний Новгород";
        firm5.PostInx = "603005";
        firm5.Street = "Минина";
        firm5.Email = "info@volga.example";
        firm5.Web = "volga.example";
        firm5.DateIn = new DateTime(2025, 7, 1);

        firm5.SetField("Field1", "Постоянный клиент");
        firm5.SetField("Field2", "Логистика");
        firm5.SetField("Field3", "Средний приоритет");
        firm5.SetField("Field4", "Анна");
        firm5.SetField("Field5", "Договор подписан");

        firm5.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 10, 25, 10, 0, 0),
            EndDt = new DateTime(2026, 10, 25, 11, 0, 0),
            Descr = "Обсуждение доставки"
        });

        firms.Add(firm5);

        Firm firm6 = FirmFactory.Instance.Create();
        firm6.Name = "Нева";
        firm6.Country = "Россия";
        firm6.Region = "Санкт-Петербург";
        firm6.Town = "Санкт-Петербург";
        firm6.PostInx = "190000";
        firm6.Street = "Невский проспект";
        firm6.Email = "info@neva.example";
        firm6.Web = "neva.example";
        firm6.DateIn = new DateTime(2026, 2, 18);

        firm6.SetField("Field1", "Новый клиент");
        firm6.SetField("Field2", "IT");
        firm6.SetField("Field3", "Низкий приоритет");
        firm6.SetField("Field4", "Олег");
        firm6.SetField("Field5", "Ожидается ответ");

        firm6.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 10, 1, 9, 0, 0),
            EndDt = new DateTime(2026, 10, 1, 10, 0, 0),
            Descr = "Первый звонок"
        });

        firm6.AddCont(new Contact
        {
            BeginDt = new DateTime(2026, 11, 1, 11, 0, 0),
            EndDt = new DateTime(2026, 11, 1, 12, 0, 0),
            Descr = "Повторное обсуждение"
        });

        firms.Add(firm6);

        FirmView view = new FirmView(new List<Field>
        {
            new NameField(),
            new CountryField(),
            new TownField(),
            new DateInField(),
            new DateBegField(),
            new CountContField()
        });

        FirmManager manager = new FirmManager(firms, view);

        Application.Run(new MainForm(manager));
    }
}