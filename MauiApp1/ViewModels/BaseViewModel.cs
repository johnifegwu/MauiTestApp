using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsInitialized { get; set; }

        bool canLoadMore;

        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value, nameof(CanLoadMore)); }
        }

        #region  New Loading Method


        #endregion

        public bool AmBusy { get; set; }

        BusyHandler isBusy;

        //set to false or true to show with  or withuot click-through
        // set to restresponsestatus to show error message
        // set to string to show status message
        // set to null to hide
        // handled via property change handler in popuppage
        public BusyHandler IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(nameof(IsBusy)); }
        }

        bool isValid;
        public const string IsValidPropertyName = "IsValid";

        public bool IsValid
        {
            get { return isValid; }
            set { SetProperty(ref isValid, value, nameof(IsValid)); }
        }
        bool loadedSavedData;
        public bool LoadedSavedData
        {
            get => loadedSavedData;
            set
            {
                loadedSavedData = value;
                OnPropertyChanged(nameof(LoadedSavedData));
            }
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;
            OnPropertyChanged(propertyName);
        }


        protected void SetProperty<U>(
            ref U backingStore, U value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null,
            Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            OnPropertyChanged(propertyName);
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

