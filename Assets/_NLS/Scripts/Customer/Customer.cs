using UnityEngine;

namespace _NLS.Scripts.Customer
{
    public class Customer : MonoBehaviour
    {
        #region SerializeFields-Private Variables
        [SerializeField] private CustomerSO customerData;
        #endregion

        public void Initialize(CustomerSO data)
        {
            customerData = data;
        }
    }
}
