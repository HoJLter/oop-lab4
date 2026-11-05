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

            for (int row = 0; row < )
        }

        public FiltersForm()
        {
            InitializeComponent();
        }
    }
}
