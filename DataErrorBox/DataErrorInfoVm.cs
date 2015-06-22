using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataErrorBox.Annotations;

namespace DataErrorBox
{
    public class DataErrorInfoVm : INotifyPropertyChanged, IDataErrorInfo
    {
        public readonly Errors _errors = new Errors();
        private string _stringValue;
        private int _intValue;
        public event PropertyChangedEventHandler PropertyChanged;

        public string StringValue
        {
            get { return _stringValue; }
            set
            {
                if (value == _stringValue) return;
                _stringValue = value;
                OnPropertyChanged();
            }
        }

        public int IntValue
        {
            get { return _intValue; }
            set
            {
                if (value == _intValue) return;
                if (value > 2)
                {
                    _errors.Update(">2");
                }
                else
                {
                    _intValue = value;
                    _errors.Clear();
                }
                OnPropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get
            {
                return _errors.Get(columnName);
            }
        }

        public string Error
        {
            get
            {
                return "";
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
