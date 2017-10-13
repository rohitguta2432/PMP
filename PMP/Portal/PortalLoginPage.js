(function() {
    'use strict';

    angular
        .module('Portal')
        .directive('customLoginImageHeight', customLoginImageHeight);

    customLoginImageHeight.$inject = ['$window', '$log'];
    
    function customLoginImageHeight($window) {

        var directive = {
            link: link,
            restrict: 'EA'
        };
        return directive;

        function link(scope, element, attrs) {
            element.css('height',$window.outerHeight+'px')
        }
    }

})();