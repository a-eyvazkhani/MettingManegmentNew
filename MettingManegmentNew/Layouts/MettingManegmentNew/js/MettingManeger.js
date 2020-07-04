

var currenttime = "";
var meetingDataSource = [];
var MettingClass = {};
var DSMeetingPropAllUsers = [];
var meetingID = "";
var _notification = null;
var _UserTimingGuage = [];
var _PlaceTimingGuge = [];
var _SelectedPlaceID = "";
var _SelectUserId = "";


var _TimeArray = [
            "00:00", "00:15", "00:30", "00:45", "01:00", "01:15", "01:30", "01:45", "02:00", "02:15", "02:30",
            "02:45", "03:00", "03:15", "03:30", "03:45", "04:00", "04:15", "04:30", "04:45", "05:00", "05:15",
            "05:30", "05:45", "06:00", "06:15", "06:30", "06:45", "07:00", "07:15", "07:30", "07:45", "08:00",
            "08:15", "08:30", "08:45", "09:00", "09:15", "09:30", "09:45", "10:00", "10:15", "10:30", "10:45",
            "11:00", "11:15", "11:30", "11:45", "12:00", "12:15", "12:30", "12:45", "13:00", "13:15", "13:30",
            "13:45", "14:00", "14:15", "14:30",
            "14:45", "15:00", "15:15", "15:30", "15:45", "16:00", "16:15", "16:30", "16:45", "17:00", "17:15",
            "17:30", "17:45", "18:00", "18:15", "18:30", "18:45", "19:00", "19:15", "19:30", "19:45", "20:00",
            "20:15", "20:30", "20:45", "21:00", "21:15", "21:30", "21:45", "22:00", "22:15", "22:30", "22:45",
            "23:00", "23:15", "23:30", "23:45"
]

var DSPlaces = [];
var DSMeetingTemplate = [];
var DSUnit = [];
var MeetingUserRelJson = [];
var SelectUserSecretary = {};
var _Curentdate = "";

var _TypeAlert = [{ "value": 1, "text": "ایمیل" }, { "value": 2, "text": "پیامک" }, { "value": 3, "text": "هر دو" }];
var DSAlerts = [];
var DSAlertsDatabse = [];
var DSAlertsAddRegisteri = [];
var DSAlertsAddChekList = [];
var ClassAddAlert = {};


var cmbAllUsersInternal_data = [];
var GRDUsersInternal_data = [];

var cmbAddUsersOrderUser_data = [];
var GRDAllUsersOrderUser_data = [];

var cmbAddGetInFormedUser_data = [];
var GRDGetInFormedUser_data = [];


$(document).ready(function () {
    InitGridMetting();
    GetAllMetting();
    InitLoadTabstrip1Or2();
    $("#tabRequestATopic").data("kendoTabStrip").select(0);
    selectedColorTab(1);
    _notification = $("#notification").kendoNotification().data("kendoNotification");
   
});

function InitLoadTabstrip1Or2() {
    var ts = $("#tabRequestATopic").kendoTabStrip({
        contentUrls: [

                     '../../../../_layouts/15/MettingManegmentNew/Page/MettingPageTab1.html',
                        '../../../../_layouts/15/MettingManegmentNew/Page/MettingPageTab2.html',
                         '../../../../_layouts/15/MettingManegmentNew/Page/MettingPageTab3.html',



        ]
    }).data('kendoTabStrip');

   
}

