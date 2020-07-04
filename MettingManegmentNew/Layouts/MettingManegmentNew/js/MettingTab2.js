






$(document).ready(function () {

    initcmbAllUsersInternal();
    initGRDUsersInternal();


    initcmbAddUsersOrderUser();
    InitGRDAllUsersOrderUser();


    InitcmbAddGetInFormedUser();
    InitGRDGetInFormedUser();
    Get_Data_cmbAddAllUsersInternal();
    Get_Data_cmbAddAll_Outer();
    GetAllMeetingUserRelIdInternal();
    GetAllMeetingUserRelIdNotInternal();
    GetAllMeetingUserRelIdIsGetInFormed();


});
function initcmbAllUsersInternal() {
    $("#cmbAllUsersInternal").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: cmbAllUsersInternal_data,
        change: SelectinitcmbAllUsersInternal,
        optionLabel: "افزودن افراد درون سازمانی",
    });
}
function SelectinitcmbAllUsersInternal(e) {
    debugger;
    if (!$("#DATMeetingDate").val()) {
        _notification.show("تاریخ انتخاب نشده", "warning");

        return;
    }

    var dataItem = this.dataItem(e.item);
    if (dataItem.ID != "") {
        for (var i = 0; i < GRDUsersInternal_data.length ; i++) {

            if (GRDUsersInternal_data[i].ID == dataItem.ID) {

                _notification.show("شخص قبلا اضافه گردیده", "warning");
                isrepeated = false;
                return;
            }
        }
        for (var i = 0; i < GRDGetInFormedUser_data.length ; i++) {

            if (GRDGetInFormedUser_data[i].ID == dataItem.ID) {

                _notification.show("شخص قبلا اضافه گردیده", "warning");
                isrepeated = false;
                return;
            }
        }
        _SelectUserId = dataItem.ID
        GetUserTimingGauge();
        GRDUsersInternal_data.push(AddClassUserInListUser(dataItem, "False"));


        //ShowAlert("success", "شخص به لیست اضافه گردید");
        $("#GRDUsersInternal").data("kendoGrid").dataSource.read();
        //InitTimigGugeOutUsers();
        //countUsers.push(dataItem);
    }

}

function initGRDUsersInternal() {
    var PlacesDataSource = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                e.success(GRDUsersInternal_data);
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

    $("#GRDUsersInternal").kendoGrid({
        dataSource: PlacesDataSource,
        //pageable: {
        //    buttonCount: 5
        //},
        //scrollable: false,
        //persistSelection: true,
        //navigatable: true,
        //sortable: true,
        //filterable: {
        //    mode: "row"
        //},
        ////groupable: true,
        // selectable: true,
        columns: [


            //{
            //    title: "ردیف",
            //    template: "#= ++record #",
            //    width: 10
            //},

         //   { field: "RowNumber", title: "ردیف", width: 20, editable: false },
                 { field: "FullName", title: "نام", width: 120, editable: false },
                //{ field: "LastName", title: "نام خانوادگی", filterable: { multi: true, search: true }, width: 120 },
                 { field: "Mobile", title: "موبایل", filterable: { multi: true, search: true }, width: 120 },
               { field: "Email", title: "ایمیل", filterable: { multi: true, search: true }, width: 120 },
                 { field: "Department", title: "گروه سازمانی", filterable: { multi: true, search: true }, width: 120 },
                  //{
                  //    command: {
                  //        name: "addUser",
                  //        text: "افزودن",
                  //        title: "اضافه کردن شخص",
                  //        click: ClickCommandAddAllUser
                  //    },
                  //    title: "افزودن", width: "50px"
                  //},
                  {
                      title: "حذف",
                      width: 60,
                      editable: false,
                      template: function (dataItem) {
                          if (dataItem.ID == MettingClass.SecretaryUserId) {
                              return "<div style='background-color:#e2e2e2; color:transparent;'>*****</div>"
                          }
                          else {
                              return "<button onclick='OnclickDeleteInnerUser(\"" + dataItem.ID + "\");return false;'class='k-button k-primary'> حذف</button>"
                          }
                      }
                  }
        ],

    }).data("kendoGrid");
}

function OnclickDeleteInnerUser(id) {
    debugger;
    var dataItem;
    if (id == MettingClass.SecretaryUserId) {
        _notification.show("امکان حذف دبیر جلسه وجود ندارد", "warning");
    }
    for (var i = 0; i < GRDUsersInternal_data.length; i++) {
        if (GRDUsersInternal_data[i].ID == id) {

            dataItem = GRDUsersInternal_data[i];
            GRDUsersInternal_data.splice(i, 1);
            $("#GRDUsersInternal").data("kendoGrid").dataSource.read();
            break;
        }

    }
}




function initcmbAddUsersOrderUser() {
    $("#cmbAddUsersOrderUser").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: cmbAddUsersOrderUser_data,
        optionLabel: "افزودن افراد برون سازمانی",
        change: SelectinitcmbAllOrderUser,
    });
}


