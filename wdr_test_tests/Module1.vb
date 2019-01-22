Imports wdr_test_datalayer
Module Module1

    Sub Main()
        '
        Dim MyGlobalProvider As New GlobalProvider
        Dim libl As String

        '' compte nb couleur
        'Console.WriteLine("nombre de couleur:" & MyGlobalProvider.CouleursPro.CountAll())
        'Console.ReadKey()

        'ajout nouvelle couleur
        'Console.WriteLine("saisir nouvelle couleur:")
        'libl = Console.ReadLine()
        'MyGlobalProvider.CouleursPro.InsertNewCouleur(libl)
        'Console.ReadKey()
        ''
        '
        'Dim toto As Couleur = New Couleur(MyGlobalProvider.DataContext)
        'toto.libelle = "Bleu Horizon"
        'toto.Save()
        ''
        'Dim toto2 As Marque = New Marque(MyGlobalProvider.DataContext)
        'toto2.libelle = "Peugot"
        'toto2.Save()
        ''
        'Dim toto3 As Modele = New Modele(MyGlobalProvider.DataContext)
        'toto3.libelle = "S-35"
        'toto3.cheveaux = 10
        'toto3.portes = 2
        'toto3.MyMarque = MyGlobalProvider.MarquesPro.GetAllByLibelle("SOMUA").First
        'toto3.Save()
        '
        'For Each mark As Marque In MyGlobalProvider.MarquesPro.GetAllByLibelle("")
        '    Console.WriteLine(mark.libelle)
        'Next
        'Console.ReadLine()

        ''Supprimer plusieurs couleurs par nom
        'Console.WriteLine("Les couleurs a supprimer:")
        'libl = Console.ReadLine()
        'Dim iCpt As Integer = MyGlobalProvider.CouleursPro.DeleteAllCouleursContains(libl)
        'Select Case iCpt
        '    Case 0
        '        Console.WriteLine(String.Format("Aucune couleur {0} supprimé", libl))
        '    Case 1
        '        Console.WriteLine(String.Format("Une seule couleur {0} supprimé", libl))
        '    Case Else
        '        Console.WriteLine(String.Format("{0} couleurs {1} supprimés", iCpt, libl))
        'End Select

        ''Compte Nb Couleur
        'Console.WriteLine("Nombre de couleur bleu:" & MyGlobalProvider.CouleursPro.CountAllBleu())
        'Console.ReadKey()
        ''
        ' Affiche une couleur par son nom
        Console.WriteLine("Quel couleur désirez vous voir ?")
        libl = Console.ReadLine
        Dim fct As List(Of Couleur) = MyGlobalProvider.CouleursPro.GetAllByLibelle(libl)
        If Not fct Is Nothing AndAlso fct.Count > 0 Then
            For Each MyObject As Couleur In fct
                Console.WriteLine(String.Format("{0} [{1}]", MyObject.libelle, MyObject.UniqueId.ToString))
            Next
        End If
        Console.ReadKey()
        ''
        '' Ajoute nouvelle couleur
        'Console.WriteLine("Saisir nouvelle couleur:")
        'libl = Console.ReadLine()
        'MyGlobalProvider.CouleursPro.InsertNewCouleur(libl)
        'Console.ReadKey()
        ''
        '' Compte Nb Couleur
        'Console.WriteLine("Nombre de couleur:" & MyGlobalProvider.CouleursPro.CountAll())
        'Console.ReadKey()
        ''
        '' Affiche toutes les couleurs
        'fct = MyGlobalProvider.CouleursPro.GetAll()
        'If Not fct Is Nothing AndAlso fct.Count > 0 Then
        '    For Each MyObject As Couleur In fct
        '        Console.WriteLine(String.Format("{0} [{1}]", MyObject.libelle, MyObject.UniqueId.ToString))
        '    Next
        'End If
        'Console.ReadKey()
        ''
        '' supprime une couleur par son nom
        'Console.WriteLine("Supprimer une couleur:")
        'libl = Console.ReadLine()
        'MyGlobalProvider.CouleursPro.DeleteOneCouleurParNom(libl)
        ''
        '' Affiche toutes les couleurs
        fct = MyGlobalProvider.CouleursPro.GetAll()
        If Not fct Is Nothing AndAlso fct.Count() > 0 Then
            For Each MyObjects As Couleur In fct
                Console.WriteLine(String.Format("{0} [{1}]", MyObjects.libelle, MyObjects.UniqueId.ToString))
            Next
        End If
        Console.ReadKey()
        ''
        '' Supprime toutes les couleurs
        'MyGlobalProvider.CouleursPro.DeleteAllCouleurs()
        ''
        'Dim fct As List(Of Modele) = MyGlobalProvider.ModelesProv.GetAllModeles()
        'If Not fct Is Nothing AndAlso fct.Count > 0 Then
        '    For Each MyObject As Modele In fct
        '        Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5}", MyObject.libelle, MyObject.UniqueID.ToString, MyObject.cheveaux, MyObject.portes, MyObject.MyMarque.libelle, MyObject.MyMarque.libelle))
        '    Next
        'End If
        'Console.ReadKey()


    End Sub

End Module
