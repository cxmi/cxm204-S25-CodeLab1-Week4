using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    public float range = 5;
    [SerializeField] private Wasd wasd;

    
    void OnTriggerEnter2D(Collider2D other)
    {
  
    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("COLLISION");
        //Debug.Log(other.gameObject.name);
        //TODO make this function do something for real
        //throw new NotImplementedException();
       
        GameManager.instance.Score++;
        wasd.ShrinkMatt();
        
        transform.position = new Vector3(
            Random.Range(-range, range),
            Random.Range(-range, range),
            0); // could also just use Vector2 or leave out the z in Vector3
    }
}
