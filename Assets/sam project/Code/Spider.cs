using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed;
    public bool DoesMoveVertical;
    public Rigidbody2D rigidbody2dOfSpider;
    public float changeTime = 3.0f;


    float timer;
    int direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0){
            direction = -direction;
            timer = changeTime;
        }
        
    }

    void FixedUpdate() {
        Vector2 position = rigidbody2dOfSpider.position;
        if(DoesMoveVertical){
            position.y = position.y + Time.deltaTime * speed * direction;
        } else{
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        rigidbody2dOfSpider.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other){
        MainCharacter player = other.gameObject.GetComponent<MainCharacter>();

        if(player != null){
            player.ChangeHealth(-1);
        }
    }

    public void destroy(){
        Destroy(gameObject);
    }
}
