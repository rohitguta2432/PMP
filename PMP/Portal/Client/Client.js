(function () {
    'use strict';
  angular.module('Portal.Client',[])
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider.state('Platform.Portal.Client',{
            url: '/Client',
            views: {
                "Content@Platform.Portal": {
                    templateUrl: '/Static/ClientList',
                    controller: 'ClientListCtrl'
                }
            }
        }).state('Platform.Portal.Client.Create', {
            url: '/Create/:ClientID',
            params: {
                ClientID: {
                    squash: true,
                    value: null
                }
            },
            views: {
                "Content@Platform.Portal": {
                    templateUrl: '/Static/ClientCreate',
                    controller:'ClientCreateCtrl'
                }
            }
        })
    }]);
})();