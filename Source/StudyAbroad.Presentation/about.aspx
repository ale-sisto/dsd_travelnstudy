<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="StudyAbroad.Presentation.about" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div id="pageTitle">
            <h1>Introducing Travel 'n Study</h1>
        </div>
    <div id="aboutContent">
        <p class="desc">Travel 'n Study project aims to develop a system that will help students in choosing a university and the city in which they want to study abroad. 
            The project goal is to collect information from different open data sources on the Web and use it to develop a recommendation system which will guide the
            user towards a decision.The goal of the project is to build a web application which will provide a service to the user in a form of a recommendation system for deciding where to go to study abroad. 
            The application will gather data needed to make that decision from various open data sources and present the data to the user in a organized and visually attractive user interface. 
            The application will allow the user to input data on a number of options so the system can provide the user with choices which are suitable to his preferences.
        </p>
        <div>
            <h2>Credits</h2>
            <p class="desc" >We would like to thank the following people / organizations for their help, support or information providing for this application:</p>
            <dl>
                <dt>Freebase</dt>
                <dd> providing general information about cities and universities</dd></br>
                <dt>Numbeo</dt>
                <dd>providing cost of life information</dd></br>
                <dt>WorldBank</dt>
                <dd>providing climate information</dd></br>
                <dt>4icu</dt>
                <dd>providing university ratings and basic information</dd></br>
                <dt>Panoramio</dt>
                <dd>providing photos of cities</dd></br>
                <b>Google</b>
                <dd>for maps and places information</dd></br>
                <b>Ivana Bosnic</b>
                <dd>our supervisor</dd></br>
                <dt>DSD Staff</dt> 
                <dd>providing support and feedback for the project</dd></br>
            </dl>
        </div>
        <h2>Project members</h2>

        <div class="row first_row">
            <div class="span3"><img src="images/about/milan.jpg" /></div>
            <div class="span9">
                <h3>Milan Čop</h3>
                <dl>
                    <dt>Role(s)</dt>
                    <dd>Lead Developer, Database manager</dd></br>
                    <dt>Personal Info</dt>
                    <dd>My name is Milan and I'm 23 years old. I was born and raised in Zagreb. I finished Mathematical Gymnasium and after that I enrolled undergraduate study at FER. I have bachelor degree in Computer science since 2011. Currently I'm at my second year of Master's study.  </dd></br>
                </dl>
            </div>
        </div>
        <div class="row">
            <div class="span3"><img src="images/about/katarina.jpg" /></div>
            <div class=" desc span9">
                <h3>Katarina Sekula</h3>
                <dl>
                    <dt>Role(s)</dt>
                    <dd>Requirements manager, Testing manager, Developer (Server)</dd></br>
                    <dt>Personal Info</dt>
                    <dd>I am 23 years old. I live in Zagreb, Croatia. I am studying at the Faculty of Electrical Engineering and Computer Science at the University of Zagreb, the module software engineering. This is the first college I enrolled.  </dd>
                </dl>
            </div>
        </div>
        <div class="row">
            <div class="span3"><img src="images/about/branimir.jpg" /></div>
            <div class="span9">
                <h3>Branimir Lochert</h3>
                <dl>
                    <dt>Role(s)</dt>
                    <dd>Project leader, Documentation manager, Developer (Server)</dd></br>
                    <dt>Personal Info</dt>
                    <dd> My name is Branimir, I am 24 years old. I am from Croatia, the city of Zagreb. I am studying at FER (Faculty of Electrical Engineering and Computing) where I got my Bachelor's degree.  </dd></br>
                </dl>
            </div>
        </div>
        <div class="row">
            <div class="span3"><img src="images/about/alessandro.jpg" /></div>
            <div class="span9">
                <h3>Alessandro Sisto</h3>
                <dl>
                    <dt>Role(s)</dt>
                    <dd>Team leader, User interface manager, Developer (Client)</dd></br>
                    <dt>Personal Info</dt>
                    <dd> My name is Alessandro Sisto, i'm italian, i live in Milan and i am 26 years old. Actually i'm a student in the Msc of computer science engineering at Politecnico of Milan. I have a Bsc in computer science engineering taken from POLIMI on february 2011</dd></br>
                </dl>
            </div>
        </div>
        <div class="row">
            <div class="span3"><img src="images/about/daniele.JPG" /></div>
            <div class="span9">
                <h3>Daniele Rogora</h3>
                <dl>
                    <dt>Role(s)</dt>
                    <dd>Virtual Machine manager, Backup manager, SVN manager, Developer (Client)</dd></br>
                    <dt>Personal Info</dt>
                    <dd> I was born in Busto Arsizio (Varese) and I live near the Malpensa airport. I am 24 at the moment; I'll be 25 the next December. I studied in Busto Arsizio at the local liceo scientifico and then I immediatly joined the Politecnico di Milano, where I got the first level laurea in 2010, with a thesis project of a CUDA implementation of the number field sieve algorithm.  </dd></br>
                </dl>
            </div>
        </div>
        <div class="row">
            <div class="span3"><img src="images/about/javier.jpg" /></div>
            <div class="span9">
                <h3>Javier Hualpa</h3>
                <dl>
                    <dt>Role(s)</dt>
                    <dd>Server - Client coordinator, Data sources manager, Developer (Server)</dd></br>
                    <dt>Personal Info</dt>
                    <dd>I am an international student from Argentina I am on the computer engineering master. I have 6 years of industry experience and I am in the master because I always wated to persue a degree program in Europe.  </dd></br>
                </dl>
            </div>
        </div>
       </div>
    </div>
</asp:Content>
