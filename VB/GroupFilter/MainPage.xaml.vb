Imports Microsoft.VisualBasic
Imports System.Windows.Controls
Imports System.IO
Imports System.Xml.Serialization
Imports System.Reflection
Imports DevExpress.Xpf.PivotGrid

Namespace GroupFilter
    Partial Public Class MainPage
        Inherits UserControl
        Private dataFileName As String = "nwind.xml"
        Public Sub New()
            InitializeComponent()

            ' Parses an XML file and creates a collection of data items.
            Dim stream As Stream = System.Reflection.Assembly. _
                GetExecutingAssembly().GetManifestResourceStream(dataFileName)
            Dim s As New XmlSerializer(GetType(OrderData))

            ' Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = s.Deserialize(stream)

            ' Creates a group and adds two fields to it.
            Dim ShippedDateGroup As PivotGridGroup = pivotGridControl1.Groups.Add( _
                pivotGridControl1.Fields(1), pivotGridControl1.Fields(2))

            ' Locks the PivotGroupFilterValues object by disabling visual updates.
            ShippedDateGroup.FilterValues.BeginUpdate()

            ' Sets a filter type. 
            ' It specifies that the PivotGridControl should display only filter values.
            ShippedDateGroup.FilterValues.FilterType = FieldFilterType.Included

            ' Creates a filter value and adds it to the PivotGroupFilterValues.Values collection.
            ShippedDateGroup.FilterValues.Values.Add(1)

            ' Creates a filter value and adds it to the PivotGroupFilterValues.Values collection.
            ' Then creates a child value of the filter value and adds it to the parent value collection.
            ShippedDateGroup.FilterValues.Values.Add(2).ChildValues.Add(4)

            ' Unlocks the PivotGroupFilterValues object.
            ShippedDateGroup.FilterValues.EndUpdate()
        End Sub
    End Class
End Namespace