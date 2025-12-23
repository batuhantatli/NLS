using System;
using DG.Tweening;
using UnityEngine;

namespace _NLS.Scripts.CustomerServices
{
    public class Customer : MonoBehaviour
    {
        #region SerializeFields-Private Variables

        [SerializeField] private CustomerSO customerData;

        #endregion

        #region Public Methods

        public void Initialize(CustomerSO data, Transform spawnPoint, Transform targetPoint)
        {
            customerData = data;
            transform.position = spawnPoint.position;

            MoveTarget(targetPoint, null);
        }

        #endregion

        #region Private Methods

        private void MoveTarget(Transform target, Action onMovementCompleted)
        {
            transform.DOMove(target.position, 1f).OnComplete((() => { onMovementCompleted?.Invoke(); }));
        }

        #endregion
    }
}