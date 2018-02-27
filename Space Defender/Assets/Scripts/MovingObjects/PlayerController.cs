using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : Crashable {

    public Animator animator;

    private Vector2 velAux;

    private double shootTimer = 0;
    public GameObject bullet;

    public Text PowerUp;
    public Camera cam;
    public RectTransform CanvasRect;
    private float speed = 2;
    private float fireRate = 1;
    private int cannons = 1;
    public Text CannonsText;
    public Text FireRateText;
    public Text SpeedText;
    public Text HealthText;

    private AudioSource audioSource;

    private bool lose;

    protected override void Start() {
        base.Start();
        lose = false;
        audioSource = GetComponent<AudioSource>();
        animator.speed = 2;
        UpdateStats();
    }
    private void UpdateStats() {
        CannonsText.text = "Cannons:  " + cannons;
        SpeedText.text = "Speed:  " + speed;
        FireRateText.text = "Fire Rate:  " + fireRate;
        HealthText.text = "Health: " + currentHealth;
    }
    private void Movement() {
        velAux = rBody.velocity;
        if (Input.GetKey( KeyCode.LeftArrow )) {
            velAux.x -= speed * 0.1f;
        }
        else if (Input.GetKey( KeyCode.RightArrow )) {
            velAux.x += speed * 0.1f;
        } else {
            velAux.x = velAux.x / 1.05f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            velAux.y -= speed * 0.1f;
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            velAux.y += speed * 0.1f;
        }
        else {
            velAux.y = velAux.y / 1.05f;
        }

        velAux.x = Mathf.Clamp( velAux.x, -speed, speed );
        velAux.y = Mathf.Clamp(velAux.y, -speed, speed);
        rBody.velocity = velAux;

        Vector3 vec = this.transform.position;
        vec = Camera.main.WorldToViewportPoint( vec );
        vec.x = Mathf.Clamp( vec.x, 0.05f, 0.95f );
        vec.y = Mathf.Clamp(vec.y, 0.05f, 0.95f);
        this.transform.position = Camera.main.ViewportToWorldPoint( vec );
    }
    private void PowerUpMessage() {
        Vector2 ViewportPosition = cam.WorldToViewportPoint( this.transform.position + new Vector3( 0, -1, 0 ) );
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ( ( ViewportPosition.x * CanvasRect.sizeDelta.x ) - ( CanvasRect.sizeDelta.x * 0.5f ) ),
        ( ( ViewportPosition.y * CanvasRect.sizeDelta.y ) - ( CanvasRect.sizeDelta.y * 0.5f ) ) );
        PowerUp.GetComponent<RectTransform>().anchoredPosition = WorldObject_ScreenPosition;
    }
    void Update() {
        if (!lose) {
            PowerUpMessage();
            Movement();
            Shoot();
        }
    }
    void Shoot() {
        shootTimer -= Time.deltaTime * fireRate;
        if (shootTimer < 0) {
            if (Input.GetKey( KeyCode.Space )) {
                Vector3 aux = this.transform.position;
                aux.z = 1;
                aux.x -= 0.8f;
                float division = 1.6f / ( ( float )cannons + 1f );
                for (int i = 0; i < cannons; i++) {
                    audioSource.Play();
                    aux.x += division;
                    if (i > cannons / 2) {
                        aux.y -= 0.05f;
                    }
                    else {
                        aux.y += 0.05f;
                    }
                    GameObject b = Instantiate( bullet, aux, Quaternion.identity );
                }
                shootTimer = 1;
            }
        }
    }

    IEnumerator Improvement() {
        int op = Random.Range( 1, 5 );
        switch (op) {
            case 1:
                PowerUp.color = new Color( 0.9f, 0.9f, 0.1f );
                PowerUp.text = "Fire Rate Improved";
                fireRate += 1;
                break;
            case 2:
                PowerUp.color = new Color( 1f, 0.3f, 0.3f );
                PowerUp.text = "Cannon Added";
                cannons += 1;
                break;
            case 3:
                PowerUp.color = new Color( 0.3f, 0.3f, 1f );
                PowerUp.text = "Speed Improved";
                speed += 1f;
                break;
            case 4:
                PowerUp.color = new Color( 0.2f, 1f, 0.2f );
                PowerUp.text = "Health Augment";
                currentHealth += 5;
                TotalHealth += 5;
                break;
        }
        UpdateStats();
        yield return new WaitForSeconds( 1.5f );
        PowerUp.text = string.Empty;
    }
    protected override void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D( collision );
        UpdateStats();
        if (collision.gameObject.CompareTag( "PowerUp" )) {
            StartCoroutine( Improvement() );
        }
    }
    IEnumerator EndGame() {
        Destroy( Instantiate( Explosion, this.transform.position, Quaternion.identity ), 2 );
        lose = true;
        this.transform.position = new Vector3( 0, -20 );

        yield return new WaitForSeconds( 3 );

        UnityEngine.SceneManagement.SceneManager.LoadScene( "Lose" );
    }

    protected override void DestroySelf() {
        StartCoroutine( EndGame() );
    }
}
