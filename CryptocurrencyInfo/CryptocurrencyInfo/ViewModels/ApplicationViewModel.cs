using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CryptocurrencyInfo.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        private ObservableCollection<string> _themes;
        public ObservableCollection<string> Themes
        {
            get => _themes;
            set => Set(ref _themes, value);
        }

        private string _slectedTheme;
        public string SlectedTheme
        {
            get => _slectedTheme;
            set
            {
                Set(ref _slectedTheme, value);
                SelectedThemesEvent?.Invoke(_slectedTheme);
            }
        }

        public delegate void SelectedThemesDelegate(string theme);
        public event SelectedThemesDelegate SelectedThemesEvent;

        public ApplicationViewModel()
        {
            Themes = new ObservableCollection<string> { "Light", "Dark" };
            SlectedTheme = Themes.First();
            SelectedThemesEvent += OnSelectedTheme;
            OnSelectedTheme(SlectedTheme);
        }

        public void OnSelectedTheme(string theme)
        {
            var uri = new Uri(String.Format($"Resources/Themes/{theme}.xaml"), UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
