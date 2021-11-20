namespace Interfaces
{
    public interface IWinnable
    {
        public void GameWin();
        public void SetWin(bool isGameOver, bool isGameWin);
        public void SetWin(bool isGameWin);
    }
}