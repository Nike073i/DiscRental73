﻿using MathCore.WPF.Commands;
using System.Windows;

namespace DiscRental73.Wpf.Infrastructure.Commands
{
    public class CloseDialogCommand : Command
    {
        public bool? DialogResult { get; set; }
        public override bool CanExecute(object? parameter) => parameter is Window;

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter) || parameter is not Window window) return;
            window.DialogResult = DialogResult;
            window.Close();
        }
    }
}