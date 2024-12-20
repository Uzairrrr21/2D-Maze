using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    public int keys = 0;
    public float speed = 5.0f;
    public GameObject door;
    public Text keyAmount;
    public Text youwin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        // if (keys==3)
        // {
        //     Destroy(collision.gameObject(door));
        // }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag== "Keys")
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;

            keys++;
            keyAmount.text = "Keys: " + keys;
            
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag== "Gem")
        {
            youwin.text = "You Win!!!!!";
        }
        if(collision.gameObject.tag== "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
            //Debug.Log("Enemy Hit");
        }
         if (collision.gameObject.CompareTag("Door") && keys >= 3)
        {
            Destroy(collision.gameObject); // Destroy the door upon collision
            Debug.Log("Door destroyed!");
        }
        if(collision.gameObject.tag== "Walls")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}