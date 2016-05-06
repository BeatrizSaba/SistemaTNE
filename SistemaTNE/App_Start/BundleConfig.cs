using System.Web;
using System.Web.Optimization;

namespace SistemaTNE
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"
                      //,"~/Content/site.css"
                      ));
   

            bundles.Add(new StyleBundle("~/bundles/estilos_dependentes").Include(
                "~/Content/CSS/bootstrap-table.css",
                "~/Content/CSS/waitMe.css",
                "~/Content/CSS/sb-admin.css",
                "~/Content/CSS/font-awesome.min.css",
                "~/Content/CSS/bootstrap-select.css",
                "~/Content/CSS/geral.css",
                "~/Content/CSS/select2.css",
                "~/Content/CSS/bootstrap-dialog.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts_dependentes").Include(
                "~/Scripts/bootstrap-table.js",
                "~/Scripts/waitMe.js",
                "~/Scripts/App/constantes.js",
                "~/Scripts/App/geral.js",
                "~/Scripts/App/sistema.js",
                "~/Scripts/App/usuarios.js",
                "~/Scripts/App/clientes.js",
                "~/Scripts/App/sistema.js",
                "~/Scripts/bootstrap-select.js",
                "~/Scripts/select2.js",
                "~/Scripts/chart.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/bootstrap-dialog.js",
                "~/Scripts/bsModelCustom.js",
                "~/Scripts/jquery.inputmask.bundle.js"
                ));
        }
    }
}
