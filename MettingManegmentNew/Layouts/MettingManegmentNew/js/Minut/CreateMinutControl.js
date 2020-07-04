



$(document).ready(function () {
   
    DatePicker('DATTaskDate');
    InitDDLUnit();
    initDDLMasolAnjam();
    initDDLApprover();
    initGridTask();
    initGridUser();
    initGridUserOutUser();

});

function InitDDLUnit() {
    $("#DDLUnitCompanies").kendoDropDownList({
        filter: "contains",
        dataTextField: "Title",
        dataValueField: "ID",
        dataSource: DSUnit,
        optionLabel: "واحد سازمانی",
    });
}

function initDDLMasolAnjam() {
    $("#DDLUsers").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: DSMasolAnjam,
        optionLabel: "مسول انجام",
        change: SelectDDLMasolAnjam,
    });
}
function initDDLApprover() {
    $("#DDLApprover").kendoDropDownList({
        filter: "contains",
        dataTextField: "FullName",
        dataValueField: "ID",
        //template: '<span>#= FirstName #, #= LastName #</span>',
        dataSource: DSApprover,
        optionLabel: "مسول تایید",
        change: SelectDDLApprover,
    });
}
function initGridTask()
{
   var DSTasks = new kendo.data.DataSource({
        transport: {
            read: function (e) {

                e.success(TaskList);
            },

            create: function (e) {

            },

            schema: {
                model: { id: "ID" }
            },
        },


    });

    $("#GRDTasks").kendoGrid({
        dataSource: DSTasks,
        scrollable: false,
        columns: [
                 { field: "RowNumber", title: "ردیف", width: 10, filterable: false, editable: false },
                 { field: "Title", title: "عنوان اقدام", width: 150, editable: false },
                 { field: "TarikhStart", title: "تاریخ اقدام ", width: 150, editable: false },
                
                    { field: "EstimatedTimeText", title: "برآورد انجام کار", width: 160, editable: false },

                      { field: "MasolAnjamFullName", title: "مسعول انجام", width: 160, editable: false },
                       { field: "Aprove1IDFullName", title: "مسعول تایید", width: 160, editable: false },
              
              
                
                 //{
                 //    command: {
                 //        name: "del",
                 //        title: "حذف",
                 //        text: "حذف",
                 //        width: 70,
                 //        click: function (e) {

                 //            var dataItem = this.dataItem($(e.target).closest("tr"));
                 //            for (var i = 0; i < _Working.Tasks.length; i++) {


                 //                if (_Working.Tasks[i].ID == dataItem.ID) {
                 //                    _Working.Tasks.splice(i, 1);
                 //                    ShowAlert("danger", "اقدام حذفگردید");
                 //                    $("#GRDTasks").data("kendoGrid").dataSource.read();
                 //                    return;
                 //                }
                 //            }

                 //        }, title: "حذف ",
                 //    }
                 //    ,
                 //},
        ],

    }).data("kendoGrid");
}


function initGridUser()
{
  

    var gridUsers = $("#GRDMeetingPresents").kendoGrid({
        dataSource: {
            pageSize: 10,
            transport: {
                read: function (e) {
                    e.success(ListUserInit);
                },
            },
            schema: {
                model: {
                    id: "ID"
                }
            }
        },
        scrollable: false,
        navigatable: true,
        columns: [
                { field: "RowNumber", title: "ردیف", width: 10, filterable: false, editable: false },
               
                { field: "FullName", title: "نام خانوادگی", filterable: { multi: true, search: true }, width: 250 },
             
                { template: "<input type='checkbox' class='checkbox' checked  />", width: 50 },
        ],
    }).data("kendoGrid");
    //متد انتخاب کاربران با چک باکس کناری آن

    gridUsers.table.on("click", ".checkbox", selectUsersRow);
}


function initGridUserOutUser() {



    var gridOutUsers = $("#GRDMeetingOutPresents").kendoGrid({
        dataSource: ListUserOrder,
        scrollable: false,
        persistSelection: true,
        navigatable: true,

        columns: [
            { field: "RowNumber", title: "ردیف", width: 10, filterable: false, editable: false },
              
               { field: "FullName", title: "نام خانوادگی", filterable: { multi: true, search: true }, width: 250 },
              
                 { template: "<input type='checkbox' class='checkbox' checked />", width: 50 },
        ],
    }).data("kendoGrid");
    //متد انتخاب کاربران با چک باکس کناری آن
    gridOutUsers.table.on("click", ".checkbox", selectOutUsersRow);
  
}



