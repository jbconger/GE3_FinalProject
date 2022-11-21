using UnityEngine;

public class ChargeState : AimState
{
    public ChargeState(PlayerController player) : base(player) { }

	public override void Enter()
	{
		base.Enter();

		player.currentCharge = player.minArrowSpeed;
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void StateUpdate()
	{
		base.StateUpdate();
		if (player.currentCharge < player.maxArrowSpeed)
			player.currentCharge += player.chargeSpeed * Time.deltaTime;

		if (Input.GetKeyUp(KeyCode.Mouse0))
			player.shootingStateMachine.ChangeState(player.shootState);
	}

	public override void StateFixedUpdate()
	{
		base.StateFixedUpdate();
	}
}
