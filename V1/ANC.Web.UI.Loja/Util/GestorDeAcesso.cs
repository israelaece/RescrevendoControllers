using System;
using System.Web;

namespace ANC.Web.UI.Loja.Util
{
    public class GestorDeAcesso
    {
        public static void Autenticar(Guid clienteId)
        {
            ClienteId = clienteId;
        }

        public static Guid? ClienteId
        {
            get
            {
                var clienteId = HttpContext.Current.Session["ClienteId"];

                return clienteId != null ? (Guid)clienteId : (Guid?)null;
            }
            private set
            {
                HttpContext.Current.Session["ClienteId"] = value;
            }
        }
    }
}