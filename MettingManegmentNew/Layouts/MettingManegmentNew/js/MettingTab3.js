



$(document).ready(function () {
    initGRDAlert();
    DatePicker('DATAlertDate');

    InitStartAlertTime();
    InitDDLAlertType();
    GetAllAlerByMettingId();
    

});
function GetAllAlerByMettingId() {
    if (meetingID != "") {
        var jsonData = JSON.stringify({

            MettingId: meetingID,



        });
        $.ajax({
            type: "POST",

            url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetAllAlerByMettingId",
            contentType: "application/json; charset=utf-8",
            data: jsonData,
            dataType: "json",
            success: succes_GetAllAlerByMettingId,


        });
    }
}
function succes_GetAllAlerByMettingId(respons)
{
    DSAlerts = respons.d;
    $("#GRDAlert").data("kendoGrid").dataSource.read();

}
function InitStartAlertTime() {
    $("#TIMStartAlertTime").kendoComboBox({
        dataSource: _TimeArray,
        optionLabel: "ساعت ارسال هشدار",

    });
}
function InitDDLAlertType() {
    $("#DDLAlertType").kendoComboBox({
        dataSource: _TypeAlert,
        dataTextField: "text",
        dataValueField: "value",

    });
}
function initGRDAlert()
{
    var PlacesDataSource = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                e.success(DSAlerts);
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
    $("#GRDAlert").kendoGrid({
        dataSource: PlacesDataSource,
        //scrollable: false,
        //persistSelection: true,
        //navigatable: true,
        //sortable: true,
        //selectable: true,
        columns: [
              { field: "ID", title: "ردیف", width: 40, editable: false },
               { field: "Title", title: "عنوان", width: 100, editable: false },
             { field: "AlarmTarikh", title: " تاریخ ارسال", width: 100, editable: false },
                { field: "SaatErsal", title: " زمان ارسال", width: 100, editable: false },
                    { field: "FullName", title: " نام ", width: 100, editable: false },
                     //{ field: "Mobile", title: "موبایل", width: 100, editable: false },
                     // { field: "Email", title: "ایمیل", width: 100, editable: false },
                 {
                     template: function (e) {
                         if (e.AlarmType == "SMS") {
                             return "پیامک "
                         }
                         if (e.AlarmType == "Email") {
                             return "ایمیل "
                         }
                       
                     },
                     title: "نوع اطلاع رسانی",
                     width: 100,
                     editable: false

                 },

               {
                   template: function (dataItem) {
                    //   if (_Mode == "Update") {

                       //    if (FullDateTimeToInt(dataItem.AlarmTime) > _CurrentTime) {
                       //        return "<button onclick='OnclickDeleteAlert(\"" + dataItem.ID + "\");return false;'  class='k-button k-primary'> حذف</button>"
                       //    }
                       if (dataItem.IsSent) {
                           return "<div style='background-color:#e2e2e2; color:transparent;'>*** </div>"
                       }
                       else {
                           return "<button onclick='OnclickDeleteAlert(\"" + dataItem.ID + "\");return false;' class='k-button k-primary'> حذف</button>"
                       }

                   },
                   title: "حذف",
                   width: 80
               },
        ],
    }).data("kendoGrid");
}
function OnclickDeleteAlert(ID) {
   
    for (var i = 0; i < DSAlerts.length; i++) {
        if (DSAlerts[i].ID == ID) {
            DSAlerts.splice(i, 1);
            //ShowAlert("danger", "هشدار از لیست حذف گردید");
        }
    }
       
   $("#GRDAlert").data("kendoGrid").dataSource.read();
    
    //else {
    //    alert("در حالت ویرایش امکان حذف هشدارها وجود ندارد");
    //}
}
function RegisteriAlert() {
    debugger;
    GetCrentTime();
    var ListUserAddAlertSelected = [];
    if ($("#DATAlertDate").val() == "") {
        _notification.show("لطفا ابتدا تاریخ را جلسه وارد کنید", "warning");
        return;
    }
    if ($("#DATAlertDate").val() == "")
    {
        _notification.show("لطفا ابتدا تاریخ را وارد کنید", "warning");
        return;
    }
    if ($("#TIMStartAlertTime").val() == "") {
        _notification.show("لطفا ابتدا زمان را وارد کنید", "warning");
        return;
    }
    if ($("#DDLAlertType").val() == "") {
        _notification.show("لطفا ابتدا نوع اطلا رسانی را وارد کنید", "warning");
        return;
    }
    if (DateToInt($("#DATAlertDate").val()) < DateToInt(_Curentdate))
    {
        _notification.show("امکان ثبت هشدار قبل از تاریخ امروز نمی باشد", "warning");
        return;
    }
    if (DateToInt($("#DATAlertDate").val()) == DateToInt(_Curentdate))
    {
        if(TimeToInt($("#TIMStartAlertTime").val())<TimeToInt(currenttime))
        {
            _notification.show("امکان ثبت هشدار قبل از ساعت جاری نمی باشد", "warning");
            return;
        }
    }
    if (DateToInt($("#DATMeetingDate").val()) < DateToInt(_Curentdate))
    {
        _notification.show("امکان ثبت هشدار بعد از تاریخ جلسه نمی باشد", "warning");
        return;
    }
    for (var i = 0; i < GRDUsersInternal_data.length ; i++) {

        ListUserAddAlertSelected.push(GRDUsersInternal_data[i]);

    }
    for (var i = 0; i < GRDAllUsersOrderUser_data.length ; i++) {
        ListUserAddAlertSelected.push(GRDAllUsersOrderUser_data[i]);
      
    }
    for (var i = 0; i < GRDGetInFormedUser_data.length ; i++) {
        ListUserAddAlertSelected.push(GRDGetInFormedUser_data[i]);
      
    }
    //DSAlertsAddRegisteri = [];
    for (var i = 0; i < ListUserAddAlertSelected.length; i++) {
        if ($("#DDLAlertType").val() == "1") 
        {
            DSAlertsAddRegisteri.push(SetClassAddUserAlert(ListUserAddAlertSelected[i], "Email"));
            if (SelectUserSecretary.FullName != "") {
                DSAlertsAddRegisteri.push(SetClassAddUserAlert(SelectUserSecretary, "Email"));
            }
           
        }
        if ($("#DDLAlertType").val() == "2") 
        {
            DSAlertsAddRegisteri.push(SetClassAddUserAlert(ListUserAddAlertSelected[i], "SMS"));
            if (SelectUserSecretary.FullName != "") {
                DSAlertsAddRegisteri.push(SetClassAddUserAlert(SelectUserSecretary, "SMS"));
            }
        }
        if ($("#DDLAlertType").val() == "3") 
        {
            DSAlertsAddRegisteri.push(SetClassAddUserAlert(ListUserAddAlertSelected[i], "SMS"))
            DSAlertsAddRegisteri.push(SetClassAddUserAlert(ListUserAddAlertSelected[i], "Email"))
            if (SelectUserSecretary.FullName != "") {
                DSAlertsAddRegisteri.push(SetClassAddUserAlert(SelectUserSecretary, "SMS"));
                DSAlertsAddRegisteri.push(SetClassAddUserAlert(SelectUserSecretary, "Email"));
            }
        }
    }

 
    FainalAlert();
 



}

