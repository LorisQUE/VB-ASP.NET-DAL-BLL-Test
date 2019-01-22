Public Class GlobalProvider
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
    Public Sub New()
        '
        DataContext = New DataClasses1DataContext
        '
        _CouleursPro = New CouleursProvider(DataContext)
        _MarquesPro = New MarquesProvider(DataContext)
        _ModelesProv = New ModelesProvider(DataContext, MarquesPro)
        _VoituresPro = New VoituresProvider(ModelesProv, CouleursPro)
    End Sub

    '
    Private _CouleursPro As CouleursProvider
    Public Property CouleursPro() As CouleursProvider
        Get
            Return _CouleursPro
        End Get
        Set(ByVal value As CouleursProvider)
            _CouleursPro = value
        End Set
    End Property
    '
    Private _MarquesPro As MarquesProvider
    Public Property MarquesPro() As MarquesProvider
        Get
            Return _MarquesPro
        End Get
        Set(ByVal value As MarquesProvider)
            _MarquesPro = value
        End Set
    End Property

    Private _ModelesProv As ModelesProvider
    Public Property ModelesProv() As ModelesProvider
        Get
            Return _ModelesProv
        End Get
        Set(ByVal value As ModelesProvider)
            _ModelesProv = value
        End Set
    End Property

    '
    Private _VoituresPro As VoituresProvider
    Public Property VoiturePro() As VoituresProvider
        Get
            Return _VoituresPro
        End Get
        Set(ByVal value As VoituresProvider)
            _VoituresPro = value
        End Set
    End Property

End Class
