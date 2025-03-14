Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

Namespace CandleStickChart

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a new chart.
            Dim candlestickChart As ChartControl = New ChartControl()
            ' Create a candlestick series.
            Dim series1 As Series = New Series("Series 1", ViewType.CandleStick)
            ' Bind the series to data.
            series1.DataSource = GetDataPoints()
            series1.SetFinancialDataMembers("Argument", "Low", "High", "Open", "Close")
            ' Specify that date-time arguments are expected.
            series1.ArgumentScaleType = ScaleType.DateTime
            ' Add the series to the chart.
            candlestickChart.Series.Add(series1)
            ' Customize the series view settings.
            Dim view As CandleStickSeriesView = CType(series1.View, CandleStickSeriesView)
            view.LineThickness = 2
            view.LevelLineLength = 0.25
            ' Specify the series reduction options.
            view.ReductionOptions.ColorMode = ReductionColorMode.OpenToCloseValue
            view.ReductionOptions.FillMode = CandleStickFillMode.AlwaysEmpty
            view.ReductionOptions.Level = StockLevel.Close
            view.ReductionOptions.Visible = True
            ' Set point colors.
            view.Color = Color.Green
            view.ReductionOptions.Color = Color.Red
            ' Access the chart's diagram.
            Dim diagram As XYDiagram = CType(candlestickChart.Diagram, XYDiagram)
            ' Exclude empty ranges from the X-axis range
            ' to avoid gaps in the chart's data.
            diagram.AxisX.DateTimeScaleOptions.SkipRangesWithoutPoints = True
            ' Hide the range without points at the beginning of the y-axis.
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
            ' Hide the legend.
            candlestickChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
            ' Add a title to the chart.
            candlestickChart.Titles.Add(New ChartTitle())
            candlestickChart.Titles(0).Text = "Candlestick Chart"
            ' Add the chart to the form.
            candlestickChart.Dock = DockStyle.Fill
            Me.Controls.Add(candlestickChart)
        End Sub

        Private Function GetDataPoints() As List(Of DataPoint)
            Dim dataPoints As List(Of DataPoint) = New List(Of DataPoint) From {New DataPoint(Date.Now.AddDays(-9), 24.00, 25.00, 25.00, 24.875), New DataPoint(Date.Now.AddDays(-8), 23.625, 25.125, 24.00, 24.875), New DataPoint(Date.Now.AddDays(-7), 26.25, 28.25, 26.75, 27.00), New DataPoint(Date.Now.AddDays(-6), 26.50, 27.875, 26.875, 27.25), New DataPoint(Date.Now.AddDays(-4), 25.75, 26.875, 26.75, 26.00), New DataPoint(Date.Now.AddDays(-3), 25.75, 26.75, 26.125, 26.25), New DataPoint(Date.Now.AddDays(-2), 25.75, 26.375, 26.375, 25.875), New DataPoint(Date.Now.AddDays(-1), 24.875, 26.125, 26.00, 25.375), New DataPoint(Date.Now.AddDays(0), 25.125, 26.00, 25.625, 25.75)}
            Return dataPoints
        End Function
    End Class

    Public Class DataPoint

        Public Property Argument As Date

        Public Property Low As Double

        Public Property High As Double

        Public Property Open As Double

        Public Property Close As Double

        Public Sub New(ByVal argument As Date, ByVal low As Double, ByVal high As Double, ByVal open As Double, ByVal close As Double)
            Me.Argument = argument
            Me.Low = low
            Me.High = high
            Me.Open = open
            Me.Close = close
        End Sub
    End Class
End Namespace
