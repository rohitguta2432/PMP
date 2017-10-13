'use strict';
 angular.module('Portal.Token')
        .factory('TokenFactory', function ($http, $q, $log) {
            return {
                GetClientData: function () {
                    var deferred = $q.defer();

                    $http.get("/api/ClientMaster", { params: { 'PageSize': 100 } }).then(function (response) {
                       deferred.resolve(response);
                    }, function (error) {
                        deferred.reject(error);
                    });

                    return deferred.promise;
                },
                GetChannelData: function () {
                        return $http.get('/api/ChannelMaster');
                },
                GetSourceData: function () {
                        return $http.get('/api/SourceMaster');
                },
                GetEquityTypeData: function () {
                        return $http.get('/api/InquiryTypeMaster');

                },
                GetContactPersonData: function (ClientID) {
                        var deferred = $q.defer();
                        $http.get('/api/ContactPersonMaster', {
                            params: {
                                'ClientID': ClientID,
                            }
                        }).then(function (response) {
                            deferred.resolve(response);                          
                        },
                        function (error) {
                           deferred.reject(error);
                        });

                        return deferred.promise;
                }
            }
        }).factory('TokenCreateFactory', function ($http,$log) {
            return {
                UpdateTokenInformation: function (tokenID,model) {
                   return $http.put('/api/TokenDetail/' + tokenID, model)
                },
                SubmitTokenInformation: function (TokenModel) {
                    return $http.post('/api/TokenDetail', TokenModel)
                },
                GetInfoBasedOnTokenID: function (TokenID) {
                    return $http.get('api/TokenDetail', { params: { "id": TokenID } })
                }
            }
        }).factory('TokenListFactory', function ($http, $log) {
            return {
                GetTokenList: function (PageNumber,SearchText,CreatedBy) {
                    return $http.get('/api/TokenDetail', { params: { "PageNum": PageNumber, "SearchText": SearchText == "" ? null : SearchText, "CreatedBy": CreatedBy } })
                }
            }
        });