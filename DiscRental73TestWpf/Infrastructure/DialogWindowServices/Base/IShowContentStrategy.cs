using DiscRental73.Domain.DtoModels.Base;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public interface IShowContentStrategy
    {
        bool ShowDialog<T>(T? formationData) where T : DtoBase;
    }
}
