using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExemploVortice.ViewModels
{
    public class AddItemPageViewModel : BaseViewModel
    {        
        private INavigation _navigation;
        public AddItemPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public ICommand BackCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _navigation.PopModalAsync();
                });
            }
        }
    }
}
