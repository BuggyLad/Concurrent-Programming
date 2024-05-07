using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelAPI : ModelAbstractAPI
    {
        private readonly ObservableCollection<object> Balls = [];
        private readonly LogicAbstractAPI LogicAPI = LogicAbstractAPI.CreateAPI();

        public override void CreateBall()
        {
            LogicAPI.CreateBall(5, true);
        }

        public override void RemoveBall()
        {
            LogicAPI.RemoveBall();
        }

        public override ObservableCollection<object> GetBalls()
        {
            Balls.Clear();
            foreach (object ball in LogicAPI.GetBalls())
            {
                Balls.Add(ball);
            }
            return Balls;
        }
    }
}
