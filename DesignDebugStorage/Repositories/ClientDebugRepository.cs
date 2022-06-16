using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storage;

namespace DesignDebugStorage.Repositories;

public class ClientDebugRepository : IClientRepository
{
    private readonly IEnumerable<ClientResDto> _clients = Enumerable.Range(1, 10).Select(i => new ClientResDto
    {
        Id = i,
        Address = $"Адрес - {i}",
        ContactNumber = $"н.тел - {i}",
        FirstName = $"Имя - {i}",
        SecondName = $"Фамилия - {i}"
    });

    public ClientResDto GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ClientResDto> GetAll()
    {
        return _clients.ToList();
    }

    public ClientResDto Insert(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public ClientResDto GetByContactNumber(string contactNumber)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public ClientResDto Update(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}