using BusinessLogic.DtoModels.ResponseDto;
using System.Collections.Generic;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public abstract class WindowProductFormationService : WindowDataFormationService<ProductResDto>
    {
        public IEnumerable<DiscResDto> Discs { get; set; }
    }
}
