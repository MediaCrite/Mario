using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ja = 25; 
    public float gs = 9.8f;
    public float fgs = 40;
    private bool isGr = true;
    public float speed;
    public float moveSpeed = 8f;
    public Text score;
    private int sc = 0;
    public GameObject LOSE;
    public GameObject WIN;

    void Start()
    {
        score.text = $"{sc}";
        WIN.SetActive(false);
        LOSE.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); 

        if (moveInput != 0)
        {
            
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        else
        {
            
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    private void Jump()
    {
        if (isGr)
        {
            rb.AddForce(Vector2.up * ja, ForceMode2D.Impulse);
            if (rb.velocity.y >= 0)
            {
                rb.gravityScale = gs;
            }
            else if (rb.velocity.y < 0)
            {
                rb.gravityScale = fgs;
            }
        }
    }
    public void but()
    {
        SceneManager.LoadScene(0);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("plat1") || col.gameObject.CompareTag("plat2") || col.gameObject.CompareTag("plat3"))
        {
            isGr = true;
        }
        if (col.gameObject.CompareTag("enemy"))
        {
            LOSE.SetActive(true);
        }
        if (col.gameObject.CompareTag("finish"))
        {
            WIN.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("plat1") || col.gameObject.CompareTag("plat2") || col.gameObject.CompareTag("plat3"))
        {
            isGr = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            sc += 1;
            score.text = $"{sc}";
        }
    }
}
