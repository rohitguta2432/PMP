(function() {
    'use strict';

    angular
        .module('Portal')
        .directive('portalInfiniteScroll', PortalInfiniteScroll);

    PortalInfiniteScroll.$inject = ['$window','$log'];
    
    function PortalInfiniteScroll($window, $log) {
        // Usage:
        //     <PortalInfiniteScroll></PortalInfiniteScroll>
        // Creates:
        // 
        $log.info('Inside Directive');
        var directive = {
            link: link,
            restrict: 'A',
        };
        return directive;

        function link(scope, element, attrs) {
            var raw = element[0];
            $log.info('Inside link function of the directive');

            angular.element(element).mCustomScrollbar({
                callbacks: {
                    onScroll: function () {
                        $log.info('Scroll event fired inside the directive');
                        if ((raw.scrollTop + raw.clientHeight) > (raw.scrollHeight)) {
                            scope.$apply(attrs.PortalInfiniteScroll);
                        }
                    }
                }
            })

            //angular.element(element).bind('scroll', function () {
            //    $log.info('Scrolling using element binding');
            //})
            //raw.addEventListener('scroll', function () {
            //    $log.info('Scroll event fired inside the directive');
            //    if ((raw.scrollTop + raw.clientHeight) > (raw.scrollHeight)) {
            //        scope.$apply(attrs.PortalInfiniteScroll);
            //    }
            //});
        }
    };

})();