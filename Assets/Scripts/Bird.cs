using UnityEngine;
using System.Collections;
public class Bird : MonoBehaviour
{
    public float upForce;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip flapSFX;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.linearVelocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                audioSource.PlayOneShot(flapSFX);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Columns"))
        {
            HandleDeath();
        }
    }
    private void HandleDeath()
    {
        if (isDead == true)
            return;
        rb2d.linearVelocity = Vector2.zero;
        rb2d.gravityScale = 0;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.Instance.BirdDied();
    }
}
