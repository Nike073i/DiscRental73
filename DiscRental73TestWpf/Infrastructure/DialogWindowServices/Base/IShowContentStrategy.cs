namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base
{
    public interface IShowContentStrategy
    {
        void SetData(ref object formationData);
        bool ShowDialog();
        object? GetData();
    }
}
