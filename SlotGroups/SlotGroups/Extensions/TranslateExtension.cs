using SlotGroups.Interfaces;
using SlotGroups.Resources.Languages;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SlotGroups.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo cultureInformation = null;
        const string ResourceId = "UpMovies.Resources.Languages.AppResources";

        private static readonly Lazy<ResourceManager> LocaleResourceManager = new(() => new ResourceManager(ResourceId, typeof(AppResources).GetTypeInfo().Assembly));

        public TranslateExtension()
        {
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                cultureInformation = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                AppResources.Culture = cultureInformation;
                DependencyService.Get<ILocalize>().SetLocale(cultureInformation);
            }
        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var translation = LocaleResourceManager.Value.GetString(Text, cultureInformation);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, cultureInformation.Name),
                    "Text");
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}
