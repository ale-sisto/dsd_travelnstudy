<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="university.aspx.cs" Inherits="StudyAbroad.Presentation.university" %>
<%@ Import namespace="StudyAbroad.Presentation.Helpers" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    


</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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

    <script type='text/javascript' src='https://www.google.com/jsapi'></script>
    <script type="text/javascript" src="/scripts/tab_univ.js"></script>
    <script type='text/javascript' src='/scripts/places.js'></script>
    <script type='text/javascript' src='/scripts/jquery.raty.min.js'></script>
    <script type='text/javascript' src='/scripts/review.js'></script>
    <script type='text/javascript' src='/scripts/university.js'></script>
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
    <div id="pageTitle" >        	
        <h1 id="uni_title"></h1>             
	</div>
    <div id="subTitle">
        <h2 id="location"></h2>
    </div>

<ul id="mapBread" class="breadcrumb">
</ul>
</div>   

<div id="uniContainer" class="container-fluid">
    <div class="row">
    <div id="button-menu" class="span4">

        <a id='btn_tab0' href="#tab0" class='btn btn-block btn-primary' data-toggle="tab">Introduction</a>
		<a id='btn_tab1' href="#tab1" class='btn btn-block btn-primary' data-toggle="tab">Details and Contacts</a>
		<a id='btn_tab2' href="#tab2" class='btn btn-block btn-primary' data-toggle="tab">Costs and Admissions</a>
		<a id='btn_tab3' href="#tab3" class='btn btn-block btn-primary' data-toggle="tab">Reviews</a>
		<a id='btn_tab4' href="#tab4" class='btn btn-block btn-primary' data-toggle="tab">University Life</a>

    </div>
   
	<div class="tab-content span8" id="UniContent">

        <div class="tab-pane active" id="tab0">

            <div id="title_image"></div>
            <blockquote id="motto" class= "lead"></blockquote>
            <p class="lead" id="foundation"></p>
            <p class="lead" id="global_rank"><b>Global university ranking position: </b></p>
		    <a class="btn btn-large btn-primary" id="web_link"><b>Official website</b></a>
            <a class="btn btn-large btn-primary" id="city"></a>
            
        </div>

        <div class="tab-pane" id="tab1">
            
            <div id="description">
            </div>
            <h3>Courses details</h3>
            <div id="structure"></div>
            <br />
            <div id="studies" class="well"></div>
            <div id="contacts">
            </div>
            <div id="socialmedia">	    
            </div>
		</div>

		<div class="tab-pane" id="tab2">
            
            <h3>Ranks</h3>
            <p>The following graphs compare the global rank of the current university with the averages ranks of the universities in the same country and continent and the relative rank within different regions</p>
            <p><i>Note that a lower rank is better.</i></p>
                <div class="graph" id="ranks_chart_div">
                    <img src="images/ajax-loading-transparent.gif"/>
                    <p>Your data is being fetched... please wait</p>
                </div>
                <div class="graph" id="relativeranks_chart_div">
                    <img src="images/ajax-loading-transparent.gif"/>
                    <p>Your data is being fetched... please wait</p>
                </div>
            <h3>Costs</h3>
            <div class=""><p class="lead" id="controlType_p"></p></div>

            <p>The following graph compares the cost of the current university with the averages costs of the universities in the same country and continent</p>

                <div id="costs_chart_div" class="graph">
                    <img src="images/ajax-loading-transparent.gif"/>
                    <p>Your data is being fetched... please wait</p>
                </div>           
            
            <h3>Admission</h3>
            <p>The following paragraph gives informations about admission restrictions to the university</p>
  
                    <div class="graph" id="admission_chart_div">
                        <img src="images/ajax-loading-transparent.gif"/>
                        <p>Your data is being fetched... please wait</p>
                    </div>
                    <div class="" id="admission_gender"></div>

            <h3>Students</h3>
            <p>The following paragraph gives informations about students currently enrolled at the university</p>
            <div class="graph" id="students_chart_div">
                    <img src="images/ajax-loading-transparent.gif"/>
                    <p>Your data is being fetched... please wait</p>
            </div>
		</div>

		<div class="tab-pane" id="tab3">            
            <asp:UpdateProgress runat="server" DisplayAfter="0" > 
                <ProgressTemplate>                    
                    <img src="images/ajax-loading-transparent.gif"/>
                    <p>Fetching reviews... please wait</p>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="review-box">
                    <asp:GridView ID="gvUniReview" runat="server" AutoGenerateColumns="False" GridLines="None" OnRowCancelingEdit="gvUniReview_RowCancelingEdit" OnRowCommand="gvUniReview_RowCommand" OnRowDataBound="gvUniReview_RowDataBound" OnRowDeleting="gvUniReview_RowDeleting" OnRowEditing="gvUniReview_RowEditing" OnRowUpdating="gvUniReview_RowUpdating" ShowFooter="True" ShowHeader="False" Width="600px">
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
                                            <p>
                                                <asp:Button ID="btnEdit" runat="server" CausesValidation="True" CommandArgument='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %>' CommandName="Edit" CssClass="btn btn-primary" Text="Edit" Visible="false" />
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
                                <p class="lead">There are no reviews on this university!</p>
                                 <p class="">Only registered users can review universities.
                                   Please <a id="loginLink" runat="server" href="~/Account/Login.aspx">Log in</a>to continue.</p>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="hldAddReview" runat="server" Visible="false">
                                <div class="control-group">
                                    <div class="controls">
                                        <p class="lead">There are no reviews on this university!</p>
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
                    <asp:AsyncPostBackTrigger ControlID="gvUniReview" EventName="RowCommand" />                    
                </Triggers>
            </asp:UpdatePanel>            
        </div>

        <div class="tab-pane" id="tab4">
            <div id="life">
                <div class="btn-toolbar">
               
                    <h4>Culture and study</h4>
                    <div class="btn-group" data-toggle="buttons-checkbox">
                        <button id="btn_museum" type="button" class="btn btn-primary" onclick="toggle('museum')">Museums</button>
                        <button id="btn_book_store" type="button" class="btn btn-primary" onclick="toggle('book_store')">Book stores</button>
                        <button id="btn_library" type="button" class="btn btn-primary" onclick="toggle('library')">Libraries</button>
                    </div>
                    <br />
                    <h4>Lodging and transports</h4>
                    <div class="btn-group" data-toggle="buttons-checkbox">
                        <button id="btn_lodging" type="button" class="btn btn-primary" onclick="toggle('lodging')">Lodging</button>
                        <button id="btn_taxi_stand" type="button" class="btn btn-primary" onclick="toggle('taxi_stand')">Taxi</button>
                        <button id="btn_train_station" type="button" class="btn btn-primary" onclick="toggle('train_station')">Train stations</button>
                        <button id="btn_subway_station" type="button" class="btn btn-primary" onclick="toggle('subway_station')">Subway stations</button>
                    </div>
                    <br />
                    <h4>Food and cafe</h4>
                    <div class="btn-group" data-toggle="buttons-checkbox">
                        <button id="btn_bar" type="button" class="btn btn-primary" onclick="toggle('bar')">Bar</button>
                        <button id="btn_cafe" type="button" class="btn btn-primary" onclick="toggle('cafe')">Cafe</button>
                        <button id="btn_food" type="button" class="btn btn-primary" onclick="toggle('food')">Food</button>
                        <button id="btn_meal_delivery" type="button" class="btn btn-primary" onclick="toggle('meal_delivery')">Meal delivery</button>
                        <button id="btn_meal_takeaway" type="button" class="btn btn-primary" onclick="toggle('meal_takeaway')">Meal takeaway</button>
                        <button id="btn_restaurants" type="button" class="btn btn-primary btn-primary" onclick="toggle('restaurants')">Restaurants</button>
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
     </div>
	</div>
</div>
   

</asp:Content>
