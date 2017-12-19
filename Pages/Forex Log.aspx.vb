Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Userinfo
Imports log4net
Imports log4net.Config



Partial Class Pages_Forex_Log
    Inherits System.Web.UI.Page
    Public addapter As MySqlDataAdapter
    Public tb As DataTable
    Public Shared row As Integer

    'Dim sql As String = "select currname, fetchrate, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, date_format(systemcreated,'%Y/%m/%d - %T %p') as logCreated from mlforexrate.globallogs order by logcreated desc"
    Dim sql As String = "select currname, fetchrate, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, date_format(systemcreated,'%Y/%m/%d - %T %p') as logCreated from mlforexrate.globallogs where date_format(systemcreated, '%m%Y')=date_format(now(), '%m%Y') order by logcreated desc;"
    Dim sPath As String
    Dim con As New GetList
    Dim ls As New connect
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("Forex Logs")



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sPath = Server.MapPath("..\Bin\kpForex.ini")

        ls.ReadINI(sPath)
        ls.ConnectDatabase()

        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If


        If IsPostBack = False Then
            getLogs(sql)
            btnLogs.ImageUrl = "~/Images/btnLogs1.png"

        End If

    End Sub

    Public Sub getLogs(ByVal mysql As String)
        Try
            log4net.Info("GETLOGS - mysql:" + mysql)
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()
            If Me.GridView1.Rows.Count = 0 Then
                lblmsg.Text = "No data was found in Forex History."
                log4net.Info("ForexLog.getLogs - " + lblmsg.Text)
            Else
                lblmsg.Text = ""
                lblMsg0.Text = ""
            End If
            ls.DisconnectDatabase()
            log4net.Info("GETLOGS - SUCCESS!")
        Catch ex As Exception
            lblMsg0.Text = ex.Message
            log4net.Error("GETLOGS - " + ex.Message)
        End Try
    End Sub

    Public Sub getdata(ByVal mysql As String)
        Try
            'Show to Gridview
            log4net.Info("GETDATA - mysql: " + mysql)
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()

            If Me.GridView1.Rows.Count = 0 Then
                lblmsg.Text = "No data was found in Forex Rate Logs."
                lblMsg0.Text = ""
            Else
                lblmsg.Text = ""
                lblMsg0.Text = ""
            End If
            ls.DisconnectDatabase()
            log4net.Info("GETDATA - SUCCESS!")
        Catch ex As Exception
            log4net.Error("GETDATA - " + ex.Message)
            lblMsg0.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If txtSearch.Text = "" Then
                lblMsg0.Text = "Year must have a value"

                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()
                lblmsg.Text = ""
                Exit Sub
            End If
            If dropmonth.Text = Nothing Or dropmonth.Text = "" Then
                lblMsg0.Text = "Month must have a value"

                Me.GridView1.DataSource = Nothing
                Me.GridView1.DataBind()
                lblmsg.Text = ""
                Exit Sub
            End If
            Dim month As String = getDateNum(dropmonth.Text)
            sql = "select currname, fetchrate, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, date_format(systemcreated,'%Y/%m/%d - %T %p') as logCreated from mlforexrate.globallogs where date_format(systemcreated, '%Y') = '" & txtSearch.Text & "' and date_format(systemcreated, '%m') = '" & month & "' order by logCreated desc"
            Dim logs As String = ("" + txtSearch.Text + ", systemcreated: " + month)
            log4net.Info("ForexHistory.btnSearch_Click - INFO :" + logs)
            getdata(sql)
            txtSearch.Focus()

        Catch ex As Exception
            log4net.Error("BTNSEARCH_CLICK - " + ex.Message)
            lblMsg0.Text = ex.Message
        End Try
    End Sub
    Public Function getDateNum(ByVal month As String) As String
        Select Case month
            Case Is = "January"
                Return "01"
            Case Is = "February"
                Return "02"
            Case Is = "March"
                Return "03"
            Case Is = "April"
                Return "04"
            Case Is = "May"
                Return "05"
            Case Is = "June"
                Return "06"
            Case Is = "July"
                Return "07"
            Case Is = "August"
                Return "08"
            Case Is = "September"
                Return "09"
            Case Is = "October"
                Return "10"
            Case Is = "November"
                Return "11"
            Case Is = "December"
                Return "12"
        End Select
        Return month
    End Function


    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView1.Controls(0), Table)

            ' Adding Cells


            Dim cell As TableCell = New TableHeaderCell()
            cell.ColumnSpan = 3
            row.Cells.Add(cell)


            Dim c1 As TableCell = New TableHeaderCell()
            c1.ColumnSpan = 3
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = "BUYING"
            row.Cells.Add(c1)

            Dim c2 As TableCell = New TableHeaderCell()
            c2.ColumnSpan = 3
            c2.HorizontalAlign = HorizontalAlign.Center
            c2.Text = "SELLING"
            row.Cells.Add(c2)

            Dim c3 As TableCell = New TableHeaderCell()
            c3.ColumnSpan = 1
            c3.HorizontalAlign = HorizontalAlign.Center
            row.Cells.Add(c3)

            t.Rows.AddAt(0, row)
        End If
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

    Protected Sub btnBranchSet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBranchSet.Click
        Response.Redirect("BranchSettings.aspx")
    End Sub
End Class
