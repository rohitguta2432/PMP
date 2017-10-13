'use strict';
angular.module('Portal.Client')
        .factory('ClientListFactory', function ($http) {
            return {

                GetClientList:function(){
                    return $http.get('/api/ClientMaster');
                  },

                GetClientData: function (PageNumber, SearchText, CreatedBy) {
                    return $http.get('/api/ClientMaster', { params: { "PageNum": PageNumber, "SearchText": SearchText == "" ? null : SearchText, "CreatedBy": CreatedBy } });
                }
            }
        }).factory('ClientCreateFactory', function ($http) {
            return {
                UpdateClientMasterData:function(ClientID,model){
                    return $http.put('/api/ClientMaster/' + ClientID, model);
                },
                GetClientDataBasedOnClientId: function (ClientID) {
                    return $http.get('/api/ClientMaster', { params: { "id": ClientID } })
                }
            }
        });

   
