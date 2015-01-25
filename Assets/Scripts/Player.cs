using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float moveSpeed = 6.0F;
	public float gravity = 20.0F;
	public float turnSpeed = 100.0F;
	public float pushPower = 2.0F;
	public float ballKickStrength = 1.0F;
	public float benchKickStrength = 5.0F;
	public float colliderDistance = 1.2F;
//	public AudioClip[] ballKickAudio;

	private Vector3 moveDirection = Vector3.zero;
	private bool isCollided = false;

	private bool disableMove = false;
	private NPC npc;
	public GameObject interactText;
	public GameObject visualNovelPart;
	private Rigidbody[] balloons;
	public Camera mainCamera;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		//Feed moveDirection with input.
		if(!disableMove){



			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);

			if(Input.GetKey(KeyCode.LeftArrow))
				transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			if(Input.GetKey(KeyCode.RightArrow))
				transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

			//Verify if the player is in range of an NPC.
			RaycastHit hit;
			Ray test = mainCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
			Vector3 dir = test.direction;
			if(Physics.Raycast(transform.position, dir, out hit, colliderDistance)) {
				if(hit.collider.tag == "NPC") {
					if(!isCollided) {
						isCollided = true;
						npc = hit.collider.transform.gameObject.GetComponent<NPC>();
						interactText.SetActive(true);
					}
				}
				else{
					if(hit.collider.tag == "Balloons"){
						interactText.SetActive(true);
						if(Input.GetKey(KeyCode.Space))
						{
							balloons = hit.collider.transform.gameObject.GetComponentsInChildren<Rigidbody>();
							foreach(Rigidbody b in balloons){
								b.constraints = RigidbodyConstraints.None;
							}
						}
					}
					else{
						isCollided = false;
					}
				}
			}
			else{
				isCollided = false;
				interactText.SetActive(false);
			}
			if(isCollided){
				if(Input.GetKey(KeyCode.Space))
				{
					visualNovelPart.SetActive(true);
					visualNovelPart.GetComponent<VisualNovelManager>().SetNPC(npc);
					disableMove = true;
				}
			}
			//Multiply it by speed.
			moveDirection *= moveSpeed;
			//Applying gravity to the controller
			moveDirection.y -= gravity * Time.deltaTime;
			//Making the character move
			controller.Move(moveDirection * Time.deltaTime);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		Vector3 pushDir;
		if(Input.GetKey(KeyCode.E) && body.tag == "Ball")
			pushDir = new Vector3(hit.moveDirection.x, ballKickStrength, hit.moveDirection.z);
		else if(Input.GetKey(KeyCode.E) && body.tag == "Bench")
			pushDir = new Vector3(hit.moveDirection.x, benchKickStrength, hit.moveDirection.z);
		else
			pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity += pushDir * pushPower;
//		if(hit.collider.tag == "Ball" && !audio.isPlaying){
//			audio.clip = ballKickAudio[Random.Range(0,ballKickAudio.Length)];
//			audio.Play();
//		}
	}

	public void SetDisableMoveFalse(){
		disableMove = false; 
	}
}
