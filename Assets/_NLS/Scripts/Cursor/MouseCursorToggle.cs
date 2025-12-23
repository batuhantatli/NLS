using UnityEngine;

namespace _NLS.Scripts.Cursor
{
    public class MouseCursorToggle : MonoBehaviour
    {
        [SerializeField] private KeyCode toggleKey = KeyCode.Escape;

        private bool isCursorVisible;

        private void Start()
        {
            SetCursor(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(toggleKey))
            {
                SetCursor(!isCursorVisible);
            }
        }

        private void SetCursor(bool visible)
        {
            isCursorVisible = visible;

            UnityEngine.Cursor.visible = visible;
            UnityEngine.Cursor.lockState = visible 
                ? CursorLockMode.None 
                : CursorLockMode.Locked;
        }
    }
}