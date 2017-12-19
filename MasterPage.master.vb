
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckSessionTimeout()
        lblUserinfo.Text = Me.Session("xxxcheckLoginInfo")
    End Sub

    Private Sub CheckSessionTimeout()
        Dim int_MilliSecondsTimeReminder As Integer = (Me.Session.Timeout * 60000)
        Dim int_MilliSecondsTimeOut As Integer = (Me.Session.Timeout * 60000)
        Dim msgSession As String = "Warning: Within next 5 minutes, if you do not do anything MLKP Forex will redirect to the login page."

        Dim str_Script As String = vbCr & vbLf & "            var myTimeReminder, myTimeOut; " & vbCr & vbLf & "            clearTimeout(myTimeReminder); " & vbCr & vbLf & "            clearTimeout(myTimeOut); " & "var sessionTimeReminder = " & int_MilliSecondsTimeReminder.ToString() & "; " & "var sessionTimeout = " & int_MilliSecondsTimeOut.ToString() & ";" & "function doRedirect(){ window.location.href='../Pages/Login.aspx'; }" & vbCr & vbLf & "            myTimeReminder=setTimeout('doReminder()', sessionTimeReminder); " & vbCr & vbLf & "            myTimeOut=setTimeout('doRedirect()', sessionTimeout); "

        ScriptManager.RegisterClientScriptBlock(Me.Page, Me.[GetType](), "CheckSessionOut", str_Script, True)
    End Sub
    Protected Sub lblUserinfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblUserinfo.Load
        'If Userinfo.username = "" Or Userinfo.username Is Nothing Then
        If Me.Session("xxxcheckLoginInfo") = "" Then
            btnSignOut.Visible = False
            Label2.Visible = False
            lblSys.Visible = True
            Exit Sub
        Else
            If Me.lblUserinfo.Text = Me.Session("xxxcheckLoginInfo") Then
                btnSignOut.Visible = True
                Label2.Visible = True
                lblSys.Visible = False
            Else
                btnSignOut.Visible = False
                Label2.Visible = False
                lblSys.Visible = True
            End If
        End If
      
    End Sub
    Protected Sub btnSignOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignOut.Click
        Me.Session.Clear()
        'Me.lblUserinfo.Text = ""
        Response.Redirect("Login.aspx")
    End Sub
End Class

