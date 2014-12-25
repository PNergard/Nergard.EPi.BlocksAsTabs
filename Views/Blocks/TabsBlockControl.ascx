<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TabsBlockControl.ascx.cs" Inherits="BlocksAsTabs.Views.Blocks.TabsBlockControl" %>

<asp:Repeater runat="server" ID="Tabbarna">
    <HeaderTemplate>
        <div class="widget tabs">
            <ul class="nav nav-tabs">
    </HeaderTemplate>
    <ItemTemplate>
        <li <%# Container.ItemIndex == 0 ? "class='active'" : ""%>>
<a href="#tab_<%#((EPiServer.Core.ContentAreaItem)Container.DataItem).ContentLink %>" data-toggle="tab"><%#TabName(((EPiServer.Core.ContentAreaItem)Container.DataItem)) %></a>
        </li>
    </ItemTemplate>
        
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>

<asp:Repeater runat="server" ID="TabbarnaContent">
    <HeaderTemplate>
        <div class="tab-content">

    </HeaderTemplate>

    <ItemTemplate>     
        <div class="tab-pane <%# Container.ItemIndex == 0 ? "active" : ""%>" id="tab_<%#((EPiServer.Core.ContentAreaItem)Container.DataItem).ContentLink %>">
            <EPiServer:Property  runat="server" ID="BlockPropertyControl"/>
        </div> 
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>
