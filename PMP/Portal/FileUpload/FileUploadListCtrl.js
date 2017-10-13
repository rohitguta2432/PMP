//(function () {
//    'use strict';

//      angular.module('Portal.Client')
//    .controller('ClientListCtrl', ClientListCtrl);

//      ClientListCtrl.$inject = ['$scope', '$http', '$log', 'ClientListFactory', '$state', 'localStorageService'];
//      function ClientListCtrl($scope, $http, $log, ClientListFactory, $state,localStorageService) {
        
//        var EmployeeModel = localStorageService.get('loggedInEmployee');
//        $scope.LoggedInUser = EmployeeModel.model.Result;
//        $scope.SearchText = '';
//        $scope.PageNum = 1;
//        $scope.CreatedBy = $scope.LoggedInUser.EmployeeID;

//        $scope.dtOptions = {
//            info: false,
//            paging: false,
//            searching: false
//        }

//        $scope.$watch("SearchText", function () {
//            ClientListFactory.GetClientData($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (response) {
//                $scope.ClientMasterData = response.data;
//            });
//        });


//        $scope.$on('EventSearch', function (event, SearchKey) {
//            if ($state.current.name == 'Platform.Portal.Client') {
//                $log.info('Inside EventSearch');
//                $scope.SearchText = SearchKey;
//            }
//        })

//        $scope.Next = function () {
//            $scope.PageNum = $scope.PageNum + 1;
//            ClientListFactory.GetClientData($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {
//                $scope.ClientMasterData = promise.data;
//                $log.info(promise.data);
//                if (Object.keys($scope.ClientMasterData) == 0) {
//                    $scope.PageNum = 1;
//                    ClientListFactory.GetClientData($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {
//                        $scope.ClientMasterData = promise.data;
//                        $log.info(promise.data);
//                    })
//                }
//            })
//            $log.info($scope.PageNum);
//        }
//        $scope.Previous = function () {
//            $scope.PageNum = $scope.PageNum - 1;
//            if ($scope.PageNum < 1) {
//                $scope.PageNum = 1;
//            }
//            ClientListFactory.GetClientData($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {
//                $scope.ClientMasterData = promise.data;
//                $log.info(promise.data);
//            })
//        }
//      }

//})();