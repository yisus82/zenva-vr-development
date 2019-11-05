using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform target;
    public float speed = 1;
    private bool isMoving = false;

    private void Update()
    {
        HandleInput();
        HandleMovement();

    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isMoving = !isMoving;
        }
    }

    private void HandleMovement()
    {
        if (!isMoving)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
