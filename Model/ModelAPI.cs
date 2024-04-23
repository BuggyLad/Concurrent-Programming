using System.Collections.ObjectModel;

﻿namespace Presentation.Model
{
    internal class ModelAPI : ModelAbstractAPI
    {
        private readonly ObservableCollection<object> Balls = [];
        private readonly Logic.LogicAbstractAPI LogicAPI = Logic.LogicAbstractAPI.CreateAPI();

        public override float Radius { get; protected set; } = 5;

        public override void CreateBall()
        {
            LogicAPI.CreateBall(Radius, true);

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
