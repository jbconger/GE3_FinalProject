using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Source")]
	[SerializeField] private AudioSource audioSource;
	
	[Header("SFX")]
    [SerializeField] private AudioClip drawSound;
	[SerializeField] private AudioClip shootSound;

    public void PlaySound(string clipName)
	{
        switch(clipName)
		{
			case "draw":
				audioSource.clip = drawSound;
				break;
			case "shoot":
				audioSource.clip = shootSound;
				break;
		}

		audioSource.Play();
	}
}
