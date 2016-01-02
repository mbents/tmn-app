pitchApp
    .controller('mainController', function ($scope, $http) {
        $scope.search = function () {
            $http.get("/api/search/" + $scope.searchString)
                .then(function (response) {
                    $scope.showResults = true;
                    $scope.results = response.data;
                });
        };
    })

    .controller('batterController', function ($scope, $http, $routeParams) {
        $scope.playerId = $routeParams.paramId;
        $scope.playerName = $routeParams.paramName;
        $scope.message = 'This is a message for batterController for playerId:' + $scope.playerId;
    })

    .controller('pitchController', function ($scope, $http, $routeParams) {
        $scope.playerId = $routeParams.paramId;
        $scope.playerName = $routeParams.paramName;
        $scope.loading = true;
        $http.get("/api/pitch/" + $scope.playerId)
            .then(function (response) {
                $scope.results = response.data;

                createPitchBreakdownChart({
                    data: response.data,
                    scope: $scope,
                    chartObjName: 'lhhPitchBreakdownChartObject',
                    batterHand: 'L',
                    title: 'Pitch Breakdown vs LHH'
                });

                createPitchBreakdownChart({
                    data: response.data,
                    scope: $scope,
                    chartObjName: 'rhhPitchBreakdownChartObject',
                    batterHand: 'R',
                    title: 'Pitch Breakdown vs RHH'
                });
            })
            .finally(function () {
                $scope.loading = false;
            });
    })

    .controller("pitchAverageController", function ($scope, $http) {
        $http.get("/api/pitchaverage/" + $scope.playerId)
            .then(function (response) {
                createPitchAverageChart({
                    data: response.data,
                    scope: $scope,
                    chartObjName: 'lhhVeloChartObject',
                    fieldName: 'AvgReleaseVelocity',
                    batterHand: 'L',
                    title: 'Average Release Velocity vs LHH'
                });

                createPitchAverageChart({
                    data: response.data,
                    scope: $scope,
                    chartObjName: 'rhhVeloChartObject',
                    fieldName: 'AvgReleaseVelocity',
                    batterHand: 'R',
                    title: 'Average Release Velocity vs RHH'
                });

                createPitchAverageChart({
                    data: response.data,
                    scope: $scope,
                    chartObjName: 'lhhSpinRateChartObject',
                    fieldName: 'AvgSpinRate',
                    batterHand: 'L',
                    title: 'Average Spin Rate vs LHH'
                });

                createPitchAverageChart({
                    data: response.data,
                    scope: $scope,
                    chartObjName: 'rhhSpinRateChartObject',
                    fieldName: 'AvgSpinRate',
                    batterHand: 'R',
                    title: 'Average Spin Rate vs RHH'
                });

                addTable({
                    elementID: "pitch-average-table",
                    data: response.data,
                    columnModel: [
                        { displayName: 'Pitch Type', fieldName: 'PitchType' },
                        { displayName: 'Avg. Release Velocity (sample size)', fieldName: ['AvgReleaseVelocity', 'ReleaseVelocitySampleSize'] },
                        { displayName: 'Avg. Spin Rate (sample size)', fieldName: ['AvgSpinRate', 'SpinRateSampleSize'] },
                        { displayName: 'Swinging Strike % (sample size)', fieldName: ['SwStrRate', 'SwStrRateSampleSize'] },
                    ]
                });
            });
    });
