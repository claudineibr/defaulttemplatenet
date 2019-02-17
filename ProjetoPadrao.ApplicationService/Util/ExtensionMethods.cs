namespace ProjetoPadrao.ApplicationService.Util
{
    using System;

    public static class ExtensionMethods
    {
        public static bool ExcecaoNaoTratada(this Exception exception)
        {
            return exception.GetType().FullName.StartsWith("System.") && !exception.GetType().FullName.Contains(".FaultException");
        }
    }
}
