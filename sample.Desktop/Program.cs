using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Input;

namespace AvaloniaGraphControlSample.Desktop;

class Program
{
  // Initialization code. Don't use any Avalonia, third-party APIs or any
  // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
  // yet and stuff might break.
  [STAThread]
  public static void Main(string[] args) => BuildAvaloniaApp()
    .StartWithClassicDesktopLifetime(args);

  // Avalonia configuration, don't remove; also used by visual designer.
  public static AppBuilder BuildAvaloniaApp()
    => AppBuilder.Configure<App>()
      .UsePlatformDetect()
      .WithInterFont()
      .LogToTrace()
      .SetUrlOpener(OpenUrl)
      .WithDeveloperTools(options =>
      {
        options.Gesture = KeyGesture.Parse("F12");
      });
  
  private static void OpenUrl(string url)
  {
    using var proc = new Process();
    proc.StartInfo.UseShellExecute = true;
    proc.StartInfo.FileName = url;
    proc.Start();
  }
}
