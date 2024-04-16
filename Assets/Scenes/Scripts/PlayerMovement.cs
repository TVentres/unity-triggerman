using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 MoveDirection;
    public float HorizontalInput;
    public float VerticalInput;
    public float Speed;
    CharacterController Controller;


    // Start is called before the first frame update
    void Start()
    {
        Speed = 2f;
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
	}

    void MovementInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        MoveDirection = transform.forward * VerticalInput + transform.right * HorizontalInput;
        Controller.Move(MoveDirection * Speed * Time.deltaTime);
    }
}
