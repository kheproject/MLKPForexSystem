<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Global Rate.aspx.vb" Inherits="Pages_Global_Rate" title="Global Rate Logs" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">

    <script src="../JavaScript/jsDecimals.js" type="text/javascript"></script>
    <script src="../JavaScript/allowOnlyNumber.js" type="text/javascript"></script>
     <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
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
            height: 631px;
        }
        .style22
        {
            height: 41px;
        }
        .style20
        {
            width: 106%;
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
            height: 22px;
            color: #FF0000;
            font-size: medium;
        }
        .style24
        {
            height: 25px;
        }
        .style30
        {
            height: 44px;
            width: 100%;
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
                                 <td class="style30" colspan="2">
                                     <span class="style27">*</span><b>Currency</b><br />
                                     <asp:DropDownList ID="drpcurr" runat="server" Height="24px" Width="167px">
                                     </asp:DropDownList>
                                 </td>
                             </tr>
                             <tr>
                                 <td class="style24" colspan="2" style="width: 100%">
                                     <b>Month</b><br />
                                     <asp:DropDownList ID="drpMonth" runat="server" Height="20px" Width="129px">
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
                                 <td class="style24" colspan="2" style="width: 100%; font-weight: 700;">
                                     Year<br />
                                     <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Height="15px"
                                         onkeydown="return allowOnlyNumber(event);" Width="100px"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="txtYear_FilteredTextBoxExtender" 
                                         runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtYear">
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
                         Note: All data are sorted according to logs created in ascending order.<br />
                     </div>
                 </div>
             
             </td>
                <td class="style18" 
                    style="background-color: #808080; text-align: center;">
                    <table class="style21">
                        <tr>
                            <td style="border-style: groove; border-width: medium; text-align: left; vertical-align: top; background-color: #C0C0C0; height: 640px;">
                    
                     <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="100%" Width="100%">
                  
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="None"
                        Font-Names="Arial" Font-Size="9pt" DataKeyNames="Currency" 
                        AutoGenerateColumns="False" 
                        Height="48%" Width="100%" ForeColor="#333333">
                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Wrap="False" />
                   
                   <Columns>
                    
                     <asp:TemplateField HeaderText="System Created">
                      <ItemTemplate>
                        <%#Eval("systemcreated")%>
                      </ItemTemplate>
                     </asp:TemplateField>                
                                        
                    <asp:TemplateField HeaderText="Currency">
                      <ItemTemplate>
                        <%#Eval("Currency")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                   <asp:TemplateField HeaderText="Rate">
                      <ItemTemplate>
                        <%#Eval("Rate")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                        
                   <asp:TemplateField HeaderText="Modified By">
                      <ItemTemplate>
                        <%#Eval("modifier")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    
                   <asp:TemplateField HeaderText="Remarks">
                      <ItemTemplate>
                        <%#Eval("remarks")%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    
                    </Columns>
                     <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                     <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                          <AlternatingRowStyle BackColor="White" />
                   </asp:GridView>
                  
                    
                         <br />
                         <div style="text-align: center">
                             <asp:Label ID="lblmsg1" runat="server" Font-Bold="True" Font-Italic="True" 
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

<asp:Content ID="Content4" runat="server" 
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


