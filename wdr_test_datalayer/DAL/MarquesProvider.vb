Public Class MarquesProvider
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
    Public Function GetOneById(ByVal pId As Guid) As Marque
        '
        Dim MyObjects As IEnumerable(Of Marques)
        Try
            MyObjects = From a In DataContext.Marques Where a.ma_id = pId Select a
            '
            If Not MyObjects Is Nothing AndAlso MyObjects.Count = 1 Then
                Return BuildAll(MyObjects).First
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Function GetAllByLibelle(pLibelle As String) As List(Of Marque)
        Try
            Dim MyObjects As IEnumerable(Of Marques)
                MyObjects = From a In DataContext.Marques Where a.ma_lib.Contains(pLibelle)
                If Not MyObjects Is Nothing AndAlso MyObjects.Count > 0 Then
                    Return BuildAll(MyObjects)
                End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '
    Public Sub InsertNewMarque(pLibelle As String)
        Try
            Dim MyNewMarque As Marques
            If Not String.IsNullOrEmpty(pLibelle) Then
                MyNewMarque = New Marques
                MyNewMarque.ma_id = Guid.NewGuid
                MyNewMarque.ma_lib = pLibelle
                DataContext.Marques.InsertOnSubmit(MyNewMarque)
                DataContext.SubmitChanges()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '
    Public Sub DeleteOneMarque(pUnique As Guid)
        Try
            DataContext.Marques.DeleteOnSubmit((From a In DataContext.Marques Where a.ma_id = pUnique).First)
            DataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " Fonctions privées "
    Private Function BuildAll(pMarques As IEnumerable(Of Marques)) As List(Of Marque)
        Try
            Dim MyReturn As New List(Of Marque)
            For Each MyMarque As Marques In pMarques
                MyReturn.Add(BuildOne(MyMarque))
            Next
            '
            Return MyReturn
        Catch ex As Exception
        End Try
    End Function
    Private Function BuildOne(pMarque As Marques) As Marque
        Try
            Return New Marque(pMarque, DataContext)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
