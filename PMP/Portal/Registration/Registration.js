(function () {
    'use strict';

    angular.module('Portal.Registration', [])
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider.state('Registration', {
            url: '/Registration',            
            views: {
                "Platform": {
                    templateUrl: '/Static/Registration',
                    controller:'RegistrationCtrl'
                }
            }
        })
    }]);
})();