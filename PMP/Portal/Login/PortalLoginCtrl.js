(function () {
    'use strict';

    angular
        .module('Portal.Login')
        .controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$scope', '$log', '$http', 'LoginFactory', '$state', '$timeout','$stateParams', 'localStorageService', 'PortalAuthService','$rootScope'];

    function LoginCtrl($scope, $log, $http, LoginFactory, $state, $timeout, $stateParams, localStorageService, PortalAuthService, $rootScope) {

        $scope.Login = function () {

            var grant_type = 'password';

            LoginFactory.AuthenticatedUserLogin(grant_type, $scope.UserName, $scope.Password).then(
                function (promise) {
               
                    $http.get('/api/User/GetUserName/' + $scope.UserName).then(
                        function (response) {

                            localStorageService.set('loggedInEmployee', {
                                model: response.data
                            });

                            $state.go('Platform.Portal.Token');

                        },
                        function (err) {

                        }
                    )

                },
                function (response) {
                    $scope.Error = response.data;
             
                }
            );
        }
    }
})();
