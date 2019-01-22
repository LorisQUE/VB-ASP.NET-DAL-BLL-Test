Public Class VoituresProvider
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
    Private _ModelesProvider As ModelesProvider
    Public Property ModelesProvider() As ModelesProvider
        Get
            Return _ModelesProvider
        End Get
        Set(ByVal value As ModelesProvider)
            _ModelesProvider = value
        End Set
    End Property
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
    Public Sub New(pModelesProvider As ModelesProvider, pCouleursProvider As CouleursProvider)
        DataContext = New DataClasses1DataContext
        _ModelesProvider = pModelesProvider
        _CouleursProvider = pCouleursProvider
    End Sub
    '
    Public Function GetOneById(ByVal pId As Guid) As Voiture
        Dim MyObjects As IEnumerable(Of Voitures)
        Try
            MyObjects = From a In DataContext.Voitures Where a.vo_id = pId Select a
            If Not MyObjects Is Nothing AndAlso MyObjects.Count = 1 Then
                Return BuildAll(MyObjects).First
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetOneByImmat(ByVal pImmat As String) As Voiture
        Dim MyObjects As IEnumerable(Of Voitures)
        Try
            MyObjects = From a In DataContext.Voitures Where a.vo_immat = pImmat Select a
            If Not MyObjects Is Nothing AndAlso MyObjects.Count = 1 Then
                Return BuildAll(MyObjects).First
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllByimmat(pImmat As String) As List(Of Voiture)
        Try
            Dim Myobjects As IEnumerable(Of Voitures)
            Try
                Myobjects = From a In DataContext.Voitures Where a.vo_immat.Contains(pImmat)
                If Not Myobjects Is Nothing AndAlso Myobjects.Count > 0 Then
                    Return BuildAll(Myobjects)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllSuperieurKm(pKm As Integer) As List(Of Voiture)
        Try
            Dim MyObjects As IEnumerable(Of Voitures)
            Try
                MyObjects = From a In DataContext.Voitures Where a.vo_km >= pKm
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllInferieurKm(pKm As Integer) As List(Of Voiture)
        Try
            Dim MyObjects As IEnumerable(Of Voitures)
            Try
                MyObjects = From a In DataContext.Voitures Where a.vo_km <= pKm
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Sub InsertNewVoitures(pKm As Integer, pImmat As String)
        Try
            Dim MyNewVoiture As Voitures
            MyNewVoiture = New Voitures
            MyNewVoiture.vo_id = Guid.NewGuid
            MyNewVoiture.vo_km = pKm
            MyNewVoiture.vo_immat = pImmat
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
    Public Sub DeleteOneVoiture(pUnique As Guid)
        Try
            DataContext.Voitures.DeleteOnSubmit((From a In DataContext.Voitures Where a.vo_id = pUnique).First)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
#Region "Fonctions Privées"
    Private Function BuildAll(pVoitures As IEnumerable(Of Voitures)) As List(Of Voiture)
        Try
            Dim MyReturn As New List(Of Voiture)
            For Each MyVoiture As Voitures In pVoitures
                MyReturn.Add(BuildOne(MyVoiture))
            Next
            Return MyReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Private Function BuildOne(pVoiture As Voitures) As Voiture
        Try
            Return New Voiture(pVoiture, ModelesProvider, CouleursProvider)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
