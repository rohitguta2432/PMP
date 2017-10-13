(function () {
    'use strict';

    angular.module('Portal.Token')
        .controller('TokenCreateCtrl', TokenCreateCtrl);

    TokenCreateCtrl.$inject = ['$scope', '$http', '$log', '$state', '$stateParams', 'TokenFactory', 'TokenCreateFactory', '$window', '$rootScope', 'localStorageService'];

    function TokenCreateCtrl($scope, $http, $log, $state, $stateParams, TokenFactory, TokenCreateFactory, $window, $rootScope, localStorageService) {

        $scope.ShowCreate = true;
        $scope.ShowUpdate = false;
        $scope.ReferenceFlag = false;
        $scope.TaskCreationStatus = false;
        $scope.ContactPersons = {};

        var EmployeeModel = localStorageService.get('loggedInEmployee');
        $scope.LoggedInUser = EmployeeModel.model.Result;

        //TODO Implement Elegent Solution
        var extractConPerson = function () {
            $scope.ContactDetails.forEach(function (elem, index, arr) {

                var ContactPerson = {
                    ContactPersonID: elem.ContactPersonID,
                    ContactPersonName: elem.ContactPersonName,
                    ContactPersonCode: elem.ContactPersonCode
                }

                $scope.ContactPersons[elem.ContactPersonID] = ContactPerson;
            })
        }

        TokenFactory.GetClientData().then(function (promise) {
            $scope.ClientData = promise.data;
            $log.info('client info '+$scope.ClientData);
        });

        $scope.GetContactPersonInfo = function (ClientID) {
              $scope.ContactPerson = {
                ContactPersonName: '',
                ContactPersonID: ''
            };

            TokenFactory.GetContactPersonData(ClientID).then(function (promise) {
                $scope.ContactDetails = promise.data;

                $log.info('ContactDetails '+$scope.ContactDetails)
                extractConPerson();
            });
        }

        TokenFactory.GetChannelData().then(function (response) {
            $scope.ChannelData =response.data;
        });

        TokenFactory.GetSourceData().then(function (response) {
            $scope.SourceData = response.data;
        });

        TokenFactory.GetEquityTypeData().then(function (response) {
            $scope.EnquiryData = response.data;
        });
        
        $scope.TokenModel = {};
        $scope.TokenModel.ReferenceName = '';

        $scope.CheckAvailable = function () {
            $log.info('checkAvailable '+$scope.ContactPerson);
        }

        if ($stateParams.TokenID != null) {
            $scope.TaskCreationStatus = true;
            $scope.ShowCreate = false;
            $scope.ShowUpdate = true;
            TokenCreateFactory.GetInfoBasedOnTokenID($stateParams.TokenID).then(function (promise) {
                $log.info('$scope.ReferenceFlag :' + promise.data.ReferenceName);
                if (promise.data.ReferenceName != '') {
                    $scope.ReferenceFlag = true;
                } else {
                    $scope.ReferenceFlag = false;
                }
                $scope.TokenModel = promise.data;
                $log.info('$scope.ReferenceFlag :' + $scope.ReferenceFlag);
                TokenFactory.GetContactPersonData($scope.TokenModel.ClientID).then(function (promise) {
                    $scope.ContactDetails = promise.data; extractConPerson();
                    $scope.ContactPerson = $scope.ContactPersons[$scope.TokenModel.ContactPersonID];
                });                
            })
        }

        $scope.$watch('ContactPerson', function (newVal, oldVal) {
            if (typeof (newVal) != 'undefined') {
                $scope.TokenModel.ContactPersonID = $scope.ContactPerson.ContactPersonID;
            }
        })

        $scope.UpdateTokenInfo = function () {
            $scope.TokenModel.ModifiedBy = $scope.LoggedInUser.EmployeeID;
            TokenCreateFactory.UpdateTokenInformation($stateParams.TokenID, $scope.TokenModel).then(function (promise) {
                $log.info($state.current.name);
                $state.go('Platform.Portal.Token');
            })
        }

        $scope.SubmitToken = function () {            
            $scope.TokenModel.CreatedBy = $scope.LoggedInUser.EmployeeID;
            $log.info($scope.TokenModel.ContactPersonID);
            TokenCreateFactory.SubmitTokenInformation($scope.TokenModel).then(function (promise) {
                 $state.go('Platform.Portal.Token');
            })
        }

        $scope.BackToList = function () {
            $log.info($scope.ContactPerson);
        }

        $scope.ResetForm = function () {
            $scope.TokenModel = {};
            $scope.ContactPerson = {
                ContactPersonName: '',
                ContactPersonID: ''
            };
        }

        $scope.SetReferenceFlag = function () {
            $log.info($scope.TokenModel.SourceID);
            if ($scope.TokenModel.SourceID == 3) {
                $scope.ReferenceFlag = true;
            } else {
                $scope.ReferenceFlag = false;
            }
        }

        $scope.SaveTask = function (TaskModel, EmployeeContribution) {
            $log.info(TaskModel);
            $log.info(EmployeeContribution);
        }

      }
})();
