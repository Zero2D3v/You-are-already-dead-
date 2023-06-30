using System.Collections;
using System.Collections.Generic;
using FirstGearGames.SmoothCameraShaker;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRotateToTarget : MonoBehaviour
{
    //declare fields
    public AudioSource audioSorce;
    public AudioClip nosSound;
    public AudioClip nosCutOff;
    public AudioClip pickUpSound;

    public float rotationSpeed;

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
        //set mouse offset
        offset = new Vector2(0f, -5f);
        scoreManager = FindObjectOfType<ScoreManager>();
        collider = GetComponent<PolygonCollider2D>();

        //set UI
        tunaBar = GameObject.Find("TunaBar");
        tunaScript = tunaBar.GetComponentInChildren<BarControl>();

        bananaBar = GameObject.Find("BananaBar");
        bananaScript = bananaBar.GetComponentInChildren<BarControl>();

        nO2Bar = GameObject.Find("NO2Bar");
        nO2Script = nO2Bar.GetComponentInChildren<BarControl>();
        
        //make sure effects are off
        flameEffect.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //timer
        powerUpTimer -= Time.deltaTime;

        //when power up timer ends, reset modifiers and effects
        if(powerUpTimer <= 0f)
        {
            ResetPoints();
            ResetSpeed();
            ResetEffects();
            powerUpManager.DisablePowerUpUI(powerUpManager.doublePoints);
            scoreManager.doublePoints = false;
            if(scoreManager.nos != false)
            {
                //if Nitrous on, turn off Nitrous sounds and effects
                scoreManager.DisableNOS();
                audioSorce.Stop();
                audioSorce.PlayOneShot(nosCutOff, 0.5f);
                powerUpManager.DisablePowerUpUI(powerUpManager.boostIcon);

            }
        }

        //set direction to mouse
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        //calculate angle
        float angle = Mathf.Clamp((Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg), -150f, 210f);
        //apply rotation, 90 degrees added to compensate for sprite resting direction
        Quaternion rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        //track mouse position
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //only enable score increase if going down 
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

    //this function handles the power ups and what effect is applied to the player depending on the tag of the power up
    public void OnTriggerEnter2D(Collider2D other)
    {
        //tuna = double points
        if (other.CompareTag("Tuna"))
        {
            //+50 to score
            scoreManager.IncreaseScore(50f);
            //pop up text
            ShowFloatingText();
            //show double points UI icon whilst power up active
            powerUpManager.EnablePowerUpUI(powerUpManager.doublePoints);
            //play pick up sound
            audioSorce.PlayOneShot(pickUpSound, 10f);
            //make sure trigger working
            Debug.Log("tuna");
            //restart powerUp timer in update
            powerUpTimer = powerUpLength;
            //apply doublepoints modifier to regular score count for duration of power up
            scoreManager.pointsPerSecond *= 2;
            //set doublepoints bool to on
            scoreManager.doublePoints = true;
            //increase UI bar for tuna/Phosphorous
            tunaScript.UpdateBar(0.1f);
            //spawn cartoon explosion effect
            Instantiate(tunaEffect, effectSpawnPoint);
            //show score increase with pop up text prefab
            textPopupTextUI = "+50";
            //change text colour
            ShowFloatingTextUI(Color.blue);
            //destroy picked up power up
            Destroy(other.gameObject);
           
        }
        //Nitrous = double speed
        else if (other.CompareTag("NO2"))
        {
            //play NOS boost sound 1 as nitrogen sound split into 2, sound 2 played when effects and sound stopped in update function when power up timer runs out
            audioSorce.PlayOneShot(nosSound, 0.5f);
            //+50 to score
            scoreManager.IncreaseScore(50f);
            //pop up text
            ShowFloatingText();
            //show Nitrous UI icon whilst power up active
            powerUpManager.EnablePowerUpUI(powerUpManager.boostIcon);
            //restart powerUp timer in update
            powerUpTimer = powerUpLength;
            //make sure trigger working
            Debug.Log("NO2");
            //aply x2 speed modifier for duration of power up
            moveSpeed *= 2;
            //call function in score manager script
            scoreManager.EnableNOS();
            //destroy picked up power up
            Destroy(other.gameObject);
            //increase UI bar for Nitrous/Nitrogen
            nO2Script.UpdateBar(0.1f);
            //spawn cartoon NOS effect
            Instantiate(nO2Effect, effectSpawnPoint);
            //turn on flames animation effect
            flameEffect.SetActive(true);
            //show score increase with pop up text prefab
            textPopupTextUI = "+50";
            //change text colour
            ShowFloatingTextUI(Color.red);


        }
        //banana not give buff but is worth twice as much as other two pick ups
        else if (other.CompareTag("Banana"))
        {
            //increase score by 100
            scoreManager.IncreaseScore(100f);
            //pop up text
            ShowFloatingText();
            //play pick up sound
            audioSorce.PlayOneShot(pickUpSound, 10f);
            //check if trigger working
            Debug.Log("Banana");
            //destroy picked up power up
            Destroy(other.gameObject);
            //increase bar fill amount 
            bananaScript.UpdateBar(0.2f);
            //spawn pick up effect
            Instantiate(bananaEffect, effectSpawnPoint);
            //pop up score text
            textPopupTextUI = "+100";
            //change text colour
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
