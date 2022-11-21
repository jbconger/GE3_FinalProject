using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent OnGoalHit;

	[SerializeField] private AudioSource audioSource;

	private void Awake()
	{
        if (OnGoalHit is null)
            OnGoalHit = new UnityEvent();
		if (audioSource is null)
			audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Arrow"))
		{
			OnGoalHit.Invoke();
			audioSource.Play();
			Destroy(this.gameObject);
		}
	}
}
