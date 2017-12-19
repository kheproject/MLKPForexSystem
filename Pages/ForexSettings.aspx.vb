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


Partial Class Pages_ForexSettings
    Inherits System.Web.UI.Page
    Public addapter As New MySqlDataAdapter
    Public tb As DataTable
    Dim ls As New connect
    Dim ls_cmms As New connect
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("ForexSettings")


    Dim sql1 As String = "select currname, global_rate, average_globalrate, ord_sell, ord_buy, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modified, modifier, status from mlforexrate.globalforexrates where identifier='0';"
    Dim sql2 As String = "select currname, global_rate, average_globalrate, ord_sell, ord_buy, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modified, modifier, status from mlforexrate.globalforexrates where identifier='1' order by currname ASC;"
    Dim sql5 As String = "select * from globalrates where identifier='1'"

    Dim sPath As String

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex

        empVal()

        Me.Session("currName") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("currname").ToString
        Me.Session("globalrate") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("global_rate").ToString
        Me.Session("st_buy") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("stan_buy").ToString
        Me.Session("st_sell") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("stan_sell").ToString
        Me.Session("sp_buy") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("spe_buy").ToString
        Me.Session("sp_sell") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("spe_sell").ToString
        Me.Session("ex_buy") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("extra_buy").ToString
        Me.Session("ex_sell") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("extra_sell").ToString
        'Me.Session("or_buy") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("ord_buy").ToString
        'Me.Session("or_sell") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("ord_sell").ToString
        Me.Session("globalAverage") = Me.GridView1.DataKeys(Me.GridView1.EditIndex).Values("average_globalrate").ToString
        'getOfficialRateTO_MakeHistory()

        e.Cancel = True
        GridView1.EditIndex = -1
        getUnOfficial(sql2)

        Me.Session("ident") = "1"
        Response.Redirect("RateSett.aspx")
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView1.Controls(0), Table)

            ' Adding Cells



            Dim cell As TableCell = New TableHeaderCell()
            cell.ColumnSpan = 3
            cell.HorizontalAlign = HorizontalAlign.Left
            cell.Text = "M LHUILLIER RATES"
            cell.Font.Size = 10
            cell.ForeColor = Drawing.Color.White
            row.Cells.Add(cell)

            Dim cell2 As TableCell = New TableHeaderCell()
            cell2.ColumnSpan = 2
            cell2.HorizontalAlign = HorizontalAlign.Center
            cell2.Text = "GLOBAL RATES"
            cell2.ForeColor = Drawing.Color.White
            row.Cells.Add(cell2)

            Dim c1 As TableCell = New TableHeaderCell()
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = "STANDARD"
            row.Cells.Add(c1)

            Dim c2 As TableCell = New TableHeaderCell()
            c2.ColumnSpan = 2
            c2.HorizontalAlign = HorizontalAlign.Center
            c2.Text = "SPECIAL"
            row.Cells.Add(c2)

            Dim c3 As TableCell = New TableHeaderCell()
            c3.ColumnSpan = 2
            c3.HorizontalAlign = HorizontalAlign.Center
            c3.Text = "EXTRA SPECIAL"
            row.Cells.Add(c3)

            Dim c4 As TableCell = New TableHeaderCell()
            c4.ColumnSpan = 2
            c4.HorizontalAlign = HorizontalAlign.Center
            c4.Text = "ORDINARY"
            row.Cells.Add(c4)

            Dim c5 As TableCell = New TableHeaderCell()
            c5.ColumnSpan = 4
            row.Cells.Add(c5)

            t.Rows.AddAt(0, row)
        End If
    End Sub
    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView2.Controls(0), Table)

            ' Adding Cells


            Dim cell As TableCell = New TableHeaderCell()
            cell.ColumnSpan = 2
            cell.HorizontalAlign = HorizontalAlign.Left
            cell.Text = "M LHUILLIER RATES"
            cell.ForeColor = Drawing.Color.White
            cell.Font.Size = 10
            row.Cells.Add(cell)

            Dim cell2 As TableCell = New TableHeaderCell()
            cell2.ColumnSpan = 2
            cell2.HorizontalAlign = HorizontalAlign.Center
            cell2.Text = "GLOBAL RATES"
            cell2.ForeColor = Drawing.Color.White
            row.Cells.Add(cell2)

            Dim c1 As TableCell = New TableHeaderCell()
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = "STANDARD"
            row.Cells.Add(c1)

            Dim c2 As TableCell = New TableHeaderCell()
            c2.ColumnSpan = 2
            c2.HorizontalAlign = HorizontalAlign.Center
            c2.Text = "SPECIAL"
            row.Cells.Add(c2)

            Dim c3 As TableCell = New TableHeaderCell()
            c3.ColumnSpan = 2
            c3.HorizontalAlign = HorizontalAlign.Center
            c3.Text = "EXTRA SPECIAL"
            row.Cells.Add(c3)

            Dim c4 As TableCell = New TableHeaderCell()
            c4.ColumnSpan = 2
            c4.HorizontalAlign = HorizontalAlign.Center
            c4.Text = "ORDINARY"
            row.Cells.Add(c4)

            Dim c5 As TableCell = New TableHeaderCell()
            c5.ColumnSpan = 4
            row.Cells.Add(c5)

            t.Rows.AddAt(0, row)
        End If
    End Sub
    Public Sub empVal()
        Me.Session("currName") = ""
        Me.Session("globalrate") = ""
        Me.Session("stBuy") = ""
        Me.Session("stSell") = ""
        Me.Session("spBuy") = ""
        Me.Session("spSell") = ""
        Me.Session("exBuy") = ""
        Me.Session("exSell") = ""
        Me.Session("orBuy") = ""
        Me.Session("orSell") = ""

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)
        ls_cmms.ReadINI_CMMS(sPath)
        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If


        If IsPostBack = False Then
            getUnOfficial(sql1)
            '-----Update Global Rate inside the ML rates
            getLastSignite()
            '========================================
            btnSettings.ImageUrl = "~/Images/btnSett1.png"
        End If

        getOfficial(sql2)
    End Sub

    Public Sub updateGlobalRateandAvergeRate(ByVal _val As String, ByVal _ave As String, ByVal _cur As String)
        Try
            log4net.Info("UPDATE_GLOBAL_RATE_AND_AVERGERATE - value:" + _val + ", average:" + _ave + ", currency:" + _cur)
            ls.ConnectDatabase()
            Dim sql As String
            sql = "update mlforexrate.globalforexrates set global_rate='" & _val & "',average_globalrate='" & _ave & "' where currname='" & _cur & "'; "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            '-----insert to cmms
            ls_cmms.ConnectDatabaseCMMS()
            Dim sql_cmms As String
            sql_cmms = "update cmms.globalforexrates set global_rate='" & _val & "',average_globalrate='" & _ave & "' where currname='" & _cur & "'; "
            'sqlExecuter_cmms(sql_cmms)
            addapter = New MySqlDataAdapter(sql_cmms, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            log4net.Info("UPDATE_GLOBAL_RATE_AND_AVERGERATE - SUCCESS!")
        Catch ex As Exception
            log4net.Error("UPDATE_GLOBAL_RATE_AND_AVERGERATE - " + ex.Message)
        End Try
    End Sub
    Public Function getAverageRate(ByVal _cur As String) As String
        Try
            log4net.Info("GETAVERAGERATE - currency:" + _cur)
            Dim sql As String
            ls.ConnectDatabase()
            sql = "select count(currency) from mlforexrate.globalratelogs where date_format(systemcreated, '%Y-%m-%d')=date_format(now(), '%Y-%m-%d') and remarks is null and currency='" & _cur & "';"
            'log.makeLog("ForexSetting.getAverageRate - currency : ", _cur)
            log4net.Info("ForexSetting.getAverageRate - currency : " + _cur)
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            If tb(0).Item(0).ToString >= "3" Then
                ls.ConnectDatabase()
                sql = "select avg(rate) from (select * from mlforexrate.globalratelogs order by systemcreated desc)as system where date_format(systemcreated,'%Y%d%m')=date_format(now(), '%Y%d%m') and currency='" & _cur & "' and remarks is null group by currency"
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
                Return tb(0).Item(0).ToString

                'If tb.Rows.Count = 0 Then
                '    ls.ConnectDatabase()
                '    sql = "select avg(rate) from (select * from mlforexrate.globalratelogs order by systemcreated desc)as system where date_format(systemcreated,'%Y-%m-%d')=date_sub(curdate(), interval 1 day) and currency='" & _cur & "' and remarks is null group by currency"
                '    addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                '    tb = New DataTable
                '    addapter.Fill(tb)
                '    Return tb(0).Item(0).ToString
                'Else
                '    Return tb(0).Item(0).ToString
                'End If

            Else

                ls.ConnectDatabase()
                sql = "select avg(rate) from (select * from mlforexrate.globalratelogs order by systemcreated desc)as system where date_format(systemcreated,'%Y-%m-%d')=date_sub(curdate(), interval 1 day) and currency='" & _cur & "' and remarks is null group by currency"
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                Return tb(0).Item(0).ToString

            End If
            log4net.Info("GETAVERAGERATE - SUCCESS!")
        Catch ex As Exception
            Return 0
            'log.makeLog("ForexSetting.getAverageRate - ERROR : ", ex.Message)
            log4net.Error("GETAVERAGERATE - " + ex.Message)
            Return 0
        End Try
    End Function
    Public Sub getLastSignite()
        Try
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql5, connect.myDal.ConnectionString)
            Dim tbx As New DataTable
            Dim i As Integer
            addapter.Fill(tbx)

            For i = 0 To tbx.Rows.Count - 1
                Dim curr As String = tbx(i).Item(0).ToString
                Dim id As String = tbx(i).Item(4).ToString
                If curr = "USD" Then
                    If id = "1" Then
                        pn_05.Visible = True
                    End If
                    lblUSD.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblUSD.Text, getAverageRate(curr), curr) '===Average Eya kwaon
                    'updateGlobalRateandAvergeRate(lblUSD.Text, lblUSD.Text, curr)
                ElseIf curr = "JPY" Then
                    If id = "1" Then
                        pn_03.Visible = True
                    End If
                    lblJPY.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblJPY.Text, getAverageRate(curr), curr)  '===Average Eya kwaon
                    'updateGlobalRateandAvergeRate(lblJPY.Text, lblJPY.Text, curr)
                ElseIf curr = "EUR" Then
                    If id = "1" Then
                        pn_01.Visible = True
                    End If
                    lblEUR.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblEUR.Text, getAverageRate(curr), curr)
                    'updateGlobalRateandAvergeRate(lblEUR.Text, lblEUR.Text, curr)
                ElseIf curr = "GBP" Then
                    If id = "1" Then
                        pn_02.Visible = True
                    End If
                    lblGBP.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblGBP.Text, getAverageRate(curr), curr)
                    'updateGlobalRateandAvergeRate(lblGBP.Text, lblGBP.Text, curr)
                ElseIf curr = "KRW" Then
                    If id = "1" Then
                        pn_04.Visible = True
                    End If
                    lblKRW.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblKRW.Text, getAverageRate(curr), curr)
                    'updateGlobalRateandAvergeRate(lblKRW.Text, lblKRW.Text, curr)
                ElseIf curr = "SGD" Then
                    If id = "1" Then
                        pn_06.Visible = True
                    End If
                    lblSGD.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblSGD.Text, getAverageRate(curr), curr)
                    'updateGlobalRateandAvergeRate(lblSGD.Text, lblSGD.Text, curr)


                    'new 06-22-17-----------------------------

                ElseIf curr = "ALL" Then
                    lblNewCurr2.Text = curr
                    If id = "1" Then
                        pn2.Visible = True
                    End If
                    lblNewRate2.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblNewRate2.Text, getAverageRate(curr), curr)


                ElseIf curr <> "EUR" Or curr <> "GBP" Or curr <> "JPY" Or curr <> "KRW" Or curr <> "SGD" Or curr <> "USD" Then
                    lblNewCurr1.Text = curr
                    If id = "1" Then
                        pn1.Visible = True
                    End If
                    lblNewRate1.Text = tbx(i).Item(1).ToString
                    updateGlobalRateandAvergeRate(lblNewRate1.Text, getAverageRate(curr), curr)

                    'ElseIf curr = "ALL" Then
                    '    If id = "1" Then
                    '        pn1.Visible = True
                    '    End If
                    '    lblNewRate1.Text = tbx(i).Item(1).ToString
                    '    updateGlobalRateandAvergeRate(lblNewRate1.Text, getAverageRate(curr), curr)
                    '------------------------------------------

                Else
                    getNewForex()
                End If
            Next
        Catch ex As Exception
            lblMsg.Text = ex.Message
            log4net.Error("GETLASTSIGNITE - " + ex.Message)
        End Try
    End Sub
    Public Sub getNewForex()
        Try
            Dim sql As String = "select * from mlforexrate.globalrates limit 6,6"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)

            pn1.Visible = True
            lblNewCurr1.Text = "1-" & tb(0).Item(0).ToString & " ="
            lblNewRate1.Text = tb(0).Item(1).ToString
            Userinfo.newCur1 = tb(0).Item(0).ToString
            Userinfo.newRate1 = tb(0).Item(1).ToString

            If tb.Rows.Count > 1 Then
                pn2.Visible = True
                lblNewCurr2.Text = "1-" & tb(1).Item(0).ToString & " ="
                lblNewRate2.Text = tb(1).Item(1).ToString
                Userinfo.newCur2 = tb(1).Item(0).ToString
                Userinfo.newRate2 = tb(1).Item(1).ToString
            End If

        Catch ex As Exception
            lblMsg.Text = ex.Message
            log4net.Error("GETNEWFOREX - " + ex.Message)
        End Try
    End Sub
    Public Sub getOfficial(ByVal mysql As String)
        Try
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()

            ls.DisconnectDatabase()
        Catch ex As Exception
            lblMsg.Text = ex.Message
            log4net.Error("GETOFFICIAL - " + ex.Message)
        End Try
    End Sub
    Public Sub getUnOfficial(ByVal mysql As String)
        Try
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView2.DataSource = tb
            Me.GridView2.DataBind()
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                Panel3.Visible = False
                Label8.ForeColor = Drawing.Color.Red
                Label8.Text = "There are no Unofficial rate found"
            End If
        Catch ex As Exception
            lblMsg.Text = ex.Message
            log4net.Error("GETUNOFFICIAL - " + ex.Message)
        End Try
    End Sub
    Protected Sub btnLogs_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogs.Click
        Response.Redirect("Forex Log.aspx")
    End Sub
    Protected Sub btnGlobal_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGlobal.Click
        Response.Redirect("Global Rate.aspx")
    End Sub
    Protected Sub btnHistory_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnHistory.Click
        Response.Redirect("Forex History.aspx")
    End Sub
    Protected Sub btnSettings_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSettings.Click
        Response.Redirect("ForexSettings.aspx")
    End Sub
    Protected Sub btnBranchSet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBranchSet.Click
        Response.Redirect("BranchSettings.aspx")
    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        GridView2.EditIndex = e.NewEditIndex
        Me.Session("currName") = Me.GridView2.DataKeys(Me.GridView2.EditIndex).Values("currname").ToString
        Me.Session("globalrate") = Me.GridView2.DataKeys(Me.GridView2.EditIndex).Values("global_rate").ToString
        Me.Session("globalAverage") = Me.GridView2.DataKeys(Me.GridView2.EditIndex).Values("average_globalrate").ToString
        Me.Session("ident") = "0"


        e.Cancel = True
        GridView2.EditIndex = -1

        Panel2.Visible = True
        GridView2.Enabled = False

        Response.Redirect("RateSett.aspx")
    End Sub
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click


        'Dim sql As String

        'sql = "update mlforexrate.globalforexrates set identifier='1' where currname='" & lblCurrname.Text & "'"
        'updateCurForex()
        'getOfficial(sql)
        'getOfficial(sql2)
        'getUnOfficial(sql1)
        'GridView2.Enabled = True
        'Panel2.Visible = False


    End Sub
    Public Sub updateCurForex()
        Try
            Dim sql As String
            ls.ConnectDatabase()
            sql = "update mlforexrate.currencyforex set status='1' where currency = '" & lblCurrname.Text & "'"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
        Catch ex As Exception
            log4net.Error("UPDATECURFOREX - " + ex.Message)
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Panel2.Visible = False
        GridView2.Enabled = True
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.Session("currName") = ""
        Me.Session("globalrate") = ""
        Me.Session("currName") = Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values("currname").ToString
        Me.Session("globalrate") = Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values("global_rate").ToString
        Me.Session("globalAverage") = Me.GridView1.DataKeys(Me.GridView1.SelectedIndex).Values("average_globalrate").ToString
        Response.Redirect("OverridVal.aspx")
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        getR(Label11, getAverageRate("EUR"))
        Me.Session("currName") = "EUR"
    End Sub
    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        getR(Label17, getAverageRate("USD"))
        Me.Session("currName") = "USD"
    End Sub
    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        getR(Label13, getAverageRate("GBP"))
        Me.Session("currName") = "GBP"
    End Sub
    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
        getR(Label19, getAverageRate("SGD"))
        Me.Session("currName") = "SGD"
    End Sub
    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        getR(Label15, getAverageRate("JPY"))
        Me.Session("currName") = "JPY"
    End Sub
    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click
        getR(Label16, getAverageRate("KRW"))
        Me.Session("currName") = "KRW"
    End Sub
    Public Function getglobalRateFOrOverride(ByVal _cur As String) As String
        Try
            log4net.Info("GET_GLOBAL_RATE_FOR_OVERRIDE - currency:" + _cur)
            Dim sql As String = "select rate from (select * from mlforexrate.globalratelogs order by systemcreated DESC) as systemcreated where currency='" & _cur & "' group by currency order by date_format(systemcreated,'%Y/%m/%d - %T');"
            Dim _val As Double

            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            _val = tb(0).Item(0).ToString
            ls.DisconnectDatabase()

            Return _val

        Catch ex As Exception
            log4net.Error("GET_GLOBAL_RATE_FOR_OVERRIDE - " + ex.Message)
            Return 0
        End Try

    End Function
    Public Sub getR(ByVal lbl As Label, ByVal rate As Double)
        Me.Session("_dcm") = rate.ToString("##.#####")

        lblCurrname0.Text = lbl.Text & " " & Me.Session("_dcm") & " ?" '& " To " & Me.Session("_dcm") & "0000" & "?"
        Panel4.Visible = True
    End Sub
    Protected Sub btnOK0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK0.Click


        Try
            Dim sql As String
            Dim _eyangsod As String = 0
            Dim format As String = "HH:mm"
            Dim time As DateTime = ls.getServerTime
            Userinfo.getServerDate = time.ToString(format)


            ls.ConnectDatabase()
            sql = "insert into mlforexrate.globalratelogs (currency, rate, remarks, systemcreated, modifier) values ('" & Me.Session("currName") & "', '" & Me.Session("_dcm") & "','[AUTOMATE]" & Me.Session("_dcm") & "', now(), '" & Me.Session("xxxcheckLoginInfo") & "') "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            '===========================================================================================


            '---------------Global Rates
            _eyangsod = getAverageRate(Me.Session("currName"))
            '======================

            '=========Change rates via Formula
            changeSSE(Me.Session("currName"), Me.Session("_dcm"), "Automate")

            '----------update
            updateMLrateOfficial(_eyangsod)
            '======================

            log4net.Info("BTNOK0_CLICK - SUCCESS!")
        Catch ex As Exception
            log4net.Error("BTNOK0_CLICK - " + ex.Message)
            lblMsg.Text = ex.Message
        Finally
            Response.Redirect("ForexSettings.aspx")

        End Try

    End Sub
    'Select Case Userinfo.getServerDate
    '    Case "00:00" To "13:00"

    '        ls.ConnectDatabase()
    '        sql = "insert into mlforexrate.globalratelogs (currency, rate, remarks, systemcreated, modifier) values ('" &  Me.Session("currName")  & "', '" & Me.Session("_dcm") & "','[AUTOMATE]" & Me.Session("_dcm") & "', now(), '" & Me.Session("xxxcheckLoginInfo") & "') "
    '        addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '        tb = New DataTable
    '        addapter.Fill(tb)
    '        ls.DisconnectDatabase()
    '        '===========================================================================================


    '        '---------------Global Rates
    '        _eyangsod = getAverageRate( Me.Session("currName") )
    '        '======================

    '        '=========Change rates via Formula
    '        changeSSE( Me.Session("currName") , Me.Session("_dcm"), "Automate")

    '        '----------update
    '        updateMLrateOfficial(_eyangsod)
    '        '======================

    '    Case "13:01" To "23:59"
    '        ls.ConnectDatabase()
    '        sql = "Select * from globalratesfornextday where currency='" &  Me.Session("currName")  & "'"
    '        addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '        tb = New DataTable
    '        addapter.Fill(tb)
    '        ls.DisconnectDatabase()
    '        If tb.Rows.Count = 0 Then

    '            ls.ConnectDatabase()
    '            sql = "insert into mlforexrate.globalratesfornextday " _
    '                & "(Currency, Rate, systemcreated, remarks, identifier, datetoupdate, modifier)values ('" &  Me.Session("currName")  & "' " _
    '                & ",'" & Me.Session("_dcm") & "',now(),'Automate','1',date_format(date_add(now(), interval 1 day), '%Y-%m-%d 12:00:00'), '" & Me.Session("xxxcheckLoginInfo") & "')"
    '            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '            tb = New DataTable
    '            addapter.Fill(tb)
    '            ls.DisconnectDatabase()
    '        Else

    '            ls.ConnectDatabase()
    '            sql = "update globalratesfornextday set rate='" & Me.Session("_dcm") & "', systemcreated=now(), remarks='Automate', datetoupdate=date_format(date_add(now(), interval 1 day), '%Y-%m-%d 12:00:00'), modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currency='" &  Me.Session("currName")  & "'; "
    '            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '            tb = New DataTable
    '            addapter.Fill(tb)
    '            ls.DisconnectDatabase()

    '        End If
    '        Dim val As String
    '        ls.ConnectDatabase()
    '        sql = "select date_format(date_add(now(), interval 1 day), '%Y/%m/%d') as dateTomorrow;"
    '        addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '        tb = New DataTable
    '        addapter.Fill(tb)
    '        val = tb(0).Item(0).ToString
    '        ls.DisconnectDatabase()


    '        '==================insert sa globallogs
    '        ls.ConnectDatabase()
    '        sql = "insert into mlforexrate.globalratelogs (currency, rate, remarks, systemcreated, modifier) values ('" &  Me.Session("currName")  & "', '" & Me.Session("_dcm") & "','[AUTOMATE] For the next day ' '" & val & " " & Me.Session("_dcm") & "', now(), '" & Me.Session("xxxcheckLoginInfo") & "') "
    '        addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '        tb = New DataTable
    '        addapter.Fill(tb)
    '        ls.DisconnectDatabase()
    '        '=======================end


    '        '==================insert sa logs
    '        makeLog()
    '        '====================end
    'End Select

    Public Sub changeSSE(ByVal currname As String, ByVal rate As String, ByVal status As String)
        Try
            log4net.Info("CHANGESSE - currname:" + currname + ", rate:" + rate + ", status:" + status)
            Dim st_buy, st_sell As String
            Dim sp_buy, sp_sell As String
            Dim ex_buy, ex_sell As String
            Dim or_buy, or_sell As String
            Dim op1, op2, op3, op4, op5, op6, op7, op8 As String
            Dim f_op1, f_op2, f_op3, f_op4, f_op5, f_op6, f_op7, f_op8 As String

            Dim dr As DataRow
            Dim dt As New DataTable()


            Dim sqlFormula As String = "select currname, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell, for_ord_buy, for_ord_sell, operator1, operator2, operator3, operator4, operator5, operator6, operator7, operator8, f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6, f_operator7, f_operator8 from mlforexrate.fomula where currname='" & currname & "'"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sqlFormula, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                Dim sqlRateOfficial As String = "UPDATE mlforexrate.globalforexrates SET ord_sell='" & rate & "', ord_buy='" & rate & "', stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                                & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now() , status='" & status & "' " _
                                                & "where currname='" & currname & "'"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sqlRateOfficial, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '------------ insert to cmms
                Dim sqlRateOfficial_cmms As String = "UPDATE cmms.globalforexrates SET ord_sell='" & rate & "', ord_buy='" & rate & "', stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                                & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now() , status='" & status & "' " _
                                                & "where currname='" & currname & "'"
                sqlExecuter_cmms(sqlRateOfficial_cmms)

            Else
                '======================Put values
                st_buy = tb(0).Item(1).ToString
                st_sell = tb(0).Item(2).ToString

                sp_buy = tb(0).Item(3).ToString
                sp_sell = tb(0).Item(4).ToString

                ex_buy = tb(0).Item(5).ToString
                ex_sell = tb(0).Item(6).ToString

                or_buy = tb(0).Item(7).ToString
                or_sell = tb(0).Item(8).ToString

                op1 = tb(0).Item(7).ToString
                op2 = tb(0).Item(9).ToString
                op3 = tb(0).Item(10).ToString
                op4 = tb(0).Item(11).ToString
                op5 = tb(0).Item(12).ToString
                op6 = tb(0).Item(13).ToString
                op7 = tb(0).Item(14).ToString
                op8 = tb(0).Item(15).ToString

                f_op1 = tb(0).Item(16).ToString
                f_op2 = tb(0).Item(17).ToString
                f_op3 = tb(0).Item(18).ToString
                f_op4 = tb(0).Item(19).ToString
                f_op5 = tb(0).Item(20).ToString
                f_op6 = tb(0).Item(21).ToString
                f_op7 = tb(0).Item(22).ToString
                f_op8 = tb(0).Item(23).ToString
                '================================


                dt.Columns.Add(New System.Data.DataColumn("Buying", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying  ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling  ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying   ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling   ", GetType([String])))
                dr = dt.NewRow()
                Dim x As Double

                '==========Standard Rate BUY
                If f_op1 = "FIX" Then
                    If op1 = "+" Then
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(st_buy)), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    Else
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(st_buy)), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    End If
                ElseIf f_op1 = "PERCENTAGE" Then
                    If op1 = "+" Then
                        x = Convert.ToDecimal(st_buy / 100) * rate
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    Else
                        x = Convert.ToDecimal(st_buy / 100) * rate
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    End If
                End If
                '=========Standard Rate SELL
                If f_op2 = "FIX" Then
                    If op2 = "+" Then
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(st_sell)), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    Else
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(st_sell)), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    End If
                ElseIf f_op2 = "PERCENTAGE" Then
                    If op2 = "+" Then
                        x = Convert.ToDecimal(st_sell / 100) * rate
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    Else
                        x = Convert.ToDecimal(st_sell / 100) * rate
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    End If
                End If


                '=========Special Rate BUY
                If f_op3 = "FIX" Then
                    If op3 = "+" Then
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(sp_buy)), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    Else
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(sp_buy)), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    End If
                ElseIf f_op3 = "PERCENTAGE" Then
                    If op3 = "+" Then
                        x = Convert.ToDecimal(sp_buy / 100) * rate
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    Else
                        x = Convert.ToDecimal(sp_buy / 100) * rate
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    End If
                End If

                '=========Special Rate SELL
                If f_op4 = "FIX" Then
                    If op4 = "+" Then
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(sp_sell)), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    Else
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(sp_sell)), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    End If
                ElseIf f_op4 = "PERCENTAGE" Then
                    If op4 = "+" Then
                        x = Convert.ToDecimal(sp_sell / 100) * rate
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    Else
                        x = Convert.ToDecimal(sp_sell / 100) * rate
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    End If
                End If


                '=========Extra Rate BUY
                If f_op5 = "FIX" Then
                    If op5 = "+" Then
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(ex_buy)), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    Else
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(ex_buy)), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    End If
                ElseIf f_op5 = "PERCENTAGE" Then
                    If op5 = "+" Then
                        x = Convert.ToDecimal(ex_buy / 100) * rate
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    Else
                        x = Convert.ToDecimal(ex_buy / 100) * rate
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    End If
                End If

                '=========Extra Rate SELL
                If f_op6 = "FIX" Then
                    If op6 = "+" Then
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(ex_sell)), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    Else
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(ex_sell)), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    End If
                ElseIf f_op6 = "PERCENTAGE" Then
                    If op6 = "+" Then
                        x = Convert.ToDecimal(ex_sell / 100) * rate
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    Else
                        x = Convert.ToDecimal(ex_sell / 100) * rate
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    End If
                End If


                '=========Ordinary BUY
                If f_op7 = "FIX" Then
                    If op7 = "+" Then
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(or_buy)), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    Else
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(or_buy)), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    End If
                ElseIf f_op7 = "PERCENTAGE" Then
                    If op7 = "+" Then
                        x = Convert.ToDecimal(ex_buy / 100) * rate
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    Else
                        x = Convert.ToDecimal(ex_buy / 100) * rate
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    End If
                End If

                '=========Ordinary SELL
                If f_op8 = "FIX" Then
                    If op8 = "+" Then
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(or_sell)), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    Else
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(or_sell)), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    End If
                ElseIf f_op8 = "PERCENTAGE" Then
                    If op8 = "+" Then
                        x = Convert.ToDecimal(or_sell / 100) * rate
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    Else
                        x = Convert.ToDecimal(or_sell / 100) * rate
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    End If
                End If

                '========================================
                Dim sqlRateOfficial As String = "UPDATE mlforexrate.globalforexrates SET ord_buy='" & dr(7).ToString & "', ord_sell='" & dr(6).ToString & "', stan_buy='" & dr(0).ToString & "', stan_sell='" & dr(1).ToString & "', spe_buy='" & dr(2).ToString & "' " _
                                                & ",spe_sell='" & dr(3).ToString & "', extra_buy='" & dr(4).ToString & "', extra_sell='" & dr(5).ToString & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now(), status='" & status & "' " _
                                                & "where currname='" & currname & "'"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sqlRateOfficial, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '---------------- insert to cmms
                Dim sqlRateOfficial_cmms As String = "UPDATE cmms.globalforexrates SET ord_buy='" & dr(7).ToString & "', ord_sell='" & dr(6).ToString & "', stan_buy='" & dr(0).ToString & "', stan_sell='" & dr(1).ToString & "', spe_buy='" & dr(2).ToString & "' " _
                                               & ",spe_sell='" & dr(3).ToString & "', extra_buy='" & dr(4).ToString & "', extra_sell='" & dr(5).ToString & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now(), status='" & status & "' " _
                                               & "where currname='" & currname & "'"
                sqlExecuter_cmms(sqlRateOfficial_cmms)
                '===================make history
                'getOfficialRateTO_MakeHistory()

                '===================make log
                makeLog()
            End If
            log4net.Info("CHANGESSE - SUCCESS!")
        Catch ex As Exception
            lblMsg.Text = ex.Message
            'log.makeLog("ForexSetting.changeSSE - ", ex.Message)
            log4net.Error("CHANGESSE - " + ex.Message)
        End Try
    End Sub
    Public Sub makeLog()
        Try

            Dim sql As String
            Dim rate As String = Me.Session("_dcm")
            Dim status As String = "Automate"

            Dim st_buy, st_sell As String
            Dim sp_buy, sp_sell As String
            Dim ex_buy, ex_sell As String
            Dim or_buy, or_sell As String
            Dim op1, op2, op3, op4, op5, op6, op7, op8 As String
            Dim f_op1, f_op2, f_op3, f_op4, f_op5, f_op6, f_op7, f_op8 As String

            Dim dr As DataRow
            Dim dt As New DataTable()


            Dim sqlFormula As String = "select currname, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell, for_ord_buy, for_ord_sell, operator1, operator2, operator3, operator4, operator5, operator6, operator7, operator8, f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6, f_operator7, f_operator8 from mlforexrate.fomula where currname='" & Me.Session("currName") & "'"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sqlFormula, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                Dim sqlRateOfficial As String = "UPDATE mlforexrate.globalforexrates SET ord_buy='" & rate & "', ord_sell='" & rate & "', stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                                & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "',modified=now(), status='" & status & "' " _
                                                & "where currname='" & Me.Session("currName") & "'"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sqlRateOfficial, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '--------------insert to cmms
                Dim sqlRateOfficial_cmms As String = "UPDATE cmms.globalforexrates SET ord_buy='" & rate & "', ord_sell='" & rate & "', stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                               & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "',modified=now(), status='" & status & "' " _
                                               & "where currname='" & Me.Session("currName") & "'"
                sqlExecuter_cmms(sqlRateOfficial_cmms)

            Else
                '======================Put values
                st_buy = tb(0).Item(1).ToString
                st_sell = tb(0).Item(2).ToString

                sp_buy = tb(0).Item(3).ToString
                sp_sell = tb(0).Item(4).ToString

                ex_buy = tb(0).Item(5).ToString
                ex_sell = tb(0).Item(6).ToString

                or_buy = tb(0).Item(7).ToString
                or_sell = tb(0).Item(8).ToString

                op1 = tb(0).Item(9).ToString
                op2 = tb(0).Item(10).ToString
                op3 = tb(0).Item(11).ToString
                op4 = tb(0).Item(12).ToString
                op5 = tb(0).Item(13).ToString
                op6 = tb(0).Item(14).ToString
                op7 = tb(0).Item(15).ToString
                op8 = tb(0).Item(16).ToString

                f_op1 = tb(0).Item(17).ToString
                f_op2 = tb(0).Item(18).ToString
                f_op3 = tb(0).Item(19).ToString
                f_op4 = tb(0).Item(20).ToString
                f_op5 = tb(0).Item(21).ToString
                f_op6 = tb(0).Item(22).ToString
                f_op7 = tb(0).Item(23).ToString
                f_op8 = tb(0).Item(24).ToString
                '================================


                dt.Columns.Add(New System.Data.DataColumn("Buying", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying  ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling  ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying   ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling   ", GetType([String])))
                dr = dt.NewRow()
                Dim x As Double


                '==========Standard Rate BUY
                If f_op1 = "FIX" Then
                    If op1 = "+" Then
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(st_buy)), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    Else
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(st_buy)), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    End If
                ElseIf f_op1 = "PERCENTAGE" Then
                    If op1 = "+" Then
                        x = Convert.ToDecimal(st_buy / 100) * rate
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    Else
                        x = Convert.ToDecimal(st_buy / 100) * rate
                        dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("st_buy") = dr(0).ToString
                    End If
                End If
                '=========Standard Rate SELL
                If f_op2 = "FIX" Then
                    If op2 = "+" Then
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(st_sell)), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    Else
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(st_sell)), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    End If
                ElseIf f_op2 = "PERCENTAGE" Then
                    If op2 = "+" Then
                        x = Convert.ToDecimal(st_sell / 100) * rate
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    Else
                        x = Convert.ToDecimal(st_sell / 100) * rate
                        dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("st_sell") = dr(1).ToString
                    End If
                End If



                '=========Special Rate BUY
                If f_op3 = "FIX" Then
                    If op3 = "+" Then
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(sp_buy)), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    Else
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(sp_buy)), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    End If
                ElseIf f_op3 = "PERCENTAGE" Then
                    If op3 = "+" Then
                        x = Convert.ToDecimal(sp_buy / 100) * rate
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    Else
                        x = Convert.ToDecimal(sp_buy / 100) * rate
                        dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("sp_buy") = dr(2).ToString
                    End If
                End If
                '=========Special Rate SELL
                If f_op4 = "FIX" Then
                    If op4 = "+" Then
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(sp_sell)), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    Else
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(sp_sell)), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    End If
                ElseIf f_op4 = "PERCENTAGE" Then
                    If op4 = "+" Then
                        x = Convert.ToDecimal(sp_sell / 100) * rate
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    Else
                        x = Convert.ToDecimal(sp_sell / 100) * rate
                        dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("sp_sell") = dr(3).ToString
                    End If
                End If



                '=========Extra Rate BUY
                If f_op5 = "FIX" Then
                    If op5 = "+" Then
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(ex_buy)), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    Else
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(ex_buy)), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    End If
                ElseIf f_op5 = "PERCENTAGE" Then
                    If op5 = "+" Then
                        x = Convert.ToDecimal(ex_buy / 100) * rate
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    Else
                        x = Convert.ToDecimal(ex_buy / 100) * rate
                        dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("ex_buy") = dr(4).ToString
                    End If
                End If
                '=========Extra Rate SELL
                If f_op6 = "FIX" Then
                    If op6 = "+" Then
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(ex_sell)), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    Else
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(ex_sell)), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    End If
                ElseIf f_op6 = "PERCENTAGE" Then
                    If op6 = "+" Then
                        x = Convert.ToDecimal(ex_sell / 100) * rate
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    Else
                        x = Convert.ToDecimal(ex_sell / 100) * rate
                        dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("ex_sell") = dr(5).ToString
                    End If
                End If


                '=========Ordinary BUY
                If f_op7 = "FIX" Then
                    If op7 = "+" Then
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(or_buy)), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    Else
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(or_buy)), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    End If
                ElseIf f_op7 = "PERCENTAGE" Then
                    If op7 = "+" Then
                        x = Convert.ToDecimal(or_buy / 100) * rate
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    Else
                        x = Convert.ToDecimal(or_buy / 100) * rate
                        dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("or_buy") = dr(6).ToString
                    End If
                End If
                '=========Ordinary SELL
                If f_op8 = "FIX" Then
                    If op8 = "+" Then
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + Convert.ToDecimal(or_sell)), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    Else
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - Convert.ToDecimal(or_sell)), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    End If
                ElseIf f_op8 = "PERCENTAGE" Then
                    If op8 = "+" Then
                        x = Convert.ToDecimal(or_sell / 100) * rate
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) + x), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    Else
                        x = Convert.ToDecimal(or_sell / 100) * rate
                        dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(rate) - x), 2)
                        Me.Session("or_sell") = dr(7).ToString
                    End If
                End If
            End If


            ls.ConnectDatabase()
            sql = "Insert into mlforexrate.globallogs (currname, ord_buy, ord_sell, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate) Values ('" & Me.Session("currName") & "','" & Me.Session("or_buy") & "','" & Me.Session("or_sell") & "','" & Me.Session("st_buy") & "', " & _
                    "'" & Me.Session("st_sell") & "','" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "','" & Me.Session("xxxcheckLoginInfo") & "','" & Me.Session("_dcm") & "'); "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            'Else
            '    ls.ConnectDatabase()
            '    sql = "update mlforexrate.globallogs set fetchrate='" & Me.Session("_ovRate") & "', stan_buy='" & Me.Session("st_buy") & "',stan_sell='" & Me.Session("st_sell") & "',spe_sell='" & Me.Session("sp_sell") & "',extra_buy='" & Me.Session("ex_buy") & "',extra_sell='" & Me.Session("ex_sell") & "',modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currname='" &  Me.Session("currName")  & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d');"
            '    addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            '    tb = New DataTable
            '    addapter.Fill(tb)
            '    ls.DisconnectDatabase()
            'End If
            log4net.Info("MAKELOG - SUCCESS!")
        Catch ex As Exception
            'log.makeLog("ForexSetting.makelog - ERROR : ", ex.Message)
            log4net.Error("MAKELOG - ERROR : " + ex.Message)

        End Try
    End Sub
    Public Sub getOfficialRateTO_MakeHistory()
        Try
            Dim sql As String

            '----check kong naa na cya history
            ls.ConnectDatabase()
            sql = "select * from mlforexrate.globalratehistory where date_format(systemcreated, '%Y/%m/%d')= date_format(now(), '%Y/%m/%d') and currname='" & Me.Session("currName") & "'; "
            'log.makeLog("ForexSetting.getOfficialRateTO_MakeHistory - ", Me.Session("currName"))
            log4net.Info("ForexSetting.getOfficialRateTO_MakeHistory - " + Me.Session("currName"))
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                sql = "insert into mlforexrate.globalratehistory (currname, ord_buy, ord_sell, stan_buy, stan_sell, spe_buy, spe_sell, " _
                         & "extra_buy, extra_sell, systemcreated, modified)values ('" & Me.Session("currName") & "','" & Me.Session("or_buy") & "','" & Me.Session("or_sell") & "','" & Me.Session("st_buy") & _
                         "', '" & Me.Session("st_sell") & "', '" & Me.Session("sp_buy") & "', '" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "', '" & Me.Session("ex_sell") & _
                         "', now(), '" & Me.Session("xxxcheckLoginInfo") & "')"

                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
            Else
                sql = "update mlforexrate.globalratehistory set ord_buy='" & Me.Session("or_buy") & "', ord_sell='" & Me.Session("or_sell") & "', stan_buy='" & Me.Session("st_buy") & "', stan_sell='" & Me.Session("st_sell") & "', spe_buy='" & Me.Session("sp_buy") & "', spe_sell='" & Me.Session("sp_sell") & "', extra_buy='" & Me.Session("ex_buy") & "', extra_sell='" & Me.Session("ex_sell") & "' where currname ='" & Me.Session("currName") & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d')"
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
            End If
            log4net.Info("GETOFFICIALRATETO_MAKEHISTORY - SUCCESS!")
        Catch ex As Exception
            'log.makeLog("ForexSetting.getOfficialRateTO_MakeHistory - ERROR : ", ex.Message)
            log4net.Error("GETOFFICIALRATETO_MAKEHISTORY - " + ex.Message)
        End Try
    End Sub

    Public Sub updateMLrateOfficial(ByVal _eyangsod As String)
        Try
            log4net.Info("UPDATEMLRATEOFFICIAL - val:" + _eyangsod)
            Dim sql As String
            Dim val As String
            Dim sql4 As String = "select rate from (select * from mlforexrate.globalratelogs order by systemcreated DESC) as systemcreated where currency='" & Me.Session("currName") & "' group by currency order by date_format(systemcreated,'%Y/%m/%d - %T');"
            'log.makeLog("ForexSetting.updateMLrateOfficial - currname : ", Me.Session("currName"))
            log4net.Info("ForexSetting.updateMLrateOfficial - currname : " + Me.Session("currName"))
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql4, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            val = tb(0).Item(0).ToString
            ls.DisconnectDatabase()


            '-------------Update GlobalForex
            ls.ConnectDatabase()
            sql = "update mlforexrate.globalforexrates set global_rate='" & Me.Session("_dcm") & "',average_globalrate='" & _eyangsod & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now(), status='Automate' where currname='" & Me.Session("currName") & "'; "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            '---- update cmms
            Dim sql_cmms As String = "update cmms.globalforexrates set global_rate='" & Me.Session("_dcm") & "',average_globalrate='" & _eyangsod & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now(), status='Automate' where currname='" & Me.Session("currName") & "'; "
            sqlExecuter_cmms(sql_cmms)

            '-------------Update Global Rates
            ls.ConnectDatabase()
            sql = "update mlforexrate.globalrates set rate='" & Me.Session("_dcm") & "', systemcreated=now(), Remarks='Automate' where currency ='" & Me.Session("currName") & "'; "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            log4net.Info("UPDATEMLRATEOFFICIAL -  SUCCESS!")
        Catch ex As Exception
            lblMsg.Text = ex.Message
            'log.makeLog("ForexSetting.updateMLrateOfficial - ERROR : ", ex.Message)
            log4net.Error("UPDATEMLRATEOFFICIAL - " + ex.Message)
        End Try
    End Sub
    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel0.Click
        Panel4.Visible = False
    End Sub
    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Me.Session("currName") = "EUR"
        Me.Session("_ovRate") = lblEUR.Text
        Response.Redirect("OverGlobal.aspx")
    End Sub
    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        Me.Session("currName") = "USD"
        Me.Session("_ovRate") = lblUSD.Text
        Response.Redirect("OverGlobal.aspx")
    End Sub
    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Me.Session("currName") = "GBP"
        Me.Session("_ovRate") = lblGBP.Text
        Response.Redirect("OverGlobal.aspx")
    End Sub
    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        Me.Session("currName") = "SGD"
        Me.Session("_ovRate") = lblSGD.Text
        Response.Redirect("OverGlobal.aspx")
    End Sub
    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Me.Session("currName") = "JPY"
        Me.Session("_ovRate") = lblJPY.Text
        Response.Redirect("OverGlobal.aspx")
    End Sub
    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        Me.Session("currName") = "KRW"
        Me.Session("_ovRate") = lblKRW.Text
        Response.Redirect("OverGlobal.aspx")
    End Sub
    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        Try

            Me.Session("currName") = lblNewCurr1.Text
            Me.Session("_ovRate") = lblNewRate1.Text
            Response.Redirect("OverGlobal.aspx")

        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
    End Sub
    Protected Sub LinkButton14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton14.Click
        getR(lblNewCurr1, getAverageRate(lblNewCurr1.Text))
        Me.Session("currName") = lblNewCurr1.Text
    End Sub
    Protected Sub LinkButton15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton15.Click
        Try

            Me.Session("currName") = lblNewCurr2.Text
            Me.Session("_ovRate") = lblNewRate2.Text
            Response.Redirect("OverGlobal.aspx")

        Catch ex As Exception
            lblMsg.Text = ex.Message
        End Try
    End Sub
    Protected Sub LinkButton16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton16.Click
        getR(lblNewCurr2, getAverageRate(lblNewCurr2.Text))
        Me.Session("currName") = lblNewCurr2.Text
    End Sub

    Public Sub sqlExecuter_cmms(ByVal mysql As String)
        Try
            log4net.Info("SQLEXECUTER_CMMS - mysql:" + mysql)
            ls_cmms.ReadINI_CMMS(sPath)
            ls_cmms.ConnectDatabaseCMMS()
            Dim adapter As MySqlDataAdapter
            Dim tb As DataTable
            adapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            adapter.Fill(tb)
            ls_cmms.DisconnectDatabase()

        Catch ex As Exception
            log4net.Error("SQLEXECUTER_CMMS - " + ex.Message)
        End Try
    End Sub


End Class