function InitGridMetting()
{
    var PlacesDataSource = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                e.success(meetingDataSource);
            },

            parameterMap: function (options, operation) {
                if (operation !== "read" && options.models) {
                    return { models: kendo.stringify(options.models) };
                }
            },
        },
        schema: {
            model: { id: "ID" }
        },
        batch: true,
        pageSize: 10,
    });
    $("#GRDMeetings").kendoGrid({

        dataSource: PlacesDataSource,
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
             {
                 title: "ردیف",
                 template: "#= ++record #",
                 width: 10
             },
             { field: "Title", title: "عنوان", editable: false },
              { field: "TarikhMetting", title: "تاریخ برگزاری", filterable: { multi: true, search: true } },
               { field: "StartTime", title: "زمان شروع", width: 20, filterable: false },
               { field: "FinishTime", title: "زمان پایان", width: 20, filterable: false },
              // { field: "Statuse", title: "وضعیت", editable: false },
                { field: "RegistrerFullName", title: "منشی جلسه", editable: false },
                 { field: "SecretaryFullName", title: "دبیر جلسه", editable: false },

                  { field: "PlaceAddress", title: "مکان جلسه", editable: false },
                   //{
                   //    title: "صورت جلسه",
                   //    width: 10,
                   //    editable: false,
                   //    template: function (dataItem) {

                   //        if (dataItem.HaveMinuts == false) {
                   //            return "<div style='background-color:#e2e2e2;color:transparent;'>****</div> ";
                   //        }
                   //        else {
                   //            return "<img onclick='ShowMinuts(\"" + dataItem.ID + "\");return false;' class='imgbtnstyle' src='../../../../_layouts/15/Samix.EPM/Icons/application_cascade.png' alt='صورت جلسه' title='صورت جلسه' />";
                   //            //<button onclick='ShowMinuts(\"" + dataItem.ID + "\");return false;' class='k-button k-primary'> صورت جلسه</button>";
                   //        }
                   //    },
                   //},
                    {
                        title: "ویرایش",
                        width: 10,
                        editable: false,
                        template: function (dataItem) {
                            if (!dataItem.HaveMinuts  && !dataItem.IsDeleted) {
                                //if (_CurrentUser.ID == dataItem.SecretaryUserId || dataItem.RegistrerUserID == _CurrentUser.ID) {
                                //if (!dataItem.IsHeld)
                                //    return "<div style='background-color:#e2e2e2; color:transparent;'>***</div>";
                              //  else
                                    return "<img onclick='OnclickEditMeeting(\"" + dataItem.ID + "\");return false;' class='imgbtnstyle' src='../../../../_layouts/15/Samix.EPM/Icons/iconfinder_document_edit_48757.png' alt='ویرایش' title='ویرایش' />";
                                //return "<button onclick='OnclickEditMeeting(\"" + dataItem.ID + "\");return false;' class='k-button k-primary'> ویرایش</button>";
                                //}
                                //else {
                                //    return "<div style='background-color:#e2e2e2; color:transparent;'>2**</div>";
                                //}
                            }
                           // else {
                               // return "<div style='background-color:#e2e2e2; color:transparent;'>***</div>";
                           // }
                        }
                    },
                      //{

                      //    title: "ابطال",
                      //    width: 20,
                      //    editable: false,
                      //    template: function (dataItem) {
                      //        if (dataItem.IsRevoke) {
                      //            return "<div style='   background-color:#ffb3b3;text-align:center;'>باطل    شده</div> "
                      //        }


                      //        if (!dataItem.HaveMinuts && !dataItem.IsRevoke && !dataItem.IsDeleted) {
                      //            if (dataItem.SecretaryUserId == _CurrentUser.ID || dataItem.RegistrerUserID == _CurrentUser.ID) {
                      //                if (!dataItem.IsHeld)
                      //                    return "<div style='background-color:#e2e2e2; color:transparent;'>***</div>";
                      //                else
                      //                    return "<img onclick='OnclickRevokeMeeting(\"" + dataItem.ID + "\");return false;' class='imgbtnstyle' src='../../../../_layouts/15/Samix.EPM/Icons/application_delete.png' alt='ابطال' title='ابطال' />";
                      //                //return "<button onclick='OnclickRevokeMeeting(\"" + dataItem.ID + "\");return false;' class='k-button k-primary'> ابطال</button>"
                      //            }
                      //            else {
                      //                return "<div style='background-color:#e2e2e2; color:transparent;'>*** </div>"

                      //            }
                      //        }


                      //        else {
                      //            return "<div style='background-color:#e2e2e2; color:transparent;'>*** </div>"

                      //        }




                      //    },
                      //},

                         //{
                         //    title: "حذف",
                         //    width: 10,
                         //    editable: false,
                         //    template: function (dataItem) {
                         //        if (dataItem.IsDeleted) {
                         //            return "<div style='background-color:#ffb3b3;text-align:center;'>__حذف_شده__</div> "
                         //        }
                         //        if (!dataItem.IsRevoke && !dataItem.IsDeleted) {
                         //            if (_CurrentUser.ID == dataItem.SecretaryUserId || dataItem.RegistrerUserID == _CurrentUser.ID || (isAdmin)) {
                         //                if (!dataItem.IsHeld)
                         //                    return "<div style='background-color:#e2e2e2; color:transparent;'>***</div>";
                         //                else
                         //                    return "<img onclick='OnclickDeleteMeeting(\"" + dataItem.ID + "\");return false;' class='imgbtnstyle' src='../../../../_layouts/15/Samix.EPM/Icons/Delete.png' alt='حذف' title='حذف' />";

                         //                //return "<button onclick='OnclickDeleteMeeting(\"" + dataItem.ID + "\");return false;' class='k-button k-primary'> حذف</button>"
                         //            } else {
                         //                return "<div style='background-color:#e2e2e2; color:transparent;'>*** </div>"
                         //            }
                         //        }
                         //        else {
                         //            return "<div style='background-color:#e2e2e2; color:transparent;'>*** </div>"
                         //        }
                         //    },
                         //},
        ],

        toolbar: "<button title='افزودن جلسه جدید' type='button'  class='k-primary' onclick='OnclickAddMeeting();return false;'><img class='imgstyl' src='../../../../_layouts/15/Samix.EPM/Icons/add.png' />افزودن جلسه جدید</button>",
        dataBinding: function () {
            record = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    }).data("kendoGrid");

}
function OnclickEditMeeting(id) {
    OnclickAddMeeting();
    for (var i = 0; i < meetingDataSource.length ; i++) {
        if (id == meetingDataSource[i].ID) {
            meetingID = id;
            MettingClass.Title = meetingDataSource[i].Title;
            MettingClass.PlaceAddress = meetingDataSource[i].PlaceAddress;
            MettingClass.SecretaryUserId = meetingDataSource[i].SecretaryUserId;
            MettingClass.RegistrerUserID = meetingDataSource[i].RegistrerUserID;
            MettingClass.PlaceID = meetingDataSource[i].PlaceID;
            MettingClass.UnitID = meetingDataSource[i].UnitID;
            MettingClass.MeetingTemplateID = meetingDataSource[i].MeetingTemplateID;
            MettingClass.StartTime = meetingDataSource[i].StartTime;
            MettingClass.FinishTime = meetingDataSource[i].FinishTime;
            
            
        }

    }

    fiilDataTab1();


}
function OnclickAddMeeting()
{
    $("#PanelGridMetting").hide();
    $("#PanelAddHoldingDeal").show();
}

