Public Class CouleursProvider
    '
    Private _DataContext As DataClasses1DataContext
    Private Property DataContext() As DataClasses1DataContext
        Get
            Return _DataContext
        End Get
        Set(ByVal value As DataClasses1DataContext)
            _DataContext = value
        End Set
    End Property
    '
    Public Sub New(pDataContext As DataClasses1DataContext)
        DataContext = pDataContext
    End Sub
    '
    Public Function GetOneById(ByVal pId As Guid) As Couleur
        '
        Dim MyObjects As IEnumerable(Of Couleurs)
        Try
            '
            MyObjects = From a In DataContext.Couleurs Where a.co_id = pId Select a
            '
            If Not MyObjects Is Nothing AndAlso MyObjects.Count = 1 Then
                Return BuildAll(MyObjects).First
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllByLibelle(pLibelle As String) As List(Of Couleur)
        Try
            '
            Dim MyObjects As IEnumerable(Of Couleurs)
            '
            MyObjects = From a In DataContext.Couleurs Where a.co_lib = pLibelle
            '
            If Not MyObjects Is Nothing AndAlso MyObjects.Count > 0 Then
                Return BuildAll(MyObjects)
            End If
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAll() As List(Of Couleur)
        Try
            Dim MyObjects As IEnumerable(Of Couleurs)
            MyObjects = From a In DataContext.Couleurs Select a
            If Not MyObjects Is Nothing Then
                Return BuildAll(MyObjects)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function CountAll() As Integer
        Try
            Return DataContext.Couleurs.Count()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function CountAllBleu() As Integer
        Try
            Return (From a In DataContext.Couleurs Where a.co_lib.Contains("Bleu")).Count
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Sub InsertNewCouleur(pLibelle As String)
        Try
            Dim MyNewCouleurs As Couleurs
            If Not String.IsNullOrEmpty(pLibelle) Then
                MyNewCouleurs = New Couleurs
                MyNewCouleurs.co_id = Guid.NewGuid
                MyNewCouleurs.co_lib = pLibelle
                '
                DataContext.Couleurs.InsertOnSubmit(MyNewCouleurs)
                DataContext.SubmitChanges()
                '
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteOneCouleurParId(pUnique As Guid)
        Try
            '
            DataContext.Couleurs.DeleteOnSubmit((From a In DataContext.Couleurs Where a.co_id = pUnique).First)
            DataContext.SubmitChanges()
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteOneCouleurParNom(pNom As String)
        Try
            '
            DataContext.Couleurs.DeleteOnSubmit((From a In DataContext.Couleurs Where a.co_lib = pNom).First)
            DataContext.SubmitChanges()
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Public Function deleteallcouleurs() As Integer
    '    Try
    '        Return deletecouleursparnom()
    '    Catch ex As exception
    '        Throw ex
    '    End Try
    'End Function
    Public Function DeleteAllCouleursContains(pCouleur As String) As Integer
        Try

            If Not String.IsNullOrEmpty(pCouleur) Then
                Return DeleteCouleursParNom(pCouleur)
            Else
                Throw New Exception("Le Champ couleur est vide !")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Function DeleteCouleursParNom(pNom As String) As Integer
        Try
            '
            Dim MyObjects As IEnumerable(Of Couleurs) = From a In DataContext.Couleurs Where a.co_lib.Contains(pNom) Select a
            '
            Dim iCpt As Integer = MyObjects.Count
            DataContext.Couleurs.DeleteAllOnSubmit(MyObjects)
            DataContext.SubmitChanges()
            '
            Return iCpt

            '
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteAllCouleurs()
        Try
            DataContext.Couleurs.DeleteAllOnSubmit(From a In DataContext.Couleurs Select a)
            DataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Fonctions privées"
    Private Function BuildAll(pCouleurs As IEnumerable(Of Couleurs)) As List(Of Couleur)
        Try
            Dim MyReturn As New List(Of Couleur)
            For Each MyCouleur As Couleurs In pCouleurs
                MyReturn.Add(BuildOne(MyCouleur))
            Next
            '
            Return MyReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function BuildOne(pCouleur As Couleurs) As Couleur
        Try
            Return New Couleur(pCouleur, DataContext)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
