using UnityEngine;

public class spike : MonoBehaviour
{
    public Animator animator;
    public PolygonCollider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        MainCharacter player = other.gameObject.GetComponent<MainCharacter>();

        if(player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
