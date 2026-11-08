using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA2;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace oop_lab4.Tests;

[TestClass]
[DoNotParallelize]
public class FilterGuiTests
{
    private const string AppPath =
        @"C:\Users\HoJLter\source\repos\HoJLter\oop-lab4\oop-lab4\bin\Debug\net10.0-windows\oop-lab4.exe";

    private const string AllFirms =
        "Яндекс|Сбер|Google|Вектор|Волга|Нева";

    [TestMethod]
    [DataRow("equalRadio5", "Москва", "Яндекс|Вектор")]
    [DataRow("notEqualRadio5", "Москва", "Сбер|Google|Волга|Нева")]
    [DataRow("containsRadio5", "Новгород", "Сбер|Волга")]
    [DataRow("notContainsRadio5", "Новгород", "Яндекс|Google|Вектор|Нева")]
    [DataRow("equalRadio5", "Казань", "")]
    public void FilterByTown(
        string operation,
        string town,
        string expected)
    {
        RunFilter(
            operation,
            town,
            null,
            null,
            expected
        );
    }

    [TestMethod]
    [DataRow("equalRadio8", "01.11.2026", "Яндекс|Нева")]
    [DataRow("notEqualRadio8", "01.11.2026", "Сбер|Вектор|Волга")]
    [DataRow("lessRadio8", "01.11.2026", "Волга")]
    [DataRow("greaterRadio8", "01.11.2026", "Сбер|Вектор")]
    [DataRow("equalRadio8", "10.10.2026", "")]
    public void FilterByContactDate(
        string operation,
        string date,
        string expected)
    {
        RunFilter(
            null,
            null,
            operation,
            date,
            expected
        );
    }

    [TestMethod]
    [DataRow("greaterRadio8", "Вектор")]
    [DataRow("lessRadio8", "")]
    public void FilterByTownAndDate(
        string dateOperation,
        string expected)
    {
        RunFilter(
            "equalRadio5",
            "Москва",
            dateOperation,
            "01.11.2026",
            expected
        );
    }

    [TestMethod]
    public void DisabledFilters_KeepAllFirms()
    {
        RunFilter(
            null,
            null,
            null,
            null,
            AllFirms
        );
    }

    private void RunFilter(
        string? townOperation,
        string? town,
        string? dateOperation,
        string? date,
        string expected)
    {
        Assert.IsTrue(
            File.Exists(AppPath),
            "Не найден exe приложения. Проверь AppPath и собери проект."
        );

        using UIA2Automation automation = new UIA2Automation();
        using Application app = Application.Launch(AppPath);

        try
        {
            Window main = app.GetMainWindow(
                automation,
                TimeSpan.FromSeconds(10)
            );

            Assert.IsNotNull(main, "Главная форма не открылась.");

            // Проверяем исходные данные.
            CheckFirms(main, AllFirms);

            main.Focus();

            Button filterButton = FindElement(
                main,
                "filterButton"
            ).AsButton();

            Assert.IsTrue(
                filterButton.IsEnabled,
                "Кнопка фильтрации недоступна."
            );

            filterButton.Click();

            AutomationElement filter = FindFilterWindow(
                app,
                automation
            );

            if (townOperation != null)
            {
                FindElement(filter, "disabledCheck5")
                    .AsCheckBox()
                    .IsChecked = false;

                FindElement(filter, "valueInput5")
                    .AsTextBox()
                    .Text = town!;

                FindElement(filter, townOperation)
                    .AsRadioButton()
                    .Click();
            }

            if (dateOperation != null)
            {
                FindElement(filter, "disabledCheck8")
                    .AsCheckBox()
                    .IsChecked = false;

                FindElement(filter, "valueInput8")
                    .AsTextBox()
                    .Text = date!;

                FindElement(filter, dateOperation)
                    .AsRadioButton()
                    .Click();
            }

            FindElement(filter, "applyButton")
                .AsButton()
                .Click();

            WaitFilterClosed(app, automation);

            CheckFirms(main, expected);
        }
        finally
        {
            // Следующий тест запускает приложение заново.
            if (!app.HasExited)
            {
                app.Kill();
            }
        }
    }

    private AutomationElement FindElement(
        AutomationElement parent,
        string id)
    {
        Stopwatch timer = Stopwatch.StartNew();

        while (timer.ElapsedMilliseconds < 5000)
        {
            AutomationElement element = parent.FindFirstDescendant(
                condition => condition.ByAutomationId(id)
            );

            if (element != null)
            {
                return element;
            }

            Thread.Sleep(1);
        }

        throw new AssertFailedException(
            "Не найден элемент: " + id
        );
    }

    private AutomationElement? GetFilterWindow(
        Application app,
        UIA2Automation automation)
    {
        foreach (Window window in app.GetAllTopLevelWindows(automation))
        {
            if (window.AutomationId == "FilterForm")
            {
                return window;
            }

            // Проверяем также вложенные окна.
            AutomationElement filter = window.FindFirstDescendant(
                condition => condition.ByAutomationId("FilterForm")
            );

            if (filter != null)
            {
                return filter;
            }
        }

        return null;
    }

    private AutomationElement FindFilterWindow(
        Application app,
        UIA2Automation automation)
    {
        Stopwatch timer = Stopwatch.StartNew();

        while (timer.ElapsedMilliseconds < 5000)
        {
            AutomationElement? filter = GetFilterWindow(
                app,
                automation
            );

            if (filter != null)
            {
                return filter;
            }

            Thread.Sleep(1);
        }

        throw new AssertFailedException(
            "Окно FilterForm не найдено в дереве автоматизации."
        );
    }

    private void WaitFilterClosed(
        Application app,
        UIA2Automation automation)
    {
        Stopwatch timer = Stopwatch.StartNew();

        while (timer.ElapsedMilliseconds < 5000)
        {
            if (GetFilterWindow(app, automation) == null)
            {
                return;
            }

            Thread.Sleep(1);
        }

        throw new AssertFailedException(
            "После применения фильтра окно не закрылось."
        );
    }

    private void CheckFirms(
        Window main,
        string expectedText)
    {
        string[] expected = expectedText.Split(
            '|',
            StringSplitOptions.RemoveEmptyEntries
        );

        Array.Sort(expected, StringComparer.Ordinal);

        AutomationElement list = FindElement(main, "firmsList");

        string[] actual = Array.Empty<string>();
        Stopwatch timer = Stopwatch.StartNew();

        while (timer.ElapsedMilliseconds < 5000)
        {
            AutomationElement[] rows = list.FindAllDescendants(
                condition => condition.ByControlType(ControlType.ListItem)
            );

            actual = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                actual[i] = rows[i].Name;
            }

            Array.Sort(actual, StringComparer.Ordinal);

            if (actual.SequenceEqual(expected))
            {
                break;
            }

            Thread.Sleep(1);
        }

        CollectionAssert.AreEqual(
            expected,
            actual,
            "Неверный состав фирм." +
            "\nОжидалось: " + string.Join(", ", expected) +
            "\nПолучено: " + string.Join(", ", actual)
        );
    }
}