function btnCanselMetting() {
    $("#PanelGridMetting").show();
    $("#PanelAddHoldingDeal").hide();
}

function selectedColorTab(selectTab) {

    //  document.getElementById("spanTabDealRequest").style.color = "cornsilk";
    // document.getElementById("spanTabConsultantSelectingMethod").style.color = "cornsilk";
    // document.getElementById("spanTabBigLimitedAndPublicDealCheckList").style.color = "cornsilk";
    document.getElementById("spanTabMettingTab1").style.color = "cornsilk";
    document.getElementById("spanTabMettingTab2").style.color = "cornsilk";
    document.getElementById("spanTabMettingTab3").style.color = "cornsilk";
   
   
    if (selectTab == 1) {
        document.getElementById("spanTabMettingTab1").style.color = "#ffd800";
       
    }
   else if (selectTab == 2) {
       document.getElementById("spanTabMettingTab2").style.color = "#ffd800";
       LoadDataTab2();
      
   }
   else if (selectTab == 3) {
       document.getElementById("spanTabMettingTab3").style.color = "#ffd800";
       LoadDataTab3();
   }
    //else if (selectTab == 5) {
    //    document.getElementById("spanTabBypassProtocolt").style.color = "#ffd800";
    //}
   

}

function GetAllMetting() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllMetting",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: success_GetAllBiddingMethod,
      

    });
}

function success_GetAllBiddingMethod(respons) {
    debugger;

    meetingDataSource = respons.d;
    $("#GRDMeetings").data("kendoGrid").dataSource.read();
}

