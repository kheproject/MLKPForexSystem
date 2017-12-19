Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Userinfo
Imports log4net
Imports log4net.Config

Partial Class Pages_Forex_History_fsd
    Inherits System.Web.UI.Page
    Public addapter As MySqlDataAdapter
    Public tb As DataTable
    Dim sql As String = "SELECT currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell,date_format(systemcreated,'%Y/%m/%d - %T %p') as systemmodified, modified FROM mlforexrate.globalratehistory where date_format(systemcreated, '%m%Y')=date_format(now(), '%m%Y') and currname='USD' order by systemcreated desc;"
    Dim sql1 As String = "SELECT CONCAT(CURRENCY, ' - ',DESCRIPTION) AS CURRENCY FROM mlforexrate.currencyforex where status=1;"
    Dim con As New GetList
    Dim ls As New connect
    Dim sPath As String
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("Forex History_FSD")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If

        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)
        ls.ConnectDatabase()

        If IsPostBack = False Then
            getHistory(sql)
            getCurrency(sql1)
            btnHistory.ImageUrl = "~/Images/btnHist1.png"
        End If

        If Userinfo.role = "KP-MISHELPDESK" Then
            btnUtil.Visible = True
        Else
            btnUtil.Visible = False
            btnHistory.Visible = False
        End If
    End Sub
    Public Sub getCurrency(ByVal mysql As String)
        Try
            log4net.Info("GETCURRENCY - mysql:" + mysql)
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable()
            addapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To tb.Rows.Count - 1
                    drpcurr.Items.Add(tb(i).Item(0).ToString)
                Next
            End If

        Catch ex As Exception
            log4net.Error("GETCURRENCY - " + ex.Message)
        End Try
    End Sub

    Public Sub getHistory(ByVal mysql As String)
        Try
            log4net.Info("GETHISTORY - mysql:" + mysql)
            'Show to Gridview
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()
            If Me.GridView1.Rows.Count = 0 Then
                lblmsg1.Text = "No data was found in Forex History."
            Else
                lblmsg1.Text = ""
                lblMsg0.Text = ""
            End If
            ls.DisconnectDatabase()

        Catch ex As Exception
            log4net.Info("GETHISTORY - " + ex.Message)
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim month As String = getDateNum(drpMonth.Text)
            Dim curr As String = getCurrName(drpcurr.Text)

            If Not drpMonth.Text <> "" And Not txtSearch.Text <> "" Then
                sql = "SELECT currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, date_format(systemcreated,'%Y/%m/%d - %T %p') as systemmodified, modified FROM mlforexrate.globalratehistory where currname='" & curr & "' order by systemcreated desc"

                getHistory(sql)
                lblMsg0.Text = ""
                txtSearch.Focus()
                Exit Sub
            Else
                If txtSearch.Text = "" Then
                    lblMsg0.Text = "Year must have a value"

                    Me.GridView1.DataSource = Nothing
                    Me.GridView1.DataBind()
                    lblmsg1.Text = ""
                    Exit Sub
                ElseIf drpMonth.Text = "" Then
                    lblMsg0.Text = "Month must have a value"

                    Me.GridView1.DataSource = Nothing
                    Me.GridView1.DataBind()
                    lblmsg1.Text = ""
                    Exit Sub
                End If
            End If
            sql = "SELECT currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, date_format(systemcreated,'%Y/%m/%d - %T %p') as systemmodified, modified FROM mlforexrate.globalratehistory where currname='" & curr & "' and date_format(systemcreated, '%m')= '" & month & "' and date_format(systemcreated, '%Y')='" & txtSearch.Text & "' order by systemcreated desc"
            'sql = "SELECT currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, date_format(modified,'%Y/%m/%d - %r') as systemmodified, modified FROM mlforexrate.globalforexrates where identifier=1 and date_format(modified,'%Y') = '" & txtSearch.Text & "' and date_format(modified,'%m') ='" & month & "' and currname= '" & curr & "' order by systemmodified DESC"

            getHistory(sql)
            lblMsg0.Text = ""
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

    Public Function getCurrName(ByVal currency As String) As String
        Try
            log4net.Info("GETCURRNAME - currency:" + currency)
            Dim sql As String = "SELECT currency FROM mlforexrate.currencyforex where CONCAT(CURRENCY, ' - ',DESCRIPTION)='" & drpcurr.Text & "';"
            'log.makeLog("ForexHistory_FSD.getCurrName - Currency Name: ", drpcurr.Text)
            log4net.Info("ForexHistory_FSD.getCurrName - Currency Name: " + drpcurr.Text)
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)

            Return tb(0).Item(0).ToString

        Catch ex As Exception
            log4net.Error("GETCURRNAME - " + ex.Message)
            Return 0
        End Try
    End Function

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView1.Controls(0), Table)

            ' Adding Cells


            Dim cell As TableCell = New TableHeaderCell()
            cell.ColumnSpan = 2
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

            'Dim c3 As TableCell = New TableHeaderCell()
            'c3.ColumnSpan = 2
            'c3.HorizontalAlign = HorizontalAlign.Center
            'c3.Text = "EXTRA SPECIAL"
            'row.Cells.Add(c3)

            Dim c4 As TableCell = New TableHeaderCell()
            c4.ColumnSpan = 1
            row.Cells.Add(c4)

            t.Rows.AddAt(0, row)
        End If
    End Sub
    Protected Sub btnUtil_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUtil.Click
        Response.Redirect("Utility.aspx")
    End Sub

    Protected Sub btnHistory_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnHistory.Click
        Response.Redirect("Forex History_fsd.aspx")
    End Sub

    'Protected Sub btnLogs_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogs.Click
    '    Response.Redirect("Forex Log.aspx")
    'End Sub

    'Protected Sub btnGlobal_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGlobal.Click
    '    Response.Redirect("Global Rate.aspx")
    'End Sub


End Class
