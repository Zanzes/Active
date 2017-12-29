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

        public ICommand OnLoadCommand { get; set; }
        public ICommand TestCommand { get; set; }

        public MainViewModel()
        {
            OnLoadCommand = new DelegateCommand(OnLoad);
            TestCommand = new DelegateCommand(Run);
        }

        public void Run()
        {
            hooker.AddEvent(WriteKey);
            //Program.Main(Environment.GetCommandLineArgs());
        }


        public void OnLoad() => WriteLine("Started");
        public void Write(object text) => OutputData += text;
        void WriteKey(KeyboardData x) => WriteLine(x.ToString());
        public void WriteLine(object text) => Write(text + Environment.NewLine);
    }
}
