using UnityEngine;
using Cinemachine;

public class SimpleMovement : MonoBehaviour
{
    public bool playing;
    public Animator animator;
    public float movementSpeed = .8f;
    public float rotationSpeed = 8;
    public CinemachineFreeLook cinemachineFreeLook;

    private float movX, movY;
    Transform lastCheckPoint;

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        
            movX = Input.GetAxisRaw("Horizontal");
            movY = Input.GetAxisRaw("Vertical");

            

            if(movX != 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 45 * movX, -65 * movX), Time.deltaTime * rotationSpeed);
            }

            if(movY != 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-25 * movY, transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z), Time.deltaTime * rotationSpeed);
            }

            if(movX == 0 && movY == 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * rotationSpeed);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "checkpoint")
        {
            lastCheckPoint = other.transform;
        }
        else if(other.tag == "endgame")
        {
            playing = false;
            cinemachineFreeLook.Follow = other.transform;
            cinemachineFreeLook.LookAt = other.transform;
            Destroy(this);
        }
        else
        {
            MoveToCheckPoint();
        }
    }

    void MoveToCheckPoint()
    {
        if(lastCheckPoint != null)
        {
            transform.position = lastCheckPoint.position;
        }
    }

}
