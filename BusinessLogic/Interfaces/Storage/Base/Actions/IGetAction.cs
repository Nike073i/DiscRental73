namespace BusinessLogic.Interfaces.Storage.Base.Actions;

public interface IGetAction<TRes> where TRes : ResDto, new()
{
    TRes? GetById(int id);
    IEnumerable<TRes> GetAll();
}