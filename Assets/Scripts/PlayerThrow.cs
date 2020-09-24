using UnityEngine;
using Cinemachine;

public class PlayerThrow : MonoBehaviour
{
    public SimpleMovement playerMovement;
    public CinemachineFreeLook cinemachineFreeLook;
    // Start is called before the first frame update
    void Throw()
    {
        playerMovement.transform.SetParent(null);
        playerMovement.transform.position = new Vector3(-0.125f,0.995f,-3.442f);
        playerMovement.transform.rotation = Quaternion.Euler(0,0,0);
        playerMovement.playing = true;
        playerMovement.enabled = true;
        playerMovement.GetComponent<Rigidbody>().isKinematic = false;
        cinemachineFreeLook.Follow = playerMovement.transform;
        cinemachineFreeLook.LookAt = playerMovement.transform;
    }
}
