Array.prototype.distinct = function (propertyName) {
    var lookup = {};
    var result = [];

    for (var item, i = 0; item = this[i++];) {
        var name = item[propertyName];

        if (!(name in lookup)) {
            lookup[name] = 1;
            result.push(name);
        }
    }

    return result;
}

Array.prototype.where = function (propertyName, searchName) {
    return this.filter(function (item) {
        return item[propertyName] === searchName;
    });
}

// adds a header row to table to display column names
function addTableHeader(table, columnHeaders) {
    var tr = table.insertRow();
    var td = tr.insertCell();
    td.appendChild(document.createTextNode("Count"));
    for (var i = 0; i < columnHeaders.length; i++) {
        var td = tr.insertCell();
        td.appendChild(document.createTextNode(columnHeaders[i]));
    }
}

function createPitchAverageChart(options) {
    options.scope[options.chartObjName] = {};
    options.scope[options.chartObjName].type = "BarChart";
    var rowData = [];
    var pitchTypes = options.data.distinct('PitchType');
    var rowValues = options.data.where('BatterHand', options.batterHand);
    for (var i = 0; i < pitchTypes.length; i++) {
        var value = rowValues.where('PitchType', pitchTypes[i]);
        if (value.length > 0) {
            var item = {};
            item.c = [];
            var cItem1 = { v: pitchTypes[i] };
            var cItem2 = { v: value[0][options.fieldName] };
            item.c.push(cItem1);
            item.c.push(cItem2);
            rowData.push(item);
        }
    }

    options.scope[options.chartObjName].data = {
        "cols": [
            { id: "t", label: "Pitch Type", type: "string" },
            { id: "s", label: "Avg. Release Velocity", type: "number" }
        ],
        "rows": rowData
    };

    options.scope[options.chartObjName].options = {
        'title': options.title
    };
}

function createPitchBreakdownChart(options) {
    options.scope[options.chartObjName] = {};
    options.scope[options.chartObjName].type = "PieChart";
    var rowData = [];
    var pitchTypes = options.data.distinct('pitchType');
    var rowValues = options.data.where('batterHand', options.batterHand);
    for (var i = 0; i < pitchTypes.length; i++) {
        var groupData = rowValues.where('pitchType', pitchTypes[i]);
        if (groupData.length > 0) {
            var groupTotal = groupData.reduce(function (prevVal, curValObj) {
                return prevVal + curValObj.pitchTypeCount;
            }, 0);
            var item = {};
            item.c = [];
            var cItem1 = { v: pitchTypes[i] };
            var cItem2 = { v: groupTotal };
            item.c.push(cItem1);
            item.c.push(cItem2);
            rowData.push(item);
        }
    }

    options.scope[options.chartObjName].data = {
        "cols": [
            { id: "t", label: "Pitch Type", type: "string" },
            { id: "s", label: "Percentage of Pitch Type", type: "number" }
        ],
        "rows": rowData
    };

    options.scope[options.chartObjName].options = {
        'title': options.title
    };
}

function addTable(options) {
    document.getElementById(options.elementID).innerHTML = '';
    var batterHand = options.data.distinct('BatterHand');
    for (var a = 0; a < batterHand.length; a++) {
        var div = document.createElement("div");
        div.setAttribute("class", batterHand[a] === "L" ? "left" : "right");

        var h4 = document.createElement("h4");
        h4.appendChild(document.createTextNode("Pitch Averages vs. " + batterHand[a] + "HH"));
        div.appendChild(h4);

        var table = document.createElement("table");
        table.setAttribute("class", "pure-table pure-table-bordered pure-table-striped");
        var tr = table.insertRow();
        for (var i = 0; i < options.columnModel.length; i++) {
            var td = tr.insertCell();
            td.appendChild(document.createTextNode(options.columnModel[i].displayName));
        }
        var subset = options.data.where('BatterHand', batterHand[a]);
        for (var i = 0; i < subset.length; i++) {
            var tr = table.insertRow();
            for (var j = 0; j < options.columnModel.length; j++) {
                var td = tr.insertCell();
                if (options.columnModel[j].fieldName.length !== undefined && options.columnModel[j].fieldName.length === 2
                        && subset[i][options.columnModel[j].fieldName[0]] !== null) {
                    td.appendChild(document.createTextNode(subset[i][options.columnModel[j].fieldName[0]] +
                        ' (' + subset[i][options.columnModel[j].fieldName[1]] + ')'));
                } else if (subset[i][options.columnModel[j].fieldName] !== undefined) {
                    td.appendChild(document.createTextNode(subset[i][options.columnModel[j].fieldName]));
                } else {
                    td.appendChild(document.createTextNode("n/a"));
                }
            }
        }
        div.appendChild(table);
        document.getElementById(options.elementID).appendChild(div);
    }
}