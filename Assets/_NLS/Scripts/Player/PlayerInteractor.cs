using _NLS.Scripts.Crosshair;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _NLS.Scripts.Player
{
    public class PlayerInteractor : MonoBehaviour
    {
        [SerializeField] CrosshairImageController  crosshairImageController;
        private Color _crosshairBaseColor;
        private bool _isInteractReady;
        private Vector3 _hitPoint;
        private bool _hitDetected = false;
        private float _rayDistance = 100f;
        private float _radius = 0.5f;
        private Camera _camera;
        private Ray _ray;
        private RaycastHit _hit;
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

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        
                    }
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
    }
}