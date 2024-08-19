using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    Movement m_movement;

    private void Start()
    {
        m_movement = GameObject.FindObjectOfType<Movement>(); 
    }
   

     void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.name == "Player" )
        {
            m_movement.Die();
            SceneManager.LoadScene(0);

        }
    }
     
}
