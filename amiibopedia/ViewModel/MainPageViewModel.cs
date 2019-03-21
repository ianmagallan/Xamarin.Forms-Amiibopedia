using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using amiibopedia.Helpers;
using amiibopedia.Model;
using Xamarin.Forms;

namespace amiibopedia.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Amiibo> _amiibos;

        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos
        {
            get => _amiibos;
            set
            {
                _amiibos = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {

            SearchCommand = new Command(async (param) =>
            {
                IsBusy = true;
                var character = param as Character;
                if(character != null)
                {
                    string url = $"https://www.amiiboapi.com/api/amiibo/?character={character.name}";
                    var service =
                        new HttpHelper<Amiibos>();
                    var amiibos = await service.GetServiceDataAsync(url);
                    Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                }
                IsBusy = false;
            });
        }

        public async Task LoadCharacters()
        {
            IsBusy = true;
            var url = "https://www.amiiboapi.com/api/character";
            var service = new HttpHelper<Characters>();

            var characters = await service.GetServiceDataAsync(url);
            Characters = new ObservableCollection<Character>(characters.amiibo);
            IsBusy = false;
        }
    }
}
