using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Prism;
using Prism.Ioc;
using PrismFilms.DependencyServices;

namespace PrismFilms.Droid
{
    [Activity(Label = "PrismFilms", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            InitializeThirdParty();

            LoadApplication(new App(new AndroidInitializer()));
        }

        private void InitializeThirdParty()
        {
            CachedImageRenderer.Init(true);
            CachedImageRenderer.InitImageViewHandler();
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextToSpeech, TextToSpeechAndroid>();
        }
    }
}

