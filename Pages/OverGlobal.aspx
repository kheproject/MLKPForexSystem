<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="OverGlobal.aspx.vb" Inherits="Pages_OverGlobal" title="Forex Rate Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../JavaScript/jsDecimals.js" type="text/javascript"></script>
    <script src="../JavaScript/IsOneDecimalPoint.js" type="text/javascript"></script>
     <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
    <style type="text/css">


        .style28
        {
            width: 100%;
            height: 85px;
        }
        .style29
        {
            width: 100%;
        }
        .style30
        {
            width: 40px;
        }
        .style31
        {
        }
        .style32
        {
        }
        .style34
        {
            width: 132px;
        }
        .style36
        {
            width: 132px;
            height: 54px;
        }
        .style37
        {
            width: 623px;
            height: 54px;
        }
        .style39
        {
            width: 40px;
            height: 61px;
        }
        .style40
        {
            height: 61px;
        }
        .style43
        {
            width: 623px;
        }
        .style44
        {
            width: 40px;
            height: 91px;
        }
        .style45
        {
            width: 132px;
            height: 91px;
        }
        .style46
        {
            width: 623px;
            height: 91px;
        }
        .style47
        {
            height: 91px;
        }
        .style48
        {
            width: 231px;
        }
        .style49
        {
            width: 40px;
            height: 54px;
        }
        .style50
        {
            height: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="style28">
        <tr>
            <td>
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
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="pan" runat="server" DefaultButton="btnSave">
    <div>
        <table class="style29">
            <tr>
                <td class="style39">
                </td>
                <td class="style40" colspan="2" style="text-align: left">
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <table class="style29">
                            <tr>
                                <td class="style48" 
                                
                                
                                    style="text-align: center; border-style: outset; border-width: medium; border-color: #808080 #000000 #808080 #808080">
                                    <asp:Label ID="lblMsg" runat="server" Font-Names="Arial" Font-Size="10pt" 
                        Font-Italic="True" ForeColor="Red"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td class="style40">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Italic="True" 
                        ForeColor="#666633" Text="Forex Rate Setting (Official)"></asp:Label>
                    <br />
                    <asp:Label ID="lblOve" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Size="8pt" ForeColor="#333300" Text="Override Global Rate for "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style49">
                </td>
                <td class="style36" style="vertical-align: top">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" />
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" Width="60px" />
                </td>
                <td class="style37">
                    &nbsp;</td>
                <td class="style50">
                </td>
            </tr>
            <tr>
                <td class="style30">
                    &nbsp;</td>
                <td class="style34" style="text-align: left">
                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="10pt" 
                        ForeColor="Blue" Text="GLOBAL RATE"></asp:Label>
                </td>
                <td class="style43">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style30">
                    &nbsp;</td>
                <td class="style31" colspan="2" style="text-align: left">
                    <div style="background-color: #FF9933; text-align: center; width: 152px;">
                        <asp:Label ID="lblGlovalVal" runat="server" Text="curr" Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblequal" runat="server" Text="="></asp:Label>
                        <asp:Label ID="lblGlovalVal1" runat="server" Text="00.00000"></asp:Label>
                    </div>
                    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style30">
                    &nbsp;</td>
                <td class="style34">
                    &nbsp;</td>
                <td class="style43">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style30">
                    &nbsp;</td>
                <td class="style32" colspan="2" style="text-align: left">
                    <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="10pt" 
                        ForeColor="Blue" Text="NEW GLOBAL RATE INFORMATION"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style30">
                    &nbsp;</td>
                <td class="style34" style="text-align: left">
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="10pt" 
                        Text="Rate :"></asp:Label>
                    <asp:Label ID="Label9" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td class="style43" style="text-align: left">
                    <asp:TextBox ID="txtRate" runat="server" 
                        onkeypress="return IsOneDecimalPoint(event);" MaxLength="8"
                        onkeydown="return jsDecimals(event);" Width="163px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtRate" ErrorMessage="RequiredFieldValidator" 
                        Font-Names="Arial" Font-Size="10pt">Rate must 
                    have value.</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44">
                    </td>
                <td class="style45" style="text-align: left; vertical-align: top;">
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="10pt" 
                        Text="Remarks :"></asp:Label>
                    <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="*"></asp:Label>
                </td>
                <td class="style46" style="text-align: left">
                    <asp:TextBox ID="txtRemarks" style="text-transform:uppercase" runat="server" Height="81px" Width="216px" 
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtRemarks" ErrorMessage="RequiredFieldValidator" 
                        Font-Names="Arial" Font-Size="10pt">Remarks must have value.</asp:RequiredFieldValidator>
                </td>
                <td class="style47">
                    </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
</asp:Content>

