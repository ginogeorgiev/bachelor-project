using Features.ActionMaps.Input;
using UnityEngine;

namespace Features.Input.Logic
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private CursorData cursorData;
        
        [SerializeField] private bool lockCursor;

        private PlayerControls inputControls;

        private void Awake()
        {
            inputControls = new PlayerControls();
            ChangeCursor(cursorData.Normal);
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
        }

        private void Start()
        {
            cursorData.ChangeCursorEvent.RegisterListener(ChangeCursor);
            
            inputControls.Player.Click.started += _ => StartedClick();
            inputControls.Player.Click.performed += _ => EndedClick();
        }

        private void OnEnable()
        {
            inputControls.Enable();
        }

        private void OnDisable()
        {
            inputControls.Disable();
        }

        private static void ChangeCursor(Texture2D cursorType)
        {
            // Use if hotspot of cursor is in the middle of it and not in the top left corner
            // Vector2 hotspot = new Vector2(cursorType.width / 2f, cursorType.height / 2f);
            Vector2 hotspot = Vector2.zero;
            Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
        }

        private void StartedClick()
        {
            
        }

        private void EndedClick()
        {
            
        }
    }
}
