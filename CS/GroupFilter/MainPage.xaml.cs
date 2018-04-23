using System.Windows.Controls;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using DevExpress.Xpf.PivotGrid;

namespace GroupFilter {
    public partial class MainPage : UserControl {
        string dataFileName = "GroupFilter.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = s.Deserialize(stream);

            // Creates a group and adds two fields to it.
            PivotGridGroup ShippedDateGroup = pivotGridControl1.Groups.Add(pivotGridControl1.Fields[1], 
                pivotGridControl1.Fields[2]);

            // Locks the PivotGroupFilterValues object by disabling visual updates.
            ShippedDateGroup.FilterValues.BeginUpdate();

            // Sets a filter type. 
            // It specifies that the PivotGridControl should display only filter values.
            ShippedDateGroup.FilterValues.FilterType = FieldFilterType.Included;

            // Creates a filter value and adds it to the PivotGroupFilterValues.Values collection.
            ShippedDateGroup.FilterValues.Values.Add(1);

            // Creates a filter value and adds it to the PivotGroupFilterValues.Values collection.
            // Then creates a child value of the filter value and adds it to the parent value collection.
            ShippedDateGroup.FilterValues.Values.Add(2).ChildValues.Add(4);

            // Unlocks the PivotGroupFilterValues object.
            ShippedDateGroup.FilterValues.EndUpdate();
        }
    }
}
