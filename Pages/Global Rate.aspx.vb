Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Userinfo
Imports log4net
Imports log4net.Config


Partial Class Pages_Global_Rate
    Inherits System.Web.UI.Page
    Public addapter As MySqlDataAdapter
    Public tb As DataTable
    Public Shared row As Integer
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("GlobalRate")

    Dim sql As String
    Dim sql1 As String = "SELECT CONCAT(CURRENCY, ' - ',DESCRIPTION) AS CURRENCY FROM mlforexrate.currencyforex;"
    Dim sql2 As String
    Dim sPath As String
    Dim con As New GetList
    Dim ls As New connect
    Dim rw As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If
        If IsPostBack = False Then
            sPath = Server.MapPath("..\Bin\kpForex.ini")
            ls.ReadINI(sPath)
            ls.ConnectDatabase()
            sql2 = "select currency, rate, remarks, date_format(systemcreated,'%Y/%m/%d - %T %p') as systemcreated, modifier from mlforexrate.globalratelogs where currency= 'USD' and date_format(systemcreated, '%m')= date_format(now(), '%m') order by systemcreated desc"
            getdata(sql2)
            getCurrency(sql1)
            btnGlobal.ImageUrl = "~/Images/btnGlobal1.png"

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
            Dim sql As String = "SELECT currency FROM mlforexrate.currencyforex where CONCAT(CURRENCY, ' - ',DESCRIPTION)='" & drpcurr.Text & "';"
            log4net.Info("GETCURRNAME - currency description : " + drpcurr.Text)
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)

            Return tb(0).Item(0).ToString

        Catch ex As Exception
            Return 0
            'log.makeLog("Global_Rate.getCurrName - ERROR : ", ex.Message)
            log4net.Error("GETCURRNAME - " + ex.Message)
        End Try
    End Function

    Public Sub getdata(ByVal mysql As String)
        Try
            log4net.Info("GETDATA - mysql:" + mysql)
            'Show to Gridview
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()

            If Me.GridView1.Rows.Count = 0 Then
                lblmsg1.Text = "No data was found in Global Rate Logs."

                lblMsg0.Text = ""
            Else
                lblmsg1.Text = "Data Found"
                lblMsg0.Text = ""
            End If
            'log.makeLog("Global_Rate.getdata - ", lblmsg1.Text)

            ls.DisconnectDatabase()
            log4net.Info("GETDATA - SUCCESS!")
        Catch ex As Exception
            log4net.Error("GETDATA - " + ex.Message)
            lblMsg0.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim month As String = getDateNum(drpMonth.Text)
            If Not drpMonth.Text <> "" And Not txtYear.Text <> "" Then
                sql = "select currency, rate, remarks, date_format(systemcreated,'%Y/%m/%d - %T %p') as systemcreated, modifier from mlforexrate.globalratelogs where currency ='" & getCurrName(drpcurr.Text) & "' order by systemcreated desc"

                getdata(sql)
                txtYear.Focus()
                Exit Sub
            Else
                If txtYear.Text = "" Then
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

            sql = "select currency, rate, remarks, date_format(systemcreated,'%Y/%m/%d - %T %p') as systemcreated, modifier from mlforexrate.globalratelogs where date_format(systemcreated, '%Y') = '" & txtYear.Text & "' and date_format(systemcreated, '%m')= '" & getDateNum(drpMonth.Text) & "' and currency ='" & getCurrName(drpcurr.Text) & "' order by systemcreated desc"
            getdata(sql)
            txtYear.Focus()

        Catch ex As Exception
            lblMsg0.Text = ex.Message
            log4net.Error("BTNSEARCH_CLICK - " + ex.Message)
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

    Protected Sub btnBranchSet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBranchSet.Click
        Response.Redirect("BranchSettings.aspx")
    End Sub
End Class
