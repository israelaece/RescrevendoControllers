using ANC.Web.UI.Loja.Core.Infraestrutura;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Util.ActionResults
{
    public class CommandActionResult<T> : ActionResult where T : Command
    {
        public CommandActionResult(T command, ActionResult success, ViewResult failure)
        {
            this.Command = command;
            this.Success = success;
            this.Failure = failure;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                this.Failure.ExecuteResult(context);
                return;
            }

            DependencyResolver.Current.GetService<IBus>().Send(this.Command);

            this.Success.ExecuteResult(context);
        }

        public T Command { get; private set; }

        public ActionResult Success { get; private set; }

        public ViewResult Failure { get; private set; }
    }
}