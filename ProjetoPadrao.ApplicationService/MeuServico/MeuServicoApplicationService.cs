using ProjetoPadrao.Domain.IApplicationService;
using ProjetoPadrao.Domain.IRepository;

namespace ProjetoPadrao.ApplicationService.MeuServico
{
    public class MeuServicoApplicationService : IMeuServicoApplicationService
    {
        private readonly IMeuServicoRepository _servicoRepository;

        public MeuServicoApplicationService(IMeuServicoRepository servicoRepository)
        {
            this._servicoRepository = servicoRepository;
        }

        public string[] GetServicos()
        {
            return this._servicoRepository.GetServicos();
        }
    }
}
