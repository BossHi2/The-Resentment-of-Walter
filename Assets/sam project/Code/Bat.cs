using System.Numerics;
using UnityEngine;

public class Bat : MonoBehaviour
{

    bool isActivated = false;

    public GameObject mainCharacter;
    public float flySpeed = 2f;
    public float rotationSpeed = 500f;
    public Rigidbody2D rigidbody2dOfBat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated){
            UnityEngine.Vector3 dir = mainCharacter.transform.position - transform.position; 
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            UnityEngine.Quaternion q = UnityEngine.Quaternion.AngleAxis(angle, UnityEngine.Vector3.forward);
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, q, Time.deltaTime * flySpeed);


            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, mainCharacter.transform.position, flySpeed * Time.deltaTime);

        }  
    }
    void OnCollisionEnter2D(Collision2D other) {
        MainCharacter player = other.gameObject.GetComponent<MainCharacter>();

        if(player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void activateBat(){
        isActivated = true;
    }
    public void destroy(){
        Destroy(gameObject);
    }
}
