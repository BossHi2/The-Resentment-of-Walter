using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
using TMPro;
using UnityEngine.Tilemaps;

public class MainCharacterSimple : MonoBehaviour
{
    public Vector2 lookDirection;
    public Rigidbody2D rigidbody2dOfMainCharacter;
    public GameObject bookshelfObject;
    public GameObject flashlightCollectableObject;
    public TMP_Text keyCount;
    public Animator anim;
    public float attackSpeed;
    public bool hasSword = false;
    public bool hasFlashlight = false;
    public GameObject swordCollectableObject;
    public GameObject NPC;
    private SpriteRenderer spriteRenderer;
    public Tilemap map;
    public GameObject paperUI;
    public GameObject scrollUI;
    public GameObject safeInputUI;
    public GameObject exitInputUI;
    public AudioSource walk;
    

    bool isThrusting = false;
    int health = 3;
    int doorsOpened = 0;
    float timeUntilAttack = 0.0f;
    int numOfKeys = 0;
    float horizontal;
    float vertical;
    string lastDirection;
    string lastDirection2;
    string lastDirection3;






     
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
        if(isThrusting == false){
            Vector2 move = new Vector2(horizontal, vertical);
            if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)){
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("Walk up mc");
            lastDirection2 = "idleUp";
            lastDirection3 = "swingUp";
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            if (hasFlashlight)
            {
                anim.Play("flashlightUp");
                lastDirection = "flashlightUp";
            }
            if(Input.GetMouseButtonDown(0) && timeUntilAttack <= 0f && hasSword)
            {
                anim.Play("swingUp");
                timeUntilAttack = attackSpeed;
            }
                
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("Walk right mc");
            lastDirection2 = "idleRight";
            lastDirection3 = "swingRight";
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            if (hasFlashlight)
            {
                anim.Play("flashlightRight");
                lastDirection = "flashlightRight";
            }
            if(Input.GetMouseButtonDown(0) && timeUntilAttack <= 0f && hasSword)
            {
                anim.Play("swingRight");
                timeUntilAttack = attackSpeed;
            }
                
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("Walk left mc");
            lastDirection2 = "idleLeft";
            lastDirection3 = "swingLeft";
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            if (hasFlashlight)
            {
                anim.Play("flashlightLeft");
                lastDirection = "flashlightLeft";
            }
            if(Input.GetMouseButtonDown(0) && timeUntilAttack <= 0f && hasSword)
            {
                anim.Play("swingLeft");
                timeUntilAttack = attackSpeed;
            }
                
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("Walk down mc");
            lastDirection2 = "idleDown";
            lastDirection3 = "swingDown";
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            if (hasFlashlight)
            {
                anim.Play("flashlightDown");
                lastDirection = "flashlightDown";
            }
            if(Input.GetMouseButtonDown(0) && timeUntilAttack <= 0f && hasSword)
            {
                anim.Play("swingDown");
                timeUntilAttack = attackSpeed;
            }
                
        }
        else
        {
            anim.Play(lastDirection2);
            anim.Play(lastDirection);
            walk.Pause();
            if(Input.GetMouseButtonDown(0) && timeUntilAttack <= 0f && hasSword)
            {
                anim.Play(lastDirection3);
                timeUntilAttack = attackSpeed;
            }
                
        }

        

        if(Input.GetKeyDown(KeyCode.R) && hasSword){
            StartCoroutine(thrust(lookDirection));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            paperUI.SetActive(false);
            scrollUI.SetActive(false);
        }

        if(timeUntilAttack <= 0f && hasSword){
            /*if(Input.GetMouseButtonDown(0)){
                if(lookDirection[1] == -1f)
                {
                    anim.Play("swingDown");
                }else if(lookDirection[0] == 1f)
                {
                    anim.Play("swingRight");
                }else if(lookDirection[0] == -1f)
                {
                    anim.Play("swingLeft");
                }else{
                    anim.Play("swingUp");
                } 
                timeUntilAttack = attackSpeed;
                
            }*/
        } else{
            timeUntilAttack -= Time.deltaTime;
        }

        

        RaycastHit2D hit = Physics2D.Raycast(rigidbody2dOfMainCharacter.position, lookDirection, 0.5f, LayerMask.GetMask("interactable"));
        if(hit.collider != null){
            UnityEngine.Debug.Log(hit.collider);
            bookshelf shelfObj = hit.collider.GetComponent<bookshelf>();
            flashlightCollectable flashlightCollect = hit.collider.GetComponent<flashlightCollectable>();
            swordCollectable swordCollect = hit.collider.GetComponent<swordCollectable>();
            NPC npc = hit.collider.GetComponent<NPC>();
            BookScript bookScript = hit.collider.GetComponent<BookScript>();
            if (bookScript != null && Input.GetKeyDown(KeyCode.Space))
            {
                bookScript.ShowText();
            }

            if(hit.collider.gameObject.name == "Key")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    numOfKeys++;
                    keyCount.text = "You have " + numOfKeys + " Keys";
                    Destroy(hit.collider.gameObject);
                }
            } else if(hit.collider.gameObject.name == "Room Door")
            {
                if (Input.GetKeyDown(KeyCode.Space) && numOfKeys > 0)
                {
                    numOfKeys--;
                    doorsOpened++;
                    keyCount.text = "You have " + numOfKeys + " Keys";
                    if (doorsOpened == 2)
                    {
                        map.ClearAllTiles();
                    }
                    Destroy(hit.collider.gameObject);
                }
            }
            else if (hit.collider.gameObject.name == "Labyrinth Door")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
            else if (hit.collider.gameObject.name == "CodeScroll")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    scrollUI.SetActive(true);
                }
            }
            else if (hit.collider.gameObject.name == "Safe" || hit.collider.gameObject.name == "SafeCollider")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    safeInputUI.SetActive(true);
                }
            }
            else if (hit.collider.gameObject.name == "ExitDoor")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    exitInputUI.SetActive(true);
                }
            }

            if(shelfObj != null){
                shelfObj.lightUp();

                if(Input.GetKeyDown(KeyCode.Space)){
                    shelfObj.getPaper();
                }
            } if(flashlightCollect != null){
                flashlightCollect.lightUp();

                if(Input.GetKeyDown(KeyCode.Space)){
                    flashlightCollect.collectFlashlight();
                    hasFlashlight = true;
                }
            } if(swordCollect != null)
            {
                swordCollect.lightUp();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    swordCollect.collectSword();
                    hasSword = true;
                }
            } if(npc != null)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                    npc.DisplayDialog();
            }
        } else{
            if(bookshelfObject != null)
                bookshelfObject.GetComponent<bookshelf>().lightDown();
            if(flashlightCollectableObject != null)
                flashlightCollectableObject.GetComponent<flashlightCollectable>().lightDown();
            if(swordCollectableObject != null)
                swordCollectableObject.GetComponent<swordCollectable>().lightDown();
        }
    }

    
    void FixedUpdate()
    {
        if(isThrusting)
            return;
        Vector2 position = rigidbody2dOfMainCharacter.position;
        float originalX = position.x;
        float originalY = position.y;

        position.x = position.x + 3.0f * horizontal * Time.deltaTime;

        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2dOfMainCharacter.MovePosition(position);
    }
    

    IEnumerator thrust(Vector2 direction){
        isThrusting = true;

        
        
        rigidbody2dOfMainCharacter.AddForce(direction * 5, ForceMode2D.Impulse);

        if(lookDirection[1] == -1f)
        {
            anim.Play("swingDown");
        }else if(lookDirection[0] == 1f)
        {
            anim.Play("swingRight");
        }else if(lookDirection[0] == -1f)
        {
            anim.Play("swingLeft");
        }else{
            anim.Play("swingUp");
        } 

        yield return new WaitForSeconds(0.3f);

        rigidbody2dOfMainCharacter.linearVelocity = Vector2.zero;
        rigidbody2dOfMainCharacter.angularVelocity=  0.0f;

        isThrusting = false;
    }

    public void ChangeHealth(int changeAmount){
        if(changeAmount < 0 && isThrusting == false){
            health += changeAmount;
            
        }else if(changeAmount > 0){
            health += changeAmount;
        }
        

        UnityEngine.Debug.Log("Health: " + health);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Tilemap tilemap = other.GetComponent<Tilemap>();

        if (tilemap != null || other.gameObject.name == "Safe")
        {
            spriteRenderer.sortingOrder = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Tilemap tilemap = other.GetComponent<Tilemap>();

        if (tilemap != null || other.gameObject.name == "Safe")
        {
            spriteRenderer.sortingOrder = 1;
        }
    }
}
