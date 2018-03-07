using System;
using System.Collections.ObjectModel;
using StaggeredPanel.Helpers;

namespace StaggeredPanel.ViewModels
{
    public class MyPhotosViewModel : Observable
    {
        public ObservableCollection<string> Images { get; } = new ObservableCollection<string>();

        public MyPhotosViewModel()
        {
        }

        public void Initialize()
        {
            Images.Clear();
            var rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                Images.Add($"https://picsum.photos/{rnd.Next(200, 500)}/{rnd.Next(200, 500)}");
            }
        }
    }
}
