using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator_controller : MonoBehaviour
{
    
    public GameObject prefab;
    public float delay;
    float first_time,end_time;
    void Start()
    {
        first_time = Time.time;
        end_time = Time.time + delay;
    }

    void FixedUpdate()
    {
        Debug.Log(end_time - first_time);
        if(end_time - first_time >= delay) 
        {
            Vector3 pos = new Vector3(this.transform.position.x,this.transform.position.y,0);
            Instantiate(prefab,pos,Quaternion.identity);
            first_time = Time.time;
            end_time = Time.time;
        }
        end_time += 1;
    }
}
