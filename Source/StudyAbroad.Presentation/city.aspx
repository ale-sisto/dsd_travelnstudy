<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="city.aspx.cs" Inherits="StudyAbroad.Presentation.city" %>
<%@ Import namespace="StudyAbroad.Presentation.Helpers" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <!-- Custom accordion style + map properties -->
    <link href="css/lightbox.css" rel="stylesheet" />
 <style type="text/css">
        #map { 
          /* to be fixed*/
        height: 500px;
        width: 99%;
        border: 1px solid #333;
        margin-top: 0.6em;
      }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type="text/javascript" src="/scripts/tab_city.js"></script>
    <script type="text/javascript" src="/scripts/places.js"></script>
    <script src="/scripts/jquery.simpleWeather.js" charset="utf-8"></script>
    <script type='text/javascript' src='/scripts/jquery.raty.min.js'></script>
    <script type='text/javascript' src='/scripts/review.js'></script>
    <script type="text/javascript" src="/scripts/city.js"></script>
    <script type='text/javascript' src="/scripts/lightbox.js"></script>    

    <div id="loaderModal" class="modal hide fade active" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-header">
    
    <h3 id="myModalLabel" style="text-align:center">Loading...</h3>
  </div>
  <div class="modal-body" style="text-align:center">
    <h5>The page will be ready soon!</h5>
  </div> 
    </div>

    <div id="content_page_header" class="container">
        <div id="pageTitle">
            <h1 id="tit"></h1>
        </div>
        <div id="subTitle">
            <h2 id="sub"></h2>      
        </div>

    <ul id="mapBread" class="breadcrumb">
    </ul>
    </div>

    

