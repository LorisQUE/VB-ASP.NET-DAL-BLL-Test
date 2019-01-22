Imports wdr_test_datalayer
Public Class frmTest
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
            Dim MyCouleurs As List(Of Couleur) = MyGlobalProvider.CouleursPro.GetAll()
            '
            If Not MyCouleurs Is Nothing AndAlso MyCouleurs.Count > 0 Then
                For Each MyCouleur As Couleur In MyCouleurs
                    Dim toto As New TableRow

                    Dim MyCell As New TableCell()
                    MyCell.Text = MyCouleur.UniqueId.ToString

                    Dim MyCell2 As New TableCell()
                    MyCell2.Text = MyCouleur.libelle

                    toto.Cells.Add(MyCell)
                    toto.Cells.Add(MyCell2)

                    Me.table.Rows.Add(toto)
                Next
            End If
            
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub btnCouleur_Click(sender As Object, e As EventArgs) Handles btnCouleur.Click
    '    Try
    '        If Not String.IsNullOrEmpty(Me.lblCouleur.Text) Then
    '            MyGlobalProvider.CouleursPro.InsertNewCouleur(txtCouleur.Text)
    '            lblNbCoul.Text = String.Format("La table couleur contient {0} couleurs", MyGlobalProvider.CouleursPro.CountAll())
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class