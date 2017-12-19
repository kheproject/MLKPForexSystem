Imports DAL
Imports System.Data
Imports MySql.Data.MySqlClient
Imports Userinfo

Partial Class Pages_RateSett
    Inherits System.Web.UI.Page
    Public MyDAL As DAL.DataAccess

    Dim sql4 As String
    Dim sql As String
    Dim ls As New connect
    Dim addapter As MySqlDataAdapter
    Dim sPath As String
    Dim tb As DataTable
    Dim ssql As String
    Dim editSql As String




    Protected Sub btnPreviewRate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreviewRate.Click
        If checkemptybox(txtStanBuy, txtStanSell, txtSpecBuy, txtSpecSell, txtExtraBuy, txtExtraSell) = True Then
            preview()
            Userinfo.botEnable = False
        End If

    End Sub

    Public Function checkemptybox(ByVal stdBuy As TextBox, ByVal stdSell As TextBox, ByVal speBuy As TextBox, ByVal speSell As TextBox, ByVal extBuy As TextBox, ByVal extSell As TextBox) As Boolean
        If stdBuy.Text <> "" And stdSell.Text <> "" And speBuy.Text <> "" And speSell.Text <> "" And extBuy.Text <> "" And extSell.Text <> "" Then
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

            Me.Session("st_buy") = dr(0)
            Me.Session("st_sell") = dr(1)
            Me.Session("sp_buy") = dr(2)
            Me.Session("sp_sell") = dr(3)
            Me.Session("ex_buy") = dr(4)
            Me.Session("ex_sell") = dr(5)

            dt.Rows.Add(dr)


            GridView1.DataSource = dt

            GridView1.DataBind()

        Catch ex As Exception
            lblMsg0.Text = ex.Message
        End Try

    End Sub
    Private Sub ToUpdate()
        ls.ConnectDatabase()
        Dim query As String = "select currname from mlforexrate.fomula where currname='" & Me.Session("currName") & "'"
        addapter = New MySqlDataAdapter(query, connect.myDal.ConnectionString)
        tb = New DataTable()
        addapter.Fill(tb)
        ls.DisconnectDatabase()
        If tb.Rows.Count > 0 Then
            updateUn()
        Else
            saveSSE()
        End If



    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            preview()
            'Select Case Userinfo.valStat
            '    Case 0
            '        If Userinfo.botEnable = True Then
            '            lbInfor.Text = "Review first before saving."
            '            Exit Sub
            '        Else
            '            ToUpdate()

            '        End If
            '    Case 1
            ToUpdate()

            'End Select
            Userinfo.botEnable = True
            Panel1.Visible = True
            lbInfor.Text = "Successfully Changed!"
            btnCancel.Text = "Back"
            'preview()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub updateUn()
        Try

            ls.ConnectDatabase()
            sql = "update mlforexrate.fomula set currvalue='" & lblGlovalVal1.Text & "', for_std_sell='" & txtStanSell.Text & "', for_std_buy='" & txtStanBuy.Text & "', for_spc_sell='" & txtSpecSell.Text & "', for_spc_buy='" & txtSpecBuy.Text & "', for_ext_sell='" & txtExtraSell.Text & "', for_ext_buy='" & txtExtraBuy.Text & "', systemmodified=now(),  operator1='" & drpop1.Text & "', operator2='" & drpop2.Text & "', operator3='" & drpop3.Text & "', operator4='" & drpop4.Text & "', operator5='" & drpop5.Text & "', operator6='" & drpop6.Text & "', f_operator1='" & drpfix1.Text & "', f_operator2='" & drpfix2.Text & "', f_operator3='" & drpfix3.Text & "', f_operator4='" & drpfix4.Text & "', f_operator5='" & drpfix5.Text & "', f_operator6='" & drpfix6.Text & "', std_buy='" & GridView1.Rows(0).Cells(0).Text & "', std_sell='" & GridView1.Rows(0).Cells(1).Text & "', spe_buy='" & GridView1.Rows(0).Cells(2).Text & "', spe_sell='" & GridView1.Rows(0).Cells(3).Text & "', ext_buy='" & GridView1.Rows(0).Cells(4).Text & "', ext_sell='" & GridView1.Rows(0).Cells(5).Text & "' where currname='" & Me.Session("currName") & "';"
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
            ls.ConnectDatabase()
            sql4 = "Insert into mlforexrate.globallogs (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate) Values ('" & Me.Session("currName") & "','" & Me.Session("st_buy") & "', " & _
                    "'" & Me.Session("st_sell") & "','" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "','" & Me.Session("xxxcheckLoginInfo") & "','" & lblGlovalVal1.Text & "'); "
            getLogs(sql4)
            'Else
            'ls.ConnectDatabase()
            'sql = "update mlforexrate.globallogs set fetchrate='" & lblGlovalVal1.Text & "', stan_buy='" & Me.Session("st_buy") & "',stan_sell='" & Me.Session("st_sell") & "',spe_sell='" & Me.Session("sp_sell") & "',extra_buy='" & Me.Session("ex_buy") & "',extra_sell='" & Me.Session("ex_sell") & "',modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currname='" & Me.Session("currName") & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d');"
            'getLogs(sql)
            'End If


        Catch ex As Exception

        End Try
    End Sub
    Public Sub saveSSE()
        Try

            ls.ConnectDatabase()
            preview()
            sql = "Insert into mlforexrate.fomula (currname, currvalue, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell,operator1, operator2, operator3, operator4, operator5, operator6, f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6,std_buy, std_sell, spe_buy, spe_sell, ext_buy, ext_sell) Values ('" & Me.Session("currName") & "','" & lblGlovalVal1.Text & "','" & txtStanBuy.Text & "', '" & txtStanSell.Text & "', '" & txtSpecBuy.Text & "','" & txtSpecSell.Text & "', '" & txtExtraBuy.Text & "', '" & txtExtraSell.Text & "','" & drpop1.Text & "','" & drpop2.Text & "','" & drpop3.Text & "' ,'" & drpop4.Text & "','" & drpop5.Text & "','" & drpop6.Text & "','" & drpfix1.Text & "','" & drpfix2.Text & "','" & drpfix3.Text & "','" & drpfix4.Text & "','" & drpfix5.Text & "','" & drpfix6.Text & "','" & GridView1.Rows(0).Cells(0).Text & "', '" & GridView1.Rows(0).Cells(1).Text & "','" & GridView1.Rows(0).Cells(2).Text & "','" & GridView1.Rows(0).Cells(3).Text & "','" & GridView1.Rows(0).Cells(4).Text & "','" & GridView1.Rows(0).Cells(5).Text & "');"
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
            ls.ConnectDatabase()
            sql4 = "Insert into mlforexrate.globallogs (currname, stan_buy, stan_sell, spe_buy, spe_sell, extra_buy, extra_sell, modifier, fetchrate) Values ('" & Me.Session("currName") & "','" & Me.Session("st_buy") & "', " & _
                    "'" & Me.Session("st_sell") & "','" & Me.Session("sp_buy") & "','" & Me.Session("sp_sell") & "','" & Me.Session("ex_buy") & "','" & Me.Session("ex_sell") & "','" & Me.Session("xxxcheckLoginInfo") & "','" & lblGlovalVal1.Text & "'); "
            getLogs(sql4)
            'Else
            'ls.ConnectDatabase()
            'sql = "update mlforexrate.globallogs set fetchrate='" & lblGlovalVal1.Text & "', stan_buy='" & Me.Session("st_buy") & "',stan_sell='" & Me.Session("st_sell") & "',spe_sell='" & Me.Session("sp_sell") & "',extra_buy='" & Me.Session("ex_buy") & "',extra_sell='" & Me.Session("ex_sell") & "',modifier='" & Me.Session("xxxcheckLoginInfo") & "' where currname='" & Me.Session("currName") & "' and date_format(systemcreated, '%Y/%m/%d')=date_format(now(), '%Y/%m/%d');"
            'getLogs(sql)
            'End If
            '-----------------------------

        Catch ex As Exception

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
                sql = "update mlforexrate.forexoverride set currency = '" & Me.Session("currName") & "', stan_sell='" & Me.Session("st_sell") & "', stan_buy='" & Me.Session("st_buy") & "', spe_sell='" & Me.Session("sp_sell") & "', spe_buy='" & Me.Session("sp_buy") & "', extra_sell='" & Me.Session("ex_sell") & "', extra_buy='" & Me.Session("ex_buy") & "', modified='" & Me.Session("xxxcheckLoginInfo") & "', systemmodified=now(), status='Manual' where currency='" & Me.Session("currName") & "'"
                getLogs(sql)
            Else
                ls.ConnectDatabase()
                sql = "insert into mlforexrate.forexoverride (currency, stan_sell, stan_buy, spe_sell, spe_buy, extra_sell, extra_buy, modified, systemmodified, status, modifier) values ('" & Me.Session("currName") & "', '" & Me.Session("st_sell") & "', '" & Me.Session("st_buy") & "', '" & Me.Session("sp_sell") & "', '" & Me.Session("sp_buy") & "', '" & Me.Session("ex_sell") & "', '" & Me.Session("ex_buy") & "', '" & Me.Session("xxxcheckLoginInfo") & "', now(), 'Manual', '" & Me.Session("xxxcheckLoginInfo") & "'); "
                getLogs(sql)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub getLogs(ByVal mysql As String)
        Try
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            ls.DisconnectDatabase()
        Catch ex As Exception
            lbInfor.Text = ex.Message
        End Try
    End Sub
    Public Sub getdata(ByVal mysql As String)
        Try
            addapter = New MySqlDataAdapter(mysql, connect.myDal.ConnectionString)
            tb = New DataTable
            addapter.Fill(tb)
            Me.GridView1.DataSource = tb
            Me.GridView1.DataBind()

            ls.DisconnectDatabase()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sPath = Server.MapPath("..\Bin\kpForex.ini")
        ls.ReadINI(sPath)


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
        ssql = "select currname, operator1, operator2, operator3, operator4, operator5, operator6, f_operator1, f_operator2, f_operator3, f_operator4, f_operator5, f_operator6,currvalue, for_std_buy, for_std_sell, for_spc_buy, for_spc_sell, for_ext_buy, for_ext_sell from mlforexrate.fomula where currname ='" & Me.Session("currName") & "';"
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

            drpfix1.Text = tb(0).Item(7).ToString
            drpfix2.Text = tb(0).Item(8).ToString
            drpfix3.Text = tb(0).Item(9).ToString
            drpfix4.Text = tb(0).Item(10).ToString
            drpfix5.Text = tb(0).Item(11).ToString
            drpfix6.Text = tb(0).Item(12).ToString

            txtStanBuy.Text = tb(0).Item(14).ToString
            txtStanSell.Text = tb(0).Item(15).ToString
            txtSpecBuy.Text = tb(0).Item(16).ToString
            txtSpecSell.Text = tb(0).Item(17).ToString
            txtExtraBuy.Text = tb(0).Item(18).ToString
            txtExtraSell.Text = tb(0).Item(19).ToString


        End If
        ls.DisconnectDatabase()
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
            Dim globalSQL, globalOfficialSQL As String

            If Me.Session("ident") = "0" Then
                globalSQL = "UPDATE mlforexrate.globalrates SET identifier='1' where currency='" & Me.Session("currName") & "'"
                globalOfficialSQL = "UPDATE mlforexrate.globalforexrates SET identifier='1' where currname='" & Me.Session("currName") & "'"

                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(globalSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)

                addapter = New MySqlDataAdapter(globalOfficialSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                Dim st As String = "alert('Successfully saved as Official currency!');location='ForexSettings.aspx';"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "key", st, True)

                'lblMsgOff.Text = "Successfully"
            Else
                globalSQL = "UPDATE mlforexrate.globalrates SET identifier='0' where currency='" & Me.Session("currName") & "'"
                globalOfficialSQL = "UPDATE mlforexrate.globalforexrates SET identifier='0' where currname='" & Me.Session("currName") & "'"

                ls.ConnectDatabase()
                addapter = New MySqlDataAdapter(globalSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)

                addapter = New MySqlDataAdapter(globalOfficialSQL, connect.myDal.ConnectionString)
                tb = New DataTable
                addapter.Fill(tb)
                ls.DisconnectDatabase()

                Dim st As String = "alert('Successfully saved as Unofficial currency!');location='ForexSettings.aspx';"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "key", st, True)
            End If

            btnCancel.Text = "Back"
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "Save", "alert('" & ex.Message & "');", True)
        End Try
    End Sub
End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         