using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using RestClient.Core.Models;

public class CircleScript : MonoBehaviour
{

    [SerializeField] private Transform circlePlace =null;

    private Vector2 initialPosition;

    private float deltaX, deltaY;

    public static bool locked ;
   // public static int point;

    public Text score;

    // Start is called before the first frame update

    void Start()
    {
        if (LevelController.isRestart)
        {
            locked = false;
        }
        initialPosition = transform.position;

       
    }

    // Update is called once per frame
    void Update()
    {
    

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - circlePlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - circlePlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(circlePlace.position.x, circlePlace.position.y);

                        if (!locked)
                        {
                            LevelController.points += 5;
                            score.text = LevelController.points.ToString();
                           locked = true;
                            SoundManagerScript.playSound("answerCorrect");
                            int child_id = SessionManagement.Instance.getChildID();
                            StartCoroutine(Main.Instance.web.setShapePoints(child_id, Int32.Parse(score.text)));
                        }



                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }
    }


}
