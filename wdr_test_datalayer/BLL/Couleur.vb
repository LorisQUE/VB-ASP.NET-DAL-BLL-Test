Public Class Couleur
    '
    Private _DataContext As DataClasses1DataContext
    Public Property DataContext() As DataClasses1DataContext
        Get
            Return _DataContext
        End Get
        Set(ByVal value As DataClasses1DataContext)
            _DataContext = value
        End Set
    End Property

    '
    Public Sub New(pDataContext As DataClasses1DataContext)
        '
        _DataContext = pDataContext
        '
    End Sub
    '
    Public Sub New(pCouleur As Couleurs, pDataContext As DataClasses1DataContext)
        _UniqueId = pCouleur.co_id
        _libelle = pCouleur.co_lib
        '
        _DataContext = pDataContext
    End Sub
    '
#Region " Propriétés "
    '
    Private _UniqueId As Guid
    Public Property UniqueId() As Guid
        Get
            Return _UniqueId
        End Get
        Set(ByVal value As Guid)
            _UniqueId = value
        End Set
    End Property
    '
    Private _libelle As String
    Public Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property
    '
#End Region
#Region " Méthodes publiques "
    Public Sub Save()
        If _UniqueId = Guid.Empty Then
            Insert()
        Else
            Update()
        End If
    End Sub
#End Region
#Region " Méthodes Privées  "
    Private Sub Insert()
        Try
            '
            Dim MaCouleur As New Couleurs
            '
            _UniqueId = Guid.NewGuid
            '
            MaCouleur.co_id = _UniqueId
            MaCouleur.co_lib = _libelle
            '
            DataContext.Couleurs.InsertOnSubmit(MaCouleur)
            DataContext.SubmitChanges()
            '
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Update()
        Try
            Dim MyCouleurs As IEnumerable(Of Couleurs)
            '
            MyCouleurs = From a In DataContext.Couleurs Where a.co_id = _UniqueId
            If Not MyCouleurs Is Nothing AndAlso MyCouleurs.Count = 1 Then
                MyCouleurs.First.co_lib = libelle
                DataContext.SubmitChanges()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
