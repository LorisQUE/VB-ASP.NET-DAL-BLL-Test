Imports wdr_test_datalayer
Public Class frmVoiture
    Inherits System.Web.UI.Page

    Private _MyGlobalProvider As GlobalProvider
    Public Property MyGlobalProvider() As GlobalProvider
        Get
            Return _MyGlobalProvider
        End Get
        Set(ByVal value As GlobalProvider)
            _MyGlobalProvider = value
        End Set
    End Property



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            MyGlobalProvider = New GlobalProvider
            'listCoul.Items.Add(MyGlobalProvider.CouleursPro.GetAll)
        Catch ex As Exception

        End Try
    End Sub

End Class