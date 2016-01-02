pitchApp
    .filter("pivotTable", function () {
        return function (input) {
            if (input !== undefined) {
                document.getElementById('data-table').innerHTML = '';
                var rowData = input.distinct('atBatCount');
                var columnHeaders = input.distinct('pitchType');
                var batterHand = input.distinct('batterHand');
                for (var a = 0; a < batterHand.length; a++) {
                    var div = document.createElement("div");
                    div.setAttribute("class", batterHand[a] === "L" ? "left" : "right");

                    var h4 = document.createElement("h4");
                    h4.appendChild(document.createTextNode("Pitch Breakdown by Count vs. " + batterHand[a] + "HH"));
                    div.appendChild(h4);

                    var table = document.createElement("table");
                    table.setAttribute("class", "pure-table pure-table-bordered pure-table-striped");

                    if (columnHeaders.length >= 9) {
                        table.style.fontSize = "0.6vw";
                    } else if (columnHeaders.length >= 5) {
                        table.style.fontSize = "0.8vw";
                    }

                    addTableHeader(table, columnHeaders);
                    for (var i = 0; i < rowData.length; i++) {
                        var tr = table.insertRow();
                        var td = tr.insertCell();
                        td.appendChild(document.createTextNode(rowData[i]));
                        var groupData = input.where('atBatCount', rowData[i]).where('batterHand', batterHand[a]);
                        var groupTotal = groupData.reduce(function (prevVal, curValObj) {
                            return prevVal + curValObj.pitchTypeCount;
                        }, 0);
                        for (var j = 0; j < columnHeaders.length; j++) {
                            var filteredData = input.where('atBatCount', rowData[i]).where('pitchType', columnHeaders[j]).where('batterHand', batterHand[a]);
                            var cellData = (filteredData.length === 1 ? filteredData[0].pitchTypeCount : 0) / groupTotal;
                            var td = tr.insertCell();
                            td.appendChild(document.createTextNode((cellData * 100).toFixed(1) + '%'));
                        }
                    }
                    div.appendChild(table);
                    document.getElementById('data-table').appendChild(div);
                }
            }
        };
    });
