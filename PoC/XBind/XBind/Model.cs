using System;
using System.ComponentModel;
using System.Windows.Input;

namespace XBind.Model
{
    public class Model : INotifyPropertyChanged
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        private string _surName;
        public string SurName { get { return _surName; } set { _surName = value; OnPropertyChanged("SurName"); } }
        private int _age;
        public int Age { get { return _age; } set { _age = value; OnPropertyChanged("Age"); } }
        public ICommand AgeIncrease { get { return new RelayCommand(() => { Age++; }); } }
        public Model() { }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    public class XBModel
    {
        public static event EventHandler UpdateBindings;
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private string _surName;
        public string SurName { get { return _surName; } set { _surName = value; } }
        private int _age;
        public int Age { get { return _age; } set { _age = value; } }
        public ICommand AgeIncrease { get { return new RelayCommand(() => { Age++; OnPropertyChanged(); }); } }

        private void OnPropertyChanged()
        {
            if (UpdateBindings != null) UpdateBindings(null, EventArgs.Empty);
        }

        public XBModel() { }
    }
}
