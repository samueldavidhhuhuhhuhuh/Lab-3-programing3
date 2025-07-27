README: Calculadora Hexadecimal en Avalonia UI
Este repositorio contiene el código fuente de una calculadora hexadecimal de escritorio desarrollada con Avalonia UI en .NET, siguiendo el patrón Model-View-ViewModel (MVVM).

1. Requisitos Previos
Antes de empezar, asegúrate de tener instalado lo siguiente:

SDK de .NET: Descarga e instala la última versión estable (se recomienda .NET 8 LTS o superior) desde https://dotnet.microsoft.com/download.

Visual Studio Code: Descarga e instala el editor desde https://code.visualstudio.com/.

Extensiones de Visual Studio Code:

C# Dev Kit: Para soporte completo de C#.

Avalonia UI: Para soporte de XAML de Avalonia.

NuGet Package Manager: Para gestionar paquetes.

2. Configuración del Proyecto
Sigue estos pasos para configurar y ejecutar el proyecto:

2.1. Instalar las Plantillas de Avalonia
Abre una terminal (en VS Code o tu sistema) y ejecuta:

dotnet new install Avalonia.Templates

2.2. Crear el Proyecto
Navega a la carpeta donde deseas guardar tu proyecto (ej. cd C:\Proyectos) y luego ejecuta:

dotnet new avalonia.mvvm -o HexCalcApp

2.3. Abrir el Proyecto en Visual Studio Code
Abre la carpeta HexCalcApp en Visual Studio Code (Archivo > Abrir Carpeta...).

3. Instalación de Dependencias
Una vez abierto el proyecto, instala los paquetes NuGet necesarios. Abre la terminal en Visual Studio Code (asegúrate de estar en la carpeta HexCalcApp) y ejecuta los siguientes comandos:

dotnet add package ReactiveUI.Fody
dotnet add package System.Reactive
dotnet add package Avalonia.ReactiveUI
dotnet restore

4. Ejecutar la Aplicación
Después de instalar las dependencias, puedes ejecutar la aplicación. En la terminal (dentro de la carpeta HexCalcApp), ejecuta:

dotnet run

Esto compilará y lanzará la calculadora hexadecimal.

5. Solución de Posibles Errores Comunes
Si encuentras problemas al ejecutar la aplicación, aquí están las soluciones para los errores más comunes que podrían surgir:

5.1. Error: "El tipo o el nombre del espacio de nombres 'Reactive' no existe..." (CS0234, CS0246)
Este error indica que las librerías de ReactiveUI no están siendo reconocidas correctamente.

Solución: Asegúrate de haber ejecutado dotnet add package ReactiveUI.Fody y dotnet add package System.Reactive correctamente. Luego, verifica que el archivo ViewModels/ViewModelBase.cs herede de ReactiveObject.

ViewModels/ViewModelBase.cs debe verse así:

using ReactiveUI;

namespace HexCalcApp.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
    }
}

Guarda el archivo y reinicia Visual Studio Code.

5.2. Error: "Call from invalid thread" o la aplicación se cierra al interactuar.
Este problema ocurre porque ReactiveUI no está configurado para interactuar correctamente con el hilo de la UI de Avalonia.

Solución: Debes añadir la llamada a UseReactiveUI() en el archivo Program.cs.

Program.cs debe verse así (fíjate en la línea .UseReactiveUI()):

using Avalonia;
using Avalonia.ReactiveUI; // Necesario para el método UseReactiveUI
using System;

namespace HexCalcApp;

class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI(); // ¡Añade esta línea!
}

Guarda el archivo y reinicia Visual Studio Code.
