(function () {
    'use strict';

    angular.module('Portal.Registration')
           .controller('RecoverCtrl', RecoverCtrl)
           .controller('ResetCtrl', ResetCtrl);

    RecoverCtrl.$inject = ['$scope', '$log', '$state', '$stateParams', 'RecoverFactory'];
    ResetCtrl.$inject = ['$scope', '$log', '$state', '$stateParams', 'RecoverFactory']

    function RecoverCtrl($scope, $log, $state, $stateParams, RecoverFactory) {
        $log.info("Recover Password Intialized");

        $scope.RecoverPassword=function(){
            RecoverFactory.SubmitRecoverPassword($scope.RecoverModel).then(function (promise) {
                $scope.done = true;
                $scope.message = "Please check your mail to reset your password.";
            }, function (response) {
                $scope.ErrorMessage = response.statusText;
                $log.info(response.data);
                $scope.Error = response.data;
            })
        }
    }

    function ResetCtrl($scope, $log, $state, $stateParams, RecoverFactory) {
        $scope.done = false;
        $scope.ReadOnly = true;
        $scope.ResetPasswordModel = {};
        $scope.ResetPasswordModel.Code = $stateParams.Code;
        $scope.ResetPasswordModel.UserID = $stateParams.UserID;        

        RecoverFactory.ValidateResetEntry($scope.ResetPasswordModel.UserID).then(
            function (promise) {
                if (promise.data.Id === $scope.ResetPasswordModel.UserID) {
                    $scope.ReadOnly = false;
                }
            },
            function (error) {
                if (error.status === 400) {
                    $state.go('Login');
                }
            }
        )

        $scope.SubmitNewPassword = function () {
            RecoverFactory.ResetPasswordAction($scope.ResetPasswordModel).then(
                function (promise) {
                    $scope.message = promise.data;
                    $scope.done = !$scope.done;
                },
                function (error) {
                    if (error.status === 400) {
                        $state.go('Login');
                    }
                }
            )
        }

    }

})();