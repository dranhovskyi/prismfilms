using System;
using FFImageLoading.Forms.Platform;
using Foundation;
using Prism;
using Prism.Ioc;
using PrismFilms.DependencyServices;
using UIKit;


namespace PrismFilms.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            InitializeThirdParty();
            LoadApplication(new App(new iOSInitializer()));

#if DEBUG
            Xamarin.Calabash.Start();
#endif

            return base.FinishedLaunching(app, options);
        }

        private void InitializeThirdParty()
        {
            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextToSpeech, TextToSpeechiOS>();
        }
    }
}
