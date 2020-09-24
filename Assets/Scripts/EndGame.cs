using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Animator animator;
    
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        animator.SetBool("endgame",true);
    }
}
