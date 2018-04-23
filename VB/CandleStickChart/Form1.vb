#Region "#usings"
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...
#End Region ' #usings

Namespace CandleStickChart
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

#Region "#code"
        Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As EventArgs) Handles MyBase.Load
            ' Create a new chart.
            Dim candlestickChart As New ChartControl()

            ' Create a candlestick series.
            Dim series1 As New Series("Stock Prices", ViewType.CandleStick)

            ' Specify the date-time argument scale type for the series,
            ' as it is qualitative, by default.
            series1.ArgumentScaleType = ScaleType.DateTime

            ' Add points to it.
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 1), _
                New Object() {24.0, 25.0, 25.0, 24.875}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 2), _
                New Object() {23.625, 25.125, 24.0, 24.875}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 3), _
                New Object() {26.25, 28.25, 26.75, 27.0}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 4), _
                New Object() {26.5, 27.875, 26.875, 27.25}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 7), _
                New Object() {26.375, 27.5, 27.375, 26.75}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 8), _
                New Object() {25.75, 26.875, 26.75, 26.0}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 9), _
                New Object() {25.75, 26.75, 26.125, 26.25}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 10), _
                New Object() {25.75, 26.375, 26.375, 25.875}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 11), _
                New Object() {24.875, 26.125, 26.0, 25.375}))
            series1.Points.Add(New SeriesPoint(New DateTime(1994, 3, 14), _
                New Object() {25.125, 26.0, 25.625, 25.75}))

            ' Add the series to the chart.
            candlestickChart.Series.Add(series1)

            ' Access the view-type-specific options of the series.
            Dim myView As CandleStickSeriesView = CType(series1.View, CandleStickSeriesView)

            myView.LineThickness = 2
            myView.LevelLineLength = 0.25

            ' Specify the series reduction options.
            myView.ReductionOptions.Level = StockLevel.Open
            myView.ReductionOptions.Visible = True

            ' Access the chart's diagram.
            Dim diagram As XYDiagram = (CType(candlestickChart.Diagram, XYDiagram))

            ' Access the type-specific options of the diagram.
            diagram.AxisY.Range.MinValue = 22

            ' Exclude weekends from the X-axis range,
            ' to avoid gaps in the chart's data.
            diagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = True
            ' Hide the legend (if necessary).
            candlestickChart.Legend.Visible = False

            ' Add a title to the chart (if necessary).
            candlestickChart.Titles.Add(New ChartTitle())
            candlestickChart.Titles(0).Text = "Candlestick Chart"

            ' Add the chart to the form.
            candlestickChart.Dock = DockStyle.Fill
            Me.Controls.Add(candlestickChart)
        End Sub
#End Region ' #code

    End Class
End Namespace
