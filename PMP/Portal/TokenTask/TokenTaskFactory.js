'use strict';
angular.module('Portal.Token')
   .factory('TokenTaskFactory', function ($http) {

       return {
           GetTaskListBasedOnStage: function (StageID) {
               return $http.get('/api/TaskMaster', { params: { "StageID": StageID } });
           },
           GetPriorityData: function () {
               return $http.get('/api/TaskPriorityMaster');
           },
           GetEmployeeBasedOnDepartment: function (DepartmentID) {
               return $http.get('/GetEmployeeDetails/' + DepartmentID);
           },
           GetCurrentStatus: function () {
               return $http.get('/api/CurrentStatusMaster');
           }
       }
   });