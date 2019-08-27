using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Web.Areas.Administration.Controllers
{
    public class ReceptionistController : AdministratorController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}