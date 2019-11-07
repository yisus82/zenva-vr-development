using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform[] targets;
    public float speed = 1;
    private bool isMoving = false;
    private int currentTarget = 0;

    private void Start()
    {
        transform.position = targets[currentTarget].position;
        UpdateTarget();
    }

    private void Update()
    {
        HandleInput();
        HandleMovement();

    }

    private void UpdateTarget()
    {
        currentTarget = ++currentTarget % targets.Length;
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ToggleMoving();
        }
    }

    private void HandleMovement()
    {
        if (!isMoving)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, targets[currentTarget].position);

        if (distance > 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targets[currentTarget].position, step);
        }
        else
        {
            ToggleMoving();
            UpdateTarget();
        }
    }

    private void ToggleMoving()
    {
        isMoving = !isMoving;
    }
}
