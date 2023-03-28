using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb2d;

    private bool isFacingRight = true;
    private float horizontal;
    private float vertical;

    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private TrailRenderer tr; //dashauksen taakse tulevan viivan porttaamiseksi

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
        canDash = false; //Varmistaa ettei Dashayksen aikana voi dashata
        isDashing = true; //Aika selke�

        //rb2d.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * DashingPower;

        tr.emitting = true; //Luo taakse taaksesi semmoseine hienon vanan
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false; //poistaa vanan
        isDashing = false; //Aika selke�

        yield return new WaitForSeconds(dashingCooldown); //Cooldown dashiin
        canDash = true;



    }

}
