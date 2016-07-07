using ANC.Web.UI.Loja.Util;
using System;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Controllers
{
    public abstract class BaseController : Controller
    {
        public Guid ClienteId
        {
            get
            {
                return GestorDeAcesso.ClienteId ?? Guid.Empty;
            }
        }
    }
}