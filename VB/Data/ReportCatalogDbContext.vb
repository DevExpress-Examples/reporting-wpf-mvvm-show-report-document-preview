Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity

Namespace ShowReportPreview_MVVM.Data
	Public Class ReportCatalogItem
		<Key>
		Public Property ID() As String
		Public Property ReportName() As String
		Public Property Layout() As Byte()
	End Class

	Public Class ReportCatalogDbContext
		Inherits DbContext

		Shared Sub New()
			Database.SetInitializer(New NullDatabaseInitializer(Of ReportCatalogDbContext)())
		End Sub

		Public Sub New()
			MyBase.New("name=ReportCatalogDbContext")
		End Sub

		Public Property ReportItems() As DbSet(Of ReportCatalogItem)
	End Class
End Namespace
