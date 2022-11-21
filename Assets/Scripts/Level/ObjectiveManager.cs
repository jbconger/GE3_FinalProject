using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private Target[] targets;
    private int targetCount;

    [SerializeField] private GameUIController uiController;

	private void Start()
	{
		targetCount = targets.Length;
		foreach (Target target in targets)
		{
			target.OnTargetDestroyed.AddListener(TargetDestroyed);
		}
	}

	public void TargetDestroyed()
	{
		targetCount--;

		if (targetCount <= 0)
			uiController.LevelComplete();
	}
}
