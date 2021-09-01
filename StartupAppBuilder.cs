using Owin;
using System.Web.Http;
using Newtonsoft.Json;

namespace WYQ
{
    public class StartupAppBuilder
    {
        //public static void Configuration(IAppBuilder appBuilder)
        //{
        //    // 在应用程序启动时运行的代码

        //    //加载WebApi服务器配置信息
        //    var config = new HttpConfiguration();

        //    //配置路由
        //    var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
        //    config.EnableCors(cors);
        //    config.MapHttpAttributeRoutes();

        //    //配置JSON格式化
        //     GlobalConfiguration.Configuration.Formatters.Insert(0, new PlainTextTypeFormatter());

        //    config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
        //    config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //    config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
        //    config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        //    config.Formatters.Remove(config.Formatters.XmlFormatter);

        //    // 解决json序列化时的循环引用问题
        //    config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        //    // 对 JSON 数据使用混合大小写。驼峰式,但是是javascript 首字母小写形式.
        //    //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        //    // 对 JSON 数据使用混合大小写。跟属性名同样的大小.输出
        //    config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new UnderlineSplitContractResolver();

        //    //使用配置
        //    appBuilder.UseWebApi(config);
        //    appBuilder.UseStageMarker(Owin.PipelineStage.PostAcquireState);

        //    //链接控制器
        //    //Type C1 = typeof(CSFramework.WebAPI.Demo.DemoController);
        //}


        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");   //解决跨域
            config.EnableCors(cors);

            // 启用Web API特性路由
            config.MapHttpAttributeRoutes();

            //默认路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }

}
