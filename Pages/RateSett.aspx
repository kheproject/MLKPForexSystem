<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RateSett.aspx.vb" Inherits="Pages_RateSett" title="Forex" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../JavaScript/disableBack.js" type="text/javascript"></script>
    <script src="../JavaScript/jsDecimals.js" type="text/javascript"></script>
    <script src="../JavaScript/IsOneDecimalPoint.js" type="text/javascript"></script>

    <style type="text/css">
        .style18
        {   height: 46px; 
        }
        .style1
        {   width: 44%;
            height: 671px;
            margin-left: 0px;
        }
        .style51
        {   height: 30px;
        }
        .style37
        {   height: 24px;
        }
        .style25
        {   height: 11px;
            width: 26px;
        }
        .style21
        {   height: 11px;
        }
        .style29
        {   height: 45px;
        }
        .style30
        {   width: 26px;
            height: 22px;
        }
        .style31
        {   width: 100%;
        }
        .style36
        {   height: 10px;
        }
        .style33
        {   width: 145%;
            height: 49px;
        }
        .style44
        {   height: 5px;
            width: 26px;
        }
        .style43
        {   height: 5px;
        }
        .style47
        {   height: 1px;
            width: 26px;
        }
        .style46
        {   height: 1px;
        }
        .style48
        {   width: 26px;
            height: 9px;
        }
        .style49
        {   width: 443px;
            height: 9px;
        }
        .style34
        {   width: 424px;
        }
        .style54
        {   height: 6px;
        }
        .style55
        {   width: 443px;
        }
        .style63
        {   height: 1px;
        }
        .style64
        {   width: 26px;
            height: 14px;
        }
        .style67
        {   height: 9px;
            width: 315px;
        }
        .style68
        {   width: 315px;
        }
        .style71
        {   width: 76px;
            height: 22px;
        }
        .style72
        {   height: 9px;
            width: 76px;
        }
        .style73
        {   width: 76px;
            height: 14px;
        }
        .style74
        {   height: 25px;
        }
        .style75
        {   height: 30px;
            width: 2270px;
        }
        .style78
        {   height: 14px;
        }
        .style79
        {   height: 22px;
        }
        .style80
        {   height: 9px;
        }
        .style81
        {   height: 45px;
            width: 315px;
        }
        .style82
        {
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="panel5" runat ="server" DefaultButton="btnSave" Width="1037px">
    <div style="text-align: center; width: 1037px;">
        <table class="style1" style="font-family: Arial; font-size: small; text-align: left; vertical-align: top; width: 1018px; height: 100%;">
            <tr>
                <td class="style51" colspan="5" style="text-align: center">
                    <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" Font-Italic="True" 
                        Font-Names="Arial" Font-Size="10pt"></asp:Label>
                </td>
                <td class="style51" colspan="5" style="text-align: center">
                    <table class="style31">
                        <tr>
                            <td class="style82">
                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Italic="True" 
                                    ForeColor="#666633" Text="Forex Rate Setting (Official)"></asp:Label>
                                <br />
                                <asp:Label ID="lblOve" runat="server" Font-Bold="True" Font-Italic="True" 
                                    Font-Size="8pt" ForeColor="#333300" Text="Edit ML Rate"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style37" colspan="5" style="text-align: left">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                        Font-Names="Berlin Sans FB Demi" Font-Size="Medium" ForeColor="#CC0000" 
                        Text="Currency Name:"></asp:Label>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                </td>
                <td class="style37" colspan="5" style="text-align: right">&nbsp;</td>
            </tr>
            <tr>
                <td class="style25"></td>
                <td class="style21" style="text-align: left">&nbsp;</td>
                <td class="style21" colspan="8" style="text-align: left">
                    <div style="background-color: #FF9933; text-align: center; width: 152px;">
                        <asp:Label ID="lblGlovalVal" runat="server" Text="USD"></asp:Label>
                        <asp:Label ID="lblequal" runat="server" Text="="></asp:Label>
                        <asp:Label ID="lblGlovalVal1" runat="server" Text="00.00000"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style29" colspan="4" style="text-align: left; vertical-align: bottom">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Maroon" Text="STANDARD RATE FORMULA"></asp:Label>
                </td>
                <td class="style81" style="text-align: left; vertical-align: bottom" colspan="2">&nbsp;</td>
                <td class="style81" style="text-align: left; vertical-align: bottom">&nbsp;</td>
                <td class="style81" style="text-align: left; vertical-align: bottom">&nbsp;</td>
                <td class="style81" style="text-align: left; vertical-align: bottom">&nbsp;</td>
                <td class="style29" style="text-align: left; vertical-align: bottom">
                    <asp:Button ID="btnPreviewRate" runat="server" Font-Bold="False" Width="193px" Font-Names="Arial" Font-Size="Small" Height="24px" Text="Preview Rate Changes"/>
                </td>
            </tr>
            <tr>
                <td class="style30" style="text-align: left">Buying:</td>
                    <td class="style71" style="text-align: left">
                        <asp:DropDownList ID="drpop1" runat="server" Width="50px" Font-Bold="True">
                            <asp:ListItem>+</asp:ListItem>
                            <asp:ListItem>-</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                
                <td class="style71" style="text-align: left;">
                    <asp:TextBox ID="txtStanBuy" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5"
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtStanBuy_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        InputDirection="RightToLeft" Mask="99.99" MaskType="Number" 
                        TargetControlID="txtStanBuy">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style79" style="text-align: left; " colspan="3">
                    <asp:DropDownList ID="drpfix1" runat="server" Height="19px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style79" style="text-align: left;">
                    &nbsp;</td>
                <td class="style79" style="text-align: left;">
                    &nbsp;</td>
                <td class="style79" style="text-align: left;">
                    &nbsp;</td>
                <td class="style31" rowspan="6" style="text-align: left; vertical-align: top;">
                    <asp:Panel ID="Panel1" runat="server" Visible="False" Width="202px">
                        <table class="style33">
                            <tr>
                                <td style="border-style: outset; border-width: medium; text-align: center;">
                                    <asp:Label ID="lbInfor" runat="server" Font-Bold="True" Font-Names="Arial" 
                                               Font-Size="10pt" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                  BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                  GridLines="Vertical" Height="37%" Width="674px">
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style36" style="text-align: left">
                    Selling:</td>
                <td class="style72">
                    <asp:DropDownList ID="drpop2" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style72">
                    <asp:TextBox ID="txtStanSell" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtStanSell_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtStanSell">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style80" colspan="3">
                <asp:DropDownList ID="drpfix2" runat="server" Height="19px" Width="120px">
                    <asp:ListItem>FIX</asp:ListItem>
                    <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="style80">
                    &nbsp;</td>
                <td class="style80">
                    &nbsp;</td>
                <td class="style80">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style63" style="text-align: left; height: 30px;" colspan="4">
                    </td>
                <td class="style67" style="text-align: left; vertical-align: top;" colspan="2">
                    &nbsp;</td>
                <td class="style67" style="text-align: left; vertical-align: top;">
                    &nbsp;</td>
                <td class="style67" style="text-align: left; vertical-align: top;">
                    &nbsp;</td>
                <td class="style67" style="text-align: left; vertical-align: top;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style36" style="text-align: left" colspan="4">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Maroon" Text="SPECIAL RATE FORMULA"></asp:Label>
                </td>
                <td class="style67" style="text-align: left; vertical-align: top;" colspan="2">
                    &nbsp;</td>
                <td class="style67" style="text-align: left; vertical-align: top;">
                    &nbsp;</td>
                <td class="style67" style="text-align: left; vertical-align: top;">
                    &nbsp;</td>
                <td class="style67" style="text-align: left; vertical-align: top;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style64" style="text-align: left">
                    Buying:</td>
                <td class="style73" style="text-align: left">
                    <asp:DropDownList ID="drpop3" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style73" style="text-align: left">
                    <asp:TextBox ID="txtSpecBuy" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtSpecBuy_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtSpecBuy">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style78" colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drpfix3" runat="server" Height="20px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style78" style="text-align: left">
                    &nbsp;</td>
                <td class="style78" style="text-align: left">
                    &nbsp;</td>
                <td class="style78" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style30" style="text-align: left">
                    Selling:</td>
                <td class="style71" style="text-align: left">
                    <asp:DropDownList ID="drpop4" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style71" style="text-align: left">
                    <asp:TextBox ID="txtSpecSell" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtSpecSell_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtSpecSell">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style79" colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drpfix4" runat="server" Height="20px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style79" style="text-align: left">
                    &nbsp;</td>
                <td class="style79" style="text-align: left">
                    &nbsp;</td>
                <td class="style79" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style54" style="text-align: left; height: 30px;" colspan="3">
                    </td>
                <td class="style75" style="text-align: left; ">
                    &nbsp;</td>
                <td class="style68" style="text-align: left" colspan="2">
                    &nbsp;</td>
                <td class="style68" style="text-align: left">
                    &nbsp;</td>
                <td class="style68" style="text-align: left">
                    &nbsp;</td>
                <td class="style68" style="text-align: left">
                    &nbsp;</td>
                <td class="style55" rowspan="2" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style74" style="text-align: left" colspan="6">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Maroon" Text="EXTRA SPECIAL RATE FORMULA"></asp:Label>
                </td>
                <td class="style74" style="text-align: left">
                    &nbsp;</td>
                <td class="style74" style="text-align: left">
                    &nbsp;</td>
                <td class="style74" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44" style="text-align: left">Buying:</td>
                <td class="style43" style="text-align: left">
                    <asp:DropDownList ID="drpop5" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style43" style="text-align: left">
                    <asp:TextBox ID="txtExtraBuy" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtExtraBuy_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtExtraBuy">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style43" colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drpfix5" runat="server" Height="20px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style47" style="text-align: left">Selling:</td>
                <td class="style46" style="text-align: left">
                    <asp:DropDownList ID="drpop6" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style46" style="text-align: left">
                    <asp:TextBox ID="txtExtraSell" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtExtraSell_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtExtraSell">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style46" colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drpfix6" runat="server" Height="20px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style54" style="text-align: left; height: 30px;" colspan="3">
                    </td>
                <td class="style75" style="text-align: left; ">
                    &nbsp;</td>
                <td class="style68" style="text-align: left" colspan="2">
                    &nbsp;</td>
                <td class="style68" style="text-align: left">
                    &nbsp;</td>
                <td class="style68" style="text-align: left">
                    &nbsp;</td>
                <td class="style68" style="text-align: left">
                    &nbsp;</td>
                <td class="style55" rowspan="2" style="text-align: left">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="style74" style="text-align: left" colspan="6">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="Maroon" Text="ORDINARY RATE FORMULA"></asp:Label>
                </td>
                <td class="style74" style="text-align: left">
                    &nbsp;</td>
                <td class="style74" style="text-align: left">
                    &nbsp;</td>
                <td class="style74" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style44" style="text-align: left">Buying:</td>
                <td class="style43" style="text-align: left">
                    <asp:DropDownList ID="drpop7" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style43" style="text-align: left">
                    <asp:TextBox ID="txtOrdBuy" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtOrdBuy_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtOrdBuy">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style43" colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drpfix7" runat="server" Height="20px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
                <td class="style43" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style47" style="text-align: left">Selling:</td>
                <td class="style46" style="text-align: left">
                    <asp:DropDownList ID="drpop8" runat="server" Width="50px" Font-Bold="True">
                        <asp:ListItem>+</asp:ListItem>
                        <asp:ListItem>-</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style46" style="text-align: left">
                    <asp:TextBox ID="txtOrdSell" runat="server" onkeypress="return IsOneDecimalPoint(event);" MaxLength="5" 
                        onkeydown="return jsDecimals(event);" Text="00.00" Width="60px"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtOrdSell_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="99.99" MaskType="Number" TargetControlID="txtOrdSell">
                    </asp:MaskedEditExtender>
                </td>
                <td class="style46" colspan="3" style="text-align: left">
                    <asp:DropDownList ID="drpfix8" runat="server" Height="20px" Width="120px">
                        <asp:ListItem>FIX</asp:ListItem>
                        <asp:ListItem>PERCENTAGE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
                <td class="style46" style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style48">
                </td>
                <td class="style49">
                    &nbsp;</td>
                <td class="style49" colspan="8">
                </td>
            </tr>
            
            <tr>
                <td class="style29" colspan="10" style="text-align: left; vertical-align: top">
                    <table class="style33">
                        <tr>
                            <td class="style34" style="text-align: left">
                                <asp:Button ID="btnSave" runat="server" Font-Bold="False" Font-Names="Arial" 
                                    Height="33px" Text="Save Formula" Width="113px" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" Font-Names="Arial" Height="33px" 
                                    Text="Cancel" Width="113px" />
                                &nbsp;<asp:Button ID="btn_01" runat="server" Font-Names="Arial" Height="33px" 
                                    Text="Make" Width="162px" />
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>
    </asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">
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