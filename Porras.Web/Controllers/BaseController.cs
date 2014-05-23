using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Porras.Entities;

namespace Porras.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        protected PorrasDataService DataService
        {
            get
            {
                return (PorrasDataService) this.HttpContext.Items["DataService"];
            }
            private set
            {
                this.HttpContext.Items["DataService"] = value;
            }
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            this.DataService = new PorrasDataService();
        }
	}
}