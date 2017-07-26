using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ViewBiblioteca
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            
               bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/estilos.css"));
            


              bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/js/jquery.js",
                "~/Content/js/main.js",
                "~/Content/js/bootstrap.min.js"));
        }
    }
}