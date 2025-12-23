using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _NLS.Scripts.CustomerServices
{
    public class CustomerSpawnManager : MonoBehaviour
    {
        #region Public Variables
        public Action OnCustomerSpawned;
        #endregion
        
        #region SerializeFields-Private Variables
        [Header("Customer Spawn Settings")]
        [SerializeField] private CustomerServices.Customer customerPrefab;
        [SerializeField] private Transform customerSpawnPoint;
        [SerializeField] private Transform customerTargetPoint;

        [Header("Customer Type Settings")] [SerializeField]
        private List<CustomerSO> customerTypes = new List<CustomerSO>();
        #endregion

        #region Unity Methods

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SpawnCustomer();
            }
        }

        #endregion

        #region Private Methods

        private void SpawnCustomer()
        {
            CustomerServices.Customer customer = Instantiate(customerPrefab);
            
            customer.Initialize(GetCustomerType(),customerSpawnPoint , customerTargetPoint);
        }

        private CustomerSO GetCustomerType()
        {
            return customerTypes[Random.Range(0, customerTypes.Count)];
        }
        #endregion
      
    }
}
