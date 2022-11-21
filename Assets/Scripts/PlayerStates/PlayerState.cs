public class PlayerState
{
    protected PlayerController player;
    
    public PlayerState(PlayerController player)
	{
        this.player = player;
	}

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void StateUpdate() { }
    public virtual void StateFixedUpdate() { }
}
