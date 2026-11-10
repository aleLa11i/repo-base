using Galeria.Presentation.ViewModels;

namespace Galeria.Launcher.Views;

public partial class ExposicionPage : ContentPage
{
    public ExposicionPage(ExposicionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // En MAUI es BindingContext (en WPF era DataContext).
    }
}
