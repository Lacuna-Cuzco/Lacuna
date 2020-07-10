using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public GameObject Player;
	public bool IsWalking = false;

	public GameObject Cam;
	//public GameObject Mark;

	private CharacterController _controller;
	private float _angularSpeed = 100;
	public float _walkSpeed = 5;
	private float _gravity = 0.5f;
	public float JumpSpeed = 5;
	public float MouseSensivity = 30;
	private float _rotationX = 0;
	private Vector3 _moveDirection = Vector3.zero;


	public float InputX;
	public float InputZ;






	void Start()
	{
		_controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;



	}





	void FixedUpdate()
	{
		
		//RotateView();

		_moveDirection = Vector3.zero;


		Vector3 camF = Cam.transform.forward;
		Vector3 camR = Cam.transform.right;

		camF.y = 0;
		camR.y = 0;

		camF = camF.normalized;
		camR = camR.normalized;


		InputX = Input.GetAxis("Horizontal");
		InputZ = Input.GetAxis("Vertical");


		if (_controller.isGrounded)
		{

			_moveDirection = Vector3.zero;
			/*
			if (Input.GetKey(KeyCode.A))
			{
				//transform.Rotate(Vector3.down * mouseSensivity * 2 * Time.deltaTime);
				_moveDirection.x = -_walkSpeed; //+ drunkSpeed;
			}
			if (Input.GetKey(KeyCode.D))
			{
				//transform.Rotate(Vector3.up * mouseSensivity * 2 * Time.deltaTime);
				_moveDirection.x = _walkSpeed;// + drunkSpeed;
			}
			if (Input.GetKey(KeyCode.W))
			{
				_moveDirection.z = _walkSpeed;// + drunkSpeed;

			}
			if (Input.GetKey(KeyCode.S))
			{
				_moveDirection.z = -_walkSpeed;// + drunkSpeed;

			}



			_moveDirection = transform.TransformDirection(_moveDirection);

			if (Input.GetKey(KeyCode.Space))
			{
				_moveDirection.y = JumpSpeed;


			}*/

			_moveDirection = camF * Input.GetAxis("Vertical") * _walkSpeed + camR * Input.GetAxis("Horizontal") * _walkSpeed;
		}

		_moveDirection.y -= _gravity;

		_controller.Move(_moveDirection * Time.deltaTime);
	}



	void RotateView()
	{
		//rotaciona a câmera na horizontal
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensivity * Time.deltaTime);

		//rotaciona a câmera na vertical
		_rotationX += Input.GetAxis("Mouse Y") * MouseSensivity * Time.deltaTime * -1;
		_rotationX = Mathf.Clamp(_rotationX, -45, 45);

		Cam.transform.localEulerAngles = new Vector3(-_rotationX,
													 Cam.transform.localEulerAngles.y,
													 Cam.transform.localEulerAngles.z);
	}

	
}
