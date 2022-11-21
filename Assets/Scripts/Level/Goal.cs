using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent OnGoalHit;

	private void Awake()
	{
        if (OnGoalHit == null)
            OnGoalHit = new UnityEvent();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Arrow"))
		{
			OnGoalHit.Invoke();
			Destroy(this.gameObject);
		}
	}
}
