using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    public float range = 5;
    
    void OnMouseDown()
    {
        //TODO make this function do something for real
        //throw new NotImplementedException();
       
        GameManager.instance.Score++;
        
        transform.position = new Vector3(
            Random.Range(-range, range),
            Random.Range(-range, range),
            0); // could also just use Vector2 or leave out the z in Vector3

    }
}
