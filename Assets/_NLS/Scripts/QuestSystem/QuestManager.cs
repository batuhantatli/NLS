using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace _NLS.Scripts.QuestSystem
{
    public class QuestManager : MonoBehaviour
    {
        [Serializable]
        public class QuestUnlock
        {
            public MonoScript quest;
            public bool isUnlocked;
        }
    
        public List<QuestUnlock> questUnlocks = new List<QuestUnlock>();
        private List<BaseQuest> _unlockedQuests = new List<BaseQuest>();

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            UpdateUnlockedQuests();
        }

        private void UpdateUnlockedQuests()
        {
            foreach (var questUnlock in questUnlocks.Where(t=>t.isUnlocked).ToList())
            {
                _unlockedQuests.Add(questUnlock.quest.GetComponent<BaseQuest>());
            }
        }

        public List<BaseQuest> GetUnlockedQuests()
        {
            return _unlockedQuests;
        }

        public int CoinMultiplier()
        {
            return 1;
            
        }

        public int XpMultiplier()
        {
            return 1;
        }

        public int DifficultyMultiplier()
        {
            return 1;
        }
    }
}
