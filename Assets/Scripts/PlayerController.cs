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
	[SerializeField] public GameObject arrow; // projectile game object
	[SerializeField] public float minArrowSpeed = 10f;
	[SerializeField] public float maxArrowSpeed = 40f;
	[SerializeField] public float maxChargeTime = 3f;
	[SerializeField] public float maxArrowDuration = 5f;

	[HideInInspector] public float chargeSpeed;
	[HideInInspector] public float currentCharge;

	// States
	[HideInInspector] public PlayerStateMachine movementStateMachine;
	[HideInInspector] public PlayerStateMachine shootingStateMachine;

	[HideInInspector] public MoveState moveState;

	[HideInInspector] public AimState aimState;
	[HideInInspector] public ChargeState chargeState;
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
		chargeState = new ChargeState(this);
		shootState = new ShootState(this);

		chargeSpeed = (maxArrowSpeed - minArrowSpeed) / maxChargeTime;
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
