(function () {
    'use strict';
    angular.module('Portal.Token', [])
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider.state('Platform.Portal.Token', {
            url: '/Token',
            views: {
                "Content@Platform.Portal": {
                    templateUrl: '/Static/TokenList',
                    controller: 'TokenListCtrl'
                }
            }
        }).state('Platform.Portal.Token.Create', {
            url: '/Create/:TokenID',
            params:{
                TokenID: {
                    squash: true,
                    value: null
                }
            },
            views: {
                "Content@Platform.Portal": {
                    templateUrl: '/Static/TokenCreate',
                    controller: 'TokenCreateCtrl'
                }
            }
        });
    }]);
})();