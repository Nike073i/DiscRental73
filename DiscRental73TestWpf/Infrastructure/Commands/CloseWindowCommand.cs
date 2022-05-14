using MathCore.WPF.Commands;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.Commands
{
    public class CloseWindowCommand : Command
    {
        public override bool CanExecute(object? parameter)
        {
            return parameter is Window;
        }

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            var window = parameter as Window;
            window.Close();
        }
    }
}
