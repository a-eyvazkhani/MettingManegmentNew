<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MinutVWUserControl.ascx.cs" Inherits="MettingManegmentNew.MinutVW.MinutVWUserControl" %>


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
<script src="../../../../_layouts/15/MettingManegmentNew/js/Minut/MinutManeger.js"></script>
<script src="../../../../_layouts/15/MettingManegmentNew/js/Minut/MinutTab1.js"></script>

<style>
    .td-border {
        border: solid;
        padding: 5px;
        border-width: 1px;
        border-color: #4d4d4d;
    }

    .td-title {
        width: 110px;
    }

    .border-pdf {
        border: solid;
        border-width: 3px;
        border-color: #4d4d4d;
        min-height: 900px;
    }

    .border-1 {
        padding: 5px;
        height: 20px;
        border: solid;
        border-width: 0px;
        border-color: #4d4d4d;
    }
</style>


<style>
    #loading {
        z-index: 9999999999999999999999999999;
        position: absolute;
        width: 200px;
        height: 200px;
        margin-right: 35%;
        margin-top: 10%;
        background: url('../../../../_layouts/15/Samix.EPM/Loader/loading.gif') no-repeat center center;
        background-color: transparent;
    }

    #wating {
        margin-right: 20%;
        color: #ffd800;
    }

    #GRDMeetings > table > tbody > tr > td {
        text-align: center;
    }
</style>

<%--<div id="loading">
    <h4 id="wating"><asp:Literal runat="server" Text='لطفا چند لحظه صبر کنید' /></h4>
</div>--%>


<div id="notification" style="display: none;"></div>
<div class="header-panel">
    <h2 style="color: black;"><asp:Literal runat="server" Text='مدیریت صورت جلسات' /></h2>
</div>
<div class="content-panel">
    <div id="TABMeetingReg">
        <ul>
            <li id="TabProperties"  onclick="MinutClicTab1()" class="back-blue k-state-active"><span id="MinutTab1">ثبت صورت جلسه</span></li>
            <li id="TabParticipant"  onclick="MinutClicTab2()" class="back-blue"><span id="MinutTab2">فهرست صورت جلسات</span></li>
        </ul>

        <div>
            <div id="panelmeetingsgrid" class="content-panel">

                <div id="GRDMeetings"></div>

                <div id="WNDMinutProperties"></div>

            </div>
        </div>
        <div>
            <div id="panelminut" class="content-panel">
                <div id="GRDMinutes"></div>
            </div>
        </div>
    </div>
</div>

<div id="WNDMinutPropertiesInMeetingCenter"></div>
