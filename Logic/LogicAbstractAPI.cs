using System.ComponentModel;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI GetAPI()
        {
            return new LogicAPI();
        }

        public abstract void CreateBall(float radius);

        public abstract List<BallLogicAbstractAPI> GetBalls();

        public abstract void RemoveBall();
    }
}
