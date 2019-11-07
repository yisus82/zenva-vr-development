using UnityEngine;

namespace ZenvaVR
{
    public class DragCamera : MonoBehaviour
    {
#if UNITY_EDITOR
        public float dragSpeed = 1.0f;
        private bool isDragging = false;
        private float startMouseX;
        private float startMouseY;
        private Camera cam;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1) && !isDragging)
            {
                isDragging = true;
                startMouseX = Input.mousePosition.x;
                startMouseY = Input.mousePosition.y;
            }
            else if (Input.GetMouseButtonUp(1) && isDragging)
            {
                isDragging = false;
            }
        }

        private void LateUpdate()
        {
            if (isDragging)
            {
                float endMouseX = Input.mousePosition.x;
                float endMouseY = Input.mousePosition.y;
                float diffX = endMouseX - startMouseX;
                float diffY = endMouseY - startMouseY;
                float newCenterX = Screen.width / 2 + diffX * dragSpeed;
                float newCenterY = Screen.height / 2 + diffY * dragSpeed;
                Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, cam.nearClipPlane));
                transform.LookAt(worldPoint);
                startMouseX = endMouseX;
                startMouseY = endMouseY;
            }
        }
#endif
    }
}

