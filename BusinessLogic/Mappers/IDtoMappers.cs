using BusinessLogic.Interfaces.Storages;

namespace BusinessLogic.Mappers
{
    public interface IDtoMappers<Req, Res> where Req : ReqDto, new() where Res : ResDto
    {
        Req MapToReq(Res resDto);
    }
}
