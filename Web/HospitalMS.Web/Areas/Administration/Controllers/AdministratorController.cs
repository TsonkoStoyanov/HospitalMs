namespace HospitalMS.Web.Areas.Administration.Controllers
{
    using HospitalMS.Common;
    using HospitalMS.Common.Attributes;
    using HospitalMS.Web.Controllers;   
    using Microsoft.AspNetCore.Mvc;


    [AuthorizeRoles(GlobalConstants.AdministratorRoleName, GlobalConstants.ReceptionistRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}