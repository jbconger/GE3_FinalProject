using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void SelectScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
