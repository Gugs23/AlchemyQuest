using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	
	/*
	 * Definindo as variáveis de controle da FSM que controla o personagem
	 */
	 public enum State {IDLE, WALK, JUMP, FALL, ATTACK, SKILL, WALLJ, WALLC, STAIRC, DAMAGE, DEAD};

	 private State state = State.IDLE;

	 private State previous;

	 private playerIDLE IDLE;

	 private playerWALK WALK;

	 private Vector2 direction;

	 public float xSpeed = 10f;

	 private bool right;

	 private Rigidbody2D rigidBody;

	 private Animator anim;

	// Use this for initialization
	void Start () {
		right = true;
		IDLE = new playerIDLE(gameObject, this);
		WALK = new playerWALK(gameObject, this);
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
			case State.IDLE:
				IDLE.Update();
				break;
			case State.WALK:
				WALK.Update();
				break;
			default:
				break;
		}

	}

	void FixedUpdate(){
		direction.x = Input.GetAxis("Horizontal");
		direction.y = Input.GetAxis("Vertical");

		switch(state){
			case State.IDLE:
				IDLE.FixedUpdate();
				break;
			case State.WALK:
				WALK.FixedUpdate();
				break;
			default:
				break;
		}

	}

	void LateUpdate(){
		switch(state){
			case State.IDLE:
				IDLE.LateUpdate();
				break;
			case State.WALK:
				WALK.LateUpdate();
				break;
			default:
				break;
		}

		Animator().SetInteger("state", (int)GetState());
	}

	public Vector2 Direction(){
		return direction;
	}

	public void SetState(State newState){
		previous = state;
		state = newState;
	}

	public State GetState(){
		return state;
	}

	public State GetPrevious(){
		return previous;
	}

	public void Flip(){
		if((right && direction.x < 0) || (!right && direction.x > 0)){
			right = !right;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}

	public Rigidbody2D RigidBody(){
		return rigidBody;
	}

	public Animator Animator(){
		return anim;
	}
}
