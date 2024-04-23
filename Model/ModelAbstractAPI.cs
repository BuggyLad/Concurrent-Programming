using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public abstract class ModelAbstractAPI
    {
        public abstract void CreateBall();
        public abstract ObservableCollection<object> GetBalls();
        public abstract int BallAmount { get; set; }

        public static ModelAbstractAPI CreateAPI()
        {
            return new ModelAPI();
        }
    }
}

