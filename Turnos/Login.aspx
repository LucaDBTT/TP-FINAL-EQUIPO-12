﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Turnos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="card-login">
    <div class="login-container">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <div>
                    <h2 class="Profesionales">Iniciar Sesión</h2>
                        <div class="form-group">
                            <label for="txtUsername">Nombre de Usuario:<br />
                            <asp:TextBox ID="txtUser" runat="server" ></asp:TextBox>
                            </label>  
                        </div>
                        <div class="form-group">
                            <label for="txtPassword">Contraseña:</label>
                            <br />
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                        </div>   
                    <asp:Button runat="server" ID="Button1" Text="Ingresar" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    <asp:Button runat="server" ID="btnRegistrarse" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>
