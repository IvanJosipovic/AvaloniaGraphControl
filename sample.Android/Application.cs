using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Avalonia;
using Avalonia.Android;
using Uri = Android.Net.Uri;

namespace AvaloniaGraphControlSample.Android;

[Application]
public class AndroidApp : AvaloniaAndroidApplication<App>
{
  protected AndroidApp(IntPtr javaReference, JniHandleOwnership transfer)
    : base(javaReference, transfer)
  {
  }

  protected override AppBuilder CreateAppBuilder()
  {
    return base.CreateAppBuilder()
      .WithInterFont()
      .SetUrlOpener(OpenUrl);
  }
  
  private void OpenUrl(string url)
  {
    var uri = Uri.Parse(url);
    var intent = new Intent(Intent.ActionView, uri);
    StartActivity(intent);
  }
}
