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

Partial Class Pages_OverridVal
    Inherits System.Web.UI.Page
    Public addapter As New MySqlDataAdapter
    Public tb As DataTable
    Dim ls As New connect
    Dim ls_cmms As New connect
    Dim sql As String
    Dim sPath As String
    'Dim log As logsss
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("OverridVal")


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)

        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If

        If IsPostBack = False Then
            Official(Me.Session("currName"))
            edited(Me.Session("currName"))

        End If
    End Sub

    Public Sub Official(ByVal cur As String)
        Try
            'log = log4net.LogManager.GetLogger("Log4NetAssembly1")
            ls.ConnectDatabase()
            sql = "select currname, stan_sell, stan_buy, spe_sell, spe_buy, extra_sell, extra_buy, modified, modifier, status from mlforexrate.globalforexrates where currname='" & cur & "'"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()

            ls.DisconnectDatabase()
            log4net.Info("OFFICIAL - SUCCESS!")
        Catch ex As Exception
            lblmsg.Text = ex.Message
            'log.Info("OverrideVal.Official - ERROR: " + ex.Message)
            log4net.Error("OFFICIAL - ERROR: " + ex.Message)
        End Try
    End Sub
    Public Sub edited(ByVal cur As String)
        Try
            log4net.Info("EDITED - cur:" + cur)
            ls.ConnectDatabase()
            sql = "select currency, stan_sell, stan_buy, spe_sell, spe_buy, extra_sell, extra_buy, modified, systemmodified, status, modifier from mlforexrate.forexoverride where currency='" & cur & "'"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView2.DataSource = tb
            Me.GridView2.DataBind()

            If tb.Rows.Count = 0 Then
                lblmsg1.Text = "No Data Found. Edit value first so that you can override."
                Button1.Enabled = False
            Else
                lblmsg1.Visible = False
                LinkButton1.Visible = False
            End If

            ls.DisconnectDatabase()
            log4net.Info("EDITED - SUCCESS!")
        Catch ex As Exception
            lblmsg.Text = ex.Message
            'log.Info("OverrideVal.edited - ERROR: " + ex.Message)
            log4net.Error("EDITED - " + ex.Message)
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
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("ForexSettings.aspx")
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("RateSett.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'log = log4net.LogManager.GetLogger("Log4NetAssembly1")
            Dim indx As Integer = GridView2.EditIndex + 1
            Dim cur, stbuy, stsell, spbuy, spsell, exbuy, exsell, modifier, status As String

            cur = Me.GridView2.DataKeys(indx).Values("currency").ToString
            stbuy = Me.GridView2.DataKeys(indx).Values("stan_buy").ToString
            stsell = Me.GridView2.DataKeys(indx).Values("stan_sell").ToString
            spbuy = Me.GridView2.DataKeys(indx).Values("spe_buy").ToString
            spsell = Me.GridView2.DataKeys(indx).Values("spe_sell").ToString
            exbuy = Me.GridView2.DataKeys(indx).Values("extra_buy").ToString
            exsell = Me.GridView2.DataKeys(indx).Values("extra_sell").ToString
            modifier = Me.Session("xxxcheckLoginInfo")
            status = "Manual"

            '--------------Insert
            ls.ConnectDatabase()
            sql = "update mlforexrate.globalforexrates set currname='" & cur & "', global_rate='" & Me.Session("globalrate") & "', average_globalrate='" & Me.Session("globalAverage") & "', stan_buy='" & stbuy & "', stan_sell='" & stsell & "', spe_buy= '" & spbuy & "', spe_sell='" & spsell & "', extra_buy='" & exbuy & "', extra_sell='" & exsell & "', modified=now(), modifier='" & modifier & "', status='" & status & "' where currname='" & cur & "'"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            '--------------Insert to CMMS 091613
            ls_cmms.ReadINI_CMMS(sPath)
            ls_cmms.ConnectDatabaseCMMS()
            sql = "update cmms.globalforexrates set currname='" & cur & "', global_rate='" & Me.Session("globalrate") & "', average_globalrate='" & Me.Session("globalAverage") & "', stan_buy='" & stbuy & "', stan_sell='" & stsell & "', spe_buy= '" & spbuy & "', spe_sell='" & spsell & "', extra_buy='" & exbuy & "', extra_sell='" & exsell & "', modified=now(), modifier='" & modifier & "', status='" & status & "' where currname='" & cur & "'"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls_cmms.DisconnectDatabase()

            '--------------Update TO History
            'updateToHistory(cur, stbuy, stsell, spbuy, spsell, exbuy, exsell, modifier, status)

            '------Log Create
            getLogs(cur, stbuy, stsell, spbuy, spsell, exbuy, exsell, status)


            lblmsg1.Visible = True
            lblmsg1.Text = "Successfully Overriden!"
            Button2.Text = "Back"
            Button1.Enabled = False
            log4net.Info("BUTTON_CLICK1 - SUCCESS!")
        Catch ex As Exception
            lblmsg.Text = ex.Message
            log4net.Error("BUTTON_CLICK1 - " + ex.Message)
        End Try
    End Sub
    Public Sub getLogs(ByVal cur As String, ByVal stbuy As String, ByVal stsell As String, ByVal spBuy As String, ByVal spsell As String, ByVal exbuy As String, ByVal exSell As String, ByVal status As String)
        Try
            log4net.Info("GETLOGS - cur:" + cur + ", stbuy:" + stbuy + ", stsell:" + stsell + ", spBuy:" + spBuy + ", spsell:" + spsell + ", exbuy:" + exbuy + ", exSell:" + exSell + ", status:" + status)
            'log = log4net.LogManager.GetLogger("Log4NetAssembly1")
            'Dim sql As String
            'sql = "select * from mlforexrate.globallogs where currname='" & cur & "' and date_format(systemcreated, '%Y-%m-%d')= date_format(now(), '%Y-%m-%d'); "
            'ls.ConnectDatabase()
            'addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            'tb = New DataTable
            'addapter.Fill(tb)
            'ls.DisconnectDatabase()


            'If tb.Rows.Count = 0 Then
            sql = "Insert into mlforexrate.globallogs (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate)" _
                  & "Values ('" & cur & "','" & stbuy & "', '" & stsell & "','" & spBuy & "','" & spsell & "','" & exbuy & "','" & exSell & "','" & Me.Session("xxxcheckLoginInfo") & "','" & Me.Session("globalrate") & "'); "
            executer(sql)

            'Else
            'sql = "update mlforexrate.globallogs set fetchrate='" & Me.Session("globalrate") & "',stan_sell='" & stsell & "',stan_buy='" & stbuy & "'," _
            '       & "spe_sell='" & spsell & "',spe_buy='" & spBuy & "',extra_sell='" & exSell & "', extra_sell='" & exSell & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "'" _
            '        & " where currname='" & cur & "' and date_format(systemcreated, '%Y-%m-%d')= date_format(now(), '%Y-%m-%d'); "
            'executer(sql)
            'End If
            log4net.Info("GETLOGS - SUCCESS!")
        Catch ex As Exception
            lblmsg.Text = ex.Message
            'log.Info("OverridVal.getLogs - ERROR:" + ex.Message)
            log4net.Error("GETLOGS - " + ex.Message)
        End Try
    End Sub
    Public Sub executer(ByVal sql As String)
        Try
            'log = log4net.LogManager.GetLogger("Log4NetAssembly1")
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

        Catch ex As Exception
            lblmsg.Text = ex.Message
            'log.Info("OverridVal.executer - ERROR:" + ex.Message)
            log4net.Error("EXECUTER - " + ex.Message)
        End Try
    End Sub
    Public Sub updateToHistory(ByVal cur As String, ByVal stbuy As String, ByVal stsell As String, ByVal spbuy As String, ByVal spsell As String, ByVal exbuy As String, ByVal exsell As String, ByVal modifier As String, ByVal status As String)
        Try
            log4net.Info("UPDATEHISTORY - cur:" + cur + ", stbuy:" + stbuy + ", stsell:" + stsell + ", spBuy:" + spbuy + ", spsell:" + spsell + ", exbuy:" + exbuy + ", exSell:" + exsell + ", modifier:" + modifier + ", status:" + status)

            'log = log4net.LogManager.GetLogger("Log4NetAssembly1")
            Dim svTime As String

            '--------Get Server Time
            sql = "select date_format(now(), '%Y-%m-%d') as serverdate"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            svTime = tb(0).Item(0).ToString
            ls.DisconnectDatabase()


            '--------update history
            sql = "select * from mlforexrate.globalratehistory where date_format(systemcreated, '%Y/%m/%d')=date_format(now(),'%Y/%m/%d') and currname='" & cur & "';"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count > 0 Then
                sql = "update mlforexrate.globalratehistory set currname='" & cur & "',stan_buy='" & stbuy & "',stan_sell='" & stsell & "',spe_buy='" & spbuy & "',spe_sell='" & spsell & "',extra_buy='" & exbuy & "',extra_sell='" & exsell & "',systemcreated=now(),modified='" & modifier & "' where date_format(systemcreated, '%Y-%m-%d')='" & svTime & "' and currname='" & cur & "'; "
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
            Else
                sql = "insert into mlforexrate.globalratehistory (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, systemcreated, modified)" & _
                      "values ('" & cur & "','" & stbuy & "','" & stsell & "','" & spbuy & "','" & spsell & "','" & exbuy & "','" & exsell & "', now(),'" & Me.Session("xxxcheckLoginInfo") & "');"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
            End If
            log4net.Info("UPDATETOHISTORY - SUCCESS!")

        Catch ex As Exception
            lblmsg.Text = ex.Message
            'log.Info("OverrideVal.updateToHistory - ERROR: " + ex.Message)
            log4net.Error("UPDATETOHISTORY - " + ex.Message)
        End Try

    End Sub

    Protected Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView2.Controls(0), Table)

            ' Adding Cells


            Dim cell As TableCell = New TableHeaderCell()
            cell.ColumnSpan = 1
            row.Cells.Add(cell)

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
            c4.ColumnSpan = 4
            row.Cells.Add(c4)

            t.Rows.AddAt(0, row)
        End If
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView1.Controls(0), Table)

            ' Adding Cells


            Dim cell As TableCell = New TableHeaderCell()
            cell.ColumnSpan = 1
            row.Cells.Add(cell)

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
            c4.ColumnSpan = 4
            row.Cells.Add(c4)

            t.Rows.AddAt(0, row)
        End If
    End Sub

    Protected Sub btnBranchSet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBranchSet.Click
        Response.Redirect("BranchSettings.aspx")
    End Sub
End Class
