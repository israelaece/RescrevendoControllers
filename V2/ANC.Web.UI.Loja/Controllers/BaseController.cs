using ANC.Web.UI.Loja.Core.Infraestrutura;
using ANC.Web.UI.Loja.Util;
using ANC.Web.UI.Loja.Util.ActionResults;
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

        public CommandActionResult<T> Command<T>(T command, ActionResult success) where T : Command
        {
            return Command<T>(command, success, View());
        }

        public CommandActionResult<T> Command<T>(T command, ActionResult success, ViewResult failure) where T : Command
        {
            return new CommandActionResult<T>(command, success, failure);
        }
    }
}