function SabtJalesat()
{
        MettingClass.ID=meetingID;
        MettingClass.Title = $("#TXTMeetingTitle").val();
        MettingClass.Description = $("#TXTMeetingAgenda").val();
        MettingClass.FinishTime = $("#TIMFinishTime").val();
        MettingClass.StartTime = $("#TIMStartTime").val();

        MettingClass.PlaceID = $("#DDLMeetingPlace").val();
        MettingClass.SecretaryUserId = $("#DDLMeetingSecretary").val();
        MettingClass.RegistrerUserID = $("#DDLRegisterer").val();
        MettingClass.TarikhMetting = $("#DATMeetingDate").val();
        MettingClass.UnitID = $("#DDLUnit").val();
        MettingClass.MeetingTemplateID = $("#DDLMeetingTemplate").val();
        CountTedadUser();

        var jsonData = JSON.stringify({

            _MettingJson: MettingClass,
            _AlertJson: DSAlerts,
            _MeetingUserRelJson: MeetingUserRelJson
         



        });
        $.ajax({
            type: "POST",

            url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/SaveMetting",
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            dataType: "json",
            success: succes_SabtJalesat,
            erore: erore_SabtJalesat,

        });
    


}
function CountTedadUser()
{
    debugger;
    MeetingUserRelJson=[];
    for(var  i=0;i<GRDUsersInternal_data.length;i++)
    {
        MeetingUserRelJson.push(AddClassUserInListUser(GRDUsersInternal_data[i],"False"))
    }
    for(var  i=0;i<GRDAllUsersOrderUser_data.length;i++)
    {
        MeetingUserRelJson.push(AddClassUserInListUser(GRDAllUsersOrderUser_data[i],"True"))
    }
    for(var  i=0;i<GRDGetInFormedUser_data.length;i++)
    {
        MeetingUserRelJson.push(AddClassUserInListUser(GRDGetInFormedUser_data[i],"False"))
    }
    if (SelectUserSecretary.ID != null) {
        MeetingUserRelJson.push(SelectUserSecretary);
    }
}



function succes_SabtJalesat(respons)
{
    meetingID = "";
    btnCanselMetting();
    GetAllMetting();
}
function erore_SabtJalesat()
{

}
function SetClassAlert(alertitem,EmailOrSms)
{
    debugger;
   var ClassAddAlert = {};
   ClassAddAlert.FullName = alertitem.FullName;
   ClassAddAlert.UserID = alertitem.ID;
    //ClassAddAlert.Mobile = alertitem.Mobile;
    //ClassAddAlert.Email = alertitem.Email;
    ClassAddAlert.AlarmType = EmailOrSms;
    ClassAddAlert.AlarmTarikh = _Curentdate;
    ClassAddAlert.SaatErsal = currenttime;
    ClassAddAlert.Title = "ارسال همین لحظه";
    ClassAddAlert.ID = 1;
    ClassAddAlert.IsSent = false;

    return ClassAddAlert;
}
function LoadDataTab3() {
    debugger;
   // DSAlerts = [];
   // GetAllAlerByMettingId();
    GetCrentTime();
  
    DSAlertsAddChekList = [];

    if ($("#CHKSendSmsRightNow").is(":checked") == true){
        for (var i = 0; i < GRDUsersInternal_data.length ; i++) {
           
            DSAlertsAddChekList.push(SetClassAlert(GRDUsersInternal_data[i], "SMS"));

        }
        for (var i = 0; i < GRDAllUsersOrderUser_data.length ; i++) {
       
            DSAlertsAddChekList.push(SetClassAlert(GRDAllUsersOrderUser_data[i], "SMS"));
        }
        for (var i = 0; i < GRDGetInFormedUser_data.length ; i++) {
            DSAlertsAddChekList.push(SetClassAlert(GRDGetInFormedUser_data[i], "SMS"));
        }
        if (SelectUserSecretary.FullName != "") {
            DSAlertsAddChekList.push(SetClassAlert(SelectUserSecretary, "SMS"));
        }
       

       
    }
   
    if ($("#CHKSendMailRightNow").is(":checked") == true) {
        
        for (var i = 0; i < GRDUsersInternal_data.length ; i++) {
            DSAlertsAddChekList.push(SetClassAlert(GRDUsersInternal_data[i], "Email"));

        }
        for (var i = 0; i < GRDAllUsersOrderUser_data.length ; i++) {
 
            DSAlertsAddChekList.push(SetClassAlert(GRDAllUsersOrderUser_data[i], "Email"));
        }
        for (var i = 0; i < GRDGetInFormedUser_data.length ; i++) {
            DSAlertsAddChekList.push(SetClassAlert(GRDGetInFormedUser_data[i], "Email"));
        }
        if (SelectUserSecretary.FullName != "") {
            DSAlertsAddChekList.push(SetClassAlert(SelectUserSecretary, "Email"));
        }
       
       

    }
   
    FainalAlert();
   
   
  

}
function GetCrentTime() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetCurrentTime",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: function (response) {
            currenttime = response.d;
            //parseInt(response.d);
        }
    });
}

