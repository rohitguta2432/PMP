(function () {
    'use strict';
    angular.module('Portal.Registration')
    .controller('RegistrationCtrl', RegistrationCtrl);
    
    RegistrationCtrl.$inject = ['$scope','$log','$http','$state', '$stateParams'];

    function RegistrationCtrl($scope, $log, $http, $state, $stateParams) {
        $log.info("Registration Page");
        $log.info('UserID : ' + $stateParams.UserID + ' Code : ' + $stateParams.Code);
   
        $scope.NewPassword = '';
        $scope.done = false;
        $scope.RegisterUser = function () {
            $http.post('/api/User/Register', $scope.RegisterModel).then(function (promise) {
                $scope.done = true;
                $scope.message = promise.data;

            }, function (response) {
                $scope.ErrorMessage = true;
                $scope.Error = response.data;
                $log.info(response.data);
            })
        }
    }
})();