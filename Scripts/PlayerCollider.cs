using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public static int winOrLose = 0 ;

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player1")
        {
            winOrLose = 1;
            Debug.Log("Player Wins");          
        }
        if (col.gameObject.tag == "Enemy")
        {
            winOrLose = 2;
            Debug.Log("Enemy Wins");
        }
    }
}