function FainalAlert()
{
    debugger;
    var ShomareId = 1;
 
    for(var i=0;i<DSAlertsAddChekList.length;i++)
    {
        DSAlertsAddChekList[i].ID = ShomareId;
        ShomareId++;
        DSAlerts.push(DSAlertsAddChekList[i]);
    }
    for (var i = 0; i < DSAlertsAddRegisteri.length; i++) {
        DSAlertsAddRegisteri[i].ID = ShomareId;
        ShomareId++;
        DSAlerts.push(DSAlertsAddRegisteri[i]);
       
    }
    $("#GRDAlert").data("kendoGrid").dataSource.read();
}

function LoadDataTab2() {
    debugger;
    GetAllMeetingUserRelIdInternal();
    GetAllMeetingUserRelIdNotInternal();
    GetAllMeetingUserRelIdIsGetInFormed();
}
function GetAllMeetingUserRelIdInternal() {
    if (meetingID != "") {
        var jsonData = JSON.stringify({

            MettingId: meetingID,
            IsGetInFormed: "False",
            IsInternal: "True"



        });
        $.ajax({
            type: "POST",

            url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllMeetingUserRelId",
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            dataType: "json",
            success: succes_GetAllMeetingUserRelIdInternal,


        });
    }
}
function succes_GetAllMeetingUserRelIdInternal(respons) {
    debugger;
    var listuserInternal = respons.d;
    GRDUsersInternal_data = [];

    for (var i = 0; i < listuserInternal.length; i++) {
        GRDUsersInternal_data.push(AddClassUserInListUser(listuserInternal[i],"False"));
    }
    $("#GRDUsersInternal").data("kendoGrid").dataSource.read();

}

function GetAllMeetingUserRelIdIsGetInFormed() {
    if (meetingID != "") {
        var jsonData = JSON.stringify({

            MettingId: meetingID,
            IsGetInFormed: "True",
            IsInternal: "True"



        });
        $.ajax({
            type: "POST",

            url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllMeetingUserRelId",
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            dataType: "json",
            success: succes_GetAllMeetingUserRelIdIsGetInFormed,


        });
    }
}
function succes_GetAllMeetingUserRelIdIsGetInFormed(respons) {

    var listuserIsGetInFormed = respons.d;
    GRDGetInFormedUser_data = [];
    for (var i = 0; i < listuserIsGetInFormed.length; i++) {
        GRDGetInFormedUser_data.push(AddClassUserInListUser(listuserIsGetInFormed[i],"True"));
    }


    $("#GRDGetInFormedUser").data("kendoGrid").dataSource.read();

}
function GetAllMeetingUserRelIdNotInternal() {
    if (meetingID != "") {
        var jsonData = JSON.stringify({

            MettingId: meetingID,
            IsGetInFormed: "False",
            IsInternal: "False"



        });
        $.ajax({
            type: "POST",

            url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllMeetingUserRelId",
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            dataType: "json",
            success: succes_GetAllMeetingUserRelIdNotInternal


        });
    }
}
function succes_GetAllMeetingUserRelIdNotInternal(respons) {
    var listuserNotInternal = respons.d;
    GRDAllUsersOrderUser_data = [];
   
    for (var i = 0; i < listuserNotInternal.length; i++)
    {
        GRDAllUsersOrderUser_data.push(AddClassUserInListUser(listuserNotInternal[i],"False"));
    }
    
    $("#GRDAllUsersOrderUser").data("kendoGrid").dataSource.read();

}
function AddClassUserInListUser(dataiteme, IsGetInFormed) {
    debugger;
    var AddUserClass = {};
    AddUserClass.ID = dataiteme.ID;
    AddUserClass.FullName = dataiteme.FullName;
    AddUserClass.Mobile = dataiteme.Mobile;
    AddUserClass.Email = dataiteme.Email;
    AddUserClass.Department = dataiteme.Department;
    AddUserClass.IsGetInFormed = IsGetInFormed;
    AddUserClass.IsPersent = "True";
    return AddUserClass;
}



