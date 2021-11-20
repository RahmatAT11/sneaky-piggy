using System;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class VictoryManager : MonoBehaviour, IWinnable
    {
        private void Update()
        {
            
        }

        public bool GameWin()
        {
            return true;
        }

        public bool GameOver()
        {
            return true;
        }
    }
}
