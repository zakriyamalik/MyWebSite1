﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MyMasterPage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyWebSite1.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="ItemGrid" runat="server">
    <Columns>
        <asp:BoundField DataField="TuCampo" HeaderText="TuEncabezado">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
</asp:Content>
