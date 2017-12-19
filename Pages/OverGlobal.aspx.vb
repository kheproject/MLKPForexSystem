Imports MySql.Data.MySqlClient
Imports System.Data
Imports Userinfo
Imports log4net
Imports log4net.Config

Partial Class Pages_OverGlobal
    Inherits System.Web.UI.Page

    Dim ls As New connect
    Dim ls_cmms As New connect
    Dim status As String
    Dim tb As New DataTable
    Dim addapter As New MySqlDataAdapter
    Dim sPath As String
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("OverGlobal")

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)

        If Me.Session("xxxcheckLoginInfo") <> Me.Session("xxxcheckLoginInfo") Or Me.Session("xxxcheckLoginInfo") = Nothing Then
            Me.Session.Clear()
            Response.Redirect("Login.aspx")
        End If

        If IsPostBack = False Then

            lblGlovalVal1.Text = Me.Session("_ovRate")
            lblGlovalVal.Text = Me.Session("currName")
            lblOve.Text = lblOve.Text & Me.Session("currName") & " Currency"
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            ' Dim adapter As MySqlDataAdapter
            'Dim tb As DataTable
            Dim sql As String
            Dim _averagerate As String
            Dim format As String = "HH:mm"
            Dim time As DateTime = ls.getServerTime
            Userinfo.getServerDate = time.ToString(format)


            sql = "update mlforexrate.globalrates set rate='" & txtRate.Text & "', remarks='" & txtRemarks.Text & "' where currency='" & lblGlovalVal.Text & "'; "
            sqlExecuter(sql) 'Now


            '===============Get ML Average
            _averagerate = getAverageRate(lblGlovalVal.Text)
            '=============================

            '===============
            changeSSE(lblGlovalVal.Text, txtRate.Text, "Manual")
            '===============

            '================update ML-Rates
            updateGlobalRateandAvergeRate(txtRate.Text, _averagerate, lblGlovalVal.Text)

            saveToGlobalLogs()
            '===============================
            btnCancel.Text = "Back"
            Panel1.Visible = True
            lblMsg.Text = lblGlovalVal.Text & " Successfully Overriden!"
            log4net.Info("BTNSAVE_CLICK : Successfully Overriden")

            lblGlovalVal1.Text = Me.Session("_ovRate")
            btnSave.Enabled = False
        Catch ex As Exception
            lblMsg.Text = ex.Message
            log4net.Error("BTNSAVE_CLICK " + ex.Message)
        End Try
    End Sub

    'Select Case Userinfo.getServerDate
    '            Case "00:00" To "13:00" 'now


    '                sql = "update mlforexrate.globalrates set rate='" & txtRate.Text & "', remarks='" & txtRemarks.Text & "' where currency='" & lblGlovalVal.Text & "'; "
    '                sqlExecuter(sql) 'Now

    ''===============Get ML Average
    '                _averagerate = getAverageRate(lblGlovalVal.Text)
    ''=============================

    ''===============
    '                changeSSE(lblGlovalVal.Text, txtRate.Text, "Manual")
    ''===============

    ''================update ML-Rates
    '                updateGlobalRateandAvergeRate(txtRate.Text, _averagerate, lblGlovalVal.Text)

    '                saveToGlobalLogs()
    ''===============================
    '                btnCancel.Text = "Back"
    '                Panel1.Visible = True
    '                lblMsg.Text = lblGlovalVal.Text & " Successfully Overriden!"
    '            Case "13:01" To "23:59" 'next day
    '                ls.ConnectDatabase()
    '                sql = "select * from mlforexrate.globalratesfornextday where currency='" & lblGlovalVal.Text & "';"
    '                adapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '                tb = New DataTable
    '                adapter.Fill(tb)
    '                ls.DisconnectDatabase()

    '                If tb.Rows.Count = 0 Then
    '                    ls.ConnectDatabase()
    '                    sql = "insert into mlforexrate.globalratesfornextday (Currency, Rate, systemcreated," _
    '                         & "remarks, identifier, datetoupdate, modifier)values('" & lblGlovalVal.Text & "', '" & txtRate.Text & "', " _
    '                         & "now(), '" & txtRemarks.Text & "', '1', date_format(date_add(now(), interval 1 day), '%Y-%m-%d 12:00:00'), '" & Me.Session("xxxcheckLoginInfo") & "' );"
    '                    adapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '                    tb = New DataTable
    '                    adapter.Fill(tb)
    '                    ls.DisconnectDatabase()
    '                Else
    '                    sql = "update globalratesfornextday set rate='" & txtRate.Text & "', remarks='" & txtRemarks.Text & "', systemcreated=now(),datetoupdate=date_format(date_add(now(), interval 1 day), '%Y-%m-%d 12:00:00'), modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currency='" & lblGlovalVal.Text & "'; "
    '                    sqlExecuter(sql) 'Next Day
    '                End If
    '                Me.Session("_ovRate") = txtRate.Text

    ''====================bag-o na add
    'Dim val As String
    '                ls.ConnectDatabase()
    '                sql = "select date_format(date_add(now(), interval 1 day), '%Y/%m/%d') as dateTomorrow;"
    '                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '                tb = New DataTable
    '                addapter.Fill(tb)
    '                val = tb(0).Item(0).ToString
    '                ls.DisconnectDatabase()


    ''==================insert sa globallogs
    '                ls.ConnectDatabase()
    '                sql = "insert into mlforexrate.globalratelogs (currency, rate, remarks, systemcreated, modifier) values ('" &  Me.Session("currName")  & "', '" & txtRate.Text & "','[Overriden] For the next day ' '" & val & " " & txtRate.Text & "', now(), '" & Me.Session("xxxcheckLoginInfo") & "') "
    '                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
    '                tb = New DataTable
    '                addapter.Fill(tb)
    '                ls.DisconnectDatabase()
    ''=======================end

    '                makeLog()
    '                btnCancel.Text = "Back"
    '                Panel1.Visible = True
    '                lblMsg.Text = lblGlovalVal.Text & " Successfully Overriden!"

    '        End Select

    Public Sub changeSSE(ByVal currname As String, ByVal rate As String, ByVal status As String)
        Try
            log4net.Info("CHANGESSE -  currname:" + currname + ", rate:" + rate + " ,status" + status)
            Dim st_buy, st_sell As String
            Dim sp_buy, sp_sell As String
            Dim ex_buy, ex_sell As String
            Dim op1, op2, op3, op4, op5, op6 As String
            Dim f_op1, f_op2, f_op3, f_op4, f_op5, f_op6 As String

            Dim dr As DataRow
            Dim dt As New DataTable()


            Dim sqlFormula As String = "select currname, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell, operator1, operator2, operator3, operator4, operator5, operator6, f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6 from mlforexrate.fomula where currname='" & currname & "'"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sqlFormula, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                Dim sqlRateOfficial As String = "UPDATE mlforexrate.globalforexrates SET stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                                & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now() , status='" & status & "' " _
                                                & "where currname='" & currname & "'"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sqlRateOfficial, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '---- insert to cmms
                Dim sqlRateOfficial_cmms As String = "UPDATE cmms.globalforexrates SET stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
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

                op1 = tb(0).Item(7).ToString
                op2 = tb(0).Item(8).ToString
                op3 = tb(0).Item(9).ToString
                op4 = tb(0).Item(10).ToString
                op5 = tb(0).Item(11).ToString
                op6 = tb(0).Item(12).ToString

                f_op1 = tb(0).Item(13).ToString
                f_op2 = tb(0).Item(14).ToString
                f_op3 = tb(0).Item(15).ToString
                f_op4 = tb(0).Item(16).ToString
                f_op5 = tb(0).Item(17).ToString
                f_op6 = tb(0).Item(18).ToString
                '================================


                dt.Columns.Add(New System.Data.DataColumn("Buying", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying  ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling  ", GetType([String])))
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

                '========================================
                Dim sqlRateOfficial As String = "UPDATE mlforexrate.globalforexrates SET stan_buy='" & dr(0).ToString & "', stan_sell='" & dr(1).ToString & "', spe_buy='" & dr(2).ToString & "' " _
                                                & ",spe_sell='" & dr(3).ToString & "', extra_buy='" & dr(4).ToString & "', extra_sell='" & dr(5).ToString & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now(), status='" & status & "' " _
                                                & "where currname='" & currname & "'"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sqlRateOfficial, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '--------- insert cmms
                Dim sqlRateOfficial_cmms As String = "UPDATE cmms.globalforexrates SET stan_buy='" & dr(0).ToString & "', stan_sell='" & dr(1).ToString & "', spe_buy='" & dr(2).ToString & "' " _
                                                & ",spe_sell='" & dr(3).ToString & "', extra_buy='" & dr(4).ToString & "', extra_sell='" & dr(5).ToString & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', modified=now(), status='" & status & "' " _
                                                & "where currname='" & currname & "'"
                sqlExecuter_cmms(sqlRateOfficial_cmms)

                '===================make history
                'getOfficialRateTO_MakeHistory()

                '===================make log
                makeLog()
            End If
            log4net.Info("CHANGESSE - SUCCESS! ")

        Catch ex As Exception
            lblMsg.Text = ex.Message
            log4net.Error("CHANGESSE " + ex.Message)
        End Try
    End Sub
    Public Sub makeLog()
        Try

            Dim sql As String
            Dim rate As String = txtRate.Text
            'Dim status As String = "Automate"

            Dim st_buy, st_sell As String
            Dim sp_buy, sp_sell As String
            Dim ex_buy, ex_sell As String
            Dim op1, op2, op3, op4, op5, op6 As String
            Dim f_op1, f_op2, f_op3, f_op4, f_op5, f_op6 As String

            Dim dr As DataRow
            Dim dt As New DataTable()


            Dim sqlFormula As String = "select currname, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell, operator1, operator2, operator3, operator4, operator5, operator6, f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6 from mlforexrate.fomula where currname='" & Me.Session("currName") & "'"
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sqlFormula, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                Dim sqlRateOfficial As String = "UPDATE mlforexrate.globalforexrates SET stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                                & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', status='" & status & "' " _
                                                & "where currname='" & currName & "'"
                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(sqlRateOfficial, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                ' ----------------insert to CMMS
                Dim sqlRateOfficial_cmms As String = "UPDATE cmms.globalforexrates SET stan_buy='" & rate & "', stan_sell='" & rate & "', spe_buy='" & rate & "' " _
                                              & ",spe_sell='" & rate & "', extra_buy='" & rate & "', extra_sell='" & rate & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "', status='" & status & "' " _
                                              & "where currname='" & currName & "'"
                sqlExecuter_cmms(sqlRateOfficial_cmms)
            Else
                '======================Put values
                st_buy = tb(0).Item(1).ToString
                st_sell = tb(0).Item(2).ToString

                sp_buy = tb(0).Item(3).ToString
                sp_sell = tb(0).Item(4).ToString

                ex_buy = tb(0).Item(5).ToString
                ex_sell = tb(0).Item(6).ToString

                op1 = tb(0).Item(7).ToString
                op2 = tb(0).Item(8).ToString
                op3 = tb(0).Item(9).ToString
                op4 = tb(0).Item(10).ToString
                op5 = tb(0).Item(11).ToString
                op6 = tb(0).Item(12).ToString

                f_op1 = tb(0).Item(13).ToString
                f_op2 = tb(0).Item(14).ToString
                f_op3 = tb(0).Item(15).ToString
                f_op4 = tb(0).Item(16).ToString
                f_op5 = tb(0).Item(17).ToString
                f_op6 = tb(0).Item(18).ToString
                '================================


                dt.Columns.Add(New System.Data.DataColumn("Buying", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Buying  ", GetType([String])))
                dt.Columns.Add(New System.Data.DataColumn("Selling  ", GetType([String])))
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
            End If

            ls.ConnectDatabase()
            sql = "Insert into mlforexrate.globallogs (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate) Values ('" & Me.Session("currName") & "','" & Me.Session("st_buy") & "', " & _
                    "'" & Me.Session("st_sell") & "','" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "','" & Me.Session("xxxcheckLoginInfo") & "','" & Me.txtRate.Text & "'); "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            log4net.Info("MAKELOG - SUCCESS! ")
            'Else
            'ls.ConnectDatabase()
            'Sql = "update mlforexrate.globallogs set fetchrate='" & txtRate.Text & "', stan_buy='" & Me.Session("st_buy") & "',stan_sell='" & Me.Session("st_sell") & "',spe_sell='" & Me.Session("sp_sell") & "',extra_buy='" & Me.Session("ex_buy") & "',extra_sell='" & Me.Session("ex_sell") & "',modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currname='" &  Me.Session("currName")  & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d');"
            'addapter = New MySqlDataAdapter(Sql, connect.myDal.ConnectionString)
            'tb = New DataTable
            'addapter.Fill(tb)
            'ls.DisconnectDatabase()
            'End If

        Catch ex As Exception
            log4net.Error("MAKELOG - " + ex.Message)
        End Try
    End Sub
    Public Sub getOfficialRateTO_MakeHistory()
        Try
            Dim sql As String

            '----check kong naa na cya history
            ls.ConnectDatabase()
            sql = "select * from mlforexrate.globalratehistory where date_format(systemcreated, '%Y/%m/%d')= date_format(now(), '%Y/%m/%d') and currname='" & Me.Session("currName") & "'; "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                sql = "insert into mlforexrate.globalratehistory (currname, stan_buy, stan_sell, spe_buy, spe_sell, " _
                         & "extra_buy, extra_sell, systemcreated, modified)values ('" & Me.Session("currName") & "','" & Me.Session("st_buy") & _
                         "', '" & Me.Session("st_sell") & "', '" & Me.Session("sp_buy") & "', '" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "', '" & Me.Session("ex_sell") & _
                         "', now(), '" & Me.Session("xxxcheckLoginInfo") & "')"

                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
            Else
                sql = "update mlforexrate.globalratehistory set stan_buy='" & Me.Session("st_buy") & "', stan_sell='" & Me.Session("st_sell") & "', spe_buy='" & Me.Session("sp_buy") & "', spe_sell='" & Me.Session("sp_sell") & "', extra_buy='" & Me.Session("ex_buy") & "', extra_sell='" & Me.Session("ex_sell") & "' where currname ='" & Me.Session("currName") & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d')"
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()
                log4net.Info("GETOFFICIALRATETO_MAKEHISTORY - SUCCESS! ")
            End If
        Catch ex As Exception
            log4net.Error("GETOFFICIALRATETO_MAKEHISTORY - " + ex.Message)
        End Try
    End Sub
    Public Sub sqlExecuter(ByVal mysql As String)
        Try

            'ls.ConnectDatabase()
            Dim adapter As MySqlDataAdapter
            Dim tb As DataTable
            adapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            adapter.Fill(tb)
            ls.DisconnectDatabase()



        Catch ex As Exception
            Throw
            lblMsg.Text = ex.Message
            log4net.Error("SQLEXECUTER - " + ex.Message)
        End Try
    End Sub
    Public Sub sqlExecuter_cmms(ByVal mysql As String)
        Try
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
            'Throw
            'lblMsg.Text = ex.Message
        End Try
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ForexSettings.aspx")
    End Sub

    Public Sub updateGlobalRateandAvergeRate(ByVal _val As String, ByVal _ave As String, ByVal _cur As String)
        Try
            log4net.Info("UPDATEGLOBALRATEANDAVERGERATE - val:" + _val + ", average:" + _ave + ", currency:" + _cur)
            Dim addapter As MySqlDataAdapter
            Dim tb As DataTable

            ls.ConnectDatabase()
            Dim sql As String
            sql = "update mlforexrate.globalforexrates set global_rate='" & _val & "',average_globalrate='" & _ave & "', status='Manual'  where currname='" & _cur & "'; "
            'sql = "update mlforexrate.globalforexrates set global_rate='" & _val & "',average_globalrate='" & _val & "', status='Manual'  where currname='" & _cur & "'; "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            '----insert to cmms
            Dim addapterCMMS As MySqlDataAdapter
            Dim tbCMMS As DataTable
            ls_cmms.ConnectDatabaseCMMS()
            Dim sql_cmms As String
            sql_cmms = "update cmms.globalforexrates set global_rate='" & _val & "',average_globalrate='" & _ave & "', status='Manual'  where currname='" & _cur & "'; "
            ' sqlExecuter_cmms(sql_cmms)
            addapterCMMS = New MySqlDataAdapter(sql_cmms, connect.myDal.ConnectionString)
            tbCMMS = New DataTable
            addapterCMMS.Fill(tbCMMS)
            ls.DisconnectDatabase()
            log4net.Info("UPDATEGLOBALRATEANDAVERGERATE - SUCCESS! ")
            Me.Session("_ovRate") = _val
        Catch ex As Exception
            log4net.Error("UPDATEGLOBALRATEANDAVERGERATE - " + ex.Message)
        End Try
    End Sub

    Public Function getAverageRate(ByVal _cur As String) As String
        Try
            log4net.Info("GETAVERAGERATE + currency:" + _cur)
            Dim sql As String
            Dim addapter As MySqlDataAdapter
            Dim tb As DataTable

            ls.ConnectDatabase()
            sql = "select avg(rate) from (select * from mlforexrate.globalratelogs order by systemcreated desc)as system where date_format(systemcreated,'%Y%d%m')=date_format(now(), '%Y%d%m') and currency='" & _cur & "' and remarks is null group by currency"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()

            If tb.Rows.Count = 0 Then
                ls.ConnectDatabase()
                sql = "select avg(rate) from (select * from mlforexrate.globalratelogs order by systemcreated desc)as system where date_format(systemcreated,'%Y-%m-%d')=date_sub(curdate(), interval 1 day) and currency='" & _cur & "' and remarks is null group by currency"
                addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                Return tb(0).Item(0).ToString
            Else
                '_eyangsod = tb(0).Item(0).ToString
                Return tb(0).Item(0).ToString
            End If
            log4net.Info("GETAVERAGERATE - SUCCESS! ")

        Catch ex As Exception
            log4net.Error("GETAVERAGERATE - " + ex.Message)
            Return 0
        End Try
    End Function

    Public Sub saveToGlobalLogs()
        Try
            Dim sql As String
            Dim addapter As MySqlDataAdapter
            Dim tb As DataTable
            '----------check kong na automate na
            'ls.ConnectDatabase()
            'sql = "select * from globalratelogs where currency = '" & lblGlovalVal.Text & "' and remarks is not null and date_format(systemcreated, '%Y%d%m')=date_format(now(), '%Y%d%m')"
            'addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            'tb = New DataTable
            'addapter.Fill(tb)
            '_val = tb.Rows.Count

            '----------insert
            'If tb.Rows.Count = 0 Then
            ls.ConnectDatabase()
            sql = "insert into mlforexrate.globalratelogs (currency, rate, remarks, systemcreated, modifier) values ('" & lblGlovalVal.Text & "', '" & txtRate.Text & "','[Overriden] " & txtRate.Text & "', now(), '" & Me.Session("xxxcheckLoginInfo") & "'); "
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            'Else
            'ls.ConnectDatabase()
            'sql = "update mlforexrate.globalratelogs set rate='" & txtRate.Text & "', remarks='" & txtRemarks.Text & "', modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currency='" & lblGlovalVal.Text & "' and remarks is not null order by systemcreated desc limit 1;"
            'addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            'tb = New DataTable
            'addapter.Fill(tb)
            'ls.DisconnectDatabase()
            'End If
        Catch ex As Exception
            log4net.Error("SAVETOGLOBALLOGS")
        End Try
    End Sub


    Protected Sub btnBranchSet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBranchSet.Click
        Response.Redirect("BranchSettings.aspx")
    End Sub
End Class
