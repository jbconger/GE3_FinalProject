using UnityEngine;

public class Arrow : MonoBehaviour
{
	//[SerializeField] public GameObject hitEffect;
	private Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(this.gameObject);
	}
}
