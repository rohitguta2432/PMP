(function () {
    'use strict';

    angular.module('Portal.Client')
        .controller('ClientCreateCtrl', ClientCreateCtrl);
    ClientCreateCtrl.$inject = ['$scope', '$http', '$log', '$stateParams', 'ClientCreateFactory', '$state', 'ClientListFactory','localStorageService'];

    function ClientCreateCtrl($scope, $http, $log, $stateParams, ClientCreateFactory, $state, ClientListFactory,localStorageService) {
        $scope.ShowCreate = true;
        $log.info($stateParams.ClientID);
      
        $scope.ResetClientInfo = function () {
            $scope.ClientModel = {};
        }

        if ($stateParams.ClientID != null) {
            $scope.ShowCreate = false;
            $scope.ShowUpdate = true;
            $scope.ShowReset = true;
            ClientCreateFactory.GetClientDataBasedOnClientId($stateParams.ClientID).then(function (promise) {
                $scope.ClientModel = promise.data;
             })
        }

        var EmployeeModel = localStorageService.get('loggedInEmployee');
        $scope.LoggedInUser = EmployeeModel.model.Result;
        
        if ($scope.LoggedInUser.DesignationID == 4 && $stateParams.ClientID != null) {
        
            $scope.ShowAccept = true;
            $scope.ShowReject = true;
            $scope.ShowCreate = false;
            $scope.ShowReset = false;
            $scope.AcceptClientInfo = function () {
                $scope.ClientModel.StatusID = '2';
                ClientCreateFactory.UpdateClientMasterData($stateParams.ClientID, $scope.ClientModel)
                    .then(function (promise) {
                    $state.go('Platform.Portal.Client');
                })
            }

            $scope.RejectClientInfo = function () {
                $scope.ClientModel.StatusID = '3';
                ClientCreateFactory.UpdateClientMasterData($stateParams.ClientID, $scope.ClientModel)
                    .then(function (promise) {
                    $state.go('Platform.Portal.Client');
                })
            }
        }

        $scope.UpdateClientInfo = function () {
            $scope.ClientModel.ModifiedBy = $scope.LoggedInUser.EmployeeID;
            ClientCreateFactory.UpdateClientMasterData($stateParams.ClientID, $scope.ClientModel).then(function (promise) {
                $state.go('Platform.Portal.Client');
            })
        }

        $scope.SubmitClientDetails = function () {            
            $scope.ClientModel.StatusID = '1';
            $scope.ClientModel.CreatedBy = $scope.LoggedInUser.EmployeeID;
            $http.post('/api/ClientMaster', $scope.ClientModel)
            .then(function (response) {
                $log.info($scope.ClientModel);
                $state.go('Platform.Portal.Client');
            }, function (error) {

            });
        }
    }
})();