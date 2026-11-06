using System;
using System.Windows.Forms;
using oop_lab4.Controllers;
using oop_lab4.Models.ControlData;
using oop_lab4.Models.Data;

namespace oop_lab4.Forms;

public partial class MainForm : Form
{
    private MainController _controller;

    public MainForm(FirmManager manager)
    {
        InitializeComponent();

        _controller = new MainController(manager);

        firmsList.View = View.Details;
        firmsList.FullRowSelect = true;
        firmsList.GridLines = true;

        filterButton.Click += FilterButton_Click;

        ShowFirms();
    }

    private void ShowFirms()
    {
        firmsList.Items.Clear();
        firmsList.Columns.Clear();

        FirmManager manager = _controller.Manager;

        foreach (Field field in manager.View.Fields)
        {
            firmsList.Columns.Add(field.GetType().Name, 150);
        }

        if (manager.View.Fields.Count == 0)
        {
            return;
        }

        foreach (Firm firm in manager.Firms)
        {
            string firstValue = manager.View.Fields[0].GetValue(firm);
            ListViewItem row = new ListViewItem(firstValue);

            for (int i = 1; i < manager.View.Fields.Count; i++)
            {
                string value = manager.View.Fields[i].GetValue(firm);
                row.SubItems.Add(value);
            }

            firmsList.Items.Add(row);
        }
    }

    private void FilterButton_Click(object sender, EventArgs e)
    {
        FilterController controller =
            _controller.CreateFilterController();

        FilterForm form = new FilterForm(controller);

        if (form.ShowDialog() == DialogResult.OK)
        {
            _controller.ApplyFilter(controller);
            ShowFirms();
        }

        form.Dispose();
    }
}