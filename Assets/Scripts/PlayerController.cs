using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float temperature = 100f;
        public TMP_Text temperatureText, survivalTimeText;
        public GameObject gameOverPanel;
        public bool isNearCampfire = false;
        public AudioSource footstepSound;


    private Animator animator;
        private Vector2 moveInput;
        private SpriteRenderer spriteRenderer;
        private bool isDead = false;
        private float survivalTime = 0f;
        private Rigidbody2D rb;

        
        private void Start()
            {
                gameOverPanel.SetActive(false);
                spriteRenderer = GetComponent<SpriteRenderer>();
                animator = GetComponent<Animator>();
                rb = GetComponent<Rigidbody2D>();
            }

        private void Update()
            {
                if (isDead)
                    {
                    if (isDead)
                        {
                            if (Input.GetKeyDown(KeyCode.R))
                                {
                                    SceneManager.LoadScene(
                                        SceneManager.GetActiveScene().buildIndex
                                    );
                                }
                        }
                    return;
                    }
                survivalTime += Time.deltaTime;
                moveInput.x = Input.GetAxisRaw("Horizontal");
                moveInput.y = Input.GetAxisRaw("Vertical");

                moveInput = moveInput.normalized;
                if (moveInput.magnitude > 0)
                    {
                        if (!footstepSound.isPlaying)
                        {
                            footstepSound.Play();
                        }
                    }
                else
                    {
                        footstepSound.Stop();
                    }

        if (moveInput.x > 0)
                    {
                        spriteRenderer.flipX = false;
                    }
                    else if (moveInput.x < 0)
                        {
                            spriteRenderer.flipX = true;
                        }

                animator.SetBool("IsMoving",moveInput.magnitude > 0);

                temperature -= Time.deltaTime * 3f;
                if (isNearCampfire)
                {
                    temperature += Time.deltaTime * 15f;
                }
                temperature = Mathf.Clamp(temperature, 0f, 100f);

                if (temperature <= 0 && !isDead)
                {
                    isDead = true;
                    gameOverPanel.SetActive(true);
                }

                if (isDead && Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(
                        SceneManager.GetActiveScene().buildIndex
                    );
                }

                if (temperature < 30)
                    {
                        temperatureText.color = Color.red;
                    }
                    else if (temperature < 70)
                        {
                            temperatureText.color = Color.yellow;
                        }
                    else
                        {
                            temperatureText.color = Color.white;
                        }
                temperatureText.text ="Temperature : " + temperature.ToString("F0");
                survivalTimeText.text ="SurvivalTime : " + survivalTime.ToString("F0") + "s";
            }
                private void FixedUpdate()
                    {
                        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
                    }
                public float GetSurvivalTime()
                    {
                        return survivalTime;
                    }
                public void TestWin()
                    {
                        SceneManager.LoadScene("WinScene");
                    }
    }