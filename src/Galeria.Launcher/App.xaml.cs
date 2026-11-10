namespace Galeria.Launcher;

// Calificado completo: dentro de "Galeria.*", el nombre "Application" resuelve al namespace Galeria.Application.
public partial class App : Microsoft.Maui.Controls.Application
{
    public App() => InitializeComponent();

    protected override Window CreateWindow(IActivationState? activationState) =>
        new(new AppShell()) { Title = "Galería — Armado de Exposición" };
}
