using System.Collections;
using System.Collections.Generic;
using FirstGearGames.SmoothCameraShaker;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRotateToTarget : MonoBehaviour
{
    //public ScreenShake screenShake;
    //public CameraShaker cameraShaker;

    public AudioSource audioSorce;
    public AudioClip nosSound;
    public AudioClip nosCutOff;
    public AudioClip pickUpSound;

    public float rotationSpeed;
    //public Transform target;

    private Vector2 direction;

    public float moveSpeed;

    private Vector2 offset;

    private ScoreManager scoreManager;

    public PowerUpManager powerUpManager;

    private PolygonCollider2D collider;

    private float powerUpTimer;
    private float powerUpLength = 3f;

    private GameObject bananaBar;
    private BarControl bananaScript;

    private GameObject tunaBar;
    private BarControl tunaScript;

    private GameObject nO2Bar;
    private BarControl nO2Script;

    public GameObject flameEffect;
    public GameObject tunaEffect;
    public GameObject nO2Effect;
    public GameObject bananaEffect;
    public Transform effectSpawnPoint;
    public Transform flamePoint;

    public Transform floatingTextUIPoint;
    private string textPopupTextUI;

    public GameObject floatingText;
    public string textPopupText;


    private void Start()
    {
        offset = new Vector2(0f, -5f);
        scoreManager = FindObjectOfType<ScoreManager>();
        collider = GetComponent<PolygonCollider2D>();

        tunaBar = GameObject.Find("TunaBar");
        tunaScript = tunaBar.GetComponentInChildren<BarControl>();

        bananaBar = GameObject.Find("BananaBar");
        bananaScript = bananaBar.GetComponentInChildren<BarControl>();

        nO2Bar = GameObject.Find("NO2Bar");
        nO2Script = nO2Bar.GetComponentInChildren<BarControl>();

        flameEffect.SetActive(false);

        //cameraShaker.Disable();



    }
    // Update is called once per frame
    void Update()
    {
        powerUpTimer -= Time.deltaTime;

        if(powerUpTimer <= 0f)
        {
            ResetPoints();
            ResetSpeed();
            ResetEffects();
            powerUpManager.DisablePowerUpUI(powerUpManager.doublePoints);
            scoreManager.doublePoints = false;
            if(scoreManager.nos != false)
            {
                //StopCoroutine(screenShake.Shake(0.2f));
                //cameraShaker.enabled = false;
                scoreManager.DisableNOS();
                audioSorce.Stop();
                audioSorce.PlayOneShot(nosCutOff, 0.5f);
                powerUpManager.DisablePowerUpUI(powerUpManager.boostIcon);

            }
        }

        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float angle = Mathf.Clamp((Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg), -150f, 210f);
        Quaternion rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
        

        if(cursorPos.y <= transform.position.y)
        {
            scoreManager.EnableScoreIncrease();
            transform.position = Vector2.MoveTowards(transform.position, cursorPos + offset, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            scoreManager.DisableScoreIncrease();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tuna"))
        {

            //textPopupText = scoreManager.WorkOutAmountToPrint()//"+50";//"Phosphorous!";
            scoreManager.IncreaseScore(50f);
            ShowFloatingText();
            //powerUpManager.IncreaseCount();
            powerUpManager.EnablePowerUpUI(powerUpManager.doublePoints);

           //textPopupText = "X2 Points";
           //
           //ShowFloatingText();

            //audioSorce.volume *= 2f;
            audioSorce.PlayOneShot(pickUpSound, 10f);

            Debug.Log("tuna");
            powerUpTimer = powerUpLength;
            scoreManager.pointsPerSecond *= 2;
            scoreManager.doublePoints = true;
            tunaScript.UpdateBar(0.1f);
            
            Instantiate(tunaEffect, effectSpawnPoint);

            textPopupTextUI = "+50";
            ShowFloatingTextUI(Color.blue);


            //tuna.UpdateBar((float)currentBar / (float)maxBar);

            Destroy(other.gameObject);
           
        }
        else if (other.CompareTag("NO2"))
        {
            //audioSorce.volume *= 0.5f;
            audioSorce.PlayOneShot(nosSound, 0.5f);

            //textPopupText = "+50";//"Nitrogen!";
            scoreManager.IncreaseScore(50f);
            ShowFloatingText();
            //powerUpManager.IncreaseCount();
            powerUpManager.EnablePowerUpUI(powerUpManager.boostIcon);

            //textPopupText = "X2 Speed";
            //
            //ShowFloatingText();

            //StartCoroutine(screenShake.Shake(0.2f));
            //cameraShaker.enabled = true;

            powerUpTimer = powerUpLength;
            Debug.Log("NO2");
            moveSpeed *= 2;
            scoreManager.EnableNOS();
            Destroy(other.gameObject);
            nO2Script.UpdateBar(0.1f);
            
            Instantiate(nO2Effect, effectSpawnPoint);
            flameEffect.SetActive(true);

            textPopupTextUI = "+50";
            ShowFloatingTextUI(Color.red);


        }
        else if (other.CompareTag("Banana"))
        {
            //textPopupText = "+100";//"Potassium!";
            scoreManager.IncreaseScore(100f);
            ShowFloatingText();

           //textPopupText = "+50";
           //
           //ShowFloatingText();

            //audioSorce.volume *= 2f;
            audioSorce.PlayOneShot(pickUpSound, 10f);

            Debug.Log("Banana");
            Destroy(other.gameObject);
            bananaScript.UpdateBar(0.2f);
            
            Instantiate(bananaEffect, effectSpawnPoint);

            textPopupTextUI = "+100";

            ShowFloatingTextUI(Color.yellow);

        }
    }

    void ResetSpeed()
    {
        moveSpeed = 15f;
    }

    void ResetPoints()
    {
        scoreManager.pointsPerSecond = 5f;
    }

    void ResetEffects()
    {
        flameEffect.SetActive(false);
    }

    void ShowFloatingText()
    {
        var go = Instantiate(floatingText, effectSpawnPoint);
        go.GetComponent<TextMeshPro>().text = textPopupText.ToString();
    }

    void ShowFloatingTextUI(Color color)
    {
        floatingText.GetComponent<TextMeshPro>().color = color;
        var go = Instantiate(floatingText, floatingTextUIPoint);
        go.GetComponent<TextMeshPro>().text = textPopupTextUI.ToString();
    }
}
