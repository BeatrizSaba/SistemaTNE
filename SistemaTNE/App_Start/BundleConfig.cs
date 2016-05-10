using System.Web;
using System.Web.Optimization;

namespace SistemaTNE
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/_bootstrap").Include(
                      "~/Content/bootstrap.css"
                      ));
   

            bundles.Add(new StyleBundle("~/Content/css/_app").Include(
                "~/Content/CSS/sb-admin.css",
                "~/Content/CSS/font-awesome.min.css",
                "~/Content/CSS/bootstrap-table.css",
                "~/Content/CSS/waitMe.css",                                
                "~/Content/CSS/bootstrap-select.css",
                "~/Content/CSS/geral.css",
                "~/Content/CSS/select2.css",
                "~/Content/CSS/bootstrap-dialog.css"               
                ));

            bundles.Add(new ScriptBundle("~/Scripts/_plugins").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/modernizr-*",

                "~/Scripts/bootstrap-table.js",
                "~/Scripts/waitMe.js",               
                "~/Scripts/bootstrap-select.js",
                "~/Scripts/select2.js",
                "~/Scripts/chart.min.js",               
                "~/Scripts/bootstrap-dialog.js",
                "~/Scripts/bsModelCustom.js",
                "~/Scripts/jquery.inputmask.bundle.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/App/_js").Include(
                "~/Scripts/App/constantes.js",
                "~/Scripts/App/geral.js",
                "~/Scripts/App/sistema.js",
                "~/Scripts/App/usuarios.js",
                "~/Scripts/App/clientes.js",
                "~/Scripts/App/sistema.js"
                ));


            BundleTable.EnableOptimizations = true;
        }
    }
}
