<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ElibraryManagement.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this template -->
  <link href="css/style.css" rel="stylesheet" />
  <!-- responsive style -->
  <link href="css/responsive.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="about_section ">
    <div class="container-fluid">
      <div class="row">
        <div class="img-box col-lg-8 col-md-7">
          <img src="imgs/AboutusImg.jpg" alt="" />
        </div>
        <div class="detail-box detail_box_common col-lg-4 col-md-5 text_center">
          <div class="heading_container heading_center">
            <h2>
              About Us
            </h2>
          </div>
          <p>
            It is a long established fact that a reader will be distracted by the readable content of a page when
            looking at its layout. The point of using LoremIt is a long established fact that a reader will be
            distracted by the readable content of a page when looking at its layout. The point of using Lorem
          </p>
          <a href="">
            Read More
          </a>
        </div>
      </div>
    </div>
  </section>
    
  <section class="contact_section ">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-8 map_container">
          <div class="map">
            <div id="googleMap"></div>
          </div>
        </div>
        <div class="col-md-4 detail-box detail_box_common">
          <div>
            <div class="heading_container">
              <h2>
                Get In Touch
              </h2>
            </div>
            <div class="info_contact">
              <div class="contact_link_box">
                <a href="">
                  <i class="fa fa-map-marker" aria-hidden="true"></i>
                  <span>
                    Kurla,Mumbai
                  </span>
                </a>
                <a href="">
                  <i class="fa fa-phone" aria-hidden="true"></i>
                  <span>
                    Call +91 - 8356032603
                  </span>
                </a>
                <a href="">
                  <i class="fa fa-envelope" aria-hidden="true"></i>
                  <span>
                    ashish@gmail.com
                  </span>
                </a>
              </div>
              <div class="info_social">
                <a href="">
                  <i class="fa fa-facebook" aria-hidden="true"></i>
                </a>
                <a href="">
                  <i class="fa fa-twitter" aria-hidden="true"></i>
                </a>
                <a href="">
                  <i class="fa fa-linkedin" aria-hidden="true"></i>
                </a>
                <a href="">
                  <i class="fa fa-instagram" aria-hidden="true"></i>
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
