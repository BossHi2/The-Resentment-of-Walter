using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ghost : MonoBehaviour
{
    public GameObject mainCharacter;
    public float floatSpeed = 1f;
    public float rotationSpeed = 500f;
    public Rigidbody2D rigidbody2dOfGhost;
    public TMP_Text ghostCountdown;
    public float countdownTime = 600f;
    public SpriteRenderer thisSpriteRenderer;
    public AudioSource screech;
    public TMP_Text gameOver;
    public Button restartBtn;

    bool isCountdownOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountdownOver == false){
            if(countdownTime > 0){
                countdownTime -= Time.deltaTime;
                string firstHalf = Mathf.Floor(countdownTime/60) + ":";
                string secondHalf;
                if(Mathf.Round(Mathf.Abs(60*Mathf.Floor(countdownTime/60) - countdownTime)) >= 10)
                    secondHalf = "" + Mathf.Round(Mathf.Abs(60*Mathf.Floor(countdownTime/60) - countdownTime));
                else
                    secondHalf = "0" + Mathf.Round(Mathf.Abs(60*Mathf.Floor(countdownTime/60) - countdownTime));
                ghostCountdown.text =  firstHalf + secondHalf;
            } else{
                thisSpriteRenderer.enabled = true;
                ghostCountdown.text =  "00:00";
                isCountdownOver = true;
            }
        }

        if(isCountdownOver){
            UnityEngine.Vector3 dir = mainCharacter.transform.position - transform.position; 
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            UnityEngine.Quaternion q = UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.forward);
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, q, Time.deltaTime * floatSpeed);


            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, mainCharacter.transform.position, floatSpeed * Time.deltaTime);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other) {
        MainCharacter player = other.GetComponent<MainCharacter>();

        if(isCountdownOver && player != null)
        {
            screech.Play();
            gameOver.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);
        }
    }
}
