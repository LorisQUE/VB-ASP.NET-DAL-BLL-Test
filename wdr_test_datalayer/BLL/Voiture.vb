Public Class Voiture
    Private _ModelesProvider As ModelesProvider
    Public Property ModelesProvider() As ModelesProvider
        Get
            Return _ModelesProvider
        End Get
        Set(ByVal value As ModelesProvider)
            _ModelesProvider = value
        End Set
    End Property
    Public Sub New()

    End Sub
    '
    Private _CouleursProvider As CouleursProvider
    Public Property CouleursProvider() As CouleursProvider
        Get
            Return _CouleursProvider
        End Get
        Set(ByVal value As CouleursProvider)
            _CouleursProvider = value
        End Set
    End Property
    '
    Public Sub New(pVoiture As Voitures, pModelesProvider As ModelesProvider, pCouleursProvider As CouleursProvider)
        ModelesProvider = pModelesProvider
        CouleursProvider = pCouleursProvider

    End Sub
    '
#Region " Propriétés "

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
    Private _km As Integer
    Public Property km() As Integer
        Get
            Return _km
        End Get
        Set(ByVal value As Integer)
            _km = value
        End Set
    End Property
    '
    Private _immat As String
    Public Property immat As String
        Get
            Return _immat
        End Get
        Set(value As String)
            _immat = value
        End Set
    End Property

    Private _MyCouleurs As Couleur
    Public Property MyCouleurs() As Couleur
        Get
            Return _MyCouleurs
        End Get
        Set(ByVal value As Couleur)
            _MyCouleurs = value
        End Set
    End Property

    Private _MyModeles As Modele
    Public Property MyModeles() As Modele
        Get
            Return _MyModeles
        End Get
        Set(ByVal value As Modele)
            _MyModeles = value
        End Set
    End Property
#End Region

#Region " Méthodes publique "
    Public Sub Save()

    End Sub
#End Region
#Region " Méthodes privées "
    Private Sub Insert()

    End Sub
    Private Sub Update()

    End Sub
#End Region
End Class
