using UnityEngine;

public class WalkingCharacters : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        float yRot = transform.rotation.eulerAngles.y;

        if(yRot == 180)
        {
            yRot = 0;
        } else if(yRot == 0)
        {
            yRot = 180;
        } else {
            yRot = -yRot;
        }
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
