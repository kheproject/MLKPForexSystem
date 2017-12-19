Imports MySql.Data.MySqlClient
Imports System.Data
Imports Userinfo
Imports AESEncrypt
Imports log4net
Imports log4net.Config
'<Assembly: log4net.Config.XMLConfigurator(ConfigFile:="log4netAssembly.exe.log4net", Watch:=True)> 


Partial Class Pages_Login

    Inherits System.Web.UI.Page

    Dim sPath As String
    Dim ls As New connect
    Dim tb As New DataTable
    Dim addapter As New MySqlDataAdapter
    Dim elhanan As Integer
    Dim usrchk As Boolean
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("Login")

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            goConnect()
            If elhanan = 0 Then
                kpUsers()

                If tb.Rows.Count = 0 Then
                    msgError.Text = "User or password error"
                    'log.makeLog("Login.btnLogin_Click - ", msgError.Text)
                    log4net.Info("Login.btnLogin_Click -" + msgError.Text)
                Else
                    If usrchk = True Then
                        Userinfo.username = tb(0).Item(0).ToString
                        Me.Session("xxxcheckLoginInfo") = Userinfo.username
                        Me.Session("currName") = "0"
                        Me.Session("stBuy") = "0"
                        Me.Session("stSell") = "0"
                        Me.Session("spBuy") = "0"
                        Me.Session("spSell") = "0"
                        Me.Session("exBuy") = "0"
                        Me.Session("exSell") = "0"
                        Me.Session("globalrate") = "0"
                        Me.Session("globalAverage") = "0"
                        Me.Session("currName") = "0"
                        Me.Session("_dcm") = "0"
                        Me.Session("_ovRate") = "0"
                        Me.Session("st_buy") = "0"
                        Me.Session("st_sell") = "0"
                        Me.Session("sp_buy") = "0"
                        Me.Session("sp_sell") = "0"
                        Me.Session("ex_buy") = "0"
                        Me.Session("ex_sell") = "0"
                        log4net.Info("Login.btnLogin_Click - User : " + Userinfo.username)
                        If Userinfo.username = "MICHAEL  LHUILLIER" Or Userinfo.username = "MARLYN L. ISIDORO" Then
                            Response.Redirect("ForexSettings.aspx")
                        Else
                            Response.Redirect("Forex History_fsd.aspx")

                        End If
                        'Exit Sub

                    Else
                        msgError.Text = "User or password error"
                        log4net.Error("BTNLOGIN_CLICK - " + msgError.Text)
                    End If
                End If

                'If Trim(txtuser.Text) = "admin" And Trim(txtpass.Text) = "admin" Or txtuser.Text.Trim = "ADMIN" And txtuser.Text.Trim = "ADMIN" Then
                '    'Direct to Home page
                '    Userinfo.username = "Admin"
                '    Me.Session("xxxcheckLoginInfo") = "Admin"
                '    Me.Session("currName") = "0"
                '    Me.Session("stBuy") = "0"
                '    Me.Session("stSell") = "0"
                '    Me.Session("spBuy") = "0"
                '    Me.Session("spSell") = "0"
                '    Me.Session("exBuy") = "0"
                '    Me.Session("exSell") = "0"
                '    Me.Session("globalrate") = "0"
                '    Me.Session("globalAverage") = "0"
                '    Me.Session("currName") = "0"
                '    Me.Session("_dcm") = "0"
                '    Me.Session("_ovRate") = "0"
                '    Me.Session("st_buy") = "0"
                '    Me.Session("st_sell") = "0"
                '    Me.Session("sp_buy") = "0"
                '    Me.Session("sp_sell") = "0"
                '    Me.Session("ex_buy") = "0"
                '    Me.Session("ex_sell") = "0"

                '    Response.Redirect("ForexSettings.aspx")
                'Response.Redirect("Utility.aspx")
                If Trim(txtuser.Text) = "vismin" And Trim(txtpass.Text) = "vismin" Or txtuser.Text.Trim = "VISMIN" And txtuser.Text.Trim = "VISMIN" Then

                    Userinfo.username = "Vismin"
                    Userinfo.zone = "1"
                    Me.Session("xxxcheckLoginInfo") = "Vismin"
                    Me.Session("currName") = "0"
                    Me.Session("stBuy") = "0"
                    Me.Session("stSell") = "0"
                    Me.Session("spBuy") = "0"
                    Me.Session("spSell") = "0"
                    Me.Session("exBuy") = "0"
                    Me.Session("exSell") = "0"
                    Me.Session("globalrate") = "0"
                    Me.Session("globalAverage") = "0"
                    Me.Session("currName") = "0"
                    Me.Session("_dcm") = "0"
                    Me.Session("_ovRate") = "0"
                    Me.Session("st_buy") = "0"
                    Me.Session("st_sell") = "0"
                    Me.Session("sp_buy") = "0"
                    Me.Session("sp_sell") = "0"
                    Me.Session("ex_buy") = "0"
                    Me.Session("ex_sell") = "0"
                    'log.makeLog("Login.btnLogin_Click - ZONECODE : 1", Userinfo.username)
                    log4net.Info("BTNLOGIN_CLICK - ZONECODE : 1, User:" + Userinfo.username)
                    Response.Redirect("Utility.aspx")
                ElseIf Trim(txtuser.Text) = "luzon" And Trim(txtpass.Text) = "luzon" Or txtuser.Text.Trim = "LUZON" And txtuser.Text.Trim = "LUZON" Then

                    Userinfo.username = "Luzon"
                    Userinfo.zone = "2"
                    Me.Session("xxxcheckLoginInfo") = "Luzon"
                    Me.Session("currName") = "0"
                    Me.Session("stBuy") = "0"
                    Me.Session("stSell") = "0"
                    Me.Session("spBuy") = "0"
                    Me.Session("spSell") = "0"
                    Me.Session("exBuy") = "0"
                    Me.Session("exSell") = "0"
                    Me.Session("globalrate") = "0"
                    Me.Session("globalAverage") = "0"
                    Me.Session("currName") = "0"
                    Me.Session("_dcm") = "0"
                    Me.Session("_ovRate") = "0"
                    Me.Session("st_buy") = "0"
                    Me.Session("st_sell") = "0"
                    Me.Session("sp_buy") = "0"
                    Me.Session("sp_sell") = "0"
                    Me.Session("ex_buy") = "0"
                    Me.Session("ex_sell") = "0"
                    log4net.Info("BTNLOGIN_CLICK - ZONECODE : 1, user:" + Userinfo.username)
                    Response.Redirect("Utility.aspx")
                Else
                    msgError.Visible = True
                    msgError.Text = "User or password error!"
                    log4net.Error("BTNLOGIN_CLICK - " + msgError.Text)

                End If

            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub goConnect()
        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)
        ls.ConnectDatabase()
        Dim connStr As String = ls.conStr
        Dim conn As New MySqlConnection(connStr)

        Try
            conn.Open()
            elhanan = 0
        Catch ex As Exception
            elhanan = 1
            ClientScript.RegisterStartupScript(Me.GetType(), "Cant Connect", "alert('Cant connect to any server.!');", True)
            log4net.Error("GOCONNECT - ERROR : Can't Connect" + elhanan)
            Exit Sub
        End Try
        conn.Close()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtuser.Focus()
        usrchk = False
        'If Me.Session("xxxcheckLoginInfo") = Me.Session("xxxcheckLoginInfo") And Not Me.Session("xxxcheckLoginInfo") = Nothing Then
        '    Response.Redirect("ForexSettings.aspx")
        'End If
    End Sub

    Protected Sub btnLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Load
        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI_US(sPath)
        ls.ReadINI_Phil(sPath)
    End Sub

    Public Sub kpUsers()
        Try
            Dim tempass As String
            Dim Mysql As String
            Dim d As New AESEncrypt.AESEncryption
            ls.ConnectDatabaseUS()

            Mysql = "CALL forex_login('" & txtuser.Text & "','" & txtpass.Text & "');" '" select b.Fullname from kpusersglobal.sysuseraccounts s inner join kpusersglobal.branchusers b on b.resourceid= s.resourceid and b.zonecode=s.zonecode where s.resourceid = '1011873' and s.zonecode='3' and s.userlogin='" & txtuser.Text & "' and s.userpassword='" & txtpass.Text & "';"
            log4net.Info("KPUSERS - " + " user : " + txtuser.Text + ", pass : " + txtpass.Text)
            addapter = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            usrchk = True
            If tb.Rows.Count = 0 Then
                ls.ConnectDatabasePhil()
                Mysql = "CALL forex_login_FSD('" & txtuser.Text & "');" '" select b.Fullname from kpusersglobal.sysuseraccounts s inner join kpusersglobal.branchusers b on b.resourceid= s.resourceid and b.zonecode=s.zonecode where s.resourceid = '1011873' and s.zonecode='3' and s.userlogin='" & txtuser.Text & "' and s.userpassword='" & txtpass.Text & "';"
                'Mysql = "SELECT b.Fullname, s.IsForex FROM kpusers.adminsysuseraccounts s " & _
                '  "INNER JOIN kpusers.adminbranchusers b ON b.resourceid= s.resourceid AND b.zonecode=s.zonecode " & _
                '  "WHERE  s.userlogin = '" & txtuser.Text & "' and s.userpassword = '" & txtpass.Text & "'"

                addapter = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                Userinfo.role = tb(0).Item(1).ToString
                Userinfo.zone = tb(0).Item(2).ToString
                tempass = tb(0).Item(3).ToString
                Userinfo.Usrpass = d.AESDecrypt(tempass, "kWuYDGElyQDpGKM9")


                If txtpass.Text = Userinfo.Usrpass Then
                    usrchk = True
                Else
                    usrchk = False
                End If
            End If
            ls.DisconnectDatabase()
            log4net.Info("KPUSERS - SUCCESS!")

        Catch ex As Exception
            usrchk = False
            msgError.Text = "Cannot connect to database"
        End Try
    End Sub
    Private Sub CheckPassword()

    End Sub


End Class
