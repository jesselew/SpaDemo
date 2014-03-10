using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace SpaDemo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js",
                "~/Scripts/knockout.mapping.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/template.js",
                "~/Scripts/app/app.js",
                "~/Scripts/app/event.viewmodel.js",
                "~/Scripts/app/eventlist.viewmodel.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/director").Include(
                "~/Scripts/director.js"));

            bundles.Add(new ScriptBundle("~/bundles/require").Include(
                "~/Scripts/require.js",
                "~/Scripts/require.text.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));
        }
    }
}
