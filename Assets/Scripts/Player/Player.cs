using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Sub Stats")]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] [Range(0f, 100f)] private static float OxygenLevel = 100f;
	[SerializeField] [Range(0f, 100f)] private static float BatteryLevel = 100f;
	[SerializeField] [Range(0f, 100f)] private static float OxygenGainRate = 100f;
	[SerializeField] [Range(0f, 100f)] private static float BatteryGainRate = 100f;
	private bool isMoving;
	private bool facingRight;

	private Rigidbody2D rb;
	private Animator animator;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
			animator = GetComponent<Animator>();
	}

	private void FixedUpdate() {
		#region Movement
		float InputX = Input.GetAxis("Horizontal");
		float InputY = Input.GetAxis("Vertical");

		if (rb.velocity == Vector2.zero) {
			isMoving = false;
		} else {
			isMoving = true;
		}

		Vector2 movement = new Vector2(InputX * moveSpeed, InputY * moveSpeed);
		rb.AddForce(movement);
		#endregion

		#region Character Flipping
		if (InputX < 0 && !facingRight) {
			Flip();
		}
		else if (InputX > 0 && facingRight) {
			Flip();
		}
		#endregion
	}

	private void Update() {
		animator.SetBool("IsMoving", isMoving);
	}
	#region Methods
	private void Flip() {
		Vector3 currentScale = gameObject.transform.localScale;
		currentScale.x *= -1;
		gameObject.transform.localScale = currentScale;

		facingRight = !facingRight;
	}
	#endregion
}
