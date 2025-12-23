using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _NLS.Scripts.QuestSystem
{
    public class CircleCounter : MonoBehaviour
    {
        [SerializeField] private List<CounterItem> items = new();

        private int _currentCount = 0;
        private void Awake()
        {
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                item.Initialize(this,i);
            }
        }

        public IEnumerator SetCount(int i )
        {
            var index = i + 1;
            for (var j = 0; j < index; j++)
            {
                items[j].Activate(true);
                yield return new WaitForSeconds(.03f);
            }
            for (int k = index; k < items.Count; k++)
            {
                items[k].Activate(false);
            }

            _currentCount = index;
        }
    }
}
