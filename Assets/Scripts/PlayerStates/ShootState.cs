using UnityEngine;

public class ShootState : AimState
{
    public ShootState(PlayerController player) : base(player) { }

	public override void Enter()
	{
		base.Enter();
		FireArrow();

		player.shootingStateMachine.ChangeState(player.aimState);
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
	}

	private void FireArrow()
	{
		GameObject arrow = GameObject.Instantiate(player.arrow, player.firePoint.position, player.firePoint.rotation);
		arrow.GetComponent<Rigidbody2D>().AddForce(player.firePoint.up * player.currentCharge, ForceMode2D.Impulse);

		GameObject.Destroy(arrow.gameObject, player.maxArrowDuration);
	}
}
