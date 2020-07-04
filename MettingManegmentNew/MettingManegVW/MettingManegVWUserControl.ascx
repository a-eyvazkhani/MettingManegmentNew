<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MettingManegVWUserControl.ascx.cs" Inherits="MettingManegmentNew.MettingManegVW.MettingManegVWUserControl" %>

<script src="../../../../_layouts/15/Samix.EPM/jquery/jquery.min.js"></script>
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.common.min.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.material.min.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.material.mobile.min.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.rtl.min.css" rel="stylesheet" type="text/css" />

<script src="../../../../_layouts/15/Samix.EPM/jquery/jquery.min.js"></script>
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.common.min.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.material.min.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.material.mobile.min.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/kendo/styles/kendo.rtl.min.css" rel="stylesheet" type="text/css" />
<script src="../../../../_layouts/15/Samix.EPM/kendo/js/kendo.all.min.js"></script>

<script src="../../../../_layouts/15/Samix.EPM/epmui/epmutility.js"></script>
<link href="../../../../_layouts/15/Samix.EPM/epmui/epmutility.css" rel="stylesheet" type="text/css" />
<link href="../../../../_layouts/15/Samix.EPM/PersianCalendarJalali/css/kamadatepicker.min.css" rel="stylesheet" type="text/css" />
<script src="../../../../_layouts/15/Samix.EPM/PersianCalendarJalali/js/kamadatepicker.min.js"></script>
<script src="../../../../_layouts/15/MettingManegmentNew/Public/ChengTimeAndInt.js"></script>

<script src="../../../../_layouts/15/MettingManegmentNew/js/MettingManeger.js"></script>



<div class="header-panel ">
    <h2 style="color: black;">
        <asp:Literal runat="server" Text="" /></h2>


</div>
<div class="content-panel">
     <div id="PanelGridMetting">
            <div class="row">
    <div id="GRDMeetings"></div>
                </div>
         </div>
     <div  id="PanelAddHoldingDeal" style="display:none;"  >
   <div id="tabRequestATopic" >
       <ul>
           <li id="MettingTab1" onclick="selectedColorTab(1)"><span id="spanTabMettingTab1">دعوت به جلسه</span></li>
           <li id="MettingTab2" onclick="selectedColorTab(2)"><span id="spanTabMettingTab2">افزودن اشخاص</span></li>
           <li id="MettingTab3" onclick="selectedColorTab(3)"><span id="spanTabMettingTab3">هشدار</span></li>
       </ul>
       </div>
         </div>
    </div>
