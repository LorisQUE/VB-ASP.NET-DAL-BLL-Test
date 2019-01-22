Public Class ModelesProvider
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
    Private _MarquesProvider As MarquesProvider
    Public Property MarquesProvider() As MarquesProvider
        Get
            Return _MarquesProvider
        End Get
        Set(ByVal value As MarquesProvider)
            _MarquesProvider = value
        End Set
    End Property
    '
    Public Sub New(pDataContext As DataClasses1DataContext, pMarquesProvider As MarquesProvider)
        DataContext = pDataContext
        _MarquesProvider = pMarquesProvider
    End Sub
    '
    Public Function GetOneById(ByVal pId As Guid) As Modele
        '
        Dim MyObjects As IEnumerable(Of Modeles)
        Try
            MyObjects = From a In DataContext.Modeles Where a.mo_id = pId Select a
            '
            If Not MyObjects Is Nothing AndAlso MyObjects.Count = 1 Then
                Return BuildAll(MyObjects).First
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllModeles() As List(Of Modele)
        Try
            Dim MyObjects As IEnumerable(Of Modeles)
            MyObjects = From a In DataContext.Modeles Select a
            If Not MyObjects Is Nothing AndAlso MyObjects.Count() > 1 Then
                Return BuildAll(MyObjects)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllByLibelle(pLibelle As String) As List(Of Modele)
        Try
            Dim MyObjects As IEnumerable(Of Modeles)
                MyObjects = From a In DataContext.Modeles Where a.mo_lib.Contains(pLibelle)
                If Not MyObjects Is Nothing AndAlso MyObjects.Count > 0 Then
                    Return BuildAll(MyObjects)
                End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllByCheveaux(pCheveaux As Integer) As List(Of Modele)
        Try
            Dim MyObjects As IEnumerable(Of Modeles)
                MyObjects = From a In DataContext.Modeles Where a.mo_cheveaux.Equals(pCheveaux)
                If Not MyObjects Is Nothing AndAlso MyObjects.Count > 0 Then
                    Return BuildAll(MyObjects)
                End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllByPortes(pPortes As Byte) As List(Of Modele)
        Try
            Dim MyObjects As IEnumerable(Of Modeles)
                MyObjects = From a In DataContext.Modeles Where a.mo_portes.Equals(pPortes)
                If Not MyObjects Is Nothing AndAlso MyObjects.Count > 0 Then
                    Return BuildAll(MyObjects)
                End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Sub InsertNewModele(pLibelle As String, pCheveaux As Integer, pPortes As Byte)
        Try
            Dim MyNewModele As Modeles
            If Not String.IsNullOrEmpty(pLibelle) And (pPortes = 3) Or (pPortes = 5) Then
                MyNewModele = New Modeles
                MyNewModele.mo_id = Guid.NewGuid
                MyNewModele.mo_lib = pLibelle
                MyNewModele.mo_cheveaux = pCheveaux
                MyNewModele.mo_portes = pPortes
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
    Public Sub DeleteOneModele(pUnique As Guid)
        Try
            DataContext.Modeles.DeleteOnSubmit((From a In DataContext.Modeles Where a.mo_id = pUnique).First)
            DataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
#Region "Fonctions Privée"
    '
    Private Function BuildAll(pModeles As IEnumerable(Of Modeles)) As List(Of Modele)
        Try
            Dim MyReturn As New List(Of Modele)
            For Each MyModele As Modeles In pModeles
                MyReturn.Add(BuildOne(MyModele))
            Next
            '
            Return MyReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Private Function BuildOne(pModele As Modeles) As Modele
        Try
            Return New Modele(pModele, MarquesProvider, DataContext)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
