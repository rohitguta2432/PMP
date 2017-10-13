(function () {
    'use strict';

    angular.module('Portal.Login', [])
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider.state('Login', {
            url: '/Login?error',
            views: {
                "Platform": {
                    templateUrl: '/Static/Login',
                    params: {
                        error: {
                            squash: true,
                            value: null
                        }
                    },
                    controller: 'LoginCtrl'
                }
            }
        })
    }]);
})();