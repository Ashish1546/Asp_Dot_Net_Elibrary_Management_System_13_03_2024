<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="ElibraryManagement.ViewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                    <center>
                        <h3 class="mt-1"> Book Inventory List </h3>
                    </center>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <br/>
                <div class="row">
                    <div class="card shadow">
                  <div class="card-body">                                                          
                      <div class="row">
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELibrary_DBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                          <div class="col">
                              <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                  <Columns>
                                      <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                      <ItemStyle Font-Bold="True" />
                                      </asp:BoundField>
                                      <asp:TemplateField>
                                          <ItemTemplate>
                                             <div class="container-fluid">
                                                 <div class="row">
                                                     <div class="col-md-10">
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Author - <asp:Label ID="Label2" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True"></asp:Label>
                                                                 &nbsp;| Genre -<asp:Label ID="Label3" runat="server" Text='<%# Eval("genre") %>' Font-Bold="True"></asp:Label>
                                                                 | Language -
                                                                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("language") %>' Font-Bold="True"></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Publisher -
                                                                 <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                 | Publisher Date -
                                                                 <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                 &nbsp;| Pages -
                                                                 <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Cost -
                                                                 <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                 &nbsp;| Actual Stock -
                                                                 <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                 &nbsp;| Available Stock -
                                                                 <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>
                                                             </div>
                                                         </div>
                                                         <div class="row">
                                                             <div class="col-12">
                                                                 Description -
                                                                 <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>
                                                             </div>
                                                         </div>
                                                     </div>
                                                     <div class="col-md-2">
                                                         <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                     </div>
                                                 </div>
                                             </div>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                  </Columns>
                              </asp:GridView>
                          </div>
                      </div>
                  </div>
                </div>
                </div>             
            </div>
            <center>
                <a href="homepage.aspx"><< Back to Home</a><br><br>
            </center>
       </div>
   </div> 
</asp:Content>
