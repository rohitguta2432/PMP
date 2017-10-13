(function() {
    'use strict';

    angular
        .module('Portal')
        .directive('customTaskAssignment', customTaskAssignment);

    customTaskAssignment.$inject = ['$window', '$log', '$timeout','TokenTaskFactory'];
    
    function customTaskAssignment($window, $log, $timeout,TokenTaskFactory) {

        var directive = {
            templateUrl: '/Static/TaskAssignmentTemplate',
           
            link: link,
            restrict: 'EA',
            scope: {
                //'TaskAdd': '&onTaskAdd',
                //'EmployeeAdd': '&onEmployeeAdd',
                'Save':'&onSave'
            }
        };

        return directive;

        function link(scope, element, attrs) {

            var UglyHack = function () {
                $timeout(function () {
                    $(element).find('.tree-2').treegrid({
                        expanderExpandedClass: 'glyphicon glyphicon-minus',
                        expanderCollapsedClass: 'glyphicon glyphicon-plus'
                    });
                }, 1)
            }

            //$window.onLoad(function () {
            //    $(element).find('.tree-2').treegrid({
            //        expanderExpandedClass: 'glyphicon glyphicon-minus',
            //        expanderCollapsedClass: 'glyphicon glyphicon-plus'
            //    });
            //})

            scope.$watchCollection('TaskList', function (newVal, oldVal) {
                UglyHack();
            })

            scope.TaskList = [{
                TaskName: 'Client Meeting',
                TaskPriority: 'High',
                TaskDesc: 'Description of our task',
                AssignTo: 'Sunny',
                DueDate: 'Tomorrow',
                Status: 'Right on Time',
                IsEmployee: false
            },
            {
                IsEmployee: true,
                Employees: [{ EmployeeID: 'SS0090', Hours: '5', Values: '25', Notes: 'Please do not get stuck' }, { EmployeeID: 'SS0109', Hours: '5', Values: '25', Notes: 'Not stuck' }]
            },
            {
                TaskName: 'Follow up',
                TaskPriority: 'Max Priority',
                TaskDesc: 'Description of our task',
                AssignTo: 'Afjal',
                DueDate: 'Tomorrow or day after tommorrow',
                Status: 'Not on Time',
                IsEmployee: false
            },
            {
                IsEmployee: true,
                Employees: [{ EmployeeID: 'SS0097', Hours: '10', Values: '75', Notes: 'It wont get stuck' }]
            }];


            scope.$watch('TaskList', function () {
                $(element).find('.tree-2').treegrid({
                    expanderExpandedClass: 'glyphicon glyphicon-minus',
                    expanderCollapsedClass: 'glyphicon glyphicon-plus'
                });
            })

            scope.AddTaskRow = function () {
                $log.info('Inside AddtaskRow');
                scope.TaskList.push({
                    TaskName: '',
                    TaskPriority: '',
                    TaskDesc: '',
                    AssignTo: '',
                    DueDate: '',
                    Status: '',
                    IsEmployee: false
                },
                {
                    Employees: [{
                        EmployeeID: '',
                        Hours: '',
                        Values: '',
                        Notes:''
                    }],
                    IsEmployee: true
                });
            }

            scope.AddEmployee = function (index) {
                $log.info('index is : ' + index);
                scope.TaskList[index].Employees.push({
                    EmployeeID: '',
                    Hours: '',
                    Values: '',
                    Notes:''
                });
            }

            var stageID = 1;
            var DepartmentID = 1;
            TokenTaskFactory.GetTaskListBasedOnStage(stageID).then(function (response) {
                scope.TaskMaster = response.data;
            }, function (error) {
            });
            TokenTaskFactory.GetPriorityData().then(function (response) {
                scope.TaskPriority = response.data;
            },
            function (response) {
            });

            TokenTaskFactory.GetEmployeeBasedOnDepartment(DepartmentID).then(function (response) {
                scope.EmployeeDetails = response.data;

            },
            function (response) {
            });

            TokenTaskFactory.GetCurrentStatus().then(function (response) {
                scope.TaskStatus = response.data;
                $log.info(scope.TaskStatus);
            },
            function (response) {
            })

            scope.SelectedEmployeeModel = [];

            scope.Demo = [
                {
                    FirstName: "Rohit",
                    LastName: "Raj"
                },
                {
                    FirstName: "Arpan",
                    LastName: "Mathur"
                }];

            scope.DataAction = {
                template:'<b>{{option.FirstName}}</b>',
                showUncheckAll: true,
                showCheckAll:true,
                enableSearch: true,
                styleActive: true,
                selectedToTop: true,
                buttonClasses: 'btn btn-entity-select',
                smartButtonMaxItems: 10,
                searchPlaceholder:'Select Employee'
                
            };
            scope.TaskAllocatedEvent={
                onItemSelect: function (item) {
                    $log.info('SelectItem '+item)
                },
                onItemDeselect:function(){
                    $log.info('DeselectedItem')
            }
            }


        }
    }

})();