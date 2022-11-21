using UnityEngine;

public class Arrow : MonoBehaviour
{
	//[SerializeField] public GameObject hitEffect;
	[SerializeField] private Rigidbody2D rb;

	private void FixedUpdate()
	{
		// rotate the arrow to the direction it is moving in
		Vector2 rotateVector = new Vector2(rb.velocity.x, rb.velocity.y);
		if (rotateVector != Vector2.zero)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.forward, rotateVector);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag("Arrow"))
			Destroy(this.gameObject);
	}
}