<div id="cityContainer" class="container-fluid">
    <div class="row">
    <div id="button-menu" class="span4">
	
            <a id='btn_tab0' href="#tab0" class='btn btn-block btn-primary' data-toggle="tab">Introduction</a>
			<a id='btn_tab1' href="#tab1" class='btn btn-block btn-primary' data-toggle="tab">General</a>
            <a id="btn_tab5" href="#tab5" class='btn btn-block btn-primary' data-toggle="tab">Climate</a>
			<a id='btn_tab2' href="#tab2" class='btn btn-block btn-primary' data-toggle="tab">Costs</a>
			<a id='btn_tab3' href="#tab3" class='btn btn-block btn-primary' data-toggle="tab">Reviews</a>
			<a id='btn_tab4' href="#tab4" class='btn btn-block btn-primary' data-toggle="tab">City Life</a>
            
	</div>

		<div class="tab-content span8" id="cityContent">
            <div id="tab0" class="tab-pane active">
                
                <div id="population"></div>
                <div id="area"></div>
                <div id="density"></div>
                <div id="country" class=""></div>     
                <div id="map1" class="mar"></div>
                                
			    <div id="universitiesList"></div>
	        </div>

			<div class="tab-pane" id="tab1">
                    <div>
                        <h3>Description</h3>
                        <p id="abstract" class=""></p>
                        <p id="wiki"></p>
                    </div>
                    
                    <div id="panoramio" class=""></div>
			</div>


			<div class="tab-pane fade" id="tab2">
                <h4>Local prices summary (€)</h4>
				    <table class="table table-striped" id="costs_table"></table>
			</div>
			<div class="tab-pane fade" id="tab3">
				<asp:UpdateProgress runat="server" DisplayAfter="0" > 
                    <ProgressTemplate>                    
                        <img src="images/ajax-loading-transparent.gif"/>
                        <p>Fetching reviews... please wait</p>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="review-box">
                        <asp:GridView ID="gvCityReview" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowCancelingEdit="gvCityReview_RowCancelingEdit" OnRowCommand="gvCityReview_RowCommand" OnRowDataBound="gvCityReview_RowDataBound" OnRowDeleting="gvCityReview_RowDeleting" OnRowEditing="gvCityReview_RowEditing" OnRowUpdating="gvCityReview_RowUpdating" ShowFooter="True" ShowHeader="False" Width="600px">
                            <Columns>
                                <asp:TemplateField>
                                    <AlternatingItemTemplate>
                                        <blockquote class="pull-right">
                                            <div class="controls">
                                                <p><%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).comment %></p>
                                                <small><%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %> wrote on <%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).date %></small>
                                                <div class="star pull-right" data-rating='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).rating %>'></div>
                                                <br />
                                                <br />
                                                <p id="modButtons">
                                                    <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %>' CommandName="Edit" CssClass="btn btn-primary" Text="Edit" Visible="false" />
                                                    <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %>' CommandName="Delete" CssClass="btn btn-primary" Text="Delete" Visible="false" />
                                                </p>
                                            </div>
                                        </blockquote>
                                    </AlternatingItemTemplate>
                                    <EditItemTemplate>
                                        <div class="control-group">
                                            <div class="controls">
                                                <h3>Write your review</h3>
                                                <asp:TextBox ID="txtComment" runat="server" CssClass="input-xxlarge" Rows="5"
                                                    Text='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).comment %>'
                                                    TextMode="MultiLine" Visible="true"></asp:TextBox>
                                                <div id="inputstars" data-rating='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).rating %>'></div>
                                                <br />
                                                <asp:HiddenField ID="inputrating" runat="server" ClientIDMode="Static" Value="0" />
                                                <asp:Button ID="btnSave" runat="server" CausesValidation="True" CommandArgument='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %>' CommandName="Update" CssClass="btn btn-primary" Text="Save" />&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" CssClass="btn btn-primary" Text="Cancel" OnClientClick="$(this).closest('.controls').hide()" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComment" CssClass="mbottom mbottom-f" Display="Dynamic" ErrorMessage="A comment is required" />
                                                <asp:CustomValidator runat="server" ClientValidationFunction="RatingCheck" CssClass="mbottom mbottom-f" ErrorMessage="Rating is required" />
                                                </br> 
                                            </div>
                                        </div>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <blockquote>
                                            <div class="controls">                                            
                                                <p><%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).comment %></p>
                                                <small><%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %> wrote on <%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).date %></small>
                                                <div class="star" data-rating='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).rating %>'></div>
                                                <br />
                                                <p>
                                                    <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %>' CommandName="Edit" CssClass="btn btn-primary" Text="Edit" Visible="false" />
                                                    <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %>' CommandName="Delete" CssClass="btn btn-primary" Text="Delete" Visible="false" />
                                                </p>                                                
                                            </div>
                                        </blockquote>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:PlaceHolder ID="hldAddReview" runat="server" Visible="false">
                                            <div class="control-group">
                                                <div class="controls">
                                                    <h3>Write your review</h3>                           
                                                    <asp:TextBox ID="txtComment" runat="server" CssClass="input-xxlarge" Rows="5" TextMode="MultiLine" Visible="true"></asp:TextBox>
                                                    <div id="inputstars" data-rating='0'></div>
                                                    <br />
                                                    <asp:HiddenField ID="inputrating" runat="server" ClientIDMode="Static" Value="0" />
                                                    <asp:Button ID="btnAdd" runat="server" CausesValidation="True" CssClass="btn btn-primary" CommandName="Add" Text="Add" Visible="true" />
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComment" CssClass="mbottom mbottom-f" Display="Dynamic" ErrorMessage="A comment is required" />
                                                    <asp:CustomValidator runat="server" ClientValidationFunction="RatingCheck" CssClass="mbottom mbottom-f" ErrorMessage="Rating is required" />
                                                    </br> 
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                    </FooterTemplate>                                
                                </asp:TemplateField>
                            </Columns>
                             <EmptyDataTemplate>
                                <asp:PlaceHolder ID="hldNoReview" runat="server" Visible="false">
                                     <p class="lead">There are no reviews on this city!</p>
                                     <p class="">Only registered users can review cities.
                                      Please <a id="loginLink" runat="server" href="~/Account/Login.aspx">Log in</a> to continue.</p>
                                </asp:PlaceHolder>
                                <asp:PlaceHolder ID="hldAddReview" runat="server" Visible="false">
                                    <div class="control-group">
                                        <div class="controls">
                                            <p class="lead">There are no reviews on this city!</p>
                                            <h3>Write your review</h3>
                                            <asp:TextBox ID="txtComment" runat="server" CssClass="input-xxlarge" Rows="5" TextMode="MultiLine" Visible="true"></asp:TextBox>
                                            <div id="inputstars" data-rating='0'></div>
                                            <br />
                                            <asp:HiddenField ID="inputrating" runat="server" ClientIDMode="Static" Value="0" />
                                            <asp:Button ID="btnAdd" runat="server" CausesValidation="True" CssClass="btn btn-primary" CommandName="EmptyAdd" Text="Add" Visible="true" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComment" CssClass="mbottom mbottom-f" Display="Dynamic" ErrorMessage="A comment is required" />
                                            <asp:CustomValidator runat="server" ClientValidationFunction="RatingCheck" CssClass="mbottom mbottom-f" ErrorMessage="Rating is required" />
                                            </br> 
                                        </div>
                                    </div>
                                </asp:PlaceHolder>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvCityReview" EventName="RowCommand" />                    
                    </Triggers>
                </asp:UpdatePanel>
			</div>
			<div class="tab-pane fade" id="tab4">

                <div id="life">
			<div class="btn-toolbar">

            <h4>Embassies</h4>
            <div class="btn-group" data-toggle="buttons-checkbox">
                <button id="btn_embassy" type="button" class="btn btn-primary" onclick="toggle('embassy')">Embassies</button>
            </div>
               <br />
               <h4>Food and cafe</h4>
               <div class="btn-group" data-toggle="buttons-checkbox">
                <button id="btn_bar" type="button" class="tabbtn btn btn-primary" onclick="toggle('bar')">Bar</button>
                <button id="btn_cafe" type="button" class="tabbtn btn btn-primary" onclick="toggle('cafe')">Cafe</button>
                <button id="btn_restaurants" type="button" class="tabbtn btn btn-primary btn-primary" onclick="toggle('restaurants')">Restaurants</button>            
                   <br />
                <button id="btn_meal_delivery" type="button" class="btn btn-primary" onclick="toggle('meal_delivery')">Meal delivery</button>
                <button id="btn_meal_takeaway" type="button" class="btn btn-primary" onclick="toggle('meal_takeaway')">Meal takeaway</button>
                <button id="btn_food" type="button" class="btn btn-primary" onclick="toggle('food')">Food</button>
                </div>
                <br />
                <h4>Fun</h4>
                <div class="btn-group" data-toggle="buttons-checkbox">                    
                <button id="btn_casino" type="button" class="tabbtn btn btn-primary" onclick="toggle('casino')">Casino</button>
                <button id="btn_movie_theater" type="button" class="tabbtn btn btn-primary" onclick="toggle('movie_theater')">Cinemas</button>
                <button id="btn_night_club" type="button" class="tabbtn btn btn-primary" onclick="toggle('night_club')">Night clubs</button>
                <button id="btn_zoo" type="button" class="tabbtn btn btn-primary" onclick="toggle('zoo')">Zoo</button>
                    <br />
                <button id="btn_amusement_park" type="button" class="btn btn-primary" onclick="toggle('amusement_park')">Amusement parks</button>
                <button id="btn_aquarium" type="button" class="btn btn-primary" onclick="toggle('aquarium')">Aquariums</button>        
                <button id="btn_bowling_alley" type="button" class="btn btn-primary" onclick="toggle('bowling_alley')">Bowling alleys</button>
            </div>
               <br />
                <h4>Shopping</h4>
               <div class="btn-group" data-toggle="buttons-checkbox">
                   <button id="btn_home_goods_store" type="button" class="tabbtn btn btn-primary" onclick="toggle('home_goods_store')">Home goods stores</button>
                <button id="btn_jewelry_store" type="button" class="tabbtn btn btn-primary" onclick="toggle('jewelry_store')">Jewelries</button>
                <button id="btn_liquor_store" type="button" class="tabbtn btn btn-primary" onclick="toggle('liquor_store')">Liquor stores</button>
                <button id="btn_shopping_mall" type="button" class="tabbtn btn btn-primary" onclick="toggle('shopping_mall')">Shopping malls</button>
                   <br />
                <button id="btn_clothing_store" type="button" class="btn btn-primary" onclick="toggle('clothing_store')">Clothing stores</button>
                <button id="btn_convenience_store" type="button" class="btn btn-primary" onclick="toggle('convenience_store')">Convenience stores</button>
                <button id="btn_department_store" type="button" class="btn btn-primary" onclick="toggle('department_store')">Department stores</button>
                <button id="btn_electronics_store" type="button" class="btn btn-primary" onclick="toggle('electronics_store')">Electronic stores</button>               
            </div>
                              
           </div>
            <div id="map"></div>
            <div id="image_div"></div>
            <h3 id="place_name"></h3>
            <h4 id="place_details_header">Details</h4>
            <div id="place_details"></div>
            <h4 id="place_reviews_header">Reviews</h4>
            <div id="place_reviews">
                <div id="reviews_accordion"></div>
            </div>
            </div>
			</div>
        <div class="tab-pane fade" id="tab5">
            <h3>Current weather</h3>
            <div class="row">
                <div class="span4" id="weather"></div>
               <div class="span3" id="weather_img"></div>
            </div>
               
    
            <h3>Climate info</h3>
            <div class=""> 
                <p id="climate_classification"></p>
				<div id="climate_chart" class="mar">
                    <img src="images/ajax-loading-transparent.gif"/>
                    <p>Your data is being fetched... please wait</p>
				</div>
            </div>
		</div>
            
         </div>
    </div>
	</div>  
</asp:Content>
