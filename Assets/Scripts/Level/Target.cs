using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent OnTargetDestroyed;

	[SerializeField] private AudioSource audioSource;

	private void Awake()
	{
        if (OnTargetDestroyed is null)
            OnTargetDestroyed = new UnityEvent();
		if (audioSource is null)
			audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Arrow"))
		{
			OnTargetDestroyed.Invoke();
			audioSource.Play();
			while (audioSource.isPlaying) { }
			Destroy(this.gameObject);
		}
	}
}
