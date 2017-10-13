(function () {
    'use strict';

    angular
        .module('Portal.Login')
        .factory('LoginFactory', function ($http, $log, $q, $httpParamSerializerJQLike, localStorageService, PortalAuthService) {
            return {
                UserLogin: function (UserName, Password) {
                    var deferred = $q.defer();
                    $http.get('/api/User', {
                        params: {
                            "UserName": UserName,
                            "Password": Password
                        }
                    }).then(function (res) {
                        $log.info(res);
                        deferred.resolve(res);
                    }, function (err) {
                        $log.info(err);
                        deferred.reject(err);
                    });

                    return deferred.promise;
                },
                AuthenticatedUserLogin: function (GrantType, UserName, Password) {
                    var deferred = $q.defer();
                    $http({
                        method: 'POST',
                        url: '/token',
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        },
                        data: $httpParamSerializerJQLike({
                            'grant_type': GrantType,
                            'username': UserName,
                            'password': Password
                        })
                    }).then(function (res) {

                        localStorageService.set('authorizationData', {
                            auth_token: res.data.access_token,
                            token_type: res.data.token_type,
                            user_name: UserName
                        });

                        PortalAuthService.authentication.isAuth = true;
                        PortalAuthService.authentication.userName = UserName;

                        deferred.resolve(res)

                    }, function (err, status) {

                        PortalAuthService.logOut();
                        deferred.reject(err);

                    });

                    return deferred.promise;
                }
            }
        });
})();