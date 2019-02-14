using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Context
{
    public class JsonResp
    {
        public static JsonResult Response(int status, object data)
        {
            return new JsonResult(new
            {
                status = status,
                data = data
            });
        }
    }
}
