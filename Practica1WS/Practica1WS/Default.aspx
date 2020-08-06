<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CONSUMIR SERVICIO SOAP</h1>
        <p class="lead">Tarea 1 de laboratorio del curso Software Avanzado.</p>
        <p class="lead">Luis Carlos Valiente - 201122864</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Listar Contactos</h2>
            <p>
                <asp:Label ID="labelFiltrar" runat="server" Text="Filtrar por: "></asp:Label>
                <asp:TextBox ID="textFiltro" runat="server" Height="20px" Width="213px"></asp:TextBox><br />
                <asp:Label ID="labelCantidad" runat="server" Text="Límite: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="textCantidad" runat="server" Height="20px" Width="213px"></asp:TextBox><br />

            </p>
            <p>
                <asp:Button ID="btnListar" runat="server" Text="Listar Contactos >>" CssClass="btn btn-primary" OnClick="btnListar_Click" />
            </p>
            <p>
                <div class="panel panel-default">

                    <div class="panel-heading">Resumen de Contactos</div>
                    <div class="panel-body">
                    </div>
                    <span id="spanListadoContactos" runat="server"><asp:Label ID="labelListado" runat="server" Text=""></asp:Label></span>
                </div>
                
            </p>
            
        </div>
        <div class="col-md-4">
            <h2>Agregar Contacto</h2>
            <p>
                <asp:Label ID="labelNombre" runat="server" Text="Nombre de Contacto:"></asp:Label><br />
                <asp:TextBox ID="textNombre" runat="server" Height="20px" Width="213px"></asp:TextBox>
            </p>
            <p>
                <span id="spanAgregar" runat="server"></span>
            </p>
            <p>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar >>" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
            </p>
        </div>
        
    </div>
</asp:Content>
