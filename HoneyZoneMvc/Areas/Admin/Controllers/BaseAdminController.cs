﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HoneyZoneMvc.Common.Constraints.ApplicationConstants;
namespace HoneyZoneMvc.Areas.Admin.Controllers
{
    [Authorize(Roles = AdministratorRoleName)]
    [Area(AdminAreaName)]
    public class BaseAdminController : Controller
    {
    }
}
