<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Utility.aspx.vb" Inherits="Pages_Utility" title="Utility Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
    <script src="../JavaScript/jsDecimals.js" type="text/javascript"></script>
    <script src="../JavaScript/my_btn.js" type="text/javascript"></script>
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
        .style22
        {
            height: 41px;
        }
        .style20
        {
            width: 106%;
        }
        .style28
        {
            color: #FF0000;
        }
        .style29
        {
            height: 12px;
        }
        .style30
        {
            height: 12px;
            width: 90px;
        }
        .style31
        {
            width: 90px;
            height: 28px;
        }
        .style32
        {
            height: 12px;
            }
        .style33
        {
            height: 28px;
        }
        .style35
        {
            height: 31px;
            font-size: small;
        }
        .style38
        {
            width: 90px;
            height: 31px;
        }
        .style40
        {
            font-size: small;
        }
        .style41
        {
            height: 12px;
            width: 90px;
            font-size: small;
        }
        .style42
        {
            height: 31px;
            width: 141px;
        }
        .style45
        {
            height: 31px;
        }
        .style46
        {
            height: 9px;
            width: 90px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="panel2" runat ="server" DefaultButton="btnSearch" Width="100%">
        <table class="style17">
            <tr>
                 <td class="style22" 
                    style="background-color: #808080; text-align: center;">
                    <b>Add / Edit Forex Web User</b>
                 </td>
            </tr>
            <tr style="background-color: #C0C0C0">
                <td style="vertical-align: top; text-align: justify; font-size: 8pt; background-color: #C0C0C0; width: 162px; font-family: Arial;">
                    <div style="text-align: justify; height: 501px; width: 580px; margin-left :90px">
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                        <br />
                        <div style="text-align: left; height: 22px;" title="Forex Rate">
                        
                            <table style="width: 74%; height: 91px;">
                                <tr>
                                    <td class="style30">
                                        <span class="style40">ID Number</span>
                                     <td class="style32" colspan="2">
                                        <asp:TextBox ID="TxtIDno" runat="server" Width="101px" AutoPostBack="True" 
                                             MaxLength="10"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="TxtIDno_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtIDno">
                                        </asp:FilteredTextBoxExtender>
                                         <asp:ImageButton ID="btnSearch" runat="server" Height="20px" 
                                             ImageUrl="~/Images/btnSearch.PNG" style="height: 16px; width: 14px" 
                                             Width="20px" ImageAlign="AbsBottom" />
                                         &nbsp;&nbsp;
                                         <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                                    </tr>
                                <tr>
                                    <td class="style41">
                                        First Name</td>
                                    <td class="style35" colspan="2">
                                        <asp:Label ID="LbFName" runat="server" 
                                            style="font-weight: 700;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style41">
                                        Middle Name</td>
                                    <td class="style35" colspan="2">
                                        <asp:Label ID="LbMName" runat="server" 
                                            style="font-weight: 700;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style41">
                                        Last Name</td>
                                    <td class="style35" colspan="2">
                                        <asp:Label ID="LbLName" runat="server" 
                                            style="font-weight: 700;"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style31">
                                        &nbsp;</td>
                                    <td class="style33" colspan="2" align="justify">
                                        <asp:CheckBox ID="CkReadonly" runat="server" 
                                            Text="Read-only access for Forex Web" style="font-size: small" 
                                            Enabled="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style38">
                                        </td>
                                    <td class="style42" align="right">
                                        <asp:Button ID="BtnSave" runat="server" Text="Save" Width="68px" />
                                    </td>
                                    <td align="left" class="style45">
                                        <asp:Button ID="BtnCancel" runat="server" Text="Clear" Width="68px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style46">
                                        </td>
                                    <td class="style14" align="left" colspan="2">
                                        <asp:Label ID="LbMsgSave" runat="server" ForeColor="Red" 
                                            style="font-size: small"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        
                        </div>
                    </div>
                </td> 
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p>
        <table class="style28">
            <tr>
                <td style="width: 100%; height: 100%">
                     <asp:ImageButton ID="btnHist" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnHist.png" style="margin-top: 0px" Width="156px" />
                     <asp:ImageButton ID="btnUtil" runat="server" Height="43px" 
                                       ImageUrl="~/Images/btnUtil.png" Width="166px"  />
                </td>
            </tr>
        </table>    
    </p>
</asp:Content>

