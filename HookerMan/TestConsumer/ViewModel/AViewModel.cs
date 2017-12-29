using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LZSoft.TestConsumer.ViewModel
{
    public abstract class AViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
