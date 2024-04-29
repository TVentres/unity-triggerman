using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 MoveDirection;
    public float HorizontalInput;
    public float VerticalInput;
    public float Speed;
    public float CurrentSpeed;
    CharacterController Controller;

    private bool canDash = true;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 0.5f;
    public int dashCount = 3;
    public int maxDashCount = 3;
    public bool onRecharge = false;
    public int dashRechargeTime = 3;
    public AudioSource dashEffect;
	HUDManager hudManager;





	// Start is called before the first frame update
	void Start()
    {
        CurrentSpeed = 15f;
        Speed = CurrentSpeed;
        Controller = GetComponent<CharacterController>();
	    hudManager = FindObjectOfType<HUDManager>();
        UpdateDashText();
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
        Speed = Speed * 3;
        dashEffect.Play();
        yield return new WaitForSeconds(dashingTime);
        Speed = CurrentSpeed;
        dashCount -= 1;
        UpdateDashText();
		yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        if(onRecharge == false)
        {
            onRecharge = true;
            while(dashCount < maxDashCount)
            {
            yield return new WaitForSeconds(dashRechargeTime);
            dashCount++;
            UpdateDashText();
			}
            onRecharge = false;
        }

    }

    void UpdateDashText()
    {
		hudManager.UpdateDashText(maxDashCount, dashCount);
	}
}