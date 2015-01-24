using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float moveSpeed = 6.0F;
	public float gravity = 20.0F;
	public float turnSpeed = 100.0F;
	public float colliderDistance = 1.2F;
	private Vector3 moveDirection = Vector3.zero;
	private bool isCollided = false;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		//Feed moveDirection with input.
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);

		if(Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
		if(Input.GetKey(KeyCode.RightArrow))
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

		//Verify if the player is in range of an NPC.
		RaycastHit hit;
		if(Physics.Raycast(transform.position, moveDirection, out hit, colliderDistance)) {
			if(hit.collider.tag == "NPC") {
				if(!isCollided) {
					isCollided = true;
					NPC npc = hit.collider.transform.gameObject.GetComponent<NPC>();
					//GUI.ShowColliderMessage = true;
					//if(Input.GetKey(KeyCode.Space))
						//GUI.SetNPC(npc.name);
				}
			}
			else isCollided = false;
		}
		else isCollided = false;
		//Multiply it by speed.
		moveDirection *= moveSpeed;
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}


}
