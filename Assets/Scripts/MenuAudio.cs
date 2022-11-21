using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonPressSound;

    public void PlaySound(string name)
	{
        switch(name)
		{
			case "button_press":
				audioSource.clip = buttonPressSound;
				break;
		}

		audioSource.Play();
	}
}
