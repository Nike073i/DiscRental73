using BusinessLogic.BusinessLogics.Base;
using BusinessLogic.Interfaces.Storages;
using BusinessLogic.Mappers;
using DiscRental73TestWpf.Infrastructure.Commands.Base;

namespace DiscRental73TestWpf.Infrastructure.Commands
{
    public class DeleteDataCommand<Req, Res> : ServiceCommand<Req, Res> where Req : ReqDto, new() where Res : ResDto, new()
    {
        private readonly IDtoMappers<Req, Res> _mapper;
        public DeleteDataCommand(CrudService<Req, Res> service, IDtoMappers<Req, Res> mapper) : base(service)
        {
            _mapper = mapper;
        }

        public override void Execute(object? parameter)
        {
            if (parameter == null)
            {
                return;
            }

            if (parameter is Res item)
            {
                try
                {
                    var reqDto = _mapper.MapToReq(item);
                    service.DeleteById(reqDto);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
