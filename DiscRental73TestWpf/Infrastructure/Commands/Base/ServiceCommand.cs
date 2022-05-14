using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.Interfaces.Storages;
using MathCore.WPF.Commands;

namespace DiscRental73TestWpf.Infrastructure.Commands.Base
{
    public class ServiceCommand<Req, Res> : LambdaCommand where Req : ReqDto, new() where Res : ResDto, new()
    {
        protected readonly CrudService<Req, Res> service;

        public ServiceCommand(CrudService<Req, Res> service)
        {
            this.service = service;
        }
    }
}
