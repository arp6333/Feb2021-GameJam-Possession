using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<string> levels;

    public static LevelManager Manager;


    public int currentLevel = 0;


    public int maxLevel = 1;

    public float fadeOutSpeed = 10.0f;
    public float maxSize = 20.0f;
    public Sprite circle;

    private Fade fade;
    private bool fading = false;



    struct Fade
    {

        public Vector3 scaleGoal;
        public Vector3 scaleStart;


        public float timeStart;
        public float speed;

        public Fade(Vector3 sG, Vector3 sS, float time, float spd)
        {
            scaleGoal = sG;
            scaleStart = sS;
            timeStart = time;
            speed = spd;
        }

        public bool Step(Transform t)
        {
            float amount = (Time.time - timeStart) * speed;
            if (amount >= 1.0f)
            {
                t.localScale = scaleGoal;
                return true;
            }
            t.localScale = Vector3.Lerp(scaleStart, scaleGoal, amount);

            return false;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Manager = this;
        DontDestroyOnLoad(gameObject);

        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            NextLevel();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartFadeIn();
        }

        if (fading)
        {
            if (fade.Step(transform))
            {

                fading = false;

                if(transform.localScale.x > 0)
                {
                    SceneManager.LoadScene(GetCurrentLevel());
                    StartFadeOut();
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            NextLevel();
        }
    }
    public void StartFadeIn()
    {
        fade = new Fade(new Vector3(maxSize, maxSize, 1.0f), new Vector3(0, 0, 1), Time.time, fadeOutSpeed);

        fading = true;
    }
    public void StartFadeOut()
    {
        fade = new Fade(new Vector3(0, 0, 1.0f), new Vector3(maxSize, maxSize, 1), Time.time, fadeOutSpeed);

        fading = true;
    }
    public string GetCurrentLevel()
    {
        return levels[currentLevel];
    }

    public void NextLevel()
    {
        currentLevel += 1;
        if(currentLevel > levels.Count)
        {
            currentLevel = maxLevel;
        }
        StartFadeIn();
    }

}
