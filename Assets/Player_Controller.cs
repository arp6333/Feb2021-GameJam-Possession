using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvent : UnityEvent<GameObject>
{

}

public class Player_Controller : MonoBehaviour
{


    Rigidbody2D rb;
    private bool inDoor = false;

    public GameObjectEvent OnPossesPowerUse = new GameObjectEvent();

    struct Fade
    {

        public Vector3 scaleGoal;
        public Vector3 scaleStart;


        public float timeStart;
        public float speed;

        public Fade (Vector3 sG, Vector3 sS, float time,float spd)
        {
            scaleGoal = sG;
            scaleStart = sS;
            timeStart = time;
            speed = spd;
        }

        public bool Step(Transform t)
        {
            float amount = (Time.time - timeStart) * speed;
            if(amount >= 1.0f)
            {
                t.localScale = scaleGoal;
                return true;
            }
            t.localScale = Vector3.Lerp(scaleStart, scaleGoal, amount);

            return false;
        }
    }


    public bool ghostMove = true;
    private bool possessing = false;
    private PossessableObject possessedObj = null;

    public float speed = 3.0f;
    public float fadeSpd = 2.5f;
    SpriteRenderer rend;


    Vector3 fullScale;
    Vector3 minScale = new Vector3(0, 0, 1);

    Fade fade;

    private bool fading = false;

    private Vector3 PositionDifference;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.isKinematic = true;

        rend = GetComponent<SpriteRenderer>();
        fullScale = transform.localScale;
    }
    private void FixedUpdate()
    {
        if (ghostMove)
        {
            Vector2 direction = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction -= Vector2.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rend.flipX = true;
                direction -= Vector2.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rend.flipX = false;
                direction += Vector2.right;
            }


            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 7)
        {
            if (other.GetComponent<Door>().IsOpen())
            {
                Debug.Log("DOOR ENTER");
                inDoor = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            inDoor = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if(fading)
        {
            if(fade.Step(transform))
            {
                fading = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!possessing)
            {
                string[] names = { "PossesableObject", "kitchen" };
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, LayerMask.GetMask(names));
                if(hit.transform != null)
                {
                    PossessableObject obj = hit.transform.GetComponentInChildren<PossessableObject>();
                    if(obj != null && obj.CanPosses)
                    {
                        possessedObj = obj;
                        possessedObj.Posses();
                        ghostMove = false;
                        possessing = true;
                        StartFadeOut();
                        PositionDifference = obj.transform.position - transform.position;
                    }

                    
                }

            }
            else
            {
                possessedObj.Unposses();
                possessing = false;
                ghostMove = true;
                StartFadeIn();
            }
        }
        if(!possessing)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("DOOR TRY");
                if(inDoor && )
                {
                    
                    LevelManager.Manager.NextLevel();
                }
            }
        }
        if(possessing && Input.GetKeyDown(KeyCode.Space))
        {
            possessedObj.UsePower();
        }
        if(possessing)
        {
            transform.position = possessedObj.transform.position - PositionDifference;

        }
    }


    public void StartFadeOut()
    {
        fade = new Fade(minScale, fullScale, Time.time, fadeSpd);
        fading = true;
    }

    public void StartFadeIn()
    {
        transform.position = possessedObj.transform.position - PositionDifference;
        fade = new Fade(fullScale, minScale, Time.time, fadeSpd);
        fading = true;

    }

    public void AddListener(UnityAction<GameObject> call)
    {
        OnPossesPowerUse.AddListener(call);
    }
}
