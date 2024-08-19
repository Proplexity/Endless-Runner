using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float turnSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.activeSelf)
        {
            Destroy(gameObject);
        }

        GameManager.instance.IncrementScore();
        Debug.Log("pussy");
   
    }
   
    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
        
    }
}
