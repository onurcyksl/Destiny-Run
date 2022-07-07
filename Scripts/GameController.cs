using RedBjorn.ProtoTiles.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Camera cam1;
    [SerializeField] private Camera cam2;
    [SerializeField] private Dice playerDice;
    [SerializeField] private Dice enemyDice;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;

    public static int moveLeft;
    public static bool enemyMoveFinished = true;
    public static bool playerMoveFinished = false;
    //[SerializeField] private GameObject dice = null;

    public TurnState state;

    // Start is called before the first frame update
    void Start()
    {
        state = TurnState.START;
        StartCoroutine(SetupGame());
    }

    IEnumerator SetupGame()
    {
        //// Stuff ////
        yield return new WaitForSeconds(4f);

        state = TurnState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator PlayerRollDice()    
    {
        playerDice.startDice();
       
        yield return new WaitForSeconds(2f);
    }
    IEnumerator CanvasLocker()
    {
        yield return new WaitForSeconds(3);
 
    }
    void PlayerTurn()
    {
        OnRollDice();
        cam1.enabled = true;
        cam2.enabled = false;
        playerDice.GetComponent<MeshRenderer>().enabled = true;
        playerMoveFinished = false;
    }

    public void OnRollDice()
    {
        if (state != TurnState.PLAYERTURN)
            return;
        Debug.Log("PlayerTurn");
        
         
        StartCoroutine(PlayerRollDice());
    }
    IEnumerator EnemyTurn()
    {
        enemyDice.GetComponent<MeshRenderer>().enabled = true;
        int range = Random.Range(1, 7);
        Debug.Log("Enemy Turn");
        cam1.enabled = false;
        cam2.enabled = true;
        enemyDice.startDice();
        yield return new WaitForSeconds(range);
        enemyDice.stopDice();
        moveLeft = enemyDice.getDiceSide();
        //enemy.unitMove.onDiceStop();
        enemyMoveFinished = false;
        yield return new WaitForSeconds(7);
        state = TurnState.PLAYERTURN;
        enemyDice.GetComponent<MeshRenderer>().enabled = false;
        PlayerTurn();
    }

    IEnumerator PlayerLoses()
    {
        yield return new WaitForSeconds(2);
        LoseUI.SetActive(true);
        yield return new WaitForSeconds(10);
        Debug.Log("You have lost the game!");
        SceneLoader.LoadScene(0);
    }


    IEnumerator PlayerWins()
    {
        yield return new WaitForSeconds(2);
        WinUI.SetActive(true);
        yield return new WaitForSeconds(10);
        Debug.Log("You have won the game!");
        SceneLoader.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && state == TurnState.PLAYERTURN)
        {
            playerDice.stopDice();
            player.unitMove.onDiceStop();
            StartCoroutine(CanvasLocker());
        }

        if (playerMoveFinished == true && state == TurnState.PLAYERTURN)
        {
            state = TurnState.ENEMYTURN;
            playerDice.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(EnemyTurn());
        }

        if (PlayerCollider.winOrLose == 1)
        {
            state = TurnState.WON;
            StartCoroutine(PlayerWins());
        }

        if(PlayerCollider.winOrLose == 2)
        {
            state = TurnState.LOST;
            StartCoroutine(PlayerLoses());
        }

    }

}
