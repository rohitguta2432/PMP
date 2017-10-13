(function () {
    'use strict';

    angular.module('Portal', ['ui.router', 'ui.bootstrap', 'datatables', 'LocalStorageModule', 'Portal.Token', 'Portal.Client', 'Portal.Login', 'Portal.Registration', 'Portal.Recover', 'angular-loading-bar','angularjs-dropdown-multiselect'])
        .config(['$urlRouterProvider', '$stateProvider', '$locationProvider', '$httpProvider', '$provide', '$logProvider', 'cfpLoadingBarProvider', function ($urlRouterProvider, $stateProvider, $locationProvider, $httpProvider, $provide, $logProvider, cfpLoadingBarProvider) {
            
            $logProvider.debugEnabled(true);
            cfpLoadingBarProvider.includeSpinner = false;
            $provide.decorator('$log', function ($delegate) {
                $delegate.info = $logProvider.debugEnabled() ? $delegate.info : function () { };
                $delegate.log = $logProvider.debugEnabled() ? $delegate.log :  function () { };

                return $delegate;
            });

            $stateProvider
                .state('Platform', {
                    abstract: true,
                    views: {
                        "Platform": {
                            templateUrl: '/Static/Platform'
                        }
                    }

                })
                .state('Platform.Portal', {
                    url: '/Portal',
                    views: {
                        "Portal@Platform": {
                            templateUrl: '/Static/Portal'
                        },

                        "Navbar@Platform": {
                            templateUrl: '/Static/Navbar',
                            controller: 'PortalNavbarCtrl'
                        },

                        "Sidenav@Platform.Portal": {
                            templateUrl: '/Static/Sidenav',
                            controller:'PortalSideNavCtrl'
                        },

                        "Footer@Platform.Portal": {
                            templateUrl: '/Static/Footer'
                        }

                    }

            });

            $urlRouterProvider.otherwise("/Login");
            $httpProvider.interceptors.push('PortalAuthInterceptors');
           
        }])
        .run(['$rootScope', '$window', '$state', '$http', '$stateParams', '$log', 'PortalAuthService', function ($rootScope, $window, $state, $http, $stateParams, $log, PortalAuthService) {

            $rootScope.$state = $state;
            PortalAuthService.fillAuthData();

        }])
        .factory('PortalAuthInterceptors', ['$q', '$state', 'localStorageService', function ($q, $state, localStorageService) {
                return {

                    request: function (config) {
                        config.headers = config.headers || {};

                        var authData = localStorageService.get('authorizationData');

                        if (authData) {
                            config.headers.Authorization = authData.token_type + ' ' + authData.auth_token;
                        }

                        return config;
                    },

                    responseError: function (rejection) {

                        if (rejection.status === 401) {
                            $state.go('Login');
                        }

                        return $q.reject(rejection);
                    }

                }

        }])
        .factory('PortalAuthService', ['$state', '$http', 'localStorageService', function ($state, $http, localStorageService) {

                var _authentication = {
                    isAuth: false,
                    userName: ''
                }

                var _logOut = function () {

                    localStorageService.remove('authorizationData');

                    _authentication.isAuth = false;
                    _authentication.userName = "";

                    $state.go("Login");
                    location.reload();
                };

                var _fillAuthData = function () {

                    var authData = localStorageService.get('authorizationData');
                    if (authData) {
                        _authentication.isAuth = true;
                        _authentication.userName = authData.userName;
                    }

                }

                return {
                        authentication: _authentication,
                        fillAuthData: _fillAuthData,
                        logOut: _logOut
                };

        }]);

})();