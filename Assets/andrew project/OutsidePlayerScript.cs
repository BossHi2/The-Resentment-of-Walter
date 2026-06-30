using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using UnityEngine.Tilemaps;

public class OutsidePlayerScript : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Vector2 lookDirection;
    public Rigidbody2D rigidbody2dOfMainCharacter;
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    float horizontal;
    float vertical;
    public GameObject dialogueCanvas;

     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UnityEngine.Debug.Log("Note: click r to thrust.");
        UnityEngine.Debug.Log("Project Settings > Player > Other Settings, then look for Configuration and change the input package from new to both");
        UnityEngine.Debug.Log("Rename the main character game object as: mainCharacter");
        UnityEngine.Debug.Log("put the bookshelf into a layer called \"interactable\"");
        UnityEngine.Debug.Log("https://discussions.unity.com/t/feathered-soft-sprite-mask/678960/2 <-- to make the mask edges blurry");
       lookDirection = new Vector2(1,0);
       UnityEngine.Debug.Log(Riddles.code);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2dOfMainCharacter.position, lookDirection, 1.5f, LayerMask.GetMask("interactable"));
        if(hit.collider != null){
            if (hit.collider.gameObject.name == "NPC" && Input.GetKeyDown(KeyCode.Space))
            {
                dialogueCanvas.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueCanvas.SetActive(false);
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2dOfMainCharacter.position;
        float originalX = position.x;
        float originalY = position.y;

        position.x = position.x + 3.0f * horizontal * Time.deltaTime;

        position.y = position.y + 3.0f * vertical * Time.deltaTime;
        rigidbody2dOfMainCharacter.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string obj = other.gameObject.name;
        UnityEngine.Debug.Log(obj);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
