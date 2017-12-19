Imports DAL
Imports System.Data
Imports MySql.Data.MySqlClient
Imports Userinfo
Imports log4net
Imports log4net.Config

Partial Class Pages_RateSett
    Inherits System.Web.UI.Page
    Public MyDAL As DAL.DataAccess

    Dim sql4 As String
    Dim sql As String
    Dim ls As New connect
    Dim ls_cmms As New connect
    Dim addapter As MySqlDataAdapter
    Dim sPath As String
    Dim tb As DataTable
    Dim ssql As String
    Dim editSql As String
    Private Shared log4net As log4net.ILog = LogManager.GetLogger("RateSett")

    Protected Sub btnPreviewRate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreviewRate.Click
        If checkemptybox(txtStanBuy, txtStanSell, txtSpecBuy, txtSpecSell, txtExtraBuy, txtExtraSell, txtOrdBuy, txtOrdSell) = True Then
            preview()
            Userinfo.botEnable = False
        End If

    End Sub

    Public Function checkemptybox(ByVal stdBuy As TextBox, ByVal stdSell As TextBox, ByVal speBuy As TextBox, ByVal speSell As TextBox, ByVal extBuy As TextBox, ByVal extSell As TextBox, ByVal ordBuy As TextBox, ByVal ordSell As TextBox) As Boolean
        If stdBuy.Text <> "" And stdSell.Text <> "" And speBuy.Text <> "" And speSell.Text <> "" And extBuy.Text <> "" And extSell.Text <> "" And ordBuy.Text <> "" And ordSell.Text <> "" Then
            Return True
        Else
            lblMsg0.Text = "Dont leave empty value in textbox"
            Return False
        End If
    End Function

    Public Sub preview()
        ' Check if the ViewState has a data assoiciated within it. If
        If ViewState("CurrentData") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(ViewState("CurrentData"), DataTable)
            Dim count As Integer = dt.Rows.Count
            BindGrid(count)
        Else
            BindGrid(1)
        End If

        Panel1.Visible = False
        lbInfor.Text = ""
    End Sub

    Private Sub BindGrid(ByVal rowcount As Integer)
        Try

            Dim dt As New DataTable()
            Dim dr As DataRow

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
            If drpfix1.Text = "FIX" Then
                If drpop1.Text = "+" Then
                    dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtStanBuy.Text)), 2)
                Else
                    dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtStanBuy.Text)), 2)
                End If
            ElseIf drpfix1.Text = "PERCENTAGE" Then
                If drpop1.Text = "+" Then
                    x = Convert.ToDecimal(txtStanBuy.Text / 100) * lblGlovalVal1.Text
                    dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtStanBuy.Text / 100) * lblGlovalVal1.Text
                    dr(0) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix2.Text = "FIX" Then
                If drpop2.Text = "+" Then
                    dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtStanSell.Text)), 2)
                Else
                    dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtStanSell.Text)), 2)
                End If
            ElseIf drpfix2.Text = "PERCENTAGE" Then
                If drpop2.Text = "+" Then
                    x = Convert.ToDecimal(txtStanSell.Text / 100) * lblGlovalVal1.Text
                    dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtStanSell.Text / 100) * lblGlovalVal1.Text
                    dr(1) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix3.Text = "FIX" Then
                If drpop3.Text = "+" Then
                    dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtSpecBuy.Text)), 2)
                Else
                    dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtSpecBuy.Text)), 2)
                End If
            ElseIf drpfix3.Text = "PERCENTAGE" Then
                If drpop3.Text = "+" Then
                    x = Convert.ToDecimal(txtSpecBuy.Text / 100) * lblGlovalVal1.Text
                    dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtSpecBuy.Text / 100) * lblGlovalVal1.Text
                    dr(2) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix4.Text = "FIX" Then
                If drpop4.Text = "+" Then
                    dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtSpecSell.Text)), 2)
                Else
                    dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtSpecSell.Text)), 2)
                End If
            ElseIf drpfix4.Text = "PERCENTAGE" Then
                If drpop4.Text = "+" Then
                    x = Convert.ToDecimal(txtSpecSell.Text / 100) * lblGlovalVal1.Text
                    dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtSpecSell.Text / 100) * lblGlovalVal1.Text
                    dr(3) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix5.Text = "FIX" Then
                If drpop5.Text = "+" Then
                    dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtExtraBuy.Text)), 2)
                Else
                    dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtExtraBuy.Text)), 2)
                End If
            ElseIf drpfix5.Text = "PERCENTAGE" Then
                If drpop5.Text = "+" Then
                    x = Convert.ToDecimal(txtExtraBuy.Text / 100) * lblGlovalVal1.Text
                    dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtExtraBuy.Text / 100) * lblGlovalVal1.Text
                    dr(4) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix6.Text = "FIX" Then
                If drpop6.Text = "+" Then
                    dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtExtraSell.Text)), 2)
                Else
                    dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtExtraSell.Text)), 2)
                End If
            ElseIf drpfix6.Text = "PERCENTAGE" Then
                If drpop6.Text = "+" Then
                    x = Convert.ToDecimal(txtExtraSell.Text / 100) * lblGlovalVal1.Text
                    dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtExtraSell.Text / 100) * lblGlovalVal1.Text
                    dr(5) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix7.Text = "FIX" Then
                If drpop7.Text = "+" Then
                    dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtOrdBuy.Text)), 2)
                Else
                    dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtOrdBuy.Text)), 2)
                End If
            ElseIf drpfix7.Text = "PERCENTAGE" Then
                If drpop7.Text = "+" Then
                    x = Convert.ToDecimal(txtOrdBuy.Text / 100) * lblGlovalVal1.Text
                    dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtOrdBuy.Text / 100) * lblGlovalVal1.Text
                    dr(6) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            If drpfix8.Text = "FIX" Then
                If drpop6.Text = "+" Then
                    dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + Convert.ToDecimal(txtOrdSell.Text)), 2)
                Else
                    dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - Convert.ToDecimal(txtOrdSell.Text)), 2)
                End If
            ElseIf drpfix8.Text = "PERCENTAGE" Then
                If drpop8.Text = "+" Then
                    x = Convert.ToDecimal(txtOrdSell.Text / 100) * lblGlovalVal1.Text
                    dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) + x), 2)
                Else
                    x = Convert.ToDecimal(txtOrdSell.Text / 100) * lblGlovalVal1.Text
                    dr(7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblGlovalVal1.Text) - x), 2)
                End If
            End If

            Me.Session("st_buy") = dr(0)
            Me.Session("st_sell") = dr(1)
            Me.Session("sp_buy") = dr(2)
            Me.Session("sp_sell") = dr(3)
            Me.Session("ex_buy") = dr(4)
            Me.Session("ex_sell") = dr(5)
            Me.Session("or_buy") = dr(6)
            Me.Session("or_sell") = dr(7)

            dt.Rows.Add(dr)


            GridView1.DataSource = dt

            GridView1.DataBind()


            log4net.Info("BINDGRID - SUCCESS!")
        Catch ex As Exception
            log4net.Error("BINDGRID - " + ex.Message)
            lblMsg0.Text = ex.Message
        End Try

    End Sub
    Public Sub ToUpdate(ByVal currname As String)
        Try
            log4net.Info("TOUPDATE - currname" + currname)
            ls.ConnectDatabase()
            Dim query As String = "select currname from mlforexrate.fomula where currname='" & currname & "'"
            addapter = New MySqlDataAdapter(query, connect.myDal.ConnectionString)
            tb = New DataTable()
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            If tb.Rows.Count > 0 Then
                updateUn(currname)
            Else
                saveSSE()
            End If

            log4net.Info("TOUPDATE - SUCCESS!")
        Catch ex As Exception
            log4net.Error("TOUPDATE - : " + ex.Message)
        End Try


    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            preview()
            ToUpdate(currName)
            '================

            If Me.Session("ident") = "0" Then
                'Eyang e save sa logs f unofficial after mo click sa "save formula".,
                sql = "Insert into mlforexrate.globallogs (currname, ord_buy, ord_sell, stan_buy, stan_sell," _
                        & "spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate)" _
                        & "Values ('" & Me.Session("currName") & "','" & Me.Session("or_buy") & "','" & Me.Session("or_sell") & "','" & Me.Session("st_buy") & "', '" & Me.Session("st_sell") & "', " _
                        & "'" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "', " _
                        & "'" & Me.Session("xxxcheckLoginInfo") & "','" & Me.Session("globalrate") & "'); "
                queryExecuter(sql)
                '===============================================


                'save sa unofficial
                sql = "update mlforexrate.globalforexrates set currname='" & Me.Session("currName") & "', global_rate='" & Me.Session("globalrate") & "', " _
                        & "average_globalrate='" & Me.Session("globalAverage") & "', stan_buy='" & Me.Session("st_buy") & "', " _
                        & "ord_buy='" & Me.Session("or_buy") & "ord_sell='" & Me.Session("or_sell") _
                        & "stan_sell='" & Me.Session("st_sell") & "', spe_buy= '" & Me.Session("sp_buy") & "', " _
                        & "spe_sell='" & Me.Session("sp_sell") & "', extra_buy='" & Me.Session("ex_buy") & "', " _
                        & "extra_sell='" & Me.Session("ex_sell") & "', modified=now(), modifier='" & Me.Session("xxxcheckLoginInfo") & "', " _
                        & "status='Manual' where currname='" & Me.Session("currName") & "'"
                queryExecuter(sql)

                Dim sql_cmms As String = "update cmms.globalforexrates set currname='" & Me.Session("currName") & "', global_rate='" & Me.Session("globalrate") & "', " _
                        & "average_globalrate='" & Me.Session("globalAverage") & "', stan_buy='" & Me.Session("st_buy") & "', " _
                        & "ord_buy='" & Me.Session("or_buy") & "ord_sell='" & Me.Session("or_sell") _
                        & "stan_sell='" & Me.Session("st_sell") & "', spe_buy= '" & Me.Session("sp_buy") & "', " _
                        & "spe_sell='" & Me.Session("sp_sell") & "', extra_buy='" & Me.Session("ex_buy") & "', " _
                        & "extra_sell='" & Me.Session("ex_sell") & "', modified=now(), modifier='" & Me.Session("xxxcheckLoginInfo") & "', " _
                        & "status='Manual' where currname='" & Me.Session("currName") & "'"
                queryExecuter_cmms(sql_cmms)
            End If


            Userinfo.botEnable = True
            Panel1.Visible = True
            lbInfor.Text = "Successfully Changed!"
            btnCancel.Text = "Back"
            btnSave.Enabled = False
            'preview()
            log4net.Info("BTNSAVE_CLICK -  SUCCESS!")
        Catch ex As Exception
            log4net.Error("BTNSAVE_CLICK - " + ex.Message)
        End Try
    End Sub
    Public Sub queryExecuter(ByVal sql As String)
        Try
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
        Catch ex As Exception
            log4net.Error("QUERYEXECUTER - " + ex.Message)
            lblMsg0.Text = ex.Message
        End Try
    End Sub
    Public Sub queryExecuter_cmms(ByVal sql As String)
        Try
            ls_cmms.ConnectDatabase()
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls_cmms.DisconnectDatabase()
        Catch ex As Exception
            ' lblMsg0.Text = ex.Message
            log4net.Error("QUERYEXECUTER_CMMS - " + ex.Message)
        End Try
    End Sub
    Public Sub updateUn(ByVal currname As String)
        Try
            log4net.Info("UPDATEUN - currname:" + currname)
            ls.ConnectDatabase()
            sql = "update mlforexrate.fomula set currvalue='" & lblGlovalVal1.Text _
                & "', for_std_sell='" & txtStanSell.Text & "', for_std_buy='" & txtStanBuy.Text _
                & "', for_spc_sell='" & txtSpecSell.Text & "', for_spc_buy='" & txtSpecBuy.Text _
                & "', for_ext_sell='" & txtExtraSell.Text & "', for_ext_buy='" & txtExtraBuy.Text _
                & "', for_ord_sell='" & txtOrdSell.Text & "', for_ord_buy='" & txtOrdBuy.Text _
                & "', systemmodified=now(), " _
                & " operator1='" & drpop1.Text & "', operator2='" & drpop2.Text & "', operator3='" & drpop3.Text & "', operator4='" & drpop4.Text _
                & "', operator5='" & drpop5.Text & "', operator6='" & drpop6.Text & "', operator7='" & drpop7.Text & "', operator8='" & drpop8.Text _
                & "', f_operator1='" & drpfix1.Text & "', f_operator2='" & drpfix2.Text & "', f_operator3='" & drpfix3.Text & "', f_operator4='" & drpfix4.Text _
                & "', f_operator5='" & drpfix5.Text & "', f_operator6='" & drpfix6.Text & "', f_operator7='" & drpfix7.Text & "', f_operator8='" & drpfix8.Text _
                & "', std_buy='" & GridView1.Rows(0).Cells(0).Text & "', std_sell='" & GridView1.Rows(0).Cells(1).Text _
                & "', spe_buy='" & GridView1.Rows(0).Cells(2).Text & "', spe_sell='" & GridView1.Rows(0).Cells(3).Text _
                & "', ext_buy='" & GridView1.Rows(0).Cells(4).Text & "', ext_sell='" & GridView1.Rows(0).Cells(5).Text _
                & "', ord_buy='" & GridView1.Rows(0).Cells(6).Text & "', ord_sell='" & GridView1.Rows(0).Cells(7).Text _
                & "' where currname='" & currname & "';"
            getdata(sql)

            '------Override Creator
            checkOverride()

            ''------Log Create
            'ls.ConnectDatabase()
            'sql = "select * from globallogs where date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d') and currname='" & Me.Session("currName") & "';"
            'addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            'tb = New DataTable
            'addapter.Fill(tb)
            'ls.DisconnectDatabase()

            'If tb.Rows.Count > 0 Then
            'ls.ConnectDatabase()
            'sql4 = "Insert into mlforexrate.globallogs (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate) Values ('" & Me.Session("currName") & "','" & Me.Session("st_buy") & "', " & _
            '        "'" & Me.Session("st_sell") & "','" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "','" & Me.Session("xxxcheckLoginInfo") & "','" & lblGlovalVal1.Text & "'); "
            'getLogs(sql4)
            'Else
            'ls.ConnectDatabase()
            'sql = "update mlforexrate.globallogs set fetchrate='" & lblGlovalVal1.Text & "', stan_buy='" & Me.Session("st_buy") & "',stan_sell='" & Me.Session("st_sell") & "',spe_sell='" & Me.Session("sp_sell") & "',extra_buy='" & Me.Session("ex_buy") & "',extra_sell='" & Me.Session("ex_sell") & "',modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currname='" & Me.Session("currName") & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d');"
            'getLogs(sql)
            'End If


        Catch ex As Exception
            log4net.Error("UPDATEUN - " + ex.Message)
        End Try
    End Sub
    Public Sub saveSSE()
        Try

            ls.ConnectDatabase()
            preview()
            sql = "Insert into mlforexrate.fomula (currname, currvalue, " _
                & "for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell, for_ord_buy, for_ord_sell, " _
                & "operator1, operator2, operator3, operator4, operator5, operator6, operator7, operator8, " _
                & "f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6, f_operator7, f_operator8," _
                & "std_buy, std_sell, spe_buy, spe_sell, ext_buy, ext_sell, ord_buy, ord_sell) " _
                & "Values ('" _
                & Me.Session("currName") & "','" & lblGlovalVal1.Text & "','" _
                & txtStanBuy.Text & "', '" & txtStanSell.Text & "', '" & txtSpecBuy.Text & "','" & txtSpecSell.Text & "', '" _
                & txtExtraBuy.Text & "', '" & txtExtraSell.Text & "','" & txtOrdBuy.Text & "','" & txtOrdSell.Text & "', '" _
                & drpop1.Text & "','" & drpop2.Text & "','" & drpop3.Text & "' ,'" & drpop4.Text & "','" _
                & drpop5.Text & "','" & drpop6.Text & "','" & drpop7.Text & "','" & drpop8.Text & "','" _
                & drpfix1.Text & "','" & drpfix2.Text & "','" & drpfix3.Text & "','" & drpfix4.Text & "','" _
                & drpfix5.Text & "','" & drpfix6.Text & "','" & drpfix7.Text & "','" & drpfix8.Text & "','" _
                & GridView1.Rows(0).Cells(0).Text & "', '" & GridView1.Rows(0).Cells(1).Text & "', '" & GridView1.Rows(0).Cells(2).Text & "', '" & GridView1.Rows(0).Cells(3).Text & "','" _
                & GridView1.Rows(0).Cells(4).Text & "', '" & GridView1.Rows(0).Cells(5).Text & "', '" & GridView1.Rows(0).Cells(6).Text & "', '" & GridView1.Rows(0).Cells(7).Text & "');"
            getdata(sql)


            '------Override Creator
            checkOverride()


            '------Log Create
            'ls.ConnectDatabase()
            'sql = "select * from globallogs where date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d') and currname='" & lblGlovalVal.Text & "';"
            'addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            'tb = New DataTable
            'addapter.Fill(tb)
            'ls.DisconnectDatabase()

            'If tb.Rows.Count > 0 Then
            'ls.ConnectDatabase()
            'sql4 = "Insert into mlforexrate.globallogs (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate) Values ('" & Me.Session("currName") & "','" & Me.Session("st_buy") & "', " & _
            '        "'" & Me.Session("st_sell") & "','" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "','" & Me.Session("xxxcheckLoginInfo") & "','" & lblGlovalVal1.Text & "'); "
            'getLogs(sql4)
            'Else
            'ls.ConnectDatabase()
            'sql = "update mlforexrate.globallogs set fetchrate='" & lblGlovalVal1.Text & "', stan_buy='" & Me.Session("st_buy") & "',stan_sell='" & Me.Session("st_sell") & "',spe_sell='" & Me.Session("sp_sell") & "',extra_buy='" & Me.Session("ex_buy") & "',extra_sell='" & Me.Session("ex_sell") & "',modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currname='" & Me.Session("currName") & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d');"
            'getLogs(sql)
            'End If
            '-----------------------------
            log4net.Info("SAVESSE - SUCCESS!")
        Catch ex As Exception
            log4net.Error("SAVESSE - " + ex.Message)
        End Try
    End Sub
    Public Sub checkOverride()
        Try
            ls.ConnectDatabase()
            sql = "select * from mlforexrate.forexoverride where currency='" & Me.Session("currName") & "'"
            addapter = New MySqlDataAdapter(sql, connect.myDal.ConnectionString)
            tb = New DataTable()
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            If tb.Rows.Count > 0 Then
                ls.ConnectDatabase()
                sql = "update mlforexrate.forexoverride set currency = '" & Me.Session("currName") _
                    & "', ord_sell='" & Me.Session("or_sell") & "', ord_buy='" & Me.Session("or_buy") _
                    & "', stan_sell='" & Me.Session("st_sell") & "', stan_buy='" & Me.Session("st_buy") _
                    & "', spe_sell='" & Me.Session("sp_sell") & "', spe_buy='" & Me.Session("sp_buy") _
                    & "', extra_sell='" & Me.Session("ex_sell") & "', extra_buy='" & Me.Session("ex_buy") _
                    & "', modified='" & Me.Session("xxxcheckLoginInfo") & "', systemmodified=now(), status='Manual' where currency='" & Me.Session("currName") & "'"
                getLogs(sql)
            Else
                ls.ConnectDatabase()
                sql = "insert into mlforexrate.forexoverride " _
                    & "(currency, stan_sell, stan_buy, spe_sell, spe_buy, extra_sell, extra_buy, ord_sell, ord_buy," _
                    & "modified, systemmodified, status, modifier) " _
                    & "values ('" & Me.Session("currName") & "', '" _
                    & Me.Session("st_sell") & "', '" & Me.Session("st_buy") & "', '" & Me.Session("sp_sell") & "', '" & Me.Session("sp_buy") & "', '" _
                    & Me.Session("ex_sell") & "', '" & Me.Session("ex_buy") & "', '" & Me.Session("or_sell") & "', '" & Me.Session("or_buy") & "', '" _
                    & Me.Session("xxxcheckLoginInfo") & "', now(), 'Manual', '" & Me.Session("xxxcheckLoginInfo") & "'); "
                getLogs(sql)
            End If
            log4net.Info("CHECKOVERRIDE - SUCCESS!")

        Catch ex As Exception
            log4net.Error("CHECKOVERRIDE - " + ex.Message)
        End Try
    End Sub

    Public Sub getLogs(ByVal mysql As String)
        Try
            log4net.Info("GETLOGS - mysql:" + mysql)
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
            log4net.Info("GETLOGS - SUCCESS!")
        Catch ex As Exception
            log4net.Error("GETLOGS - " + ex.Message)
            lbInfor.Text = ex.Message
        End Try
    End Sub
    Public Sub getdata(ByVal mysql As String)
        Try
            log4net.Info("GETDATA - mysql:" + mysql)
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()

            ls.DisconnectDatabase()

            log4net.Info("GETDATA - SUCCESS!")
        Catch ex As Exception
            log4net.Error("GETDATA -" + ex.Message)
            lblMsg0.Text = ex.Message
        End Try
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
            val()
            getOperator()
            Userinfo.botEnable = False
            If Me.Session("ident") = "1" Then
                btn_01.Text = btn_01.Text & " Unofficial"
            Else
                btn_01.Text = btn_01.Text & " Official"
            End If

        End If

    End Sub
    Public Sub getOperator()
        Try
            ssql = "select currname, operator1, operator2, operator3, operator4, operator5, operator6, operator7, operator8, " _
                 & "f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6, f_operator7, f_operator8, " _
                 & "currvalue, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell, for_ord_buy, for_ord_sell " _
                 & " from mlforexrate.fomula where currname ='" & Me.Session("currName") & "';"
            lblGlovalVal1.Text = Me.Session("globalrate")
            ls.ConnectDatabase()
            addapter = New MySqlDataAdapter(ssql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                'lblGlovalVal1.Text = tb(0).Item(13).ToString

                drpop1.Text = tb(0).Item(1).ToString
                drpop2.Text = tb(0).Item(2).ToString
                drpop3.Text = tb(0).Item(3).ToString
                drpop4.Text = tb(0).Item(4).ToString
                drpop5.Text = tb(0).Item(5).ToString
                drpop6.Text = tb(0).Item(6).ToString
                drpop7.Text = tb(0).Item(7).ToString
                drpop8.Text = tb(0).Item(8).ToString

                drpfix1.Text = tb(0).Item(9).ToString
                drpfix2.Text = tb(0).Item(10).ToString
                drpfix3.Text = tb(0).Item(11).ToString
                drpfix4.Text = tb(0).Item(12).ToString
                drpfix5.Text = tb(0).Item(13).ToString
                drpfix6.Text = tb(0).Item(14).ToString
                drpfix7.Text = tb(0).Item(15).ToString
                drpfix8.Text = tb(0).Item(16).ToString

                txtStanBuy.Text = tb(0).Item(18).ToString
                txtStanSell.Text = tb(0).Item(19).ToString
                txtSpecBuy.Text = tb(0).Item(20).ToString
                txtSpecSell.Text = tb(0).Item(21).ToString
                txtExtraBuy.Text = tb(0).Item(22).ToString
                txtExtraSell.Text = tb(0).Item(23).ToString
                txtOrdBuy.Text = tb(0).Item(24).ToString
                txtOrdSell.Text = tb(0).Item(25).ToString

            End If
            ls.DisconnectDatabase()
            log4net.Info("GETOPERATOR - SUCCESS!")
        Catch ex As Exception
            log4net.Error("GETOPERATOR -" + ex.Message)
            lblMsg0.Text = ex.Message
        End Try
    End Sub
    Public Sub val()
        lblGlovalVal.Text = "1" + " " + Me.Session("currName")

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ForexSettings.aspx")
    End Sub

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim row As New GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal)
            Dim t As Table = DirectCast(GridView1.Controls(0), Table)

            ' Adding Cells


            Dim c1 As TableCell = New TableHeaderCell()
            c1.ColumnSpan = 2
            c1.HorizontalAlign = HorizontalAlign.Center
            c1.Text = "STANDARD"
            row.Cells.Add(c1)

            Dim c2 As TableCell = New TableHeaderCell()
            c2.ColumnSpan = 2
            c2.HorizontalAlign = HorizontalAlign.Center
            c2.Text = "Special"
            row.Cells.Add(c2)

            Dim c3 As TableCell = New TableHeaderCell()
            c3.ColumnSpan = 2
            c3.HorizontalAlign = HorizontalAlign.Center
            c3.Text = "Extra Special"
            row.Cells.Add(c3)

            Dim c4 As TableCell = New TableHeaderCell()
            c4.ColumnSpan = 2
            c4.HorizontalAlign = HorizontalAlign.Center
            c4.Text = "Ordinary"
            row.Cells.Add(c4)

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


    Protected Sub btn_01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_01.Click
        Try
            Dim globalSQL, globalOfficialSQL, globalOfficialSQL_cmms As String

            If Me.Session("ident") = "0" Then
                globalSQL = "UPDATE mlforexrate.globalrates SET identifier='1' where currency='" & Me.Session("currName") & "'"
                globalOfficialSQL = "UPDATE mlforexrate.globalforexrates SET identifier='1' where currname='" & Me.Session("currName") & "'"
                globalOfficialSQL_cmms = "UPDATE cmms.globalforexrates SET identifier='1' where currname='" & Me.Session("currName") & "'"

                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(globalSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)

                addapter = New MySqlDataAdapter(globalOfficialSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '---------- update cmms
                queryExecuter_cmms(globalOfficialSQL_cmms)

                Dim st As String = "alert('Successfully saved as official currency!');location='ForexSettings.aspx';"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "key", st, True)

                'lblMsgOff.Text = "Successfully"
            Else
                globalSQL = "UPDATE mlforexrate.globalrates SET identifier='0' where currency='" & Me.Session("currName") & "'"
                globalOfficialSQL = "UPDATE mlforexrate.globalforexrates SET identifier='0' where currname='" & Me.Session("currName") & "'"
                globalOfficialSQL_cmms = "UPDATE cmms.globalforexrates SET identifier='0' where currname='" & Me.Session("currName") & "'"

                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(globalSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)

                addapter = New MySqlDataAdapter(globalOfficialSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                '--------- update cmms
                queryExecuter_cmms(globalOfficialSQL_cmms)

                Dim st As String = "alert('Successfully saved as unofficial currency!');location='ForexSettings.aspx';"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "key", st, True)
            End If

            btnCancel.Text = "Back"
            log4net.Info("BTN_01_CLICK - SUCCESS!")
        Catch ex As Exception
            log4net.Error("BTN_01_CLICK - " + ex.Message)
            lblMsg0.Text = ex.Message
            ClientScript.RegisterStartupScript(Me.GetType(), "Save", "alert('" & ex.Message & "');", True)
        End Try
    End Sub


    Protected Sub btnBranchSet_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBranchSet.Click
        Response.Redirect("BranchSettings.aspx")
    End Sub
End Class
