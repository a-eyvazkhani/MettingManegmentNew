/// <reference path="../../PsgeMinut1/MinutTab1.html" />
/// <reference path="../../PsgeMinut1/MinutTab1.html" />

var _Meetings = [];
var _MeetingUid = "";
var _notification = null;
var _MeetingsTitle = "";
var _Held = true;
var _MinutClass = {};
var _Curentdate = "";
var DSUnit = [];
var DSMasolAnjam = [];
var DSApprover = [];

var TaskList = [];
var SelectUserMasolAnjamText = "";
var SelectUserAproveText = "";
var MinutClass = {};
var MinutUid = "";

var ListUserInit = [];
var ListUserOrder = [];


$(document).ready(function () {
    debugger;
    InitLoadTabstrip1Or2();
    $("#TABMeetingReg").data("kendoTabStrip").select(0);
    selectedColorTab(1);
    _notification = $("#notification").kendoNotification().data("kendoNotification");
    InitGridMeting();
    PopupDescHolding();
    GetAllMeetingWithMinut();
    GetCurrentDate();

});

function InitLoadTabstrip1Or2() {
    $("#TABMeetingReg").kendoTabStrip();
    $("#TABMeetingReg").data("kendoTabStrip").select(0);
   


}
function GetCurrentDate() {

    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetCurentShamsiDate",

        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGetCurrentDate

    });
}
function successGetCurrentDate(respons) {
    _Curentdate = respons.d;

}

function selectedColorTab(selectTab) {


    document.getElementById("MinutTab1").style.color = "cornsilk";
    document.getElementById("MinutTab2").style.color = "cornsilk";



    if (selectTab == 1) {
        document.getElementById("MinutTab1").style.color = "#ffd800";

    }
    else if (selectTab == 2) {
        document.getElementById("MinutTab2").style.color = "#ffd800";
       

    }



}

function PopupDescHolding() {
    $("#WNDMinutProperties").kendoWindow({
        width: 1080,
        height: 680,
        title: "صورت جلسه",
        modal: true,
        resizable: false,
        size: "wide",
        scrollable: true,
        visible: false,
        content: ".../../../../_layouts/15/MettingManegmentNew/PsgeMinut1/MinutTab1.html",

        close: CloseDescHolding,


    }).data("kendoWindow").center();
}
function CancelMinut() {
    $("#WNDMinutProperties").data("kendoWindow").close();
}
function CloseDescHolding()
{

}

function OPenDescholding(id) {
    debugger;

    $("#WNDMinutProperties").data("kendoWindow").open();

}

function GetAllMeetingWithMinut() {

    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllMeetingWithoutMinut",
       
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: successGetAllMeetingWithMinut


    });
}

function successGetAllMeetingWithMinut(response)
{
    _Meetings = response.d;
    $("#GRDMeetings").data("kendoGrid").dataSource.read();
}
function InitGridMeting()
{
    DSMeeting = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                e.success(_Meetings);
            },
            schema: {
                model: { id: "ID" }
            },

        },
        batch: true,
        pageSize: 10,
    });
    $("#GRDMeetings").kendoGrid({
        dataSource: DSMeeting,
        pageable: {
            buttonCount: 5
        },
        scrollable: false,
        persistSelection: true,
        navigatable: true,
        sortable: true,
        filterable: {
            mode: "row"
        },
        columns: [
            //{ field: "RowNumber", title: "ردیف", width: 50, filterable: false, editable: false },

              { field: "ShomareRadif", title: "ردیف", width: 10, editable: false },
                 { field: "Title", title: "عنوان جلسه", width: 100, editable: false },
               //{ field: "RegistrerFullName", title: "منشی جلسه", filterable: { multi: true, search: true }, width: 100 },
                { field: "SecretaryFullName", title: "دبیر جلسه", filterable: { multi: true, search: true }, width: 100 },
               { field: "TarikhMetting", title: "تاریخ برگزاری", filterable: { multi: true, search: true }, width: 70 },
               { field: "PlaceAddress", title: "محل برگزاری", filterable: { multi: true, search: true }, width: 200 },

               {
                   command: {
                       name: "regagenda",
                       title: "ثبت صورت جلسه",
                       text: "ثبت صورت جلسه",
                       click: SelectMeeting
                   }, title: "ثبت", width: "50px"
               },
        ],
        dataBinding: function () {
            record = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    }).data("kendoGrid");
}
function SelectMeeting(e) {

    var dataItem = this.dataItem($(e.target).closest("tr"));
    _MeetingUid = dataItem.ID;
    _MeetingsTitle = dataItem.Title;


    var win = $("#WNDMinutProperties").data("kendoWindow");
    win.refresh("../../../../_layouts/15/MettingManegmentNew/PsgeMinut1/MinutTab1.html");
    win.open();







}