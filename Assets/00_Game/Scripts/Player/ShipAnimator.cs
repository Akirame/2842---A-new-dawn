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
        if (GameManager.Get().Playing() && ShipController.Get().Alive())
        {
            float horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("dir", horizontal);
        }
    }
}
