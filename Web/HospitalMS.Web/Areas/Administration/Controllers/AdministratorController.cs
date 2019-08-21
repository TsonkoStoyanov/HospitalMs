namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using HospitalMS.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class AdministratorController : BaseController
    {
    }
}