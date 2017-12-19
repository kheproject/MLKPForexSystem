Imports System.IO
Imports DAL
Imports XCommon
Imports XControls
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class connect

    Public myConMap As New XCommon.Map
    Public myConMap2 As New XCommon.Map
    Public myConMap3 As New XCommon.Map
    Public myConMap4 As New XCommon.Map
    Public frMap As New XCommon.Map
    Public myConMapXig As New XCommon.Map
    Public conn As DAL.DataAccess
    Public Shared myDal As DAL.DataAccess

    Public conStr As String
    Public mySql As String


    Public Sub ReadINI(ByVal dr As String)
        Try

            Dim fr As New XCommon.FileReader(dr)
            frMap = fr.GetFileMap()

            myConMap.Add("user id", frMap.GetValue("[UserForex]"))
            myConMap.Add("password", frMap.GetValue("[PasswordForex]"))
            myConMap.Add("server", frMap.GetValue("[Server1]"))
            myConMap.Add("database", frMap.GetValue("[DataBase]"))
            myConMap.Add("persist security info", "False")
            myConMap.Add("pooling", "True")

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ReadINI_US(ByVal dr As String)
        Try

            Dim fr As New XCommon.FileReader(dr)
            frMap = fr.GetFileMap()

            myConMap2.Add("user id", frMap.GetValue("[UserGlobal]"))
            myConMap2.Add("password", frMap.GetValue("[PasswordGlobal]"))
            myConMap2.Add("server", frMap.GetValue("[Server2]"))
            myConMap2.Add("database", frMap.GetValue("[DataBase2]"))
            myConMap2.Add("persist security info", "False")
            myConMap2.Add("pooling", "True")
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ReadINI_Phil(ByVal dr As String)
        Try

            Dim fr As New XCommon.FileReader(dr)
            frMap = fr.GetFileMap()

            myConMap3.Add("user id", frMap.GetValue("[UserDomestic]"))
            myConMap3.Add("password", frMap.GetValue("[PasswordDomestic]"))
            myConMap3.Add("server", frMap.GetValue("[Server3]"))
            myConMap3.Add("database", frMap.GetValue("[DataBase3]"))
            myConMap3.Add("persist security info", "False")
            myConMap3.Add("pooling", "True")
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ReadINI_CMMS(ByVal dr As String)
        Try

            Dim fr As New XCommon.FileReader(dr)
            frMap = fr.GetFileMap()

            myConMap4.Add("user id", frMap.GetValue("[UserCMMSGlobal]"))
            myConMap4.Add("password", frMap.GetValue("[PasswordCMMSGlobal]"))
            myConMap4.Add("server", frMap.GetValue("[Server4]"))
            myConMap4.Add("database", frMap.GetValue("[DataBase4]"))
            myConMap4.Add("persist security info", "False")
            myConMap4.Add("pooling", "True")
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ConnectDatabaseUS()
        Try
            myDal = New DAL.DataAccess(DataAccess.EnumProvider.MsSql, myConMap2)

        Catch ex As Exception
            'MsgBox("Error in connecting to the database: ", ex.Message)
        End Try
    End Sub

    Public Sub ConnectDatabasePhil()
        Try
            myDal = New DAL.DataAccess(DataAccess.EnumProvider.MsSql, myConMap3)
            conStr = myDal.ConnectionString
        Catch ex As Exception
            'MsgBox("Error in connecting to the database: ", ex.Message)
        End Try
    End Sub

    Public Sub ConnectDatabase()
        Try
            myDal = New DAL.DataAccess(DataAccess.EnumProvider.MsSql, myConMap)
            conStr = myDal.ConnectionString
        Catch ex As Exception
            'MsgBox("Error in connecting to the database: ", ex.Message)
        End Try
    End Sub
    Public Sub ConnectDatabaseCMMS()
        Try
            myDal = New DAL.DataAccess(DataAccess.EnumProvider.MsSql, myConMap4)
            conStr = myDal.ConnectionString
        Catch ex As Exception
            'MsgBox("Error in connecting to the database: ", ex.Message)
        End Try
    End Sub
    Public Sub DisconnectDatabase()
        Try
            myDal.Close()
        Catch ex As Exception
            'MsgBox("Error in disconnecting to the database: ", ex.Message)
        End Try
    End Sub

    Public Function getServerTime() As String
        Dim sql As String
        Dim addapter As New MySqlDataAdapter
        Dim tb As DataTable

        sql = "select date_format(now(), '%r')"
        'ConnectDatabase()
        addapter = New MySqlDataAdapter(sql, myDal.ConnectionString)
        tb = New DataTable
        addapter.Fill(tb)
        DisconnectDatabase()

        Return tb(0).Item(0).ToString
    End Function

    Public Function getServerDateTime() As String
        Dim sql As String
        Dim addapter As New MySqlDataAdapter
        Dim tb As DataTable

        sql = "select now()"
        'ConnectDatabase()
        addapter = New MySqlDataAdapter(sql, myDal.ConnectionString)
        tb = New DataTable
        addapter.Fill(tb)
        DisconnectDatabase()

        Return tb(0).Item(0).ToString
    End Function
End Class
