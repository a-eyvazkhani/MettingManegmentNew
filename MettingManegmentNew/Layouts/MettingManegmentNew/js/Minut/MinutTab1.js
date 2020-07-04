




function ChenqRedioRADIsHeld()
{
 
    if ($("#RADIsHeld").is(":checked") == true) {
        _Held = true;
        $("#mainbuttons").show();
        $("#panelshowhideisheld").show();
        FiilDataMinut();
      
    }
}
function FiilDataMinut()
{
    $("#TXTMinutTitle").val(_MeetingsTitle);
    GetMinuteUpdatePage();

    Get_Data_Unit();
    GetAllUserInternal();
    GetAllUserUseMettingInternal();
    GetAllUserUseMettingNotInternal();
    GetAllTaskByMettingID();


   
    
}
function GetAllTaskByMettingID()
{
    var jsonData = JSON.stringify({ MeetingID: _MeetingUid });
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllTaskByMettingID",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success: success_GetAllTaskByMettingID,




    });
}
function success_GetAllTaskByMettingID(respons)
{
    debugger;
    TaskList = respons.d;
    $("#GRDTasks").data("kendoGrid").dataSource.read();
}
function ChenqRedioRADIsNotHeld()
{
    if ($("#RADIsNotHeld").is(":checked") == true) {
        _Held = false;
        $("#mainbuttons").show();
        $("#panelshowhideisheld").hide();
    }
}
function GetAllUserUseMettingInternal()
{
    var jsonData = JSON.stringify({ MeetingID: _MeetingUid });
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllUserUseMettingInternal",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success: success_GetAllUserUseMettingInternal,




    });
}
function success_GetAllUserUseMettingInternal(respons)
{
    debugger;
    ListUserInit = respons.d;
    $("#GRDMeetingPresents").data("kendoGrid").dataSource.read();
}


function GetAllUserUseMettingNotInternal() {
    var jsonData = JSON.stringify({ MeetingID: _MeetingUid });
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllUserUseMettingNotInternal",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success: success_GetAllUserUseMettingNotInternal,




    });
}
function success_GetAllUserUseMettingNotInternal(respons) {
    debugger;
    ListUserOrder = respons.d;
    $("#GRDMeetingOutPresents").data("kendoGrid").dataSource.read();
}


function loadSDatChekedChengMinute() {
   // GetMinuteUpdatePage(_Meeting.ID)
}
function GetMinuteUpdatePage() {

    var jsonData = JSON.stringify({ MeetingID: _MeetingUid });
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetMinutByMeetingID",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success: success_GetMinuteUpdatePage,




    });
}
function success_GetMinuteUpdatePage(respons)
{
    debugger;
    if (respons.d != "") {
        _MinutClass = respons.d;
        $("#TXTMinutDescription").val(_MinutClass[0].NegotiationsDescription);
        MinutUid = _MinutClass[0].ID;
    }
}

function Get_Data_Unit() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllUnitJson",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGet_Data_Unit

    });

}
function successGet_Data_Unit(respons) {
    debugger;
    DSUnit = respons.d;

    var combobox = $("#DDLUnitCompanies").data("kendoDropDownList");
    combobox.setDataSource(DSUnit);
    combobox.refresh();
}


