using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace PMP
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Scripts/custom-scripts/jquery.js",
                "~/Scripts/custom-scripts/flot/*.js",
                "~/Scripts/custom-scripts/bootstrap.js",
                "~/Scripts/custom-scripts/bootstrap-slider.js",
                 "~/Scripts/jquery.nanoscroller.min.js",
                "~/Scripts/custom-scripts/demo.js",
                "~/Scripts/custom-scripts/demo-*",
                "~/Scripts/custom-scripts/jquery-*",
                "~/Scripts/custom-scripts/select2.min.js",
                "~/Scripts/custom-scripts/daterangepicker.js",
                "~/Scripts/custom-scripts/scripts.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap/bootstrap.min.css",
                 "~/Content/bootstrap-slider.css",
                 "~/Content/ui-bootstrap-csp.css",
                 "~/Content/jquery.mCustomScrollbar.css",
                 "~/Content/ng-scrollbar.css",
                 "~/Content/angular-datatables.css",
                 "~/Content/compiled/*.css", 
                 "~/Content/libs/*.css",
                 "~/Content/Site.css",
                 "~/Content/dd.css",
                 "~/Content/jquery.treegrid.css",
                 "~/Content/loading-bar.css")); 

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                 "~/Scripts/angular.js",
                 "~/Scripts/angular-*", 
                 "~/Scripts/angular-ui/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollbars").Include(
                 "~/Scripts/jquery.mCustomScrollbar.js",
                 "~/Scripts/ng-scrollbar.js",
                 "~/Scripts/scrollbars.js",
                 "~/Scripts/loading-bar.js"));

            bundles.Add(new ScriptBundle("~/bundles/portal").Include(
                 "~/Portal/*.js", 
                 "~/Portal/Token/*.js",
                 "~/Portal/Client/*.js",
                 "~/Portal/Login/*.js",
                 "~/Portal/Registration/*.js",
                 "~/Portal/RecoverPassword/*.js",
                 "~/Portal/TokenTask/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/navbar").Include(
                //"~/Scripts/*.js"
                "~/Scripts/custom-scripts/jquery.js",
                "~/Scripts/jquery-2.1.1.js",
                "~/Scripts/custom-scripts/bootstrap.js",
                "~/Scripts/jquery.dataTables.js",
                "~/Scripts/custom-scripts/bootstrap-slider.js",
                "~/Scripts/custom-scripts/daterangepicker.js",
                "~/Scripts/custom-scripts/demo.js",
                "~/Scripts/custom-scripts/scripts.js",
                "~/Scripts/jquery.nanoscroller.min.js",
                "~/Scripts/jquery.dd.js",
                "~/Scripts/jquery.treegrid.js",
                "~/Scripts/jquery.treegrid.bootstrap3.js"));

        }
    }
}
