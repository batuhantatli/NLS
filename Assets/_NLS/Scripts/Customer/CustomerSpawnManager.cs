using System;
using UnityEngine;

namespace _NLS.Scripts.Customer
{
    public class CustomerSpawnManager : MonoBehaviour
    {
        #region Public Variables
        public Action OnCustomerSpawned;
        #endregion
        
        #region SerializeFields-Private Variables
        [SerializeField] private Customer customerPrefab;
        #endregion

        #region Private Methods
        private void SpawnCustomer()
        {
            Instantiate(customerPrefab);
        }
        #endregion
      
    }
}
