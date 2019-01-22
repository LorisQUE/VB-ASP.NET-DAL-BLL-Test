Public Class Marque
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
        _DataContext = pDataContext
    End Sub
    '
    Public Sub New(pMarque As Marques, pDataContext As DataClasses1DataContext)
        _UniqueId = pMarque.ma_id
        _libelle = pMarque.ma_lib
        _DataContext = pDataContext
    End Sub

#Region " propriété "
    Private _UniqueId As Guid
    Public Property UniqueId() As Guid
        Get
            Return _UniqueId
        End Get
        Set(ByVal value As Guid)
            _UniqueId = value
        End Set
    End Property
    Private _libelle
    Public Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property
#End Region

#Region " Méthodes publiques"
    Public Sub Save()
        If _UniqueId = Guid.Empty Then
            Insert()
        Else
            Update()
        End If
    End Sub
#End Region
#Region " Méthodes privées "
    Private Sub Insert()
        Dim MaMarque As New Marques
        _UniqueId = Guid.NewGuid
        MaMarque.ma_id = _UniqueId
        MaMarque.ma_lib = _libelle
        '
        DataContext.Marques.InsertOnSubmit(MaMarque)
        DataContext.SubmitChanges()
    End Sub
    Private Sub Update()
        Dim MyMarques As IEnumerable(Of Marques)
        '
        MyMarques = From a In DataContext.Marques Where a.ma_id = _UniqueId
        If Not MyMarques Is Nothing AndAlso MyMarques.Count = 1 Then
            MyMarques.First.ma_id = _libelle
            DataContext.SubmitChanges()
        End If
    End Sub
#End Region

End Class
