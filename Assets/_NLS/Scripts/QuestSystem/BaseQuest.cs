using System.Collections.Generic;
using UnityEngine;

namespace _NLS.Scripts.QuestSystem
{
    public class BaseQuest : MonoBehaviour
    {
        private int _xpReward;
        private int _coinReward;
        private List<GameObject> _itemRewards;
        private int _difficultyIndex;

        public void Initialize(int xpReward, int coinReward , int difficultyIndex)
        {
            _xpReward = xpReward;
            _coinReward = coinReward;
            _difficultyIndex = difficultyIndex;
        }
        protected virtual void QuestModifier()
        {
            
        }

        private void SetReward()
        {
            
        }
    }
}
