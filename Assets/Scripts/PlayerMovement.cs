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

    private bool canDash = true;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 0.5f;
    public int dashCount = 3;
    public int maxDashCount = 3;
    public bool onRecharge = false;
    public int dashRechargeTime = 3;




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
		if (Input.GetKeyDown(KeyCode.Space) && canDash == true && dashCount > 0)
		{
            StartCoroutine(Dash());
		}

        
	}

    void MovementInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        MoveDirection = transform.forward * VerticalInput + transform.right * HorizontalInput;
        Controller.Move(MoveDirection * Speed * Time.deltaTime);
    }

    IEnumerator Dash()
    {
        canDash = false;
        Speed = 30f;
        yield return new WaitForSeconds(dashingTime);
        Speed = 2f;
        dashCount -= 1;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        if(onRecharge == false)
        {
            onRecharge = true;
            while(dashCount < maxDashCount)
            {
            yield return new WaitForSeconds(dashRechargeTime);
            dashCount++;
            }
            onRecharge = false;
        }
        
	}
}
