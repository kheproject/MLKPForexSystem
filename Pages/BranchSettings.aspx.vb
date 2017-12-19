Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DAL
Imports Userinfo
Imports log4net
Imports log4net.Config
'<Assembly: log4net.Config.XMLConfigurator(ConfigFile:="log4netAssembly.exe.log4net", Watch:=True)> 




Partial Class Pages_BranchSettings
    Inherits System.Web.UI.Page
    Dim sPath As String
    Dim ls As New connect
    Dim adapters As New MySqlDataAdapter
    Dim check As Boolean
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("Branch Settings")


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)
        Dim time As DateTime = ls.getServerTime
        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            btnBranchSet.ImageUrl = "~/Images/btnBranchSet1.png"
            GetBranch()
        End If
    End Sub
    Private Sub GetBranch()
        'sPath = Server.MapPath("..\Bin\kpForex.ini")
        'ls.ReadINI(sPath)
        'ls.ConnectDatabase()
        'Dim time As DateTime = ls.getServerTime
        Try
            Dim Mysql As String
            Mysql = "select branchname from mlforexrate.brachrateclassification where zonecode=3"
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            Dim tb As New DataTable
            adapters.Fill(tb)

            Select Case tb.Rows.Count
                Case 0
                Case Else

                    If DrpBranchName.Items.Count <> 0 Then
                        DrpBranchName.Items.Clear()
                    End If
                    DrpBranchName.Items.Add("")
                    For i = 0 To tb.Rows.Count - 1
                        DrpBranchName.Items.Add(tb.Rows(i).Item(0).ToString)
                    Next
            End Select
            ls.DisconnectDatabase()



        Catch ex As Exception
            log4net.Error("GETBRANCH - ERROR : " + ex.Message)
        End Try
    End Sub
    Protected Sub DrpBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpBranchName.SelectedIndexChanged
        UpdatePanel12.Update()
        LbMsgSave.Text = ""
        If DrpBranchName.SelectedIndex <> 0 Then
            UpdatePanel6.Update()
            Panel1.Visible = True
            UpdatePanel2.Update()
            UpdatePanel3.Update()
            UpdatePanel4.Update()
            UpdatePanel5.Update()
            UpdatePanel8.Update()
            UpdatePanel9.Update()
            UpdatePanel10.Update()

            getBCode()
            getForexClass()
            getForexStat()
            btnEdit.Enabled = True
            If ckbAutomate.Checked = True Then
                lblEffective.Visible = False
                lblDate.Visible = False
                lblFormat.Visible = False
            Else
                lblEffective.Visible = True
                lblDate.Visible = True
                lblFormat.Visible = True
            End If
            If ckbManual.Checked = True Then
                lblEffective.Visible = True
                lblDate.Visible = True
                lblFormat.Visible = True
            Else
                lblEffective.Visible = False
                lblDate.Visible = False
                lblFormat.Visible = False
            End If
        Else
            UpdatePanel6.Update()
            Panel1.Visible = False
            UpdatePanel2.Update()
            UpdatePanel3.Update()
            UpdatePanel4.Update()
            UpdatePanel5.Update()
            UpdatePanel9.Update()
            UpdatePanel10.Update()
            LbBCode.Text = ""
            LbForexClass.Text = ""
            ckbAutomate.Checked = False
            ckbManual.Checked = False
            UpdatePanel8.Update()
            btnEdit.Enabled = False
            lblEffective.Visible = False
            lblDate.Visible = False
            lblFormat.Visible = False
        End If
    End Sub
    Private Sub getBCode()
        Try
            Dim Mysql As String
            Mysql = "select branchcode from mlforexrate.brachrateclassification where zonecode=3 and branchname='" & DrpBranchName.Text & "'"
            'log.makeLog("BranchSetting.getBcode - branchname : ", DrpBranchName.Text)
            log4net.Info("BranchSetting.getBcode - branchname : " + DrpBranchName.Text)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            Dim data As New DataTable
            adapters.Fill(data)

            If data.Rows.Count <> 0 Then
                LbBCode.Text = data.Rows(0).Item(0).ToString

            Else
                LbBCode.Text = ""
            End If
            ls.DisconnectDatabase()


        Catch ex As Exception
            log4net.Error("GETBCODE - " + ex.Message)
        End Try
    End Sub
    Private Sub getForexClass()
        Try
            Dim Mysql As String
            Mysql = "select f.descriptions, f.code from mlforexrate.forexgroup f " & _
                    "inner join mlforexrate.brachrateclassification b on b.classification=f.code " & _
                    "where b.zonecode=3 and b.branchcode='" & LbBCode.Text & "'"
            'log.makeLog("BranchSetting.getForexClass - branchcode: ", LbBCode.Text)
            log4net.Info("BranchSetting.getForexClass - branchcode: " + LbBCode.Text)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            Dim data As New DataTable
            adapters.Fill(data)

            If data.Rows.Count <> 0 Then
                LbForexClass.Text = data.Rows(0).Item(0).ToString
                Me.Session("classCode") = data.Rows(0).Item(1).ToString
            Else
                LbForexClass.Text = ""
                Me.Session("classCode") = ""
            End If
            ls.DisconnectDatabase()


        Catch ex As Exception
            'log.makeLog("BranchSetting.getForexClass - ERROR : ", ex.Message)
            log4net.Error("GETFOREXCLASS - " + ex.Message)
        End Try
    End Sub
    Private Sub getValueManual()
        Try
            Dim Mysql As String
            Mysql = "select curr_buy from mlforexrate.branchforexmanual where zonecode=3 and branchcode='" & LbBCode.Text & "' and currname='USD'"
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            'log.makeLog("BranchSetting.getvalueManual - branchcode :", LbBCode.Text)
            log4net.Info("BranchSetting.getvalueManual - branchcode :" + LbBCode.Text)
            Dim data As New DataTable
            adapters.Fill(data)
            UpdatePanel7.Update()
            If data.Rows.Count <> 0 Then
                Me.Session("HasManual") = data.Rows(0).Item(0)
                Me.Session("HasAutomate") = "00.00"
                txtValue.Text = data.Rows(0).Item(0)
            Else
                Me.Session("HasManual") = ""
                txtValue.Text = "00.00"
            End If
            log4net.Info("GETVALUEMANUAL - Value :" + txtValue.Text)
            ls.DisconnectDatabase()


        Catch ex As Exception
            'log.makeLog("BranchSetting.getValueManual - ERROR : ", ex.Message)
            log4net.Info("GETVALUEMANUAL - " + ex.Message)
        End Try
    End Sub
    Private Sub getValueAutomate()
        Try
            Dim Mysql As String
            Mysql = "call mlforexrate.sp_getbranchrates ('" & LbBCode.Text & "', '3', 'USD', '" & Me.Session("classCode") & "');"
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            log4net.Info("GETVALUEAUTOMATEe - call mlforexrate.sp_getbranchrates, branchcode :" + LbBCode.Text)
            Dim data As New DataTable
            adapters.Fill(data)
            UpdatePanel7.Update()
            If data.Rows.Count <> 0 Then
                Me.Session("HasAutomate") = data.Rows(0).Item(2)
                Me.Session("HasManual") = "00.00"
                txtValue.Text = data.Rows(0).Item(2)
            Else
                Me.Session("HasAutomate") = ""
                txtValue.Text = "00.00"
            End If
            log4net.Info("GETVALUEAUTOMATE - call mlforexrate.sp_getbranchrates, branchcode :" + LbBCode.Text)
            ls.DisconnectDatabase()


        Catch ex As Exception
            log4net.Error("GETVALUEAUTOMATE" + ex.Message)
        End Try
    End Sub

    Private Sub getForexStat()
        Try
            Dim Mysql As String
            Mysql = "select identifier,effectivedate from mlforexrate.branchforextagrates where zonecode=3 and branchcode='" & LbBCode.Text & "'"
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(Mysql, connect.myDal.ConnectionString)
            'log.makeLog("BranchSetting.getForexStat - branchcode: ", LbBCode.Text)
            log4net.Info("BranchSetting.getForexStat - branchcode: " + LbBCode.Text)
            Dim data As New DataTable
            adapters.Fill(data)

            If data.Rows.Count <> 0 Then
                Dim stat As Integer = data.Rows(0).Item(0)
                Dim EDate As Date = data.Rows(0).Item(1)
                Dim EString As String = Format(EDate, "MM/dd/yyyy HH:mm:ss")

                If stat = 1 Then 'automate
                    ckbAutomate.Checked = True
                    ckbManual.Checked = False
                    getValueAutomate()
                Else
                    ckbAutomate.Checked = False
                    ckbManual.Checked = True
                    lblDate.Text = EString
                    getValueManual()
                End If
            Else
                ckbAutomate.Checked = True
                ckbManual.Checked = False
                getValueAutomate()
            End If
            ls.DisconnectDatabase()



        Catch ex As Exception
            log4net.Error("GETFOREXSTAT  - " + ex.Message)
        End Try
    End Sub
    Protected Sub btnSettings_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSettings.Click
        Response.Redirect("ForexSettings.aspx")
    End Sub
    Protected Sub btnHistory_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnHistory.Click
        Response.Redirect("Forex History.aspx")
    End Sub
    Protected Sub btnLogs_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogs.Click
        Response.Redirect("Forex Log.aspx")
    End Sub
    Protected Sub btnGlobal_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGlobal.Click
        Response.Redirect("Global Rate.aspx")
    End Sub
    Protected Sub ckbAutomate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbAutomate.CheckedChanged
        UpdatePanel4.Update()
        UpdatePanel5.Update()
        UpdatePanel7.Update()
        UpdatePanel9.Update()
        UpdatePanel10.Update()
        UpdatePanel11.Update()
        If ckbAutomate.Checked = True Then
            ckbManual.Checked = False
            getValueAutomate()
            If Me.Session("HasAutomate") <> "00.00" Then
                txtValue.Text = Me.Session("HasAutomate")
            Else
                txtValue.Text = txtValue.Text
            End If
            txtValue.BackColor = Drawing.Color.LightGray
            txtValue.ReadOnly = True
            lblEffective.Visible = False
            txtEffectiveDate.Visible = False
            lblFormat.Visible = False
            MaskedEditValidator1.Enabled = False
            MaskedEditValidator2.Enabled = False
        Else
            ckbManual.Checked = True
            getValueManual()
            If Me.Session("HasManual") <> "00.00" Then
                txtValue.Text = Me.Session("HasManual")
            Else
                txtValue.Text = txtValue.Text
            End If
            txtValue.BackColor = Drawing.Color.White
            txtValue.ReadOnly = False
            txtValue.Focus()
            lblEffective.Visible = True
            txtEffectiveDate.Visible = True
            lblFormat.Visible = True
            MaskedEditValidator1.Enabled = True
            MaskedEditValidator2.Enabled = True
        End If

    End Sub
    Protected Sub ckbManual_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbManual.CheckedChanged
        UpdatePanel4.Update()
        UpdatePanel5.Update()
        UpdatePanel7.Update()
        UpdatePanel9.Update()
        UpdatePanel10.Update()
        UpdatePanel11.Update()
        If ckbManual.Checked = True Then
            ckbAutomate.Checked = False
            getValueManual()
            If Me.Session("HasManual") <> "00.00" Then
                txtValue.Text = Me.Session("HasManual")
            Else
                txtValue.Text = txtValue.Text
            End If
            txtValue.BackColor = Drawing.Color.White
            txtValue.ReadOnly = False
            txtValue.Focus()
            If lblDate.Text <> "" Then
                txtEffectiveDate.Text = lblDate.Text
            Else
                txtEffectiveDate.Text = Format(CDate(ls.getServerDateTime()), "MM/dd/yyyy HH:mm:ss")
            End If
            lblEffective.Visible = True
            txtEffectiveDate.Visible = True
            lblFormat.Visible = True
            MaskedEditValidator1.Enabled = True
            MaskedEditValidator2.Enabled = True
        Else
            ckbAutomate.Checked = True
            getValueAutomate()
            If Me.Session("HasAutomate") <> "00.00" Then
                txtValue.Text = Me.Session("HasAutomate")
            Else
                txtValue.Text = txtValue.Text
            End If
            txtValue.BackColor = Drawing.Color.LightGray
            txtValue.ReadOnly = True
            lblEffective.Visible = False
            txtEffectiveDate.Visible = False
            lblFormat.Visible = False
            MaskedEditValidator1.Enabled = False
            MaskedEditValidator2.Enabled = False
        End If
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        UpdatePanel4.Update()
        UpdatePanel5.Update()
        UpdatePanel7.Update()
        UpdatePanel9.Update()
        UpdatePanel10.Update()
        UpdatePanel11.Update()
        DrpBranchName.Enabled = False
        btnEdit.Enabled = False
        ckbAutomate.Enabled = True
        ckbManual.Enabled = True
        btnSave.Enabled = True
        btnClear.Enabled = True
        If ckbManual.Checked = True Then
            lblEffective.Visible = True
            lblDate.Visible = False
            lblFormat.Visible = True
            txtEffectiveDate.Visible = True
            txtEffectiveDate.Text = lblDate.Text
            MaskedEditValidator1.Enabled = True
            txtValue.ReadOnly = False
            txtValue.BackColor = Drawing.Color.White
            MaskedEditValidator2.Enabled = True
        End If
        If ckbAutomate.Checked = True Then
            lblEffective.Visible = False
            lblDate.Visible = False
            lblFormat.Visible = False
            txtEffectiveDate.Visible = False
            MaskedEditValidator1.Enabled = False
            txtValue.ReadOnly = True
            txtValue.BackColor = Drawing.Color.LightGray
            MaskedEditValidator2.Enabled = False
        End If
    End Sub
    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
        LbMsgSave.Text = ""
    End Sub
    Private Sub clear()

        UpdatePanel2.Update()
        UpdatePanel3.Update()
        UpdatePanel4.Update()
        UpdatePanel5.Update()
        UpdatePanel6.Update()
        UpdatePanel7.Update()
        UpdatePanel9.Update()
        UpdatePanel10.Update()
        UpdatePanel11.Update()
        UpdatePanel12.Update()
        ckbAutomate.Enabled = False
        ckbManual.Enabled = False
        DrpBranchName.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        DrpBranchName.SelectedIndex = 0
        LbBCode.Text = ""
        LbForexClass.Text = ""
        Panel1.Visible = False
        lblEffective.Visible = False
        lblDate.Visible = False
        lblFormat.Visible = False
        txtEffectiveDate.Visible = False
        txtEffectiveDate.Text = ""
        MaskedEditValidator1.Enabled = False
        txtValue.ReadOnly = True
        MaskedEditValidator2.Enabled = False
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            UpdatePanel12.Update()
            'If txtValue.Text <> "" Then
            Dim BranchExist As Boolean = CheckBranch()
            Dim BranchExistManual As Boolean = CheckBranchManual()
            If ckbAutomate.Checked = True Then
                MaskedEditValidator2.Enabled = False
                If BranchExist = True Then
                    UpdateAutomate()
                    SaveLogs()
                Else
                    InsertAutomate()
                    SaveLogs()
                End If
            Else
                MaskedEditValidator2.Enabled = True
                If BranchExist = True Then
                    UpdateManual()
                Else
                    InsertManual()
                End If
                If check = 0 Then
                    If BranchExistManual = True Then
                        UpdateBranchForexManual()
                        SaveLogs()
                    Else
                        InsertBranchForexManual()
                        SaveLogs()
                    End If
                End If
            End If
            'Else
            log4net.Info("BTNSAVE_CLICK - SUCCESS!")



        Catch ex As Exception
            log4net.Error("BTNSAVE_CLICK - " + ex.Message)
        End Try
        'End If
    End Sub
    Function CheckBranch() As Boolean
        Try
            Dim mysql As String
            Dim IsExist As Boolean

            mysql = "select branchcode from mlforexrate.branchforextagrates where zonecode=3 and branchcode='" & LbBCode.Text & "'"
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            'log.makeLog("BranchSetting.CheckBranch - branchcode: ", LbBCode.Text)
            log4net.Info("BranchSetting.CheckBranch - branchcode: " + LbBCode.Text)
            Dim data As New DataTable
            adapters.Fill(data)

            If data.Rows.Count <> 0 Then
                IsExist = True
            Else
                IsExist = False
            End If

            Return IsExist
            log4net.Info("CHECKBRANCH -  IsExist: " + IsExist)
            ls.DisconnectDatabase()


        Catch ex As Exception
            log4net.Error("CHECKBRANCH - " + ex.Message)
        End Try
    End Function
    Private Sub InsertAutomate()
        Try
            Dim mysql As String
            Dim sysdate As Date = ls.getServerDateTime()
            Dim serDate As String = Format(sysdate, "yyyy-MM-dd HH:mm:ss")
            mysql = "INSERT INTO mlforexrate.branchforextagrates (branchcode, zonecode, remarks, identifier, effectivedate, syscreator, syscreated, sysmodified) " & _
            "VALUES('" & LbBCode.Text & "', '3', 'Automate', '1', '" & serDate & "','" & Userinfo.username & "', '" & serDate & "', '" & serDate & "')"
            Dim logs As String = ("branchcode :" + LbBCode.Text + ", username: " + Userinfo.username)
            log4net.Info("INSERTAUTOMATE - " + logs)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            Dim tb As New DataTable
            adapters.Fill(tb)
            ls.DisconnectDatabase()

            LbMsgSave.Text = "Successfully saved."
            log4net.Info("INSERTAUTOMATE - " + LbMsgSave.Text)
        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("INSERTAUTOMATE - " + ex.Message)
        End Try
    End Sub
    Private Sub UpdateAutomate()
        Try
            Dim mysql As String
            Dim sysdate As Date = ls.getServerDateTime()
            Dim serDate As String = Format(sysdate, "yyyy-MM-dd HH:mm:ss")

            mysql = "Update mlforexrate.branchforextagrates set remarks='Automate', Identifier = 1, effectivedate='" & serDate & "', syscreator ='" & Userinfo.username & "',  sysmodified = '" & serDate & "' " & _
                    "where branchcode='" & LbBCode.Text & "' and zonecode=3"
            Dim logs As String = ("effectivedate: " + serDate + ", syscreator:" + Userinfo.username + ", branchcode:" + LbBCode.Text)
            log4net.Info("UPDATEAUTOMATE - " + logs)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)

            Dim tb As New DataTable
            adapters.Fill(tb)
            ls.DisconnectDatabase()

            LbMsgSave.Text = "Successfully saved."
            log4net.Info("UPDATEAUTOMATE- SUCCESS!")
        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("UPDATEAUTOMATE - " + ex.Message)
        End Try

    End Sub
    Private Sub UpdateManual()
        Try

            Dim mysql As String
            Dim SetDate As Date = txtEffectiveDate.Text
            Dim ServerDate As Date = ls.getServerDateTime

            If SetDate > ServerDate Then
                Dim Edate As String = Format(SetDate, "yyyy-MM-dd HH:mm:ss")
                Dim servDate As String = Format(ServerDate, "yyyy-MM-dd HH:mm:ss")
                mysql = "UPDATE mlforexrate.branchforextagrates SET remarks='Manual', identifier=0, effectivedate= '" & Edate & "', syscreator = '" & Userinfo.username & "', sysmodified='" & servDate & "' " & _
                        "where zonecode= 3 and branchcode='" & LbBCode.Text & "'"
                Dim logs As String = ("effectivedate: " + Edate + ", syscreator:" + Userinfo.username + ", branchcode:" + LbBCode.Text)
                log4net.Info("UPDATEMANUAL - " + logs)
                ls.ConnectDatabase()
                adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
                Dim tb As New DataTable
                adapters.Fill(tb)
                ls.DisconnectDatabase()

                check = 0
                LbMsgSave.Text = "Successfully saved."
                log4net.Info("UPDATEMANUAL - SUCCESS!")
            Else
                check = 1
                LbMsgSave.Text = "Effective date must be set later than " + Format(ServerDate, "MM/dd/yyyy HH:mm:ss")
                Exit Sub
            End If

        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("UPDATEMANUAL - " + ex.Message)
        End Try
    End Sub
    Private Sub InsertManual()
        Try


            Dim mysql As String
            Dim SetDate As Date = txtEffectiveDate.Text
            Dim ServerDate As Date = ls.getServerDateTime

            If SetDate > ServerDate Then
                Dim Edate As String = Format(SetDate, "yyyy-MM-dd HH:mm:ss")
                Dim servDate As String = Format(ServerDate, "yyyy-MM-dd HH:mm:ss")

                mysql = "Insert into mlforexrate.branchforextagrates (branchcode, zonecode, remarks, identifier, effectivedate, syscreator, syscreated, sysmodified) " & _
                        "Values ('" & LbBCode.Text & "', '3', 'Manual', '0', '" & Edate & "','" & Userinfo.username & "', '" & servDate & "', '" & servDate & "')"
                Dim logs As String = ("effectivedate: " + Edate + ", syscreator:" + Userinfo.username + ", branchcode:" + LbBCode.Text)
                log4net.Info("INSERTMANUAL - " + logs)
                ls.ConnectDatabase()
                adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
                Dim tb As New DataTable
                adapters.Fill(tb)
                ls.DisconnectDatabase()
                LbMsgSave.Text = "Successfully saved."
                log4net.Info("INSERTMANUAL - SUCCESS!")
                check = 0
            Else
                check = 1
                LbMsgSave.Text = "Effective date must be set later than " + Format(ServerDate, "MM/dd/yyyy HH:mm:ss")
                Exit Sub
            End If


        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("INSERTMANUAL - " + ex.Message)
        End Try
    End Sub
    Function CheckBranchManual() As Boolean
        Try
            Dim mysql As String
            Dim IsExist As Boolean

            mysql = "select branchcode from mlforexrate.branchforexmanual where zonecode=3 and branchcode='" & LbBCode.Text & "'"
            log4net.Info("CHECKBRANCHMANUAL -  branchcode: " + LbBCode.Text)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            Dim data As New DataTable
            adapters.Fill(data)

            If data.Rows.Count <> 0 Then
                IsExist = True
            Else
                IsExist = False
            End If
            ls.DisconnectDatabase()
            Return IsExist
            log4net.Info("CHECKBRANCHMANUAL - IfExist" + IsExist)

        Catch ex As Exception
            log4net.Error("CHECKBRANCHMANUAL - " + ex.Message)
        End Try
    End Function
    Private Sub UpdateBranchForexManual()
        Try

            Dim sysdate As Date = ls.getServerDateTime()
            Dim serDate As String = Format(sysdate, "yyyy-MM-dd HH:mm:ss")
            Dim mysql As String
            mysql = "Update mlforexrate.branchforexmanual set curr_buy='" & txtValue.Text & "', syscreator='" & Userinfo.username & "', sysmodified='" & serDate & "' " & _
                    "where zonecode=3 and branchcode='" & LbBCode.Text & "'"
            Dim logs As String = ("curr_buy: " + txtValue.Text + ", syscreator:" + Userinfo.username + ", branchcode:" + LbBCode.Text)
            log4net.Info("UPDATEBRANCHFOREXMANUAL - " + logs)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            Dim tb As New DataTable
            adapters.Fill(tb)
            ls.DisconnectDatabase()

            LbMsgSave.Text = "Successfully saved."
            log4net.Info("UPDATEBRANCHFOREXMANUAL - SUCCESS!")
        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("UPDATEBRANCHFOREXMANUAL - " + ex.Message)
        End Try
    End Sub
    Private Sub InsertBranchForexManual()
        Try
            Dim sysdate As Date = ls.getServerDateTime()
            Dim serDate As String = Format(sysdate, "yyyy-MM-dd HH:mm:ss")
            Dim mysql As String

            mysql = "Insert into mlforexrate.branchforexmanual (currname, branchcode, zonecode, curr_buy, syscreator, syscreated, sysmodified) " & _
                    "values ('USD', '" & LbBCode.Text & "', '3', '" & txtValue.Text & "', '" & Userinfo.username & "', '" & serDate & "', '" & serDate & "')"
            Dim logs As String = ("branchcode:" + LbBCode.Text + "curr_buy: " + txtValue.Text + ", syscreator:" + Userinfo.username)
            log4net.Info("INSERTBRANCHFOREXMANUAL - " + logs)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            Dim tb As New DataTable
            adapters.Fill(tb)
            ls.DisconnectDatabase()

            LbMsgSave.Text = "Successfully saved."
            log4net.Info("INSERTBRANCHFOREXMANUAL - SUCCESS!")
        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("INSERTBRANCHFOREXMANUAL - " + ex.Message)
        End Try
    End Sub

    Private Sub SaveLogs()
        Try

            Dim mysql As String
            Dim sysdate As Date = ls.getServerDateTime()
            Dim serDate As String = Format(sysdate, "yyyy-MM-dd HH:mm:ss")
            Dim detail As String

            If ckbAutomate.Checked = True Then
                detail = "{branchcode: " + LbBCode.Text + ", zonecode: 3" + ", selling: 0" + ", buying: 0" + ", syscreator: " + Userinfo.username + ", currency: USD" + ", remarks: Automate" + ", EffectiveDate: " + serDate + "}"
            Else
                detail = "{branchcode: " + LbBCode.Text + ", zonecode: 3" + ", selling: 0" + ", buying: " + txtValue.Text + ", syscreator:" + Userinfo.username + ", currency: USD" + ", remarks: Manual" + ", EffectiveDate: " + txtEffectiveDate.Text + "}"
            End If

            mysql = "Insert into mlforexrate.branchforextaglogs (branchcode, zonecode, details, syscreator, syscreated) " & _
                    "values ('" & LbBCode.Text & "', '3', '" & detail & "', '" & Userinfo.username & "', '" & serDate & "')"
            Dim logs As String = ("branchcode: " + LbBCode.Text + ", detail: " + detail + ", syscreator: " + Userinfo.username)
            log4net.Info("SAVELOGS - " + logs)
            ls.ConnectDatabase()
            adapters = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)

            Dim tb As New DataTable
            adapters.Fill(tb)
            ls.DisconnectDatabase()

            LbMsgSave.Text = "Successfully saved."
            log4net.Info("SAVELOGS - SUCCESS!")
            clear()
        Catch ex As Exception
            LbMsgSave.Text = ex.Message
            log4net.Error("SAVELOGS - " + ex.Message)
        End Try
    End Sub
End Class
