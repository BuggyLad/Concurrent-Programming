using System.Collections.ObjectModel;

namespace Presentation.Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract float Radius { get; protected set; }
        public abstract void CreateBall();
        public abstract void RemoveBall();
        public abstract ObservableCollection<object> GetBalls();
        public static ModelAbstractAPI CreateAPI()
        {
            return new ModelAPI();
        }
    }
}

