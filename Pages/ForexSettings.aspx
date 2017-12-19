<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ForexSettings.aspx.vb" Inherits="Pages_ForexSettings" title="Forex Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
    <style type="text/css">

        .style28
        {
            width: 100%;
            height: 85px;
        }
        .style17
        {
            width: 100%;
            height: 745px;
        }
        .style25
        {
            height: 72px;
        }
        .style26
        {
            height: 224px;
        }
        .style27
        {
            height: 12px;
        }
        .style29
        {
            width: 172px;
        }
        .style30
        {
            width: 333px;
        }
        .style38
        {
            height: 22px;
        }
        .style39
        {
            height: 28px;
        }
        .style40
        {
            width: 172px;
            height: 28px;
        }
        .style41
        {
            width: 354px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style17">
    <tr>
        <td class="style18" 
                    style="text-align: center; background-color: #808080">
            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Names="Arial" Font-Size="10pt"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: left">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#001130" 
                        Text="Forex Rate Settings (Official)" Font-Names="Arial" 
                Font-Size="13pt" Font-Strikeout="False"></asp:Label>
                    &nbsp;
                   
                   
                </td>
    </tr>
    <tr>
        <td style="text-align: left">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: left; background-color: #4A3C8C;">
            <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Arial" 
                Font-Size="10pt" ForeColor="White" Text="M L GLOBAL RATES"></asp:Label>
                   
                   
                </td>
    </tr>
    <tr>
        <td class="style25" 
                    
                    style="border-style: none none groove none; border-width: medium; vertical-align: top; text-align: left;">
            <table class="style28">
                <tr>
                    <td class="style41">
                    
                    
                     <%-- EUR--%>
                    <asp:panel runat="server" ID="pn_01" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="Label11" runat="server" Text="EUR " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
&nbsp;&nbsp;<asp:Label ID="lblEUR" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Arial" 
                            Font-Size="10pt" Text="00.00000"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Arial" Font-Size="10pt">Automate</asp:LinkButton>
                        &nbsp;<br />
                        </asp:panel>
                         <%-- GBP--%>
                         <asp:Panel runat="server" ID="pn_02" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="Label13" runat="server" Text="GBP " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
                        &nbsp;&nbsp;<asp:Label ID="lblGBP" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" 
                            Text="00.00000"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton4" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Arial" Font-Size="10pt">Automate</asp:LinkButton>
                        <br />
                        </asp:Panel>
                         <%-- JPY--%>
                        <asp:Panel runat="server" ID="pn_03" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="Label15" runat="server" Text="JPY " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="lblJPY" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="9pt" Text="00.00000"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton6" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton5" runat="server" Font-Names="Arial" Font-Size="10pt">Automate</asp:LinkButton>
                        <br />
                        </asp:Panel>
                         <%-- KRW--%>
                         <asp:Panel runat="server" ID="pn_04" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="Label16" runat="server" Text="KRW " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="lblKRW" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="9pt" Text="00.00000"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton8" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton7" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Automate</asp:LinkButton>
                        </asp:Panel>
                    <%-- SGD--%>
                    <asp:Panel runat="server" ID="pn_06" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="Label19" runat="server" Text="SGD " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="lblSGD" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="9pt" Text="00.00000"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton12" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton11" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Automate</asp:LinkButton>
                    </asp:Panel>
                   
                         <%-- USD--%>
                          <asp:Panel runat="server" ID="pn_05" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="Label17" runat="server" Text="USD " Font-Names="Arial" 
                            Font-Size="9pt" Font-Overline="False"></asp:Label>
                    &nbsp;&nbsp;<asp:Label ID="lblUSD" runat="server" Font-Bold="True" Font-Names="Arial" 
                            Font-Size="10pt" Text="00.00000"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton10" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton9" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Automate</asp:LinkButton>
                    </asp:Panel>
                   
                    
                    
                    
                    
                      <%-- OTHERs--%>
                    <asp:Panel runat="server" ID="pn1" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="lblNewCurr1" runat="server" Text="OTHER " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
                        &nbsp;&nbsp;&nbsp;<asp:Label ID="lblNewRate1" runat="server" Font-Bold="True" 
                            Font-Names="Arial" Font-Size="10pt" Text=" 00.00000"> </asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton13" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Override</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="LinkButton14" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Automate</asp:LinkButton>
                        </asp:Panel>
                         <%-- ALL--%>
                        <asp:Panel runat="server" ID="pn2" Visible="False" HorizontalAlign="Left">
                        <asp:Label ID="lblNewCurr2" runat="server" Text="ALL " Font-Names="Arial" 
                            Font-Size="9pt"></asp:Label>
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblNewRate2" runat="server" Font-Bold="True" 
                                Font-Names="Arial" Font-Size="9pt" Text=" 00.00000"> </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton15" runat="server" Font-Names="Arial" 
                                Font-Size="10pt">Override</asp:LinkButton>
                            &nbsp;|
                        <asp:LinkButton ID="LinkButton16" runat="server" Font-Names="Arial" 
                            Font-Size="10pt">Automate</asp:LinkButton>
                        </asp:Panel>
                    
                    
                    
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Panel ID="Panel4" runat="server" Visible="False">
                            <table class="style28">
                                </tr>
                                    <td class="style30" rowspan="4">
                                        <table class="style28" style="border-style: outset; border-width: thick">
                                            <tr style="text-align: center">
                                                <td colspan="4">
                                                    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                        Font-Size="10pt" Text="Are you sure you want to Automate"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style38">
                                                </td>
                                                <td class="style38" colspan="2" style="text-align: center">
                                                    <asp:Label ID="lblCurrname0" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                        Font-Size="10pt" ForeColor="Red"></asp:Label>
                                                </td>
                                                <td class="style38">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td style="text-align: Right">
                                                    <asp:Button ID="btnOK0" runat="server" Text="Yes" Width="69px" />
                                                </td>
                                                <td style="text-align: Left">
                                                    <asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="68px" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr>
        <td 
                    
                    
            style="border: medium outset #C0C0C0; vertical-align: top; text-align: left;">
                
        </td>
    </tr>
    <tr>
        <td class="style26" 
            style="text-align: left; vertical-align: top; border-bottom-style: groove; border-bottom-width: medium;">
            <asp:Panel ID="Panel1" runat="server" Height="100%" Width="1124px" ScrollBars="Vertical">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                                CellPadding="3" CellSpacing="1" 
                                DataKeyNames="currname,global_rate,average_globalrate,stan_buy,stan_sell,spe_buy,spe_sell,extra_buy,extra_sell,ord_buy,ord_sell,modified" 
                                Font-Names="Arial" Font-Size="8pt" GridLines="None" Height="72%" 
                                Width="100%" EnableModelValidation="True">
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" Wrap="False" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowCancelButton="true" HeaderText="Action"
                                     ShowEditButton="true" />
                        <asp:CommandField ButtonType="Button" SelectText="Override"  HeaderText="Action"
                                     ShowSelectButton="true" />
                        <asp:TemplateField HeaderText="Currency" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#Eval("currname")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ML" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("global_rate")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtglobal" runat="server" Text='<%#Eval("global_rate")%>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Xignite" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("average_globalrate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("stan_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStanBuy" runat="server" Text='<%#Eval("stan_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                             <ItemStyle HorizontalAlign="right" />
                             <ItemTemplate>
                                <%#Eval("stan_sell")%>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStanSell" runat="server" Text='<%#Eval("stan_sell")%>' />
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("spe_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSpecBuy" runat="server" Text='<%# Eval("spe_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("spe_sell")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSpecSell" runat="server" Text='<%# Eval("spe_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("extra_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtExtBuy" runat="server" Text='<%# Eval("extra_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("extra_sell")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtExtSell" runat="server" Text='<%# Eval("extra_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("ord_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtOrdBuy" runat="server" Text='<%# Eval("ord_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("ord_sell")%>                                
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtOrdSell" runat="server" Text='<%# Eval("ord_sell")%>' />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Modified" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#Eval("modified")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Modified By">
                            <ItemTemplate>
                                <%#Eval("modifier")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("status")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <br />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="style27" style="text-align: left; vertical-align: top">
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#001130" 
                        Text="Forex Rate Settings (Unofficial)" Font-Names="Arial" 
                        Font-Size="13pt"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style27" style="text-align: left; vertical-align: top">
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <table class="style28">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style29">
                                &nbsp;</td>
                            <td class="style30" rowspan="4">
                                <table class="style28" style="border-style: outset; border-width: thick">
                                    <tr style="text-align: center">
                                        <td colspan="4">
                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                Font-Size="10pt" Text="Are you sure you want to make"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Label ID="lblCurrname" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                Font-Size="10pt" ForeColor="Red"></asp:Label>
                                            &nbsp;<asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                Font-Size="10pt" Text="Official?"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td style="text-align: Right">
                                            <asp:Button ID="btnOK" runat="server" Text="Yes" Width="69px" />
                                        </td>
                                        <td style="text-align: Left">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="68px" />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style39">
                                </td>
                            <td class="style40">
                                </td>
                            <td class="style39">
                                </td>
                            <td class="style39">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style29">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style29">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
        </td>
    </tr>
    <tr style="width: 100%; height: 100%">
        <td class="style24" 
                    style="text-align: left; vertical-align: top; width: 100%; height: 95%;">
            <asp:Panel ID="Panel3" runat="server" Height="90%" Width="1120px" 
                         ScrollBars="Vertical">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                             BackColor="White" BorderColor="White" 
    BorderStyle="Ridge" BorderWidth="2px" 
                             CellPadding="3" CellSpacing="1" 
                             DataKeyNames="currname,global_rate,average_globalrate" 
                             Font-Names="Arial" Font-Size="8pt" 
    GridLines="None" Height="72%" 
                    Width="100%" EnableModelValidation="True">
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" Wrap="False" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowCancelButton="true" HeaderText="Action"
                                     ShowEditButton="true" />
                        <asp:TemplateField HeaderText="Currency" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%#Eval("currname")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="ML" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("global_rate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Xignite" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("average_globalrate")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("stan_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStanBuy0" runat="server" Text='<%#Eval("stan_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                          
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("stan_sell")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStanSell0" runat="server" Text='<%#Eval("stan_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("spe_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSpecBuy0" runat="server" Text='<%# Eval("spe_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("spe_sell")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSpecSell0" runat="server" Text='<%# Eval("spe_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                     HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("extra_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtExtBuy0" runat="server" Text='<%# Eval("extra_buy")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                            <ItemTemplate>
                                <%#Eval("extra_sell")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtExtSell0" runat="server" Text='<%# Eval("extra_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Buying">
                            <ItemStyle HorizontalAlign="right" />
                           <ItemTemplate>
                                <%#Eval("ord_buy")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtOrdBuy0" runat="server" Text='<%# Eval("ord_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Selling">
                            <ItemStyle HorizontalAlign="right" />
                           <ItemTemplate>
                                <%#Eval("ord_sell")%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtOrdSell0" runat="server" Text='<%# Eval("ord_sell")%>' />
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Last Modified">
                            <ItemTemplate>
                                <%#Eval("modified")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Modified By">
                            <ItemTemplate>
                                <%#Eval("modifier")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                            <ItemTemplate>
                                <%#Eval("status")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                </asp:GridView>
                <br />
            </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>