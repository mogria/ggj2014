using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Player : MonoBehaviour
{
	public static bool Active = false;	// Stop userinput while in a action 

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded && !Active) {
			moveDirection = new Vector3(Input.GetAxis("Vertical") * 0, 0, Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
				Action ();
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

	void Action()
	{
		// run Action
		Tool.ActiveTool.Action();

		Active = true;
	}
}