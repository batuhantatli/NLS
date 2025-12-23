using _NLS.Scripts.Player;
using Cinemachine;
using KinematicCharacterController.Examples;
using UnityEngine;

namespace _NLS.Scripts.QuestSystem
{
    public class QuestTypeSelectController : MonoBehaviour, IInteractableArea
    {
        #region SerializeFields-Private Variables

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private bool _isInteractable;

        #endregion


        #region Unity Methods

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ExamplePlayer player))
            {
                _isInteractable = true;
            }
        }


        public void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out ExamplePlayer player))
            {
                _isInteractable = false;
            }
        }

        #endregion


        public bool IsReadyForInteract()
        {
            return _isInteractable;
        }

        public void Interact(PlayerInteractor playerInteractor)
        {
            virtualCamera.Priority = 11;
        }

        public void ExitInteractArea()
        {
            virtualCamera.Priority = 10;
        }

    }
}