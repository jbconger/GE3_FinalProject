public class PlayerStateMachine
{
	public PlayerState currentState;

	public void Initialize(PlayerState startingState)
	{
		currentState = startingState;
		currentState.Enter();
	}

	public void ChangeState(PlayerState nextState)
	{
		currentState.Exit();
		currentState = nextState;
		currentState.Enter();
	}

	public void StateUpdate()
	{
		currentState.StateUpdate();
	}

	public void StateFixedUpdate()
	{
		currentState.StateFixedUpdate();
	}
}
