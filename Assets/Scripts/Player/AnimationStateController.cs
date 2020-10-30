using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { // or?  Mathf.Abs(Input.GetAxis("Vertical")) > 0
            animator.SetBool("isWalking", true);
        }
        if (!Input.GetKey(KeyCode.W)) {
            animator.SetBool("isWalking", false);
        }
    }
}
 