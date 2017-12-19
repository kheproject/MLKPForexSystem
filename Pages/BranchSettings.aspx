<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="BranchSettings.aspx.vb" Inherits="Pages_BranchSettings" Title="Branch Rate Setting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../JavaScript/disableBack.js" type="text/javascript"></script>

    <script src="../JavaScript/jsDecimals.js" type="text/javascript"></script>

    <script src="../JavaScript/allowOnlyNumber.js" type="text/javascript"></script>
    
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style17
        {
            width: 100%;
            height: 745px;
        }
        .style18
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
            width: 100%;
            height: 85px;
        }
        .style30
        {
            height: 30px;
        }
        .style31
        {
            height: 30px;
            width: 105px;
        }
        .style35
        {
            color: #000000;
        }
        .style38
        {
            color: #000000;
        }
        .style36
        {
            /*height: 20px;*/
            font-weight: bold;
            font-size: 9pt;
            width: 130px;
        }
        .style37
        {
            color: #006600;
            font-size: 13pt;
            font-weight: 700;
        }
        .style39
        {
            height: 30px;
           
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <table class="style28">
        <tr>
            <td>
                <asp:ImageButton ID="btnSettings" runat="server" Height="43px" ImageUrl="~/Images/btnSett.png"
                    Width="166px" />
                <asp:ImageButton ID="btnHistory" runat="server" Height="43px" ImageUrl="~/Images/btnHist.png"
                    Style="margin-top: 0px" Width="156px" />
                <asp:ImageButton ID="btnLogs" runat="server" Height="43px" ImageUrl="~/Images/btnLogs.png"
                    Width="166px" />
                <asp:ImageButton ID="btnGlobal" runat="server" Height="43px" ImageUrl="~/Images/btnGlobal.png"
                    Width="156px" />
                <asp:ImageButton ID="btnBranchSet" runat="server" Height="43px" ImageUrl="~/Images/btnBranchSet.png"
                    Width="156px" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>

    <table class="style17">
        <tr>
            <td class="style39" style="background-color: #808080; text-align: center;">
            <div align="center">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">                                  
                            <ContentTemplate>
                                <asp:Label ID="LbMsgSave" runat="server" ForeColor="White" 
                                    style="font-size: large; font-weight: 700;" Font-Size="Larger"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
            </td>
        </tr>
        <tr style="background-color: #C0C0C0">
            <td style="vertical-align: top; text-align: justify; font-size: 8pt; background-color: #C0C0C0;
                width: 162px; font-family: Arial;">
                <div style="text-align: justify; height: 501px; width: 580px; margin-left: 100px">
                    <div class="style37">
                        Branch Rate Setting</div>
                    <br />
                    <table style="width: 86%;">
                        <tr>
                            <td class="style36">
                                Branch Name
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DrpBranchName" runat="server" AutoPostBack="True" ToolTip="Select Branch">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style36">
                                Branch Code
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="LbBCode" runat="server" Style="font-size: 9pt;"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style36">
                                Forex Classification
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="LbForexClass" runat="server" Style="font-size: 9pt;"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table style="width: 86%;">
                            <tr>
                                <td class="style30" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Panel ID="Panel1" runat="server" Style="color: #0000FF; font-weight: 700; font-size: 9pt;"
                                                Visible="False">
                                                <span>Forex Option:</span><table style="width: 100%;">
                                                    <tr>
                                                        <td class="style36">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbAutomate" runat="server" Style="color: #000000" Text="Automate"
                                                                        AutoPostBack="True" Enabled="False" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:CheckBox ID="ckbManual" runat="server" Style="color: #000000" Text="Manual"
                                                                        AutoPostBack="True" Enabled="False" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblEffective" runat="server" Text="Effective Date And Time" ForeColor ="Black"></asp:Label>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: left">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblDate" runat="server" Font-Bold="False" Style="color: #000000"></asp:Label>
                                                                    <asp:TextBox ID="txtEffectiveDate" runat="server" Visible="False"></asp:TextBox>
                                                                    <asp:Label ID="lblFormat" runat="server" Font-Bold="False" 
                                                                        Style="color: #000000" Text ="[mm/dd/yyyy hh:mm:ss]" Font-Italic="True" 
                                                                        Visible="False"></asp:Label>
                                                                    <asp:MaskedEditExtender ID="txtEffectiveDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                        Enabled="True" Mask="99/99/9999 99:99:99" MaskType="DateTime" TargetControlID="txtEffectiveDate">
                                                                    </asp:MaskedEditExtender>
                                                                    
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                            <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlToValidate="txtEffectiveDate"
                                                                        ControlExtender="txtEffectiveDate_MaskedEditExtender" IsValidEmpty="False" EmptyValueMessage="Input Date and Time"
                                                                        InvalidValueMessage="Inputted date time not valid" Enabled="False">
                                                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:MaskedEditValidator>
                                                                   </ContentTemplate>
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style35">
                                                            Currency Name
                                                        </td>
                                                        <td class="style38">
                                                            Forex Rate
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                            <asp:Label ID="lblCurName" runat="server" Font-Bold="False" Style="color: #000000"
                                                                Text="USD"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    &nbsp;<asp:TextBox ID="txtValue" runat="server" ToolTip="Forex Rate Value" ReadOnly="True"
                                                                        BackColor="#EDEAE1" Width="60px"></asp:TextBox>
                                                                    <asp:MaskedEditExtender ID="txtValue_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                                        Enabled="True" Mask="99.99" MaskType="Number" TargetControlID="txtValue">
                                                                    </asp:MaskedEditExtender>                                             
                                                                    <asp:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlToValidate="txtValue"
                                                                     ControlExtender="txtValue_MaskedEditExtender" IsValidEmpty="False" EmptyValueMessage="Please supply a correct value"
                                                                        InvalidValueMessage="Please supply a correct value" Enabled="True">&nbsp;&nbsp;
                                                                    </asp:MaskedEditValidator>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                       <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit Branch Rate Setting" Enabled="False"
                                    ToolTip="Edit Branch Rate" />
                                <asp:Button ID="btnSave" runat="server" Text="Save Branch Rate Setting" ToolTip="To Save Branch Rate"
                                    Enabled="False" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" ToolTip="To clear the Data"
                                    Enabled="False" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
