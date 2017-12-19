Imports MySql.Data.MySqlClient
Imports System.Data
Imports log4net
Imports log4net.Config

Partial Class Pages_Utility
    Inherits System.Web.UI.Page

    Dim ls As New connect
    Dim tb As New DataTable
    Dim addapter As New MySqlDataAdapter
    Dim sPath As String
    Dim isFound As Boolean
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("Utility")



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If

        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI_Phil(sPath)
        ls.ConnectDatabasePhil()

        If IsPostBack = False Then
            btnUtil.ImageUrl = "~/Images/btnUtil1.png"
        End If
        If Userinfo.username = "Vismin" Or Userinfo.username = "Luzon" Then
            btnUtil.Visible = False
            btnHist.Visible = False
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        SearcID(TxtIDno.Text, Userinfo.zone)
    End Sub
    Private Sub SearcID(ByVal resourceID As String, ByVal zonecode As String)
        Try
            log4net.Info("SEARCID - resourceID:" + resourceID + ", zonecode:" + zonecode)
            LbMsgSave.Text = String.Empty
            Dim Mysql As String
            resourceID = TxtIDno.Text
            Mysql = "SELECT  b.Firstname, b.middlename, b.lastname, s.IsForex FROM kpusers.adminsysuseraccounts s " & _
                    "INNER JOIN kpusers.adminbranchusers b ON b.resourceid= s.resourceid AND b.zonecode=s.zonecode " & _
                    "WHERE s.zonecode='" & zonecode & "' and s.resourceid ='" & resourceID & "' "
            addapter = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)

            Select Case tb.Rows.Count
                Case 0
                    Me.lblError.Visible = True
                    CkReadonly.Enabled = False
                    lblError.Text = "ID No. not found!"
                    LbFName.Text = String.Empty
                    LbMName.Text = String.Empty
                    LbLName.Text = String.Empty
                    CkReadonly.Checked = False
                    isFound = False
                Case Else
                    Me.lblError.Visible = False
                    CkReadonly.Enabled = True
                    LbFName.Text = tb.Rows(0).Item(0).ToString
                    LbMName.Text = tb.Rows(0).Item(1).ToString
                    LbLName.Text = tb.Rows(0).Item(2).ToString
                    CkReadonly.Checked = CBool(tb.Rows(0).Item(3))
                    isFound = True
            End Select
            ls.DisconnectDatabase()
            log4net.Info("SEARCID - SUCCESS!")
        Catch ex As Exception
            log4net.Error("SEARCID -" + ex.Message)
            lblError.Text = "Cannot connect to database"
        End Try
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If TxtIDno.Text = "1011873" Then
            LbMsgSave.Text = "This user cannot be modified."
            Exit Sub
        End If
        If LbFName.Text <> String.Empty And LbLName.Text <> String.Empty Then
            saveUser(Userinfo.zone)
        Else
            LbMsgSave.Text = "Please verify ID Number."
            TxtIDno.Focus()
        End If

    End Sub
    Private Sub saveUser(ByVal zonecode As String)
        Try
            zonecode = Userinfo.zone
            log4net.Info("SAVEUSER - zonecode:" + zonecode)
            Dim Mysql As String
            Dim isforex As Integer
            Select Case CkReadonly.Checked
                Case True
                    isforex = 1
                Case Else
                    isforex = 0
            End Select

            Mysql = "Update kpusers.adminsysuseraccounts set isforex = '" & isforex & "' " & _
                    "WHERE  resourceid ='" & Trim(TxtIDno.Text) & "' and zonecode='" & Userinfo.zone & "'"

            addapter = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            LbMsgSave.Text = "Successfully saved."
            log4net.Info("SAVEUSER - SUCCESS!")


        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("SAVEUSER -" + ex.Message)
        End Try
    End Sub

    Protected Sub TxtIDno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIDno.TextChanged
        SearcID(TxtIDno.Text, Userinfo.zone)
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        TxtIDno.Text = String.Empty
        LbFName.Text = String.Empty
        LbMName.Text = String.Empty
        LbLName.Text = String.Empty
        CkReadonly.Checked = False
        LbMsgSave.Text = String.Empty
        lblError.Text = String.Empty
        CkReadonly.Enabled = False
    End Sub

    Protected Sub BtnHist_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnHist.Click
        Response.Redirect("Forex History_fsd.aspx")
    End Sub

    Protected Sub btnUtil_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUtil.Click
        Response.Redirect("Utility.aspx")
    End Sub
End Class
