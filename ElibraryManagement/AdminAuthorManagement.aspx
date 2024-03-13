<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminAuthorManagement.aspx.cs" Inherits="ElibraryManagement.AdminAuthorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>    
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container mt-2 mb-2">
      <div class="row">
         <div class="col-md-5">
            <div class="card shadow">
               <div class="card-body">                 
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Author Details</h4>     
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <img src="imgs/writer.png" width=100px" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Author ID</label>
                        <div class="form-group">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                <asp:Button class="btn btn-primary ml-1" ID="Button2" runat="server" Text="GO" OnClick="Button2_Click" />
                            </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>Author Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Author Name" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                      <div class="col-4 ">
                          <asp:Button CssClass="btn btn-lg btn-block btn-success" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                      </div>
                      <div class="col-4 ">
                          <asp:Button CssClass="btn btn-lg btn-block btn-warning" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                      </div>
                      <div class="col-4 ">
                          <asp:Button CssClass="btn btn-lg btn-block btn-danger" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                      </div>
                  </div>
                  
                </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>

          <div class="col-md-7">
              <div class="card shadow">
                  <div class="card-body">                      
                      <div class="row">                        
                          <div class="col">
                              <center>
                                  <h4>Author List</h4>
                              </center>
                          </div>
                      </div>
                      <div class="row">
                         <div class="col">
                             <hr>
                        </div>
                       </div>
                      <div class="row">
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELibrary_DBConnectionString %>" 
                                SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                          <div class="col">
                              <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                  <Columns>
                                      <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                      <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                  </Columns>
                              </asp:GridView>
                          </div>
                      </div>
                  </div>
                </div>
              </div>
         </div>    
      </div>
</asp:Content>
