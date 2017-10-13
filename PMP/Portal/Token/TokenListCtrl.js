(function () {
    'use strict';

    angular
        .module('Portal.Token')
        .controller('TokenListCtrl', TokenListCtrl);

    TokenListCtrl.$inject = ['$scope', '$http', '$log', '$state', 'TokenListFactory', 'localStorageService'];

    function TokenListCtrl($scope, $http, $log, $state, TokenListFactory, localStorageService) {

        $scope.config = {
            autoHideScrollbar: false,
            theme: 'light',
            advanced:{
                updateOnContentResize: true
            },
            callbacks: {
                onScroll: function () {
                    $log.info('Scroll event fired inside the directive');
                    if ((raw.scrollTop + raw.clientHeight) > (raw.scrollHeight)) {
                        $scope.$apply(attrs.PortalInfiniteScroll);
                    }
                }
            },
            setHeight: 290,
            scrollInertia: 0
        }

        $scope.dtOptions = {
            info: false,
            paging: false,
            searching: false            
        }

        $scope.Status_Label = {
            '1': 'info',
            '2' : 'success' 
        };
        
        var EmployeeModel = localStorageService.get('loggedInEmployee');
        $scope.LoggedInUser = EmployeeModel.model.Result;
        $scope.SearchText = '';
        $scope.PageNum = 1;
        $scope.CreatedBy = $scope.LoggedInUser.EmployeeID;

        $scope.$watch("SearchText", function () {
            TokenListFactory.GetTokenList($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {               
                $scope.TokenDataList = promise.data;
                $log.info(promise.data);
            })
        });

        
        $scope.$on('EventSearch', function (event, SearchKey) {
            if ($state.current.name == 'Platform.Portal.Token') {
                $log.info('Inside EventSearch');
                $scope.SearchText = SearchKey;
            }
        })

        $scope.LoadMoreTokens = function () {
            $scope.PageNum = $scope.PageNum + 1;
            TokenListFactory.GetTokenList($scope.PageNum, $scope.SearchText,$scope.CreatedBy).then(function (promise) {
                $scope.MergedObject = angular.merge({}, $scope.TokenDataList, promise.data);
                $scope.TokenDataList = $scope.MergedObject;
            })
        }

        $scope.Next = function () {
            $scope.PageNum = $scope.PageNum + 1;
            TokenListFactory.GetTokenList($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {
                $scope.TokenDataList = promise.data;
                $log.info(promise.data);
                if (Object.keys($scope.TokenDataList).length == 0) {
                    $scope.PageNum = 1;
                    TokenListFactory.GetTokenList($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {
                        $scope.TokenDataList = promise.data;
                        $log.info(promise.data);
                    })
                }
            })
            $log.info($scope.PageNum);
        }

        $scope.Previous = function () {
            $scope.PageNum = $scope.PageNum - 1;
            if ($scope.PageNum < 1) {
                $scope.PageNum = 1;
            }
            TokenListFactory.GetTokenList($scope.PageNum, $scope.SearchText, $scope.CreatedBy).then(function (promise) {
                $scope.TokenDataList = promise.data;
                $log.info(promise.data);
            })
        }
    }
})();
