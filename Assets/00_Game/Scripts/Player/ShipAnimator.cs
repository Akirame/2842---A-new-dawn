using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimator : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");        
        animator.SetFloat("dir",horizontal);
    }
}
