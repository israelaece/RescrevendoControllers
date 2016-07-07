using System;
using System.Web.Mvc;

namespace ANC.Web.UI.Loja.Util.ModelBinders
{
    public class Produto : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var temp = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
            var id = Guid.Empty;

            if (Guid.TryParse(temp, out id))
                return DependencyResolver.Current.GetService<IDados>().RecuperarProdutoPor(id);

            return null;
        }
    }
}