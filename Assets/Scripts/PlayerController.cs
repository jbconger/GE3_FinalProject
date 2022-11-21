using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields
	[Header("Components")]
	[SerializeField] public Transform firePoint;
	[SerializeField] public Rigidbody2D rb;
	[HideInInspector] private Camera mainCamera;

	public struct Inputs
	{
		public int rawX;
		public int rawY;
		public Vector2 moveDir;
		public Vector2 mousePos;
	}

	[HideInInspector] public Inputs inputs;

	[Header("Movement")]
	[SerializeField] public float moveSpeed = 5f;

	[Header("Shooting")]
	[SerializeField] public float arrowSpeed = 10f;
	[SerializeField] public GameObject arrow;

	// States
	[HideInInspector] public PlayerStateMachine movementStateMachine;
	[HideInInspector] public PlayerStateMachine shootingStateMachine;

	[HideInInspector] public MoveState moveState;

	[HideInInspector] public AimState aimState;
	[HideInInspector] public ShootState shootState;
	#endregion

	private void Awake()
	{	
		//arrow = Resources.Load("Arrow") as GameObject;

		mainCamera = Camera.main;

		movementStateMachine = new PlayerStateMachine();
		shootingStateMachine = new PlayerStateMachine();

		moveState = new MoveState(this);
		aimState = new AimState(this);
		shootState = new ShootState(this);
	}

	private void Start()
    {
		movementStateMachine.Initialize(moveState);
		shootingStateMachine.Initialize(aimState);
    }

	private void Update()
	{
		CheckInput();
		movementStateMachine.StateUpdate();
		shootingStateMachine.StateUpdate();
	}

	private void FixedUpdate()
	{
		movementStateMachine.StateFixedUpdate();
		shootingStateMachine.StateFixedUpdate();
	}

	private void CheckInput()
	{
		inputs.rawX = (int)Input.GetAxisRaw("Horizontal");
		inputs.rawY = (int)Input.GetAxisRaw("Vertical");
		inputs.moveDir.x = Input.GetAxis("Horizontal");
		inputs.moveDir.y = Input.GetAxis("Vertical");

		inputs.mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
	}
}
