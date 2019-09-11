<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TimerFotografAlbumu.aspx.cs"
    Inherits="TimerFotografAlbumu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <center><table width="100%">
            <tr>
                <td colspan="2" align="left">
                    TAKIM RESİMLERİ ALBÜMÜ
                </td>
            </tr>
            <tr>
                <td width="15%" valign="top">
                    <asp:ListBox ID="listAlbumler" runat="server" AutoPostBack="True"></asp:ListBox>
                </td>
                <td width="85%" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Image ID="imgResim" runat="server" Height="300px" Width="400px" />
                            <br />
                            <asp:Button ID="btnOnceki" runat="server" Text="<< Önceki Resim" Width="130px" OnClick="btnOnceki_Click" />
                            <asp:Button ID="btnSonraki" runat="server" Text="Sonraki Resim >>" Width="130px"
                                OnClick="btnSonraki_Click" />
                            <asp:Button ID="btnDurdur" runat="server" Text="Durdur" OnClick="btnDurdur_Click" />
                            <asp:Button ID="btnBaslat" runat="server" Text="Başlat" OnClick="btnBaslat_Click" />
                            <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                            </asp:Timer>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="listAlbumler" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
            </center>
    </div>
    </form>
</body>
</html>
