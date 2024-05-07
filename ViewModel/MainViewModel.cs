using Presentation.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly ModelAbstractAPI modelAPI = ModelAbstractAPI.CreateAPI();
        private ObservableCollection<object>? balls;

        public MainViewModel()
        {
            CreateBallCommand = new RelayCommand(AddBall);
            RemoveBallCommand = new RelayCommand(SubstractBall);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float Diameter
        {
            get
            {
                return modelAPI.Radius * 2;
            }
        }

        public ObservableCollection<object>? Balls
        {
            get => balls;
            set
            {
                if (balls == value)
                {
                    return;
                }

                balls = value;
                OnPropertyChanged();
            }
        }

        public ICommand? CreateBallCommand { get; }

        public ICommand? RemoveBallCommand { get; }

        private void AddBall()
        {
            modelAPI.CreateBall();
            Balls = modelAPI.GetBalls();
        }

        private void SubstractBall()
        {
            modelAPI.RemoveBall();
            Balls = modelAPI.GetBalls();
        }
    }
}
