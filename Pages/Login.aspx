<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Pages_Login" title="Login" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br />
      <br />
      <br />
      <br />
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ToolkitScriptManager>
      <br />
      <br />
      <asp:Panel ID="panel2" runat ="server" DefaultButton="btnLogin">
       <div align="center" style="height: 152px; position: static;">
           <table frame="box" 
               style="border-style: outset; border-width: thick; vertical-align: bottom;">
               <tr>
                   <td style="border-width: inherit; border-style: outset; width: 258px">
                       <table style="width: 97%; vertical-align: middle; text-align: left; height: 120px;">
                           <tr>
                               <td style="width: 80px; table-layout: auto;">
                                   Username:</td>
                               <td>
                                   <asp:TextBox ID="txtuser" style="text-transform:uppercase" runat="server" Width="154px"></asp:TextBox>
                                   
                                   <asp:FilteredTextBoxExtender ID="txtuser_FilteredTextBoxExtender" 
                                       runat="server" Enabled="True" FilterMode="InvalidChars" 
                                       InvalidChars="~`!@#$%^&amp;*()_+|-=\{}[]:&quot;&lt;&gt;?;',./" 
                                       TargetControlID="txtuser">
                                   </asp:FilteredTextBoxExtender>
                                   
                               </td>
                           </tr>
                           <tr>
                               <td style="width: 80px">
                                   Password:</td>
                               <td>
                                   <asp:TextBox ID="txtpass" runat="server" Width="154px" TextMode="Password"></asp:TextBox>
                               </td>
                           </tr>
                           <tr>
                               <td style="width: 80px">
                                   &nbsp;</td>
                               <td style="text-align: right">
                                   <asp:Button ID="btnLogin" runat="server" style="margin-left: 0px" Text="Login" 
                                       Width="64px" />
                               </td>
                           </tr>
                           <tr>
                               <td colspan="2" style="text-align: center">
                                   <asp:Label ID="msgError" runat="server" Font-Italic="False" Font-Names="Arial" 
                                       Font-Size="Small" ForeColor="Red" Text="MsgError" Visible="False"></asp:Label>
                               </td>
                           </tr>
                       </table>
                   </td>
               </tr>
           </table>
       </div>
       </asp:Panel>
</asp:Content>

