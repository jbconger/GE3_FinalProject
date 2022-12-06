using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private Target[] targets;

	[HideInInspector] private AudioSource audioSource;
    private int targetCount;

    [SerializeField] private GameUIController uiController;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Start()
	{
		targetCount = targets.Length;
		foreach (Target target in targets)
		{
			target.OnTargetDestroyed.AddListener(TargetDestroyed);
		}

		uiController.UpdateTargetCount(targetCount);
	}

	public void TargetDestroyed()
	{
		targetCount--;
		uiController.UpdateTargetCount(targetCount);
		audioSource.Play();

		if (targetCount <= 0)
		{
			uiController.DeactivateCounter();
			uiController.LevelComplete();
		}
	}
}
