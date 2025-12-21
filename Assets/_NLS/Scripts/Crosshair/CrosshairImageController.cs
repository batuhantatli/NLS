using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _NLS.Scripts.Crosshair
{
    public class CrosshairImageController : MonoBehaviour
    {
        [SerializeField] private Image crosshairImage;
        [SerializeField] private float interactSize;
        [SerializeField] private float interactAnimationSpeed;
        [SerializeField] private Color interactColor;

        private Color _baseColor;

        private void Awake()
        {
            _baseColor = crosshairImage.color;
        }

        public void ReadyForInteractAnimation()
        {
            crosshairImage.transform.DOScale(Vector3.one * interactSize, interactAnimationSpeed);
            crosshairImage.DOColor(interactColor, interactAnimationSpeed);
        }

        public void ResetInteractAnimation()
        {
            crosshairImage.transform.DOScale(Vector3.one, interactAnimationSpeed);
            crosshairImage.DOColor(_baseColor, interactAnimationSpeed);
        }
    }
}
