Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.XtraReports.UI
Imports ShowReportPreview_MVVM.Data
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.IO
Imports System.Linq

Namespace ShowReportPreview_MVVM.Models
	<POCOViewModel>
	Public Class ReportCatalogViewModel
		Inherits ViewModelBase

		Private dbContext As New ReportCatalogDbContext()

		Private privateAvailableReports As IEnumerable(Of ReportCatalogItem)
		Public Overridable Property AvailableReports() As IEnumerable(Of ReportCatalogItem)
			Get
				Return privateAvailableReports
			End Get
			Protected Set(ByVal value As IEnumerable(Of ReportCatalogItem))
				privateAvailableReports = value
			End Set
		End Property

		Public Overridable Property Report() As XtraReport

		Protected Overrides Sub OnInitializeInRuntime()
			MyBase.OnInitializeInRuntime()
			dbContext = New ReportCatalogDbContext()
			dbContext.ReportItems.Load()
			AvailableReports = dbContext.ReportItems.Local
		End Sub

		Public Sub ShowPreview(ByVal reportId As String)
			Report = LoadReport(reportId)
		End Sub
		Protected Function CanShowPreview(ByVal reportId As String) As Boolean
			Return AvailableReports.Any(Function(x) x.ID = reportId)
		End Function

		Public Sub ShowPreviewInNewWindow(ByVal reportId As String)
			Dim report_Renamed As XtraReport = LoadReport(reportId)
			Dim dialogModel As New DocumentPreviewDialogViewModel(report_Renamed)
			Dim previewDialogService As IDialogService = GetService(Of IDialogService)("previewDialogService")
			previewDialogService.ShowDialog(New MessageButton(), "Document Preview", dialogModel)
		End Sub
		Protected Function CanShowPreviewInNewWindow(ByVal reportId As String) As Boolean
			Return CanShowPreview(reportId)
		End Function

		Private Function LoadReport(ByVal reportId As String) As XtraReport
			Dim reportItem As ReportCatalogItem = AvailableReports.Single(Function(x) x.ID = reportId)
			Using stream = New MemoryStream(reportItem.Layout)
				Return XtraReport.FromStream(stream)
			End Using
		End Function
	End Class
End Namespace
