using ExemploVortice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExemploVortice.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{
		public AddItemPage ()
		{
			InitializeComponent();
            BindingContext = new AddItemPageViewModel(Navigation);
		}
	}
}