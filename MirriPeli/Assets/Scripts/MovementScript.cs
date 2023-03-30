using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

	public float speed;
	private Rigidbody2D rb2d;

	//private bool isFacingRight = true;  T�m� on pala vanhaa koodia, jota nykyinen (ja parempi) Dash ei tarvitse en��, tosin t�t� saatetaan tarvita viel� animaatio ty�ss� joten �L� POISTA!
	private float horizontal;
	private float vertical;

	private bool canDash = true;
	private bool isDashing;
	private float DashingPower = 24f;
	private float dashingTime = 0.2f;
	private float dashingCooldown = 1f;


	[SerializeField] private TrailRenderer tr; //dashauksen taakse tulevan viivan porttaamiseksi
	[SerializeField] private GrabObjects grabObjects;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (isDashing) //Est�� sen ettei pelaaja liiku samaan aikaan kun dashaa
		{
			return;
		}

		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		rb2d.velocity = new Vector2(horizontal * speed, vertical * speed);

		if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
		{
			StartCoroutine(Dash());
		}
		// Rotate player to face direction of movement (if movement is non-zero)
		if (rb2d.velocity != Vector2.zero && grabObjects.grabbedObject == null)
		{
			float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}

		// Apply movement to player's rigidbody
		rb2d.MovePosition(rb2d.position + rb2d.velocity * Time.deltaTime);

		//Flip();

	}
	//Flip oli koodia joka "flippasi" pelattavan hahmon ymp�ri jos sattui toiseen suuntaan katsomaan. My�hemmin kun koko Dash koodi uusittiin niin t�m� muuttui v�h�n hy�dytt�m�ksi

	//Mutta on t�rke� huomata ett� t�t� saatetaan viel� tarvita mm. animaatioty�ss�, joten �L� POISTA!!!!!!!!!!!!!!!!

	/*private void Flip() 
	{
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			Vector3 localScale = transform.localScale;
			isFacingRight = !isFacingRight;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}

	}*/

	private IEnumerator Dash()
	{
		var sky = GameObject.Find("Sky");				//Hae taivas tilemap
		sky.GetComponent<Collider2D>().isTrigger = true;//Muuta taivas colliderist� triggeriksi
		canDash = false; //Varmistaa ettei Dashayksen aikana voi dashata
		isDashing = true; //Aika selke�

		//rb2d.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
		rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * DashingPower;

		tr.emitting = true; //Luo taakse taaksesi semmoseine hienon vanan
		yield return new WaitForSeconds(dashingTime);
		tr.emitting = false; //poistaa vanan
		isDashing = false; //Aika selke�

		yield return new WaitForSeconds(dashingCooldown); //Cooldown dashiin
		sky.GetComponent<Collider2D>().isTrigger = false;//Muuta taivas triggerist� collideriksi
		canDash = true;



	}
}

