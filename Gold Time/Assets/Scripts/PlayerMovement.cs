using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runningMultiplier;

    private float threshold = 0.2f;
    private bool alive = true;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetAxis("Run") > threshold)
        {
            movementSpeed *= runningMultiplier;
            running = true;
        }
        else
        {
            running = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x)) - 90f);
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            {
                transform.position += (Vector3.right * Input.GetAxis("Horizontal") * movementSpeed + Vector3.up * Input.GetAxis("Vertical") * movementSpeed);
            }
            if (Input.GetAxis("Run") > threshold && !running)
            {
                movementSpeed *= runningMultiplier;
                running = true;
            }
            else if (Input.GetAxis("Run") < threshold && running)
            {
                movementSpeed /= runningMultiplier;
                running = false;
            }
        }
    }
}
