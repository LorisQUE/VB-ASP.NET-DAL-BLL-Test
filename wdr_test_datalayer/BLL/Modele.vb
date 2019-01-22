Public Class Modele
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
    Public Sub New(pDataContext As DataClasses1DataContext)
        _DataContext = pDataContext
    End Sub
    '
    Public Sub New(pModele As Modeles, pMarquesProvider As MarquesProvider, pDataContext As DataClasses1DataContext)
        '
        MarquesProvider = pMarquesProvider
        '
        _UniqueId = pModele.mo_id
        _libelle = pModele.mo_lib
        _cheveaux = pModele.mo_cheveaux
        _portes = pModele.mo_portes
        _IdMarque = pModele.mo_ma_id
        _DataContext = pDataContext
        '
    End Sub

#Region " Propriétés"
    Private _UniqueId As Guid

    Public Property UniqueID() As Guid
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

    Private _cheveaux As Integer
    Public Property cheveaux() As Integer
        Get
            Return _cheveaux
        End Get
        Set(ByVal value As Integer)
            _cheveaux = value
        End Set
    End Property

    Private _portes As Integer
    Public Property portes() As Integer
        Get
            Return _portes
        End Get
        Set(value As Integer)
            _portes = value
        End Set
    End Property

    Private _IdMarque As Guid
    Public Property IdMarque() As Guid
        Get
            Return _IdMarque
        End Get
        Set(ByVal value As Guid)
            _IdMarque = value
        End Set
    End Property
    '
    Private _MyMarque As Marque
    Public Property MyMarque() As Marque
        Get
            If _MyMarque Is Nothing Then
                _MyMarque = MarquesProvider.GetOneById(_IdMarque)
            End If
            Return _MyMarque
        End Get
        Set(ByVal value As Marque)
            _MyMarque = value
        End Set
    End Property




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
#Region " Méthodes Privées "
    Private Sub Insert()
        Try
            Dim MonModele As New Modeles
            _UniqueId = Guid.NewGuid
            '
            MonModele.mo_id = UniqueId
            MonModele.mo_lib = _libelle
            MonModele.mo_cheveaux = _cheveaux
            MonModele.mo_portes = _portes
            MonModele.mo_ma_id = _MyMarque.UniqueId
            '
            DataContext.Modeles.InsertOnSubmit(MonModele)
            DataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Update()
        Try
            Dim MyModeles As IEnumerable(Of Modeles)
            MyModeles = From a In DataContext.Modeles Where a.mo_id = _UniqueId
            If Not MyModeles Is Nothing AndAlso MyModeles.Count = 1 Then
                MyModeles.First.mo_lib = libelle
                MyModeles.First.mo_cheveaux = cheveaux
                MyModeles.First.mo_portes = portes
                MyModeles.First.mo_ma_id = MyMarque.UniqueId
                DataContext.SubmitChanges()
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class
