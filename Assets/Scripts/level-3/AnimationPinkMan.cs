using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPinkMan : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Transform _groundChecker;

    [SerializeField] private LayerMask _whatIsGround;

    private float _groundCheckerRadius = 0.1f;

    bool canJump;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.Space) && canJump)
        {
            animator.SetBool("isJump", true);
            canJump = false;
        }
      
        else if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("isSit", true);
        }
        else
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isSit", false);
        }
    }
}