function SetClassAddUserAlert(alertitem,EmailOrSms)
{
   
    debugger;
    var ClassAddAlert = {};
    ClassAddAlert.FullName = alertitem.FullName;
    ClassAddAlert.UserID = alertitem.ID;
    //ClassAddAlert.Email = alertitem.Email;
    ClassAddAlert.AlarmType = EmailOrSms;
    ClassAddAlert.AlarmTarikh = $("#DATAlertDate").val();;
    ClassAddAlert.SaatErsal = $("#TIMStartAlertTime").val();
    ClassAddAlert.IsSent = false;
    ClassAddAlert.ID = 1;
    ClassAddAlert.Title = "هشدار";


    return ClassAddAlert;
}


function ChengSmsChecked()
{
    debugger;

    if (DateToInt($("#DATMeetingDate").val()) < DateToInt(_Curentdate))
    {
        _notification.show("امکان ثبت هشدار بعد از تاریخ جلسه نمی باشد", "warning");
        return;
    }
    
    if ($("#CHKSendSmsRightNow").is(":checked") == true) {
        LoadDataTab3();
    }
 

}
function ChengMailChecked()
{
    if (DateToInt($("#DATMeetingDate").val()) < DateToInt(_Curentdate)) {
        _notification.show("امکان ثبت هشدار بعد از تاریخ جلسه نمی باشد", "warning");
        return;
    }
    if ($("#CHKSendMailRightNow").is(":checked") == true) {
        LoadDataTab3();
    }

}





