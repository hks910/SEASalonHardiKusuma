<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RatingPage.aspx.cs" Inherits="SEALevel1.Views.RatingPage" %>

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
            <a href="RatingPage.aspx" class="elemenN" id="a1">REVIEW</a>
            <a href="ReservationPage.aspx" class="elemenN">RESERVATION</a>
            <a href="LogOut.aspx" class="contactUs">Log Out</a>
        </div>
    </div>
   
      <form class="form" runat="server">
    <div class="vertical-container">
           <div><h3><br /><br /><br /> <br /></h3></div>
        <div class="x">
            <section class ="container">
                <h3>Rating</h3>
                      <asp:GridView ID="RatingList" runat="server" AutoGenerateColumns="False" CssClass="rating-grid" HeaderStyle-CssClass="rating-grid-header" RowStyle-CssClass="rating-grid-row" AlternatingRowStyle-CssClass="rating-grid-alt-row">
                <Columns>
                    <asp:BoundField DataField="RatingId" HeaderText="Rating ID" SortExpression="RatingId" Visible="false"></asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName"></asp:BoundField>
                    <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate"></asp:BoundField>
                    <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment"></asp:BoundField>
                </Columns>
            </asp:GridView>


            </section>
            
        </div>

        <div class="y">
          <section class="container">
        <h3>Write Rating</h3>
      
            <div class="input-box">
                <asp:Label class="label" ID="FullNameLbl" runat="server" Text="Full Name"></asp:Label>
                <asp:TextBox ID="FullNameTxt" placeholder="Enter full name" runat="server"></asp:TextBox>
            </div>
            <div class="input-box">
                <asp:Label class="label" ID="RatingLbl" runat="server" Text="Rating 1-5"></asp:Label>
                <asp:TextBox ID="RatingTxt" runat="server" placeholder="Enter Rating" TextMode="Number"></asp:TextBox>
            </div>

            <div class="input-box">
                <asp:Label class="label" ID="CommentLbl" runat="server" Text="Comment"></asp:Label>
                <asp:TextBox ID="CommentTxt" runat="server" placeholder="Write your comment"></asp:TextBox>
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
