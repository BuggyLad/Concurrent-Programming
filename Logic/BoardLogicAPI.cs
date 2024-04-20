namespace Logic
{
    public abstract class BoardLogicAPI
    {
        public static BoardLogicAPI GetBoardLogic(float x, float y)
        {
            return new BoardLogic(x, y);
        }
        public abstract void CreateBall(float radius);

        public abstract void RemoveBall();
    }
}
