using System.Collections.Generic;
using _NLS.Scripts.CustomerServices;
using UnityEngine;

namespace _NLS.Scripts.QuestSystem
{
    public class QuestCreator : MonoBehaviour
    {
        [SerializeField] private QuestManager questManager;
        [SerializeField] private QuestUIController  questUIController;
        [SerializeField] private List<BaseQuest> quests = new List<BaseQuest>(); 
        
        private BaseQuest _currentBaseQuest;

        public void SetQuest()
        {
            BaseQuest unlockedQuest = questManager.GetUnlockedQuests().GetRandom();
            _currentBaseQuest = unlockedQuest;
            int difficultyValue = 0;
            int calculatedXp = SetXp(ref difficultyValue) * questManager.XpMultiplier();
            int calculatedCoin = SetCoin(ref difficultyValue)*questManager.CoinMultiplier();
            difficultyValue *= questManager.DifficultyMultiplier();
            _currentBaseQuest.Initialize(calculatedXp,calculatedCoin,difficultyValue);
        }

        private int SetXp(ref int difficulty)
        {
            int xp = this.Random0To100();
            difficulty += xp;
            return xp;
        }

        private int SetCoin(ref int difficulty)
        {
            int coin = this.Random0To100();
            difficulty += coin;
            return coin;
        }


        public void DeliverQuest(Customer customer)
        {
            // deliver the quest
        }
        
    }
}
