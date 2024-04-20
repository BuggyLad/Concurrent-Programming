namespace Logic
{
    public abstract class BoardLogicAPI
    {
        public static BoardLogicAPI GetBoardLogic()
        {
            return new BoardLogic();
        }

        public abstract void CreateBall(float radius);

        public abstract void RemoveBall();
    }
}
