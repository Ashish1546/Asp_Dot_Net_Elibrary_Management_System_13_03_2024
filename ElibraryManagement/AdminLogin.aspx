<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ElibraryManagement.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card shadow mt-2">
               <div class="card-body">                  
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Admin Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="imgs/adminuser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <div class="form-group">                       
                             <div class="form-group">
                                <asp:TextBox CssClass="form-control" Id="TextBox1" runat="server" placeholder="Username">
                                </asp:TextBox>
                            </div>                     
                            <div class="form-group">                             
                                 <asp:TextBox CssClass="form-control" Id="TextBox2" runat="server" placeholder="Password" 
                                 TextMode="Password"> </asp:TextBox>   
                            </div>
                           
                            <div class="form-group">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                            </div>                                                 
                         </div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
   </div>
</asp:Content>
