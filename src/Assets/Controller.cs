using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    private bool isStarted = false;

    private float topScore = 0.0f;

    public Text scoreText;
    public Text startText;
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStarted == true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        }
    }

    void Update ()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isStarted == false)
        {
            isStarted = true;
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;
        }

        if (isStarted == true)
        {

            if (moveInput < 0)
            {

                this.GetComponent<SpriteRenderer>().flipX = false;

            }
            else
            {

                this.GetComponent<SpriteRenderer>().flipX = true;

            }



            if (rb2d.velocity.y > 0 && transform.position.y > topScore)
            {

                topScore = transform.position.y;

            }

            scoreText.text = "Score: " + Mathf.Round(topScore * 7).ToString();

            if (rb2d.velocity.y < -50 && transform.position.y < topScore)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

}
