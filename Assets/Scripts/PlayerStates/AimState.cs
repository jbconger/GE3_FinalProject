using UnityEngine;

public class AimState : PlayerState
{
	private Vector2 lookDirection;
	private float lookAngle;

    public AimState(PlayerController player) : base(player) { }

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void StateUpdate()
	{
		base.StateUpdate();

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			player.shootingStateMachine.ChangeState(player.shootState);
		}
	}

	public override void StateFixedUpdate()
	{
		base.StateFixedUpdate();

		lookDirection = player.inputs.mousePos - player.rb.position;
		lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
		player.rb.rotation = lookAngle;
	}
}
