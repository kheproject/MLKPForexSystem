<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OverridVal.aspx.vb" Inherits="Pages_OverridVal" title="Override Rates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
    <style type="text/css">
        .style28
        {
            width: 100%;
        }
        .style29
        {
        }
        .style30
        {
            width: 240px;
            height: 137px;
        }
        .style31
        {
            height: 137px;
        }
        .style32
        {
            height: 85px;
        }
        .style33
        {
            width: 388px;
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
    <div>
        <table class="style28">
            <tr>
                <td class="style32" colspan="2" style="text-align: center">
                    <table class="style28">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style33">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td class="style33" 
                                style="border-style: none; border-color: #C0C0C0 #C0C0C0 #000000 #C0C0C0">
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style30" style="text-align: right">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Official Value:"></asp:Label>
                </td>
                <td class="style31">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                                CellPadding="3" CellSpacing="1" DataKeyNames="currname" Font-Names="Arial" 
                                Font-Size="8pt" GridLines="None" Height="72%" Width="100%">
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" Wrap="False" />
                                <Columns>
                                   
                                    <asp:TemplateField HeaderText="Currency Name">
                                        <ItemTemplate>
                                            <%#Eval("currname")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                                        <ItemTemplate>
                                            <%#Eval("stan_buy")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                                        <ItemTemplate>
                                            <%#Eval("stan_sell")%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                                        <ItemTemplate>
                                            <%#Eval("spe_buy")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                                        <ItemTemplate>
                                            <%#Eval("spe_sell")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                                        <ItemTemplate>
                                            <%#Eval("extra_buy")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                                        <ItemTemplate>
                                            <%#Eval("extra_sell")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Last Modified">
                                        <ItemTemplate>
                                            <%#Eval("modified")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Modified By">
                                        <ItemTemplate>
                                            <%#Eval("modifier")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                                        <ItemTemplate>
                                            <%#Eval("status")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                </Columns>
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                        </td>
            </tr>
            <tr>
                <td class="style29" colspan="2" 
                    style="text-align: right; background-color: #808080;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style29" style="text-align: right">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Override Value:"></asp:Label>
&nbsp;</td>
                <td>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" 
                                CellPadding="3" CellSpacing="1" DataKeyNames="currency,stan_sell,stan_buy,spe_sell,spe_buy,extra_sell,extra_buy,systemmodified,modifier,status" Font-Names="Arial" 
                                Font-Size="8pt" GridLines="None" Height="72%" Width="100%">
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" Wrap="False" />
                                <Columns>
                                   
                                    <asp:TemplateField HeaderText="Currency Name">
                                        <ItemTemplate>
                                            <%#Eval("currency")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                                        <ItemTemplate>
                                            <%#Eval("stan_buy")%>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                                        <ItemTemplate>
                                            <%#Eval("stan_sell")%>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                                        <ItemTemplate>
                                            <%#Eval("spe_buy")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                                        <ItemTemplate>
                                            <%#Eval("spe_sell")%>
                                        </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Buying">
                                        <ItemTemplate>
                                            <%#Eval("extra_buy")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Selling">
                                        <ItemTemplate>
                                            <%#Eval("extra_sell")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="System Modified">
                                        <ItemTemplate>
                                            <%#Eval("systemmodified")%>
                                        </ItemTemplate>
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Modified By">
                                        <ItemTemplate>
                                            <%#Eval("modifier")%>
                                        </ItemTemplate>
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Status">
                                        <ItemTemplate>
                                            <%#Eval("status")%>
                                        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateField>
                                    
                                </Columns>
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                            </asp:GridView>
                            <br />
                            <asp:Label ID="lblmsg1" runat="server" Font-Bold="True" ForeColor="Red" 
                                BorderStyle="Groove"></asp:Label>
                            <asp:LinkButton ID="LinkButton1" runat="server">Click here</asp:LinkButton>
                        </td>
            </tr>
            <tr>
                <td class="style29" style="text-align: right">
                    &nbsp;</td>
                <td style="vertical-align: middle; text-align: left">
                            <br />
                            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Height="31px" Text="Save and Override" Width="142px" />
                            <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Names="Arial" 
                                Height="31px" Text="Cancel" Width="142px" />
                            <br />
                        </td>
            </tr>
        </table>
    </div>
</asp:Content>

