Imports DevExpress.Mvvm
Imports DevExpress.Utils
Imports DevExpress.XtraReports.UI

Namespace ShowReportPreview_MVVM.Models
	Public Class DocumentPreviewDialogViewModel
		Inherits ViewModelBase

		Public ReadOnly Property Report() As XtraReport
		Public Sub New(ByVal report As XtraReport)
			Me.Report = report
		End Sub
	End Class
End Namespace