function SelectinitcmbAllOrderUser(e) {
    debugger;
    if (!$("#DATMeetingDate").val()) {
        _notification.show("تاریخ انتخاب نشده", "warning");

        return;
    }

    var dataItem = this.dataItem(e.item);
    if (dataItem.ID != "") {


        for (var i = 0; i < GRDAllUsersOrderUser_data.length ; i++) {

            if (GRDAllUsersOrderUser_data[i].ID == dataItem.ID) {

                _notification.show("شخص قبلا اضافه گردیده", "warning");
                isrepeated = false;
                return;
            }
        }

        GRDAllUsersOrderUser_data.push(AddClassUserInListUser(dataItem, "False"));


        //ShowAlert("success", "شخص به لیست اضافه گردید");
        $("#GRDAllUsersOrderUser").data("kendoGrid").dataSource.read();
        //InitTimigGugeOutUsers();
        //countUsers.push(dataItem);
    }

}

function InitGRDAllUsersOrderUser() {
    var PlacesDataSource = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                e.success(GRDAllUsersOrderUser_data);
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
    $("#GRDAllUsersOrderUser").kendoGrid({
        dataSource: PlacesDataSource,
        //pageable: {
        //    buttonCount: 5
        //},
        //scrollable: false,
        //persistSelection: true,
        //navigatable: true,
        //sortable: true,
        //filterable: {
        //    mode: "row"
        //},
        //groupable: true,
        //selectable: true,
        columns: [
            // { field: "RowNumber", title: "ردیف", width: 20, editable: false },
                 { field: "FullName", title: "نام", width: 120, editable: false },
               // { field: "LastName", title: "نام خانوادگی", filterable: { multi: true, search: true }, width: 120 },
                { field: "Mobile", title: "موبایل", filterable: { multi: true, search: true }, width: 120 },
               { field: "Email", title: "ایمیل", filterable: { multi: true, search: true }, width: 120 },
                 { field: "Department", title: "گروه سازمانی", filterable: { multi: true, search: true }, width: 120 },
                  {
                      title: "حذف",
                      width: 60,
                      editable: false,
                      template: function (dataItem) {
                          if (dataItem.ID == MettingClass.SecretaryUserId) {
                              return "<div style='background-color:#e2e2e2; color:transparent;'>*****</div>"
                          }
                          else {
                              return "<button onclick='OnclickDeleteOrderUser(\"" + dataItem.ID + "\");return false;'class='k-button k-primary'> حذف</button>"
                          }
                      }
                  }
        ],
    }).data("kendoGrid");
}

function OnclickDeleteOrderUser(id) {
    debugger;
    var dataItem;

    for (var i = 0; i < GRDAllUsersOrderUser_data.length; i++) {
        if (GRDAllUsersOrderUser_data[i].ID == id) {

            dataItem = GRDAllUsersOrderUser_data[i];
            GRDAllUsersOrderUser_data.splice(i, 1);
            $("#GRDAllUsersOrderUser").data("kendoGrid").dataSource.read();
            break;
        }

    }
}





function InitcmbAddGetInFormedUser() {
    $("#cmbAddGetInFormedUser").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: DSMeetingPropAllUsers,
        optionLabel: "افزودن مطلعین",
        change: SelectinitcmbAllGetInFormedUser,
    });
}

