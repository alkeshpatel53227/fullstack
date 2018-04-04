<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AlkeshPatelFullStackMaster.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Alkesh Patel Code Test</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
    <script src="scripts/js/ap.js"></script>
    <link href="styles/Gridstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <div class="jumbotron" ng-app="ApApp" ng-controller="ApCtrl">
            <div class="row">
                <div class="form-group" style="text-align: center;">
                    <h2>Alkesh Patel</h2>
                    <h4>Code Test</h4>
                    <h4>Technogies: .Net, C#, Angular, Bootstrap, Ajax, Jquery, SQL</h4>
                    <a href="https://github.com/alkeshpatel53227/fullstack">Go To Code</a>
                </div>
            </div>
            <div class="row">
                <div style="width: 100%; text-align: center">
                    <form id="form1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" CssClass="Grid"></asp:GridView>
                    </form>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>Enter Your Information Below</label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="sideOne">Enter Category ID:</label>
                        <input type="number" step="1"
                            pattern="\d+(\.\d*)?"
                            class="form-control" id="sideOne"
                            ng-model="firstValue">
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="sideTwo">Enter Category Level:</label>
                        <input type="number" step="1"
                            pattern="\d+(\.\d*)?"
                            class="form-control" id="sideTwo"
                            ng-model="secondValue">
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-sm-6">
                    <button type="button" class="btn btn-success" ng-click="calculateCategory()">Get Result</button>
                    <button type="button" class="btn btn-primary" ng-click="clearValuesCat()">Reset</button>
                </div>
                <div class="col-sm-6">
                    <button type="button" class="btn btn-success" ng-click="calculateLevel()">Get Result</button>
                    <button type="button" class="btn btn-primary" ng-click="clearValuesLevel()">Reset</button>
                </div>

            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div id="resultDiv"></div>
                </div>
                <div class="col-sm-6">
                    <div id="levelDiv"></div>
                </div>
            </div>
            
        </div>
    </div>
</body>
</html>
