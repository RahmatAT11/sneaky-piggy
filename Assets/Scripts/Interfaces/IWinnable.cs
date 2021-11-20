namespace Interfaces
{
    public interface IWinnable
    {
        public void GameWin();
        public void SetIsPlayerEscape(bool isPlayerEscape);
        public void SetIsMainTreasureGet(bool isMainTreasureGet);
        public void SetIsTimeRunningOut(bool isTimeRunningOut);
        public void SetIsCatchByNpc(bool isCatchByNpc);
    }
}