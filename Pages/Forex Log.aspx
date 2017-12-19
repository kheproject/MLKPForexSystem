<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Forex Log.aspx.vb" Inherits="Pages_Forex_Log" title="Forex Rate Logs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../JavaScript/jsDecimals.js" type="text/javascript"></script>
 <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
    <script src="../JavaScript/allowOnlyNumber.js" type="text/javascript"></script>
    <style type="text/css">
        .style17
        {
            width: 100%;
            height: 670px;
        }
        .style18
        {
            height: 41px;
        }
        .style21
        {
            width: 100%;
            height: 670px;
        }
        .style22
        {
            height: 41px;
        }
        .style20
        {
            width: 106%;
        }
        .style24
        {
            height: 25px;
        }
        .style26
        {
            width: 107px;
            height: 30px;
        }
        .style25
        {
            height: 30px;
        }
        .style27
        {
            color: #FF0000;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
               
             
 <asp:Panel ID="panel2" runat ="server" DefaultButton="btnSearch" Width="100%">
        <table class="style17">
            <tr>
                <td class="style22" 
                    style="background-color: #808080; text-align: center;" colspan="2">
                    <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Names="Arial" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr style="background-color: #C0C0C0">
             <td style="vertical-align: top; text-align: justify; font-size: 8pt; background-color: #C0C0C0; width: 162px; font-family: Arial;">
                 <div style="text-align: justify; height: 501px; width: 180px;">
                     <br />
                     <span style="font-size: medium; font-style: italic; color: #990000; font-weight: bold">
                     Search Criteria:<br />
                     </span>
                     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                     </asp:ToolkitScriptManager>
                     <div style="text-align: left; height: 22px;" title="Forex Rate">
                         <table class="style20">
                             <tr>
                                 <td class="style24" colspan="2" style="width: 100%">
                                     <b><span class="style27">*</span>Month</b><br />
                                     <asp:DropDownList ID="dropmonth" runat="server" Height="20px" Width="140px">
                                         <asp:ListItem>January</asp:ListItem>
                                         <asp:ListItem>February</asp:ListItem>
                                         <asp:ListItem>March</asp:ListItem>
                                         <asp:ListItem>April</asp:ListItem>
                                         <asp:ListItem>May</asp:ListItem>
                                         <asp:ListItem>June</asp:ListItem>
                                         <asp:ListItem>July</asp:ListItem>
                                         <asp:ListItem>August</asp:ListItem>
                                         <asp:ListItem>September</asp:ListItem>
                                         <asp:ListItem>October</asp:ListItem>
                                         <asp:ListItem>November</asp:ListItem>
                                         <asp:ListItem>December</asp:ListItem>
                                         <asp:ListItem Selected="True"></asp:ListItem>
                                     </asp:DropDownList>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style24" colspan="2" style="width: 100%">
                                     <b><span class="style27">*</span>Year<br />
                                     </b>
                                     <asp:TextBox ID="txtSearch" runat="server" MaxLength="4" Height="15px" 
                                         onkeydown="return allowOnlyNumber(event);" Width="100px"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="txtSearch_FilteredTextBoxExtender" 
                                         runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSearch">
                                     </asp:FilteredTextBoxExtender>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style24" colspan="2" style="width: 100%">
                                     <br />
                                     <asp:Button ID="btnSearch" runat="server" style="height: 26px" Text="Search" />
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style26">
                                     &nbsp;</td>
                                 <td class="style25" style="text-align: left">
                                     &nbsp;</td>
                             </tr>
                         </table>
                         <br />
                         <br />
                         <br />
                         <br />
                         Note: All data are sorted according to logs created in ascending order.<br />
                     </div>
                 </div>
             
             </td>
                <td class="style18" 
                    
                    style="background-color: #808080; text-align: center; width: 100%; height: 640px;">
                    <table class="style21" style="width: 100%; height: 460px">
                        <tr>
                            <td style="border-style: groove; border-width: medium; text-align: left; vertical-align: top; background-color: #C0C0C0; height: 660px;">
                    
                     <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="100%" Width="100%">
                     
     
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                          BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                          CellPadding="4" Font-Names="Arial" Font-Overline="False" Font-Size="9pt" 
                          Font-Strikeout="False" Height="100%" Width="100%">
                          <RowStyle BackColor="White" ForeColor="#330099" Wrap="False" />
                          <Columns>
           
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                  HeaderText="TXN DATE">
                                  <ItemTemplate>
                                      <%#Eval("logCreated")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Currency">
                                  <ItemTemplate>
                                      <%#Eval("currname")%>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText = "Fetch Global Rate" HeaderStyle-Wrap="true" HeaderStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" >
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                    <%#Eval("fetchrate")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" Width="70px" Wrap="True" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="STD">
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                      <%#Eval("stan_buy")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SPECIAL">
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                      <%#Eval("spe_buy")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="EXTRA">
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                      <%#Eval("extra_buy")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="STD">
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                      <%#Eval("stan_sell")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="SPECIAL">
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                      <%#Eval("spe_sell")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="EXTRA">
                                  <ItemStyle HorizontalAlign="right" />
                                  <ItemTemplate>
                                      <%#Eval("extra_sell")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                               <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Modifier">
                                  <ItemTemplate>
                                      <%#Eval("Modifier")%>
                                  </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                          </Columns>
                          <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                          <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                          <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                      </asp:GridView>
                         <br />
                                <div style="text-align: center">
                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Italic="True" 
                                    Font-Names="Arial" ForeColor="Red"></asp:Label>
                                </div>
                     </asp:Panel>
                                                            
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
       </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">

                   <p style="text-align: justify; vertical-align: text-top">
                       <table class="style28">
                           <tr>
                               <td>
                                   <asp:ImageButton ID="btnSettings" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnSett.png" Width="166px" />
                                   <asp:ImageButton ID="btnHistory" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnHist.png" style="margin-top: 0px" Width="156px" />
                                   <asp:ImageButton ID="btnLogs" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnLogs.png" Width="166px" />
                                   <asp:ImageButton ID="btnGlobal" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnGlobal.png" Width="156px" />
                                   <asp:ImageButton ID="btnBranchSet" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnBranchSet.png" Width="166px" />
                               </td>
                           </tr>
                       </table>
    </p>
               
</asp:Content>


