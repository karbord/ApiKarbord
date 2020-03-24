using ApiKarbord.Controllers.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ApiKarbord
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);


            UnitPublic.Appddress = Server.MapPath("");
            UnitPublic.MyIni = new IniFile(UnitPublic.Appddress + "\\Content\\ini\\SqlServerConfig.Ini");
            //UnitPublic.MyIniServer = new IniFile(UnitPublic.Appddress + "\\Content\\ini\\SqlServerConfigServer.Ini");
            //UnitPublic.MyIni = new IniFile(@"c:\test\Content\ini\SqlServerConfig.Ini");
            //UnitPublic.MyIniServer = new IniFile(@"c:\test\Content\ini\SqlServerConfigServer.Ini");

            //#if DEBUG
            //UnitPublic.Appddress = Server.MapPath("");
            //UnitPublic.MyIni = new IniFile(UnitPublic.Appddress + "\\Content\\ini\\SqlServerConfig.Ini");
            //UnitPublic.MyIniServer = new IniFile(UnitPublic.Appddress + "\\Content\\ini\\SqlServerConfigServer.Ini");
            //#endif
        }
    }
}
