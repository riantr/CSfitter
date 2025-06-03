using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using CSfitter.Models;

namespace CSfitter.ViewModels
{
    internal class ColorSpaceListViewModel : ReactiveObject
    {
        private readonly ColorSpaceRepository _colorSpace = new();
        private bool _isLoading;
        public ObservableCollection<ColorSpace> ColorSpaces { get; } = new();
        public ReactiveCommand<Unit, Unit> LoadColorSpacesCommand { get; }
        public bool IsLoading
        {
            get => _isLoading;
            private set => this.RaiseAndSetIfChanged(ref _isLoading, value);
        }

        public ColorSpaceListViewModel()
        {
            LoadColorSpacesCommand = ReactiveCommand.CreateFromTask(
                execute: LoadColorSpacesAsync,
                canExecute: this.WhenAnyValue(x => x.IsLoading, isLoading => !isLoading)
            );

            LoadColorSpacesCommand.IsExecuting.Subscribe(isExecuting => IsLoading = isExecuting);
            LoadColorSpacesCommand.ThrownExceptions.Subscribe(ex => Console.WriteLine($"Error loading color spaces: {ex.Message}"));
            LoadColorSpacesCommand.Execute().Subscribe();
        }

        private async Task LoadColorSpacesAsync()
        {
            ColorSpaces.Clear();
            ColorSpaceRepository colorSpaces = await _colorSpace.GetColorSpacesAsync(); 
            foreach (var colorSpace in colorSpaces)
            {
                ColorSpaces.Add(colorSpace);
            }
        }
        /*
        LoadColorSpacesCommand = ReactiveCommand.CreateFromTask(LoadColorSpacesAsync);
        LoadColorSpacesCommand.ThrownExceptions.Subscribe(ex => Console.WriteLine($"Error loading color spaces: {ex.Message}"));
        LoadColorSpacesCommand.Execute().Subscribe();
        */
    }
        /*
        private ObservableCollection<ColorSpace> _colorSpaces;
        public ObservableCollection<ColorSpace> ColorSpaces
        {
            get => _colorSpaces;
            set => this.RaiseAndSetIfChanged(ref _colorSpaces, value);
        }
        public ColorSpaceListViewModel()
        {
            ColorSpaces = new ObservableCollection<ColorSpace>();
            LoadColorSpaces();
        }
        private void LoadColorSpaces()
        {
            // Load color spaces from a data source or initialize them here
            // For example, you could add some predefined color spaces
            ColorSpaces.Add(new ColorSpace { Name = "sRGB", Description = "Standard RGB color space" });
            ColorSpaces.Add(new ColorSpace { Name = "Adobe RGB", Description = "Adobe RGB color space" });
            // Add more color spaces as needed
        }
        */
    }
}
