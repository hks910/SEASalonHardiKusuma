<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SEALevel1.Views.home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="responsive.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins">
    <link href="../Styles/CSS/style.css" rel="stylesheet" />
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
<!-- Admin Navbar -->
        <div class="navbar" id="AdminNavbar" runat="server">
            <img src="../Styles/IMG/logo.png" alt="Logo" class="balancing">
            <div class="hamburger" id="burger">
                <div></div>
                <div></div>
                <div></div>
            </div>
            <div class="nav-links" id="nav-links">
                <a href="Homepage.aspx" class="elemenN">HOME</a>
                <a href="ServicesManagement.aspx" class="elemenN">SERVICE MANAGEMENT</a>
                <a href="BranchManagemet.aspx" class="elemenN">BRANCH MANAGEMENT</a>
                <a href="LogOut.aspx" class="contactUs">Log Out</a>
            </div>
        </div>

        <!-- Customer Navbar -->
        <div class="navbar" id="CustomerNavbar" runat="server">
            <img src="../Styles/IMG/logo.png" alt="Logo" class="balancing">
            <div class="hamburger" id="burger">
                <div></div>
                <div></div>
                <div></div>
            </div>
            <div class="nav-links" id="nav-links">
                <a href="Homepage.aspx" class="elemenN">HOMEPAGE</a>
                <a href="RatingPage.aspx" class="elemenN">REVIEW</a>
                <a href="ReservationPage.aspx" class="elemenN">RESERVATION</a>
                <a href="LogOut.aspx" class="contactUs">Log Out</a>
            </div>
        </div>
        <!-- Header -->
        <div class="header">
            <div class="img1">
                <div class="banner-carousel">
                    <div class="banner-slide active">
                        <img src="../Styles/IMG/BANNER3.jpg" alt="Banner 1">
                        <p class="headerText">SEA Salon</p>
                        <p class="headersubText">Beauty and Elegance Redefined</p>
                        <p class="seeMore">
                            Scroll down to see more information
                            <br>
                            <button class="buttond" onClick="scrollToBriefInfo()">
                                <span>scroll down</span>
                            </button>
                        </p>
                    </div>
                    <div class="banner-slide">
                        <img src="../Styles/IMG/BANNER1.png" alt="Banner 2">
                        <p class="headerText">SEA Salon</p>
                        <p class="headersubText">Beauty and Elegance Redefined</p>
                        <p class="seeMore">
                            Scroll down to see more information
                            <br>
                            <button class="buttond" onClick="scrollToBriefInfo()">
                                <span>scroll down</span>
                            </button>
                        </p>
                    </div>
                    <div class="banner-slide">
                        <img src="../Styles/IMG/BANNER2.jpg" alt="Banner 3">
                        <p class="headerText">SEA Salon</p>
                        <p class="headersubText">Beauty and Elegance Redefined</p>
                        <p class="seeMore">
                            Scroll down to see more information
                            <br>
                            <button class="buttond" onClick="scrollToBriefInfo()">
                                <span>scroll down</span>
                            </button>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Brief Info -->
        <div class="briefInfo">
            <br />
            <img src="../Styles/IMG/logo.png" alt="Logo" class="imgBrief">
            <div class="text1Brief"><br />Welcome to SEA Salon</div>
            <div class="subtext1Brief">
                At SEA Salon, we believe in enhancing your natural beauty with a touch of elegance and simplicity. 
                Nestled in a serene environment, our salon offers a tranquil escape from the hustle and bustle of 
                everyday life. Our expert team of stylists and beauticians are dedicated to providing personalized 
                services tailored to meet your individual needs.
            </div>
        </div>

        <!-- Services -->
        <div class="upcoming">
            <div class="text1Upcoming">Our Services</div>
            <div class="cardsd">
                <article class="cardd">
                    <header>
                        <h2>Haircuts and Styling</h2>
                    </header>
                    <img src="../Styles/IMG/Haircut.png" alt="Haircut">
                    <div class="content">
                        <p>Precision haircuts and modern styling tailored to enhance your natural beauty.</p>
                    </div>
                </article>
                <article class="cardd">
                    <header>
                        <h2>Manicure and Pedicure</h2>
                    </header>
                    <img src="../Styles/IMG/medicure.png" alt="Manicure and Pedicure">
                    <div class="content">
                        <p>Luxurious manicure and pedicure services for perfectly groomed hands and feet.</p>
                    </div>
                </article>
                <article class="cardd">
                    <header>
                        <h2>Facial Treatments</h2>
                    </header>
                    <img src="../Styles/IMG/facial treatment.png" alt="Facial Treatments">
                    <div class="content">
                        <p>Rejuvenating facial treatments to refresh and revitalize your skin.</p>
                    </div>
                </article>
            </div>
        </div>

        <!-- Footer -->
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
    </form>
    <script src="effect.js"></script>
</body>
</html>
