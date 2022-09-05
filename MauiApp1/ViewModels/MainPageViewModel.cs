using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command CountCommand { get; set; }

        public string ButtonText
        {
            get
            {
                if (count == 0)
                {
                    return "Click me";
                }
                else if (count == 1)
                {
                    return $"Clicked {count} time";
                }
                else
                {
                    return $"Clicked {count} times";
                }
            }
        }


        private int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                SetProperty(ref count, value);
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        public MainPageViewModel()
        {
            CountCommand = new Command(async () => await DoCount());
        }

        private async Task DoCount()
        {
            Count++;
            OnPropertyChanged(nameof(Count));
        }
    }
}
