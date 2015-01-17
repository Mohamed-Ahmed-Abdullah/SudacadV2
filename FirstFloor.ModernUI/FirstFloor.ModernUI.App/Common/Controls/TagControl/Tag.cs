using System.ComponentModel;

namespace FirstFloor.ModernUI.App.Common.Controls.TagControl
{
    public class Tag : INotifyPropertyChanged
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public object Entity { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
