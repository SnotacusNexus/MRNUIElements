using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.ViewModels
{
    public class TextConverter
    {
        private readonly Func<string, string> _convertion;

        public TextConverter(Func<string, string> convertion)
        {
            _convertion = convertion;
        }

        public string ConvertText(string inputText)
        {
            return _convertion(inputText);
        }
        public class ObservableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected void RaisePropertyChangedEvent(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class DelegateCommand : ICommand
        {
            private readonly Action _action;

            public DelegateCommand(Action action)
            {
                _action = action;
            }

            public void Execute(object parameter)
            {
                _action();
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

#pragma warning disable 67
            public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        }
        public class Presenter : ObservableObject
        {
            private readonly TextConverter _textConverter
                = new TextConverter(s => s.ToUpper());
            private string _someText;
            private readonly ObservableCollection<string> _history
                = new ObservableCollection<string>();

            public string SomeText
            {
                get { return _someText; }
                set
                {
                    _someText = value;
                    RaisePropertyChangedEvent("SomeText");
                }
            }

            public IEnumerable<string> History
            {
                get { return _history; }
            }

            public ICommand ConvertTextCommand
            {
                get { return new DelegateCommand(ConvertText); }
            }

            private void ConvertText()
            {
                AddToHistory(_textConverter.ConvertText(SomeText));
                SomeText = String.Empty;
            }

            private void AddToHistory(string item)
            {
                if (!_history.Contains(item))
                    _history.Add(item);
            }
        }
    }
    class TextConverterCommand
    {

    }
}
