using oop_lab4.Resources;

namespace oop_lab4
{
    public partial class FiltersForm : Form
    {
        private void InitializeTable()
        {
            string[] fields =
               {
                    FiltersResources.FieldName,
                    FiltersResources.FieldEntryDate,
                    FiltersResources.FieldCountry,
                    FiltersResources.FieldPostalCode,
                    FiltersResources.FieldRegion,
                    FiltersResources.FieldCity,
                    FiltersResources.FieldStreet,
                    FiltersResources.FieldWeb,
                    FiltersResources.FieldStartDate,
                    FiltersResources.FieldContactCount,
                    FiltersResources.CustomField1,
                    FiltersResources.CustomField2,
                    FiltersResources.CustomField3,
                    FiltersResources.CustomField4,
                    FiltersResources.CustomField5
                };

            for (int row = 0; row < filterTable.RowCount; row++)
            {

                var label = new Label
                {
                    Text = fields[row],
                    AutoSize = true,
                    Anchor = AnchorStyles.Left,
                    Enabled = false,
                };
                filterTable.Controls.Add(label, 0, row);

                var input = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Enabled = false
                };
                filterTable.Controls.Add(input, 1, row);

                var disabled = new CheckBox
                {
                    Text = FiltersResources.FilterDisabled,
                    AutoSize = true,
                    Checked = true
                };
                filterTable.Controls.Add(disabled, 2, row);

                var operations = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    WrapContents = false,
                    Margin = Padding.Empty
                };

                bool isArithmetical = row == 1 || row == 8 || row == 9;
                string[] operators =
                {
                    "=",
                    FiltersResources.OperatorNotEqual,
                    isArithmetical
                        ? "<"
                        : FiltersResources.OperatorContains,
                    isArithmetical
                        ? ">"
                        : FiltersResources.OperatorNotContains
                };

                foreach (string text in operators)
                {
                    operations.Controls.Add(new RadioButton
                    {
                        Text = text,
                        AutoSize = true,
                        Enabled = false
                    });
                }

                filterTable.Controls.Add(operations);
                disabled.CheckedChanged += (sender, e) =>
                {
                    bool enabled = !disabled.Checked;

                    label.Enabled = enabled;
                    input.Enabled = enabled;

                    foreach (Control control in operations.Controls)
                    {
                        control.Enabled = enabled;
                    }
                };
            }
        }

        public FiltersForm()
        {
            InitializeComponent();
            InitializeTable();
        }
    }
}
