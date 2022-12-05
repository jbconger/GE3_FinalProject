using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent OnTargetDestroyed;

	private void Awake()
	{
        if (OnTargetDestroyed is null)
            OnTargetDestroyed = new UnityEvent();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Arrow"))
		{
			OnTargetDestroyed.Invoke();
			Destroy(this.gameObject);
		}
	}
}
