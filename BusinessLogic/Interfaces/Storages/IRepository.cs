namespace BusinessLogic.Interfaces.Storages
{
    public interface IRepository<Req, Res> where Req : ReqDto, new() where Res : ResDto, new()
    {
        ICollection<Res> GetAll();
        Res GetById(Req reqDto);
        void Insert(Req reqDto);
        void Update(Req reqDto);
        void DeleteById(Req reqDto);
    }
}
