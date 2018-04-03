
var app = angular.module('ApApp', []);
app.controller('ApCtrl', function ($scope) {
    $scope.firstValue = "";
    $scope.secondValue = "";
   

    $scope.clearValuesCat = function () {
        $scope.firstValue = "";
        $('#resultDiv').html("");
    }
    $scope.clearValuesLevel = function () {
        $scope.secondValue = "";
        $('#levelDiv').html("");
    }
    $scope.success = function (result) {
        var data = result.d;
        $scope.calculationResult = data;
    }
    $scope.displayError = function (message) {
        $scope.calculationResult = data;
    }
    $scope.calculateCategory = function () {
        //$scope.calculationResult = "";
        //Populate the values from input as numbers
        var firstVal = Number($scope.firstValue);
        var secondVal = Number($scope.secondValue);
        //Check for valid values
        if ($scope.firstValue != null && Number(firstVal) > 0) {
            var url = "index.aspx/GetCategoryInfoById",
                data = { categoryId: firstVal };
            $.ajax({
                type: "POST",
                dataType: "json",
                url: url,
                data: JSON.stringify(data),
                contentType: "application/json;charset=utf-8",
                success: function (result) {
                    var data = result.d;
                    //$scope.calculationResult = data;
                    $('#resultDiv').html(data);
                },
                failure: function (result) {
                    var data = result.d;
                    $('#resultDiv').html(data);
                }
            });

        } else {
            $('#resultDiv').html("Please enter valid values.");
        }

    }
    $scope.calculateLevel = function () {
        //$scope.calculationResult = "";
        //Populate the values from input as numbers
        var firstVal = Number($scope.firstValue);
        var secondVal = Number($scope.secondValue);
        //Check for valid values
        if ($scope.secondValue != null && Number(secondVal) > 0) {

            var url = "index.aspx/GetCategoryInfoByLevel",
               data = { level: secondVal };
            $.ajax({
                type: "POST",
                dataType: "json",
                url: url,
                data: JSON.stringify(data),
                contentType: "application/json;charset=utf-8",
                success: function (result) {
                    var data = result.d;
                    //$scope.calculationResult = data;
                    if (data.length > 0) {
                        $('#levelDiv').html(data);

                    } else {
                        $('#levelDiv').html("No Information found at this level.");
                    }

                },
                failure: function (result) {
                    var data = result.d;
                    $('#levelDiv').html(data);
                }
            });

        } else {
            $('#levelDiv').html("Please enter valid values.");
        }

    }
});




