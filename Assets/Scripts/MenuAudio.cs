using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonPressSound;
	[SerializeField] private AudioClip pauseSound;

    public void PlaySound(string name)
	{
        switch(name)
		{
			case "button_press":
				audioSource.clip = buttonPressSound;
				break;
			case "pause":
				audioSource.clip = pauseSound;
				break;
		}

		audioSource.Play();
	}
}
