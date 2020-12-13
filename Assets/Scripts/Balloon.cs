using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Balloon : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] balloonSprites;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = balloonSprites[Random.Range(0, 3)];

        transform.position = new Vector3(Random.Range(-2.91f, 2.91f), transform.position.y, transform.position.z);

        force = new Vector3(Random.Range(-100,100), Random.Range(150,250), 0);

        rb.AddForce(force);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "topWall")
        {
            
            Destroy(this.gameObject);
            int point = PopController.missedPop += 1;
            PopController.Instance.miss.text = point.ToString();
        }
    }

    void OnMouseDown()
    {
   

        
        Destroy(gameObject);
        int point = PopController.points += 1;
        PopController.Instance.score.text= point.ToString();
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.setColorPoints(child_id, System.Int32.Parse(PopController.Instance.score.text)));
    }
}
