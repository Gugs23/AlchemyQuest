using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIDLE {

	private GameObject player;

	private playerController controller;

	public playerIDLE(GameObject GM, playerController PC){
		player = GM;
		controller = PC;
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void FixedUpdate () {

	}

	public void LateUpdate () {
		if(Mathf.Abs(controller.Direction().x) > 0){
			controller.SetState(playerController.State.WALK);
		}
	}
}
