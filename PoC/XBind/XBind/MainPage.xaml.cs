using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XBind
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public string StringProp
        {
            get { return "Current Time:"; }
        }
        private string _timeProp = DateTime.Now.ToString();
        public string TimeProp
        {
            get { return _timeProp; }
            set { _timeProp = value; OnPropertyChanged("TimeProp"); }
        }
        private string _xbtimeProp = DateTime.Now.ToString();
        public string XBTimeProp
        {
            get { return _xbtimeProp; }
            set { _xbtimeProp = value; Bindings.Update(); }
        }
        private ObservableCollection<Model.Model> _modelItems;
        public ObservableCollection<Model.Model> ModelItems
        {
            get
            {
                if (_modelItems == null) _modelItems = new ObservableCollection<Model.Model>();
                return _modelItems;
            }
        }
        private ObservableCollection<Model.XBModel> _xbModelItems;
        public ObservableCollection<Model.XBModel> XBModelItems
        {
            get
            {
                if (_xbModelItems == null) _xbModelItems = new ObservableCollection<Model.XBModel>();
                return _xbModelItems;
            }
        }


        private DispatcherTimer dt = new DispatcherTimer();

        public MainPage()
        {
            this.InitializeComponent();
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += ((sender, e) => { TimeProp = XBTimeProp = DateTime.Now.ToString(); });
            dt.Start();
            ModelItems.Add(new Model.Model() { Name = "Martin", SurName = "Vega" });
            XBModelItems.Add(new Model.XBModel() { Name = "Samuel", SurName = "Vega" });
            Bindings.Update();
            Model.XBModel.UpdateBindings += UpdateBindings;
        }

        private void UpdateBindings(object sender, EventArgs e)
        {
            Bindings.Update();
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
