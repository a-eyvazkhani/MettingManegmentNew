


function TimeToInt(time) {

    var array = time.split(":");
    var str = array[0] + array[1];
    return parseInt(str);
}

function DateToInt(date) {

    var array = date.split("/");
    var str = array[0] + array[1] + array[2];
    return parseInt(str);
}

function ExistInList(list, id) {

    var exist = false
    for (var i = 0; i < list.length; i++) {
        if (list[i].ID == id) {
            exist == true;
        }
        return exist;
    }
}

function DevideWithInt(time) {
    var array = time.split(":");
    var str = +array[1];
    var result = [];
    result.push(parseInt(array[0]));
    result.push(parseInt(array[1]));
    return result;

}

function ConvertTimetoPercent(time) {

    var array = time.split(":");
    var s = "";
    var result = array[0];
    if (array[1] == "15") {
        s = ".25"
    }
    if (array[1] == "30") {
        s = ".50"
    }
    if (array[1] == "45") {
        s = ".75"
    }
    if (array[1] == "00") {
        s = ".0"
    }

    result = result + s;
    return parseFloat(result);
}

function closestNumberInTimeArray(array, num) {

    var i = 0;
    var minDiff = 1000;
    var ans;
    for (i in array) {
        var m = Math.abs(num - TimeToInt(array[i]));
        if (m < minDiff) {
            minDiff = m;
            ans = array[i];
        }
    }
    return ans;
}