Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace CandleStickChart
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			WindowsFormsSettings.SetDPIAware()
			WindowsFormsSettings.AllowDpiScale = True
			WindowsFormsSettings.AllowAutoScale = DevExpress.Utils.DefaultBoolean.True
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace
