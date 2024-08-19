using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text score;
    public Transform player;
    public Transform ground;

    public float dist1;
    
    public int high = 0;

    
    
    void Start()
    {
       dist1 = 0;
       score.text = "Score: " + dist1.ToString("0");
    }
    void FixedUpdate()
    {
        
        float dist2 = player.position.x;
        if(dist2 > dist1){
            dist1 = dist2;
            score.text = "Score: " + dist1.ToString("0");
        }
        
       /*(if (Vector3.Distance(player.position, ground.position) < 606)
       {
           high = high + 1;
           score.text = high.ToString();
       }
       */
        
    }

    
       
} 
