namespace ANC.Web.UI.Loja.Core.Infraestrutura
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T @message);
    }
}