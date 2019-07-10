using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestXam.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (value != isBusy)
                    isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        private bool canShow;
        public bool CanShow
        {
            get => canShow;
            set
            {
                if (value != canShow)
                {
                    canShow = value;
                    OnPropertyChanged(nameof(CanShow));
                }
            }
        }
        protected void StartProcess()
        {
            IsBusy = true;
            CanShow = false;
        }
        protected void EndProcess()
        {
            IsBusy = false;
            CanShow = true;
        }
    }
}
