using System.Collections.Generic;

namespace ProjetoPadrao.Domain.IRepository
{
    public interface IMeuServicoRepository
    {
        string[] GetServicos();
        IList<object> PostService();
    }
}
