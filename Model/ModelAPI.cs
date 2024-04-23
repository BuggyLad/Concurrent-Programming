﻿using Logic;
using System.Collections.ObjectModel;

namespace Presentation.Model
{
    internal class ModelAPI : ModelAbstractAPI
    {
        private ObservableCollection<object> Balls = new ObservableCollection<object>();
        private Logic.LogicAbstractAPI LogicAPI = Logic.LogicAbstractAPI.CreateAPI();
        private float Radius = 5;
        private float Diameter = 10;


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
