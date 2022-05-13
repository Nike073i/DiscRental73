using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Storages
{
    public interface IRepository<Req, Res> where Req : ReqDto, new() where Res : ResDto, new()
    {
        ICollection<Res> GetAll();
        Res GetById(Req reqDto);
        ICollection<Res> GetByFilter(Req reqDto);
        void Insert(Req reqDto);
        void Update(Req reqDto);
        void DeleteById(Req reqDto);
    }
}