function GetAllUserInternal() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllUserInternal",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGetAllUserInternal

    });

}
function successGetAllUserInternal(respons) {
    debugger;
    DSMasolAnjam = respons.d;
    DSApprover = respons.d;

    var combobox = $("#DDLUsers").data("kendoDropDownList");
    combobox.setDataSource(DSMasolAnjam);
    combobox.refresh();



    var combobox = $("#DDLApprover").data("kendoDropDownList");
    combobox.setDataSource(DSApprover);
    combobox.refresh();
}
function AddTasks()
{
 
    TaskList.push(SetTaskAddToclassDataForm());
    $("#GRDTasks").data("kendoGrid").dataSource.read();
}
function SelectDDLMasolAnjam(e) {
    debugger;
    var dataItem = this.dataItem(e.item);


    SelectUserMasolAnjamText = dataItem.FullName;
       
        // GetUserTimingGauge();

    


}
function SelectDDLApprover(e) {
    debugger;
    var dataItem = this.dataItem(e.item);


    SelectUserAproveText = dataItem.FullName;

}
function SetTaskAddToclassDataForm() {

    debugger;
    var TaskClass = {};
  
    TaskClass.Title = $("#TXTTaskTitle").val();
    TaskClass.UnitID = $("#DDLUnitCompanies").val();
    TaskClass.MeetingID = _MeetingUid;
    TaskClass.EstimatedTimeText = $("#TxtEstimatedTime").val();
    

    TaskClass.MasolAnjamID = $("#DDLUsers").val();
   
    TaskClass.MasolAnjamFullName = SelectUserMasolAnjamText;
    TaskClass.Aprove1IDFullName = SelectUserAproveText;
    TaskClass.Aprove1ID = $("#DDLApprover").val();
    TaskClass.IsCarent = 1;
    TaskClass.Persent = 0;
    TaskClass.StatusSave = 1;
    TaskClass.ShomareRadif = 1;
    TaskClass.TarikhStart = $("#DATTaskDate").val();

    return TaskClass;
}

function RegisterClic()
{
    debugger;
    MinutClass.ID = MinutUid;
    MinutClass.Title = $("#TXTMinutDescription").val();
    MinutClass.MeetingId = _MeetingUid;
    MinutClass.NegotiationsDescription = $("#TXTMinutDescription").val();
  

    var jsonData = JSON.stringify({

        MinutClass: MinutClass,
        TaskList: TaskList,
    });
    $.ajax({
        type: "POST",

        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/SaveMinut",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success: succes_SaveMinut,
        erore: erore_SaveMinut,

    });


}
function succes_SaveMinut()
{

}
function erore_SaveMinut()
{

}


function selectOutUsersRow() {

    var checked = this.checked,
    row = $(this).closest("tr"),
    gridOutUsers = $("#GRDMeetingOutPresents").data("kendoGrid"),
    dataItem = gridOutUsers.dataItem(row);

    //if (checked) {

    //    row.removeClass("k-state-selected");
    //    _Working.OutUsers.push(dataItem);
    //} else {

    //    var isexist = false;
    //    for (var i = 0; i < _Meeting.OuterUsers.length; i++) {

    //        for (var j = 0; j < _Working.OutUsers.length; j++) {
    //            if (_Working.OutUsers[j].ID == dataItem.ID) {
    //                isexist = true;
    //            }
    //        }

    //    }
    //    if (isexist) {
    //        //-select the row

    //        for (var i = 0; i < _Working.OutUsers.length; i++) {
    //            if (dataItem.ID == _Working.OutUsers[i].ID) {
    //                _Working.OutUsers.splice(i, 1);
    //            }
    //        }
    //        row.addClass("k-state-selected");
    //        return;



    //    }

   // }

}


function selectUsersRow() {

    var checked = this.checked,
    row = $(this).closest("tr"),
    gridUsers = $("#GRDMeetingPresents").data("kendoGrid"),
    dataItem = gridUsers.dataItem(row);


    if (checked) {

        row.removeClass("k-state-selected");
        _Working.Users.push(dataItem);
    }
    //else {


    //    var isexist = false;
    //    for (var i = 0; i < _Meeting.InnerUsers.length; i++) {
    //        for (var j = 0; j < _Working.Users.length; j++) {
    //            if (_Working.Users[j].ID == dataItem.ID) {
    //                isexist = true;
    //            }
    //        }

    //    }

    //    if (isexist) {
    //        row.addClass("k-state-selected");
    //        var ischecked = true;
    //        for (var i = 0; i < _Working.Users.length; i++) {
    //            if (dataItem.ID == _Working.Users[i].ID) {
    //                _Working.Users.splice(i, 1);
    //            }
    //        }
    //        return;


    //    }
    //}

}