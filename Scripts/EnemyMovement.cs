using System.Collections;

using UnityEngine;



public enum MovementState { RUN, STOP}
public class EnemyMovement : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField] public Animator enemyAnim;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;
    private MovementState state;
    // Use this for initialization
    private void Start()
    {
        state = MovementState.STOP;
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameController.enemyMoveFinished == false)
        {
            state = MovementState.RUN;
            RunningTime();
        }
        if(state == MovementState.STOP)
        {
            enemyAnim.SetBool("isEnemyRunning", false);
        }
    }

    IEnumerator RunRun()
    {
        yield return new WaitForSeconds(0);
        enemyAnim.SetBool("isEnemyRunning", true);
        Move(GameController.moveLeft);
    }

    void RunningTime()
    {
        state = MovementState.RUN;
        StartCoroutine(RunRun()); 
    }


    // Method that actually make Enemy walk
    public void Move(int movesLeft)
    {

        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            if(movesLeft+waypointIndex >= waypoints.Length)
            {
                movesLeft = waypoints.Length - waypointIndex-1;
            }
            transform.position = Vector3.MoveTowards(transform.position,
               waypoints[movesLeft+waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
            


            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position.x == waypoints[movesLeft + waypointIndex].transform.position.x && transform.position.z == waypoints[movesLeft + waypointIndex].transform.position.z)
            {
                waypointIndex += movesLeft;
                state = MovementState.STOP;
                GameController.enemyMoveFinished = true;
            }
        }
    }
}