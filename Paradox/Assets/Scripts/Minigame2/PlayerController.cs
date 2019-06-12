using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip coinCollectSound;
    public AudioSource jetpackAudio;
    public AudioSource footstepsAudio;
    public Texture2D coinIconTexture;
    private int coins;
    private bool dead = false;
    public ParticleSystem jetpack;
    ParticleSystem.EmissionModule em;
    public float thrusterForce = 75.0f;
    public Rigidbody2D rb;
    public Transform groundCheckTransform;
    private bool grounded;
    public LayerMask groundCheckLayerMask;
    Animator animator;
    public float forwardMovementSpeed = 3.0f;
    public float acceleration;
    [SerializeField] private GameObject minigame2;

    void Awake()
    {
        em = jetpack.emission;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jetpack = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(coins >= 150)
        {
            Destroy(minigame2);
            minigameText.minigames++;
            SceneManager.UnloadSceneAsync("FirstScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MapController.count = 0;
            SceneManager.UnloadSceneAsync("FirstScene");
        }
    }

    void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        jetpackActive = jetpackActive && !dead;
        if (jetpackActive)
            rb.AddForce(new Vector2(0, thrusterForce));

        if (!dead)
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.x = forwardMovementSpeed;
            rb.velocity = newVelocity;
            forwardMovementSpeed += (float)Time.timeSinceLevelLoad/(float)Time.renderedFrameCount * acceleration;
        }

        UpdateGroundedStatus();
        AdjustJetpack(jetpackActive);
        jetpackActive = false;
        AdjustSound(jetpackActive);
    }

    void UpdateGroundedStatus()
    {
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
        animator.SetBool("grounded", grounded);
    }

    void AdjustJetpack(bool jetpackActive)
    {
        em.enabled = !grounded;
        em.rateOverTime = jetpackActive ? 300.0f : 75.0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
            CollectCoin(col);
        else
            HitByLaser(col);
    }

    void OnGUI()
    {
        DisplayCoinsCount();
        DisplayRestartButton();
    }

    void HitByLaser(Collider2D col)
    {
        if (!dead)
           col.GetComponent<AudioSource>().Play();
        dead = true;
        animator.SetBool("dead", true);
    }

    void CollectCoin(Collider2D coin)
    {
        coins++;
        Destroy(coin.gameObject);
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
    }

    void DisplayCoinsCount()
    {
        Rect coinIconRect = new Rect(10, 10, 32, 32);
        GUI.DrawTexture(coinIconRect, coinIconTexture);

        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
        GUI.Label(labelRect, coins.ToString(), style);
    }

    void DisplayRestartButton()
    {
        if (dead && grounded)
        {
            Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.3f, Screen.height * 0.1f);
            if (GUI.Button(buttonRect, "TAP TO RESTART  !!"))
            {
                Destroy(minigame2);
                SceneManager.UnloadSceneAsync("FirstScene");
                SceneManager.LoadScene("FirstScene", LoadSceneMode.Additive);
            }
        }
    }

    void AdjustSound(bool jetpackActive)
    {
        footstepsAudio.enabled = !dead && grounded;
        jetpackAudio.enabled = !dead && !grounded;
        jetpackAudio.volume = jetpackActive ? 1.0f : 0.5f;
    }
}
