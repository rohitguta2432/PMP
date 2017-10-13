(function () {
    'use strict';

    angular
        .module('Portal')
        .controller('PortalNavbarCtrl', PortalNavbarCtrl);

    PortalNavbarCtrl.$inject = ['$rootScope', '$scope', '$log', '$state', '$http', 'localStorageService', 'PortalAuthService'];

    function PortalNavbarCtrl($rootScope, $scope, $log, $state, $http, localStorageService, PortalAuthService) {

        $log.info('Current State -> ' + $state.$current.name);
        
        $scope.State_Def = {
            'Platform.Portal.Token': 'TokenDetail',
            'Platform.Portal.Client': 'ClientMaster'
        };

        var EmployeeModel = localStorageService.get('loggedInEmployee');

        $scope.LoggedInUser = EmployeeModel.model.Result;

        $scope.$watch(function () {

            return $state.$current.name;

        }, function (newVal, oldVal) {

            $scope.IsStatePresent = !$scope.State_Def.hasOwnProperty($state.$current.name);

        });
                
        $scope.DoSearch = function () {
            $rootScope.$broadcast('EventSearch', $scope.SearchKey);
        }

        $scope.LogOut = function () {
            PortalAuthService.logOut();
        }
    }
})();
