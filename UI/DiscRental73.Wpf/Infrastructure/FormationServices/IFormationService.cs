namespace DiscRental73.Wpf.Infrastructure.FormationServices
{
    public interface IFormationService
    {
        public IEntityEditStrategy? EditStrategy { get; set; }

        bool EditEntity(ref object entity);

        void ShowInformation(string information, string caption);

        void ShowWarning(string message, string caption);

        void ShowError(string message, string caption);

        bool Confirm(string message, string caption, bool exclamation = false);
    }
}
