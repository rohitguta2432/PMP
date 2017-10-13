(function() {
    'use strict';

    angular
        .module('Portal')
        .directive('customDatePicker', customDatePicker);

    customDatePicker.$inject = ['$log'];
    
    function customDatePicker($log) {
        // Usage:
        //     <customDatePicker></customDatePicker>
        // Creates:
        // 
        var directive = {          
            require: '?ngModel',
            restrict: 'AEC',
            scope: {
                    field: '@'
             },
            link: link,
        };

        return directive;

        function link(scope, element, attrs, ngModel) {
            $(element).datepicker().on('changeDate', function (event) {
                $log.info(event.date.toLocaleDateString());
                scope.$apply(function () {
                    ngModel.$setViewValue(event.date.toLocaleDateString());
                });
            });
        }
    }

})();