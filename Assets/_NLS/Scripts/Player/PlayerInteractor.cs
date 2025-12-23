using System;
using _NLS.Scripts.Crosshair;
using DG.Tweening;
using KinematicCharacterController.Examples;
using UnityEngine;
using UnityEngine.UI;

namespace _NLS.Scripts.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        #region SerializeField-Private Variables
        [SerializeField] private CrosshairImageController  crosshairImageController;
        [SerializeField] private ExamplePlayer player;
        private Color _crosshairBaseColor;
        private bool _isInteractReady;
        private Vector3 _hitPoint;
        private bool _hitDetected = false;
        private float _rayDistance = 100f;
        private float _radius = 0.5f;
        private Camera _camera;
        private Ray _ray;
        private RaycastHit _hit;
        #endregion
        
        
        #region Unity Methods
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _ray = new Ray(_camera.transform.position, _camera.transform.forward);

            if (Physics.Raycast(_ray, out _hit, _rayDistance))
            {
                _hitPoint = _hit.point;
            
                if (_hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    if (!interactable.SetDistance(transform.position))
                    {
                        WaitForInteract();
                        return;
                    }
                    
                    ReadyForInteract();
                }
                else
                {
                    WaitForInteract();
                }
            }
            else
            {
                WaitForInteract();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IInteractableArea interactableArea))
            {
                if (interactableArea.IsReadyForInteract())
                {
                    Debug.Log("d");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("f");
                        interactableArea.Interact(this);
                        MovementControl(false);

                    }

                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        interactableArea.ExitInteractArea();
                        MovementControl(true);
                    }
                }
            }
        }
        

        #endregion

        #region Public Methods

        public void MovementControl(bool isActive)
        {
            player.Character.enabled = isActive;
        }
        
        #endregion

        #region Private Methods

        private void ReadyForInteract()
        {
            if (_isInteractReady) return;
            _isInteractReady = true;
            crosshairImageController.ReadyForInteractAnimation();
        }

        private void WaitForInteract()
        {
            if (!_isInteractReady) return;
            _isInteractReady = false;
            crosshairImageController.ResetInteractAnimation();
        }
        

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
            if (_camera != null)
            {
                Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

                // Yeşil Ray çiz
                Gizmos.color = Color.green;
                Gizmos.DrawRay(ray.origin, ray.direction * _rayDistance);

                // Çarpışma olduysa kırmızı küre çiz
                if (_hitDetected)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(_hitPoint, _radius);
                }
            }
        }

        #endregion

    }
}