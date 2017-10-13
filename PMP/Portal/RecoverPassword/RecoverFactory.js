'use strict';
angular.module('Portal.Recover')
        .factory('RecoverFactory', function ($http, $q) {
            return {
                SubmitRecoverPassword: function (RecoverModel) {
                    return $http.post('/api/User/ForgotPassword', RecoverModel)
                },
                ValidateResetEntry: function (UserID) {
                    var deferred = $q.defer();

                    $http.get('/api/User/FindUser/' + UserID).then(
                        function (res) {
                            deferred.resolve(res);
                        }, function (err) {
                            deferred.reject(err);
                        }
                    )

                    return deferred.promise;
                },
                ResetPasswordAction: function (ResetPasswordModel) {
                    var deferred = $q.defer();

                    $http.post('/api/User/ResetPassword', ResetPasswordModel).then(
                        function (res) {
                            deferred.resolve(res);
                        },
                        function (err) {
                            deferred.reject(err);
                        }
                    )

                    return deferred.promise;
                }
            }
        });

    
