(function () {
    'use strict';
  angular
        .module('Portal.Token')
        .controller('TokenTaskCtrl', TokenTaskCtrl);

  TokenTaskCtrl.$inject = ['$scope', 'TokenTaskFactory', '$log'];

    function TokenTaskCtrl($scope, TokenTaskFactory, $log) {

        $scope.TaskList = [{
            TaskName: 'Client Meeting',
            TaskPriority: 'High',
            TaskDesc: 'Description of our task',
            AssignTo: 'Sunny',
            DueDate: 'Tomorrow',
            Status:'Right on Time'
        },
        {
            TaskName: 'Follow up',
            TaskPriority: 'Max Priority',
            TaskDesc: 'Description of our task',
            AssignTo: 'Afjal',
            DueDate: 'Tomorrow or day after tommorrow',
            Status: 'Not on Time'
        }];

        $scope.AddTaskRow = function () {
            $scope.TaskList.push({
                TaskName: '',
                TaskPriority: '',
                TaskDesc: '',
                AssignTo: '',
                DueDate: '',
                Status: ''
            });
        }

    };

})();
