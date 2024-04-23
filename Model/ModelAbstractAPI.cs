using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract void CreateBall();
        public abstract ObservableCollection<BallLogicAbstractAPI> GetBalls();
        public abstract float Radius { get;}
        public abstract float Diameter { get; }
        public static ModelAbstractAPI CreateAPI()
        {
            return new ModelAPI();
        }
    }
}

