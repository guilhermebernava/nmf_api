using System;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace NmfApi.Controllers
{
    public class ApiController : ControllerBase
    {
        protected readonly UserContext Db;
        public ApiController(UserContext db)
        {
            Db = db;
        }

    }
}

