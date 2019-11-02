using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalking", true);
        }

        else
        {
            animator.SetBool("IsWalking", false);
        }
	}
}
