using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
         Bat bat = other.gameObject.GetComponent<Bat>();

         if(bat != null){
            bat.destroy();
         } else{
             Spider spider = other.gameObject.GetComponent<Spider>();

             if(spider != null){
                spider.destroy();
             }
         }
    }
}
