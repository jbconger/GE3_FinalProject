using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(PlayerController player) : base(player) { }

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
	}

	public override void StateFixedUpdate()
	{
		base.StateFixedUpdate();

		player.rb.MovePosition(player.rb.position + player.inputs.moveDir * player.moveSpeed * Time.fixedDeltaTime);
	}
}