function SelectinitcmbAllGetInFormedUser(e) {
    debugger;
    if (!$("#DATMeetingDate").val()) {
        _notification.show("تاریخ انتخاب نشده", "warning");

        return;
    }
    var dataItem = this.dataItem(e.item);
    if (dataItem.ID != "") {
        for (var i = 0; i < GRDGetInFormedUser_data.length ; i++) {

            if (GRDGetInFormedUser_data[i].ID == dataItem.ID) {

                _notification.show("شخص قبلا اضافه گردیده", "warning");
                isrepeated = false;
                return;
            }
        }
        for (var i = 0; i < GRDGetInFormedUser_data.length ; i++) {

            if (GRDGetInFormedUser_data[i].ID == dataItem.ID) {

                _notification.show("شخص قبلا اضافه گردیده", "warning");
                isrepeated = false;
                return;
            }
        }
        GRDGetInFormedUser_data.push(AddClassUserInListUser(dataItem, "True"));


        //ShowAlert("success", "شخص به لیست اضافه گردید");
        $("#GRDGetInFormedUser").data("kendoGrid").dataSource.read();
    }
    //InitTimigGugeOutUsers();
    //countUsers.push(dataItem);

}
function InitGRDGetInFormedUser() {
    var PlacesDataSource = new kendo.data.DataSource({
        transport: {
            read: function (e) {
                e.success(GRDGetInFormedUser_data);
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
    $("#GRDGetInFormedUser").kendoGrid({
        dataSource: PlacesDataSource,
        //pageable: {
        //    buttonCount: 5
        //},
        //scrollable: false,
        //persistSelection: true,
        //navigatable: true,
        //sortable: true,
        //filterable: {
        //    mode: "row"
        //},
        //groupable: true,
        //selectable: true,
        columns: [
           //  { field: "RowNumber", title: "ردیف", width: 20, editable: false },
                 { field: "FullName", title: "نام", width: 120, editable: false },
               // { field: "LastName", title: "نام خانوادگی", filterable: { multi: true, search: true }, width: 120 },
                { field: "Mobile", title: "موبایل", filterable: { multi: true, search: true }, width: 120 },
               { field: "Email", title: "ایمیل", filterable: { multi: true, search: true }, width: 120 },
                 { field: "Department", title: "گروه سازمانی", filterable: { multi: true, search: true }, width: 120 },
                  {
                      title: "حذف",
                      width: 60,
                      editable: false,
                      template: function (dataItem) {
                          if (dataItem.ID == MettingClass.SecretaryUserId) {
                              return "<div style='background-color:#e2e2e2; color:transparent;'>*****</div>"
                          }
                          else {
                              return "<button onclick='OnclickDeleteGetInFormedUser(\"" + dataItem.ID + "\");return false;'class='k-button k-primary'> حذف</button>"
                          }
                      }
                  }
        ],
        dataBinding: function () {
            record = (this.dataSource.page() - 1) * this.dataSource.pageSize();
        }
    }).data("kendoGrid");

}






function OnclickDeleteGetInFormedUser(id) {
    debugger;
    var dataItem;

    for (var i = 0; i < GRDGetInFormedUser_data.length; i++) {
        if (GRDGetInFormedUser_data[i].ID == id) {

            dataItem = GRDGetInFormedUser_data[i];
            GRDGetInFormedUser_data.splice(i, 1);
            $("#GRDGetInFormedUser").data("kendoGrid").dataSource.read();
            break;
        }

    }
}




function Get_Data_cmbAddAllUsersInternal() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllUserInternal",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGet_Data_cmbAddUsersOrderUser

    });

}
function successGet_Data_cmbAddUsersOrderUser(respons) {
    debugger;
    cmbAllUsersInternal_data = respons.d;

    var combobox = $("#cmbAllUsersInternal").data("kendoDropDownList");
    combobox.setDataSource(cmbAllUsersInternal_data);
    combobox.refresh();



    var combobox = $("#cmbAddGetInFormedUser").data("kendoDropDownList");
    combobox.setDataSource(cmbAllUsersInternal_data);
    combobox.refresh();
}



function Get_Data_cmbAddAll_Outer() {
    $.ajax({
        type: "POST",
        url: "/_vti_bin/MettingManegmentNew/SettingWebService.asmx/GetAllUserOuter",
        contentType: "application/json; charset=utf-8",
        data: "",
        dataType: "json",
        success: successGet_Data_cmbAddAll_Outer

    });

}
function successGet_Data_cmbAddAll_Outer(respons) {
    debugger;
    cmbAddUsersOrderUser_data = respons.d;

    var combobox = $("#cmbAddUsersOrderUser").data("kendoDropDownList");
    combobox.setDataSource(cmbAddUsersOrderUser_data);
    combobox.refresh();



}


function GetUserTimingGauge() {

    var meetingdate = $("#DATMeetingDate").val();
    var jsonData = JSON.stringify({ date: meetingdate, usereid: _SelectUserId });
    $.ajax({
        type: "POST",

        url: "/_vti_bin/MettingManegmentNew/MettingWebService.asmx/GetUserTimingGuage",
        contentType: "application/json; charset=utf-8",
        data: jsonData,
        dataType: "json",
        success: successGetUserTimingGauge




    });

}

function successGetUserTimingGauge(response) {
    debugger;
    _UserTimingGuage = response.d
    //var startmeeting = ConvertTimetoPercent($("#TIMStartTime").val());
    //var finishmeeting = ConvertTimetoPercent($("#TIMFinishTime").val());
    for (var i = 0; i < _UserTimingGuage.length; i++) {
        //if (_UserTimingGuage[i].from < startmeeting && startmeeting < _UserTimingGuage[i].to ||
        //    _UserTimingGuage[i].from < finishmeeting && finishmeeting < _UserTimingGuage[i].to
        //    ) {
        //for (var i = 0; i < _Working.InnerUsers.length; i++) {
        //    if (_Working.InnerUsers[i].ID == _SelectedUser.ID) {
        //        _Working.InnerUsers.splice(i, 1);
        //        ShowAlert("warning", "کاربر " + " | " + _SelectedUser.FirstName + _SelectedUser.LastName + " | " + "در این ساعت مشغول می باشد");
        //        $("#GRDAddedInnerUsers").data("kendoGrid").dataSource.read();

        //    }
        //}
        //for (var i = 0; i < countUsers.length; i++) {
        //    if (countUsers[i].ID == _SelectedUser.ID) {
        //        countUsers.splice(i, 1);
        //        break;
        //    }
        //}
    }

    $("#gauge").kendoLinearGauge({
        scale: {
            majorUnit: 1,
            minorUnit: 0.25,
            min: 0,
            max: 24,
            vertical: false,
            ranges: _UserTimingGuage
        }

    });

}










