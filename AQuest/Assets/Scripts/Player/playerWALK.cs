using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWALK {

    private GameObject player;
	private playerController controller;

	// Use this for initialization
	public playerWALK(GameObject GM, playerController PC){
        player = GM;
        controller = PC;
    }
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void FixedUpdate () {
		controller.Flip();
		controller.RigidBody().velocity = new Vector2(controller.Direction().x * controller.xSpeed, controller.RigidBody().velocity.y);
        controller.Animator().SetFloat("xSpeed", Mathf.Abs(controller.Direction().x));
	}

	public void LateUpdate () {
		if(Mathf.Abs(controller.Direction().x) == 0){
			controller.SetState(playerController.State.IDLE);
		}
	}
}
