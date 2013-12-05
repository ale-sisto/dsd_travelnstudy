<%@ Page Title="Profile and Preferences" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="StudyAbroad.Presentation.test2" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/places.css" />

      <style type="text/css">

        #socialmedia-links img {
            margin: 10px;
            height: 50px;
            width: 50px;
        }

 /* ============================================================================================================================
== BUBBLE WITH A BORDER AND TRIANGLE
** ============================================================================================================================ */

/* THE SPEECH BUBBLE
------------------------------------------------------------------------------------------------------------------------------- */

.triangle-border {
	position:relative;
	padding:15px;
	margin:1em 0 3em;
	border:5px solid #5a8f00;
	color:#333;
	background:#fff;
	/* css3 */
	-webkit-border-radius:10px;
	-moz-border-radius:10px;
	border-radius:10px;
}

/* Variant : for left positioned triangle
------------------------------------------ */

.triangle-border.left {
	margin-left:30px;
}

/* Variant : for right positioned triangle
------------------------------------------ */

.triangle-border.right {
	margin-right:30px;
}

/* THE TRIANGLE
------------------------------------------------------------------------------------------------------------------------------- */

.triangle-border:before {
	content:"";
	position:absolute;
	bottom:-20px; /* value = - border-top-width - border-bottom-width */
	left:40px; /* controls horizontal position */
    border-width:20px 20px 0;
	border-style:solid;
    border-color:#5a8f00 transparent;
    /* reduce the damage in FF3.0 */
    display:block; 
    width:0;
}

/* creates the smaller  triangle */
.triangle-border:after {
	content:"";
	position:absolute;
	bottom:-13px; /* value = - border-top-width - border-bottom-width */
	left:47px; /* value = (:before left) + (:before border-left) - (:after border-left) */
	border-width:13px 13px 0;
	border-style:solid;
	border-color:#fff transparent;
    /* reduce the damage in FF3.0 */
    display:block; 
    width:0;
}


    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
    <script type='text/javascript' src='../scripts/jquery.raty.min.js'></script>
    <hgroup>
        <h1><%: Title %></h1>        
    </hgroup>
    <div id="tab3">
            <div id="reviews" class="">
                <img src="images/ajax-loading-transparent.gif"/>
                    <p>Fetching reviews... please wait</p>
                <p class='triangle-border left'>fdfdsf</p>
                <p>jhualpa wrote on fecha</p><div class='star' style="display: inline">5</div>;
                <p>
                    <button class="btn btn-primary" type="button">Edit</button>
                    <button class="btn btn-primary" type="button">Remove</button>
                </p>
                <p>
                    <input class="input-block-level" type="text" placeholder=".input-block-level" />
                    <button class="btn btn-primary" type="button">Add</button>
                </p>                
            </div>
            <div id="istar" class="istar" runat="server" data-rating="0"></div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <div id="newReview" class="">
                <asp:GridView ID="gvUniReview" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False" Width="600px" OnRowDataBound="gvUniReview_RowDataBound" ShowFooter="True" OnRowDeleting="gvUniReview_RowDeleting" OnRowEditing="gvUniReview_RowEditing" OnRowCancelingEdit="gvUniReview_RowCancelingEdit" >
                    <Columns>
                        <asp:TemplateField>
                            <AlternatingItemTemplate>                                
                                <blockquote class="pull-right">
                                    <p><%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).comment %></p>
                                    <small><%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).username %> wrote on <%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).date %></small>
                                    <div class="star" data-rating='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).rating %>'></div> 
                                    <p>
                                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary" CommandName="Edit" Text="Edit" Visible="false" />
                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" CommandName="Delete" Text="Delete"  Visible="false" />                                    
                                    </p>    
                                </blockquote>                                
                            </AlternatingItemTemplate>
                            <EditItemTemplate>
                                <div class="control-group">                                    
                                    <div class="controls">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComment" CssClass="alert alert-error" ErrorMessage="A comment is required" Display="Dynamic" />
                                        <asp:CustomValidator runat="server" ErrorMessage="Rating is required" CssClass="alert alert-error" ClientValidationFunction="RatingCheck"></asp:CustomValidator>
                                        <asp:TextBox ID="txtComment" CssClass="input-xxlarge" runat="server" Rows="5" TextMode="MultiLine" Visible="true"
                                             Text='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).comment %>'></asp:TextBox>                                
                                        <div id="inputstars" data-rating='<%# ((StudyAbroad.Presentation.ReviewDTO)Container.DataItem).rating %>'></div>
                                        <br />                            
                                        <asp:HiddenField ID="inputrating" runat="server" Value="0" ClientIDMode="Static" />                                        
                                        <asp:Button ID="btnSave" runat="server" CommandName="Update" CssClass="btn btn-primary" Text="Save" />&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" CssClass="btn btn-primary" Text="Cancel" />
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
                                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary" CommandName="Edit" Text="Edit" Visible="false" />
                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" CommandName="Delete" Text="Delete"  Visible="false" />                                                                          
                                    </p>
                                    <div class="controls">                                        
                                </blockquote>                                                            
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:PlaceHolder ID="hldAddReview" runat="server" Visible="false">
                                    <div class="control-group">                                    
                                        <div class="controls">
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComment" CssClass="alert alert-error" ErrorMessage="A comment is required" Display="Dynamic" />
                                            <asp:CustomValidator runat="server" ErrorMessage="Rating is required" CssClass="alert alert-error" ClientValidationFunction="RatingCheck"></asp:CustomValidator>
                                            <asp:TextBox ID="txtComment" CssClass="input-xxlarge" runat="server" Rows="5" TextMode="MultiLine" Visible="true"></asp:TextBox>                                
                                            <div id="inputstars" data-rating='0'></div>
                                            <br />                            
                                            <asp:HiddenField ID="inputrating" runat="server" Value="0" ClientIDMode="Static" />                                        
                                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" Visible="true" OnClick="btnAdd_Click" />
                                        </div>                               
                                    </div>
                                </asp:PlaceHolder>
                                    </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div> 
                      
	</div>
    <br />
    <script type="text/javascript">

        $('.star').raty({
            readOnly: true,
            score: function () {
                return $(this).attr('data-rating');
            }
        });

        $('.istar').raty({
            click: function (score) {
                $(this).attr('data-rating', score);
            }
        });

        $('#inputstars').raty({
            cancel:     true,
            target: '#inputrating',
            targetKeep: true,
            targetType: 'number',
            score: function () {
                return $(this).attr('data-rating');
            }
        });

        function RatingCheck(source, args) {
            var score = $('#inputrating').attr('value');
            if (score > 0) {
                args.IsValid = true;
                return;
            }           
            args.IsValid = false;
        }

        

    </script>

</asp:Content>
