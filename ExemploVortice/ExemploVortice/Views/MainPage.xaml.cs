using ExemploVortice.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExemploVortice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
		}
      
    }
}