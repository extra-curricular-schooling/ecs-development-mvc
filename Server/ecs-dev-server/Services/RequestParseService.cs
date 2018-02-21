using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ecs_dev_server.Services
{
    public static class RequestParseService
    {
        public static string ReadHttpBody(Stream req)
        {
            req.Seek(0, SeekOrigin.Begin);
            return new StreamReader(req).ReadToEnd();
        }
    }
}