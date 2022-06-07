using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Storages;

namespace DesignDebugStorage.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IEnumerable<ClientResDto> _clients = Enumerable.Range(1, 10).Select(i => new ClientResDto
    {
        Id = i,
        Address = $"Адрес - {i}",
        ContactNumber = $"н.тел - {i}",
        FirstName = $"Имя - {i}",
        SecondName = $"Фамилия - {i}"
    });

    public IEnumerable<ClientResDto> GetAll()
    {
        return _clients.ToList();
    }

    public ClientResDto GetById(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Insert(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void Update(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }

    public ClientResDto GetByContactNumber(ClientReqDto reqDto)
    {
        throw new NotImplementedException();
    }
}