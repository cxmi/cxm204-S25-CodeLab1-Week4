using UnityEngine;

public class Wasd : MonoBehaviour
{
    
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;
    public Vector3 scaleChange = new Vector3(-100f, -100f, 0);
    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if(Input.GetKey(keyRight)){
            //Move to the right
            pos.x += speed;
        }

        if(Input.GetKey(keyLeft)){
            //Move to the right
            pos.x -= speed;
        }

        if(Input.GetKey(keyUp)){
            //Move to the right
            pos.y += speed;
        }

        if(Input.GetKey(keyDown)){
            //Move to the right
            pos.y -= speed;
        }
        //set the transform.position to the new position 
        transform.position = pos;

        // if (GameManager.instance.Score > 0)
        // {
        //     ShrinkMatt();
        // }
        
    }

    public void ShrinkMatt()
    {
        gameObject.transform.localScale += scaleChange;
    }

    
}
