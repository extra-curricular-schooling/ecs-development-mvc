using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECS.Cors
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Author: Scott Roberts</remarks>
    public class EnableCorsModule: IHttpModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.CorsEnableAll);
            //context.BeginRequest += new EventHandler(CorsEnableAccessPoints);
            context.EndRequest += new EventHandler(OnEndRequest);
        }

        public void Dispose() { }

        public delegate void MyEventHandler(Object s, EventArgs e);

        private MyEventHandler _eventHandler = null;

        public event MyEventHandler MyEvent
        {
            add { _eventHandler += value; }
            remove { _eventHandler -= value; }
        }

        public void CorsEnableAll(Object s, EventArgs e)
        {
            HttpApplication app = s as HttpApplication;
            app.Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8080");
            app.Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, OPTIONS");
            app.Context.Response.AddHeader("Access-Control-Allow-Headers", "*");
            app.Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            _eventHandler?.Invoke(this, null);
        }

        public void CorsEnableAccessPoints(Object s, EventArgs e)
        {
            HttpApplication app = s as HttpApplication;
            app.Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8080");
            app.Context.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, OPTIONS");
            //app.Context.Response.AddHeader("Access-Control-Allow-Headers", "" +
            //    "Access-Control-Allow-Origin" +
            //    "Access-Control-Request-Method" +
            //    "Access-Control-Request-Headers" +
            //    "Cookie" +
            //    "Host" +
            //    "Origin" +
            //    "Referer");
            app.Context.Response.AddHeader("Access-Control-Allow-Headers", "*");
            app.Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            _eventHandler?.Invoke(this, null);
        }

        public void OnEndRequest(Object s, EventArgs e)
        {
            HttpApplication app = s as HttpApplication;
            //app.Context.Response.Write("Hello from OnEndRequest in custom CORS module.<br>");
            _eventHandler?.Invoke(this, null);
        }
    }
}
