using System;
using System.Windows.Input;
using LZSoft.HookerMan;
using Prism.Commands;

namespace LZSoft.TestConsumer.ViewModel
{
    public class MainViewModel : AViewModel
    {
        Hooker hooker = new Hooker();
        string _outputData;
        public string OutputData
        {
            get => _outputData;
            set
            {
                _outputData = value;
                OnPropertyChanged();
            }
        }

        public bool IsKeyboardHooked => hooker.Enabled;
        public bool CaptureKey { get; set; }
        public ICommand OnLoadCommand { get; set; }
        public ICommand EnableKeyboardHookCommand { get; set; }
        public ICommand DisableKeyboardHookCommand { get; set; }

        public MainViewModel()
        {
            hooker.AddEvent(WriteKey);
            OnLoadCommand = new DelegateCommand(OnLoad);
            EnableKeyboardHookCommand = new DelegateCommand(EnableKeyboardHook);
            DisableKeyboardHookCommand = new DelegateCommand(DisableKeyboardHook);
        }

        public void EnableKeyboardHook()
        {
            hooker.Enable();
        }

        public void DisableKeyboardHook()
        {
            hooker.Disable();
        }


        public void OnLoad() => WriteLine("Started");
        public void Write(object text) => OutputData += text;
        void WriteKey(KeyboardData x) => WriteLine(x.ToString());
        public void WriteLine(object text) => Write(text + Environment.NewLine);
    }
}
