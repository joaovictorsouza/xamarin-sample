using ExemploVortice.Model;
using ExemploVortice.Service;
using ExemploVortice.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExemploVortice.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<ListItemModel> ListItens { get; set; }

        private INavigation _navigation;
        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ListItens = new ObservableCollection<ListItemModel>();

            LoadDataAsync();
        }

        public ICommand ButtonCommand
        {
            get
            {
                return new Command(() =>
                {
                    _navigation.PushModalAsync(new AddItemPage());

                    //_navigation.PushAsync(new AddItemPage());
                    //ListItens.Add(new ListItemModel { Title = "Paulo da Silva", Description = "01/01/2018" });
                });
            }
        }

        public async Task LoadDataAsync()
        {
            try
            {
                var response = await APIHelper.GetTodosAsync();
                if (response.Error == null)
                {
                    foreach (var item in response.Response)
                    {
                        ListItens.Add(new ListItemModel
                        {
                            Title = item.Title,
                            Description = item.Completed ? "Concluído" : "Pendente"
                        });
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        #region Properties

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    NotifyPropertyChanged("Text");
                }
            }
        }

        #endregion
    }
}
