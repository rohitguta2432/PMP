(function () {
    'use strict';

    angular
        .module('Portal')
        .controller('PortalSideNavCtrl', PortalSideNavCtrl);

    PortalSideNavCtrl.$inject = ['$scope','$location','localStorageService','$http','$log']; 

    function PortalSideNavCtrl($scope,$location,localStorageService,$http,$log) {
      
        var EmployeeModel = localStorageService.get('loggedInEmployee');
        $scope.LoggedInUser = EmployeeModel.model.Result;
       
        $http.get('/api/AuthMapping/', {
            params: {
                'DesignationID': $scope.LoggedInUser.DesignationID
            }
        }).then(function (response) {
            $scope.Menu = response.data;
            $log.info($scope.Menu);
        }, function (response) {

        }

        )
    }
})();
