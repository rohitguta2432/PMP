(function () {
    'use strict';

    angular.module('Portal.Recover', [])
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider
            .state('Recover', {
                url: '/RecoverPassword',
                views: {
                    "Platform": {
                        templateUrl: '/Static/Recover',
                        controller: 'RecoverCtrl'
                    }
                }
            })
            .state('Reset', {
                url: '/Reset/:UserID?Code',
                params:{
                    UserID: {
                        squash: true,
                        value: null
                    },
                    Code: {
                        squash: true,
                        value: null
                    }
                },
                views: {
                    "Platform": {
                        templateUrl: '/Static/ResetPassword',
                        controller: 'ResetCtrl'
                    }
                }
            });

    }]);
})();