<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservationPage.aspx.cs" Inherits="SEALevel1.Views.ReservationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="responsive.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins">
    <link href="../Styles/CSS/style.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/Styles/CSS/RegisterPage.css" />
    <title>Home Page</title>
</head>
<body>
    <div class="navbar" id="navbar">
        <img src="../Styles/IMG/logo.png" alt="" class="balancing" />
        <div class="hamburger" id="burger">
            <div></div>
            <div></div>
            <div></div>
        </div>
        <div class="nav-links" id="nav-links">
            <a href="home.aspx" class="elemenN">HOMEPAGE</a>
            <a href="RatingPage.aspx" class="elemenN" id>REVIEW</a>
            <a href="" class="elemenN" id ="a1" >RESERVATION</a>
            <a href="LogOut.aspx" class="contactUs">Log Out</a>
        </div>
    </div>
   
      <form class="form" runat="server">
    <div class="vertical-container">
           <div><h3><br /><br /><br /> <br /></h3></div>
        <div class="x">
            <section class ="container">
                <h3>Reservation</h3>
            <asp:GridView ID="Reservation" runat="server" AutoGenerateColumns="False" CssClass="rating-grid" HeaderStyle-CssClass="rating-grid-header" RowStyle-CssClass="rating-grid-row" AlternatingRowStyle-CssClass="rating-grid-alt-row">
                <Columns>
                    <asp:BoundField DataField="ReservationId" HeaderText="ReservationId" SortExpression="ReservationId" Visible="false" />
                    <asp:BoundField DataField="User.FullName" HeaderText="Customer Name" SortExpression="UserId" />
                     <asp:BoundField DataField="Branch.BranchName" HeaderText="Branch" SortExpression="BranchId" />
                    <asp:BoundField DataField="Service.ServiveName" HeaderText="Name of Service" SortExpression="ServiceId" />
                    <asp:BoundField DataField="ReservationTime" HeaderText="ReservationTime" SortExpression="ReservationTime" />
                </Columns>
            </asp:GridView>

            </section>
            
        </div>

        <div class="y">
          <section class="container">
        <h3>Reservation</h3>
      
      
          <div class="input-box">
            <asp:Label class="label" ID="BranchLbl" runat="server" Text="Choose Branch"></asp:Label>
            <asp:DropDownList ID="BranchList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BranchList_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="input-box">
            <asp:Label class="label" ID="TypeOfServiceLbl" runat="server" Text="Choose type of service"></asp:Label>
            <asp:DropDownList ID="ServiceList" runat="server"></asp:DropDownList>
        </div>

            <div class="input-box">
                <asp:Label class="label" ID="DateTimeLbl" runat="server" Text="DateTime"></asp:Label>
                <asp:TextBox ID="timeTxt" runat="server" placeholder="input DateTime" TextMode="DateTimeLocal"></asp:TextBox>
            </div>

            <div class="ErrorLbl">
                <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
            </div>

            <div class="input-box">
               <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" />
            </div>
        
    </section>
        </div>

           <div class="footer">
   <div class="balancingf">
       <img src="../Styles/IMG/logo.png" alt="Logo" class="balancingF" />
       <p class="textfooter1">Beauty and Elegance Redefined</p>
   </div>
   <p class="textfooter2">
       Our Address: <br/><br>
       456 Jenderal Sudirman Street, Karet Tengsin, Tanah Abang Central Jakarta 10220
   </p>
   <p class="textfooter3">
       Our contact: <br><br>
       Thomas: 08123456789 <br>
       Sekar: 08164829372<br><br>
       <img src="../Styles/IMG/Screenshot 2023-05-26 181338.png" alt="Icon 1" class="icon">
       <img src="../Styles/IMG/Screenshot 2023-05-26 181355.png" alt="Icon 2" class="icon">
       <img src="../Styles/IMG/Screenshot 2023-05-26 181413.png" alt="Icon 3" class="icon">
       <img src="../Styles/IMG/Screenshot 2023-05-26 181451.png" alt="Icon 4" class="icon">
       <img src="../Styles/IMG/Screenshot 2023-05-26 182211.png" alt="Icon 5" class="icon">
   </p>
   <div class="copyright">
       © 2024 - SEA Salon | All Rights Reserved
   </div>
    </div>
             
    </div>
            </form>

    <script src="effect.js"></script>


</body>
</html>
