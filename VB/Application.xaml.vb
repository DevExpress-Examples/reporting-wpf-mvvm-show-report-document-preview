Imports DevExpress.Xpf.Core
Imports System.Windows

Namespace ShowReportPreview_MVVM
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			ApplicationThemeHelper.ApplicationThemeName = Theme.Office2019ColorfulName
			MyBase.OnStartup(e)
		End Sub
	End Class
End Namespace
