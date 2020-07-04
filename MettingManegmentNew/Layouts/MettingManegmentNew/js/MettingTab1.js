



$(document).ready(function () {
    DatePicker('DATMeetingDate');
    InitMeetingPlace();
    InitDDLMeetingTemplate();
    InitDDLUnit();
    initDDLMeetingSecretary();
    initDDLRegisterer();

    Get_Data_Place();
    Get_Data_Unit();
    Get_Data_MeetingTemplate();
    GetAllUserInternal();


    GetCurrentDate();
    InitTimeStart();
    InitTimeFinish();
});
function fiilDataTab1() {
    debugger;
    $("#TXTMeetingTitle").val(MettingClass.Title);
    $("#TXTPlaceAddress").val(MettingClass.PlaceAddress);

    $('#DDLMeetingPlace').data('kendoDropDownList').value(MettingClass.PlaceID);
    $('#DDLRegisterer').data('kendoDropDownList').value(MettingClass.RegistrerUserID);
    $('#DDLMeetingSecretary').data('kendoDropDownList').value(MettingClass.SecretaryUserId);
    $('#DDLMeetingTemplate').data('kendoDropDownList').value(MettingClass.MeetingTemplateID);
    $('#DDLUnit').data('kendoDropDownList').value(MettingClass.UnitID);
    $('#TIMStartTime').data('kendoComboBox').text(MettingClass.StartTime);
    $('#TIMFinishTime').data('kendoComboBox').text(MettingClass.FinishTime);

    //$("#DDLRegisterer").val(MettingClass.RegistrerUserID);
    //$("#DDLMeetingSecretary").val(MettingClass.SecretaryUserId);

}
function InitTimeStart() {
    $("#TIMStartTime").kendoComboBox({
        dataSource: _TimeArray,
        change: OnChange_TIMStartTime,
    });
}
function InitTimeFinish() {
    $("#TIMFinishTime").kendoComboBox({

        dataSource: _TimeArray,
        change: OnChange_TIMFinishTime,

    });
}
function OnChange_TIMStartTime() {

}
function OnChange_TIMFinishTime() {

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
    $("#DATMeetingDate").val(_Curentdate);
}

function InitMeetingPlace() {
    $("#DDLMeetingPlace").kendoDropDownList({
        filter: "contains",
        dataTextField: "Title",
        dataValueField: "ID",
        dataSource: DSPlaces,
        optionLabel: " مکان جلسه را انتخاب کنید",
        change: ChenqMeetingPlace
    });
}
function ChenqMeetingPlace(e) {
    debugger;
    var dataItem = this.dataItem(e.item);
    _SelectedPlaceID = dataItem.ID;
    $("#TXTPlaceAddress").val(dataItem.PlaceAddress);
    if ($("#DATMeetingDate").val() != "") {
        GetPlaceTimingGuage();
    }

}

function InitDDLMeetingTemplate() {
    $("#DDLMeetingTemplate").kendoDropDownList({
        filter: "contains",
        dataTextField: "Title",
        dataValueField: "ID",
        dataSource: DSMeetingTemplate,
        optionLabel: "قالب را انتخاب کنید",
    });
}
function InitDDLUnit() {
    $("#DDLUnit").kendoDropDownList({
        filter: "contains",
        dataTextField: "Title",
        dataValueField: "ID",
        dataSource: DSUnit,
        optionLabel: "واحد را انتخاب کنید",
    });
}
function initDDLMeetingSecretary() {
    $("#DDLMeetingSecretary").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: DSMeetingPropAllUsers,
        optionLabel: "دبیر جلسه",
        change: SelectinitDDLMeetingSecretary,
    });
}
function SelectinitDDLMeetingSecretary(e) {
    debugger;
    var dataItem = this.dataItem(e.item);
    if ((dataItem.ID != "") && (dataItem.FullName != "")) {

        MettingClass.SecretaryUserId = dataItem.ID;
        SelectUserSecretary.ID = dataItem.ID;
        SelectUserSecretary.FullName = dataItem.FullName;
        SelectUserSecretary.Email = dataItem.Email;
        SelectUserSecretary.Mobile = dataItem.Mobile;
        SelectUserSecretary.IsGetInFormed = "False";
        SelectUserSecretary.IsPersent = "True";
       // GetUserTimingGauge();

    }
   

}

function initDDLRegisterer() {
    $("#DDLRegisterer").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: DSMeetingPropAllUsers,
        optionLabel: "منشی جلسه",
    });
}
function Get_Data_Place() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllMeetingPlaces",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGet_Data_Place

    });

}
function successGet_Data_Place(respons) {
    debugger;
    DSPlaces = respons.d;

    var combobox = $("#DDLMeetingPlace").data("kendoDropDownList");
    combobox.setDataSource(DSPlaces);
    combobox.refresh();
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

    var combobox = $("#DDLUnit").data("kendoDropDownList");
    combobox.setDataSource(DSUnit);
    combobox.refresh();
}

function Get_Data_MeetingTemplate() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllMeetingTemplate",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGet_Data_MeetingTemplate

    });

}
function successGet_Data_MeetingTemplate(respons) {
    debugger;
    DSMeetingTemplate = respons.d;

    var combobox = $("#DDLMeetingTemplate").data("kendoDropDownList");
    combobox.setDataSource(DSMeetingTemplate);
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
    DDLRegisterer = respons.d;

    var combobox = $("#DDLRegisterer").data("kendoDropDownList");
    combobox.setDataSource(DDLRegisterer);
    combobox.refresh();



    var combobox = $("#DDLMeetingSecretary").data("kendoDropDownList");
    combobox.setDataSource(DDLRegisterer);
    combobox.refresh();
}



//function GetAllUserInternal() {
//    $.ajax({
//        type: "POST",
//        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllUserInternal",
//        contentType: "application/json; charset=utf-8",
//        data: "",
//        dataType: "json",
//        success: successGetAllUserInternal

//    });

//}
//function successGetAllUserInternal(respons) {
//    debugger;
//    DDLRegisterer = respons.d;

//    var combobox = $("#DDLRegisterer").data("kendoDropDownList");
//    combobox.setDataSource(DDLRegisterer);
//    combobox.refresh();



//    var combobox = $("#DDLMeetingSecretary").data("kendoDropDownList");
//    combobox.setDataSource(DDLRegisterer);
//    combobox.refresh();
//}


function GetPlaceTimingGuage() {
    var meetingdate = $("#DATMeetingDate").val();

    var jsonData = JSON.stringify({ date: meetingdate, placeid: _SelectedPlaceID });

    $.ajax({
        type: "POST",
   
        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetPlaceTimingGuage",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success:successGetPlaceTimingGuage
            

       
       
    });
}
function successGetPlaceTimingGuage(response) {
    _PlaceTimingGuge = response.d

    $("#gaugeplace").kendoLinearGauge({
        scale: {
            majorUnit: 1,
            minorUnit: 0.25,
            min: 0,
            max: 24,
            vertical: false,
            ranges: _PlaceTimingGuge
        }

    });
}


