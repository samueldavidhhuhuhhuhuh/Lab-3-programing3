    using Avalonia;
    using Avalonia.ReactiveUI; // Necesario para el método UseReactiveUI
    using System;

    namespace HexCalcApp;

    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called:
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI(); // ¡Esta línea es la CLAVE para solucionar el error de hilo!
    }
    