using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelAPI : ModelAbstractAPI
    {
        private readonly ObservableCollection<object> Balls = [];
        private readonly LogicAbstractAPI LogicAPI = LogicAbstractAPI.CreateAPI();

        public override float Radius { get; protected set; } = 5;

        public override void CreateBall()
        {
            LogicAPI.CreateBall(Radius, true);
            GetBalls();
        }

        public override void RemoveBall()
        {
            LogicAPI.RemoveBall();
            GetBalls();
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
