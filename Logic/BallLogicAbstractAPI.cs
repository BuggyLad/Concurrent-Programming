using Data;
using System.ComponentModel;

namespace Logic
{
    public abstract class BallLogicAbstractAPI : INotifyPropertyChanged, IDisposable
    {
        public abstract float Left { get; set; }
        public abstract float Top { get; set; }
        public abstract float Radius { get; }
        public abstract float Diameter { get; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public static BallLogicAbstractAPI CreateAPI(BallDataAbstractAPI ball)
        {
            return new BallLogicAPI(ball);
        }

        public abstract void Dispose();
    }
}
