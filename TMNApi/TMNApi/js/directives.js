pitchApp
    .directive("searchDirective", function () {
        return {
            template: '<div><form ng-submit="search()"><input type="text" ng-model="searchString" placeholder="Enter pitcher name"><button type="submit" ng-click="search()"><i class="fa fa-search"></i></button></form><div ng-show="showResults"><h4>Search Results</h4><table class="pure-table pure-table-bordered pure-table-striped"><thead><tr><td>Name</td><td>Bats</td><td>Throws</td></tr></thead><tr ng-repeat="x in results"><td><a href="#/pitcher/{{x.Name}}/{{x.PlayerID}}">{{ x.Name }}</a></td><td>{{ x.Bats }}</td><td>{{ x.Throws }}</td></tr></table></div></div>',
            controller: 'mainController'
        };
    })
    .directive("headerDirective", function () {
        return {
            template: '<a href="/">Back to home page</a><h2>Scouting report for {{playerName}}</h2>'
        };
    })
    .directive("pitchExpectancyDirective", function () {
        return {
            template: '<div class="loading" ng-show="loading"><div class="loading-wrapper"><div class="spinner"><p><b>Loading</b></p><img src="images/ajax-loader.gif" /></div></div></div><div class="left"><div google-chart chart="lhhPitchBreakdownChartObject" style="height:400px; width:100%;"></div></div><div class="right"><div google-chart chart="rhhPitchBreakdownChartObject" style="height:400px; width:100%;"></div></div><div name="data-table" id="data-table">Please wait while results load...{{ results | pivotTable }}</div>'
        }
    })
    .directive("pitchAverageDirective", function () {
        return {
            template: '<div id="pitch-average-table" name="pitch-average-table"></div><div class="left"><div google-chart chart="lhhVeloChartObject" style="height:400px; width:100%;"></div><div google-chart chart="lhhSpinRateChartObject" style="height:400px; width:100%;"></div></div><div class="right"><div google-chart chart="rhhVeloChartObject" style="height:400px; width:100%;"></div><div google-chart chart="rhhSpinRateChartObject" style="height:400px; width:100%;"></div></div>',
            controller: 'pitchAverageController'
        }
    });

