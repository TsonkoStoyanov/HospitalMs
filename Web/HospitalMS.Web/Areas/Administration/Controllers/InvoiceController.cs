namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    
    public class InvoiceController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}