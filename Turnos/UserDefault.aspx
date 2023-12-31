﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebMaster.Master" AutoEventWireup="true" CodeBehind="UserDefault.aspx.cs" Inherits="Turnos.UserDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExampleIndicators" class="carousel slide">
    <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
    </div>
    <div class="carousel-inner">
        <div class="carousel-item active">
        <div class="position-relative">
            <img src="https://www.galeno.com.ar/_next/image/?url=https%3A%2F%2Fcms.galeno.com.ar%2FdA%2F60b951df-5ebc-4ae2-91ed-4c286932b9ff&w=1920&q=75" class="d-block w-100" alt="Slide 1" style="height: 400px; object-fit: cover;">
            <div class="carousel-card carosuel-container">
                <div class="login-container">
                    <h5 class="card-title">Profesionales y Especialidades</h5>
                    <p class="card-text">Conoce todo nuestro personal y las especialidades que ofrecemos.</p>
                    <a href="Especialidades.aspx" class="btn btn-primary">Conocenos</a>
                </div>

               
            </div>
        </div>
    </div>
        <div class="carousel-item">
            <img src="https://www.rgpeo.com/wp-content/uploads/2020/05/AdobeStock_215071271-1024x341.jpeg" class="d-block w-100" alt="Slide 2" style="height: 400px; object-fit: cover;">
        </div>
        <div class="carousel-item">
            <img src="https://servieratulado.com/Content/images/servier_a_tu_lado_home02.jpg" class="d-block w-100" alt="Slide 3" style="height: 400px; object-fit: cover;">
        </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </button>
</div>

    <div>   
    </div>
   <div class="content-container">
        <h1 class="user-h1-custom">Necesitás un turno próximo? Reservalo en unos simples pasos</h1>
        <div class="img-container-custom">
            <div class="img-overlay-custom"></div>
            <img src="https://storage.googleapis.com/www-saludiario-com/wp-content/uploads/2022/04/15bf8db3-computadoras-porta%CC%81tiles.jpg" alt="Turno" class="img-fluid img-custom">
        </div>
        <section class="card-login-custom">
            <div class="login-container-custom">
                <h5 class="especialidades-text">Conocé nuestras especialidades y qué profesionales tenemos asignados a ellas. Elegí el que más satisfasga tus necesidades...</h5>
                <asp:Button runat="server" ID="ButtonUser" Text="Conocenos" CssClass="btn btn-primary btn-custom" OnClick="ButtonUse_Click" />
            </div>
        </section>
    </div>
</asp:Content>
