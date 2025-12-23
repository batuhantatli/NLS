using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _NLS.Scripts.QuestSystem
{
    public class CounterItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject childToActivate;
        [SerializeField] private float scaleDuration;
        private CircleCounter _counter;
        private int _counterIndex;


        private void Awake()
        {
            childToActivate.transform.localScale = Vector3.zero;
        }

        public void Initialize(CircleCounter counter ,int counterIndex)
        {
            _counter = counter;
            _counterIndex = counterIndex;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(_counter.SetCount(_counterIndex));
        }

        public void Activate(bool activate)
        {
            var targetScale = activate ? Vector3.one : Vector3.zero;

            childToActivate.transform.DOScale(targetScale, scaleDuration);

        }
    }
}