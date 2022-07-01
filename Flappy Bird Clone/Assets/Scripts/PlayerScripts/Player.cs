using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spritesIndex;

    private Vector3 direction;

    public float gravity = -9.8f;

    public float strength = 5f;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    //To reset the position of the player(Bird)
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        BirdInput();
    }

    //Bird Control
    private void BirdInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    //To animate the bird flapping
    private void AnimateSprite()
    {
        spritesIndex++;
        if (spritesIndex >= sprites.Length)
        {
            spritesIndex = 0;
        }

        spriteRenderer.sprite = sprites[spritesIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")//Game over
        {
            FindObjectOfType<GameManager>().GameOver();
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

        } else if (collision.gameObject.tag == "Scoring")//to trigger the score to increment
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            FindObjectOfType<AudioManager>().Play("PlayerScore");
        }
    }
}
