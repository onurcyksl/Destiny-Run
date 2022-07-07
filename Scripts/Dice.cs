using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private bool diceTurning = false;
    private int diceRotateCounter;
    private int diceRotateChecker;
    private int diceRolledNumber;
    // Start is called before the first frame update
    void Start()
    {
        diceRotateCounter = 1;
        diceRotateChecker = 31;
    }

    public int getDiceSide() {
        return diceRolledNumber;
    }
    public void startDice()
    {
        diceTurning = true;
    }

    public bool getDiceTurning()
    {
        return diceTurning;
    }
    public void stopDice()
    {
        diceTurning = false;
        diceRolledNumber = setDice();
    }

    int setDice()
    {
        int newSide = 0;

        var XAngle = Mathf.Round(transform.rotation.eulerAngles.x);
        var ZAngle = Mathf.Round(transform.rotation.eulerAngles.z);

        if (XAngle % 360 == 0 && ZAngle % 360 == 0) newSide = 1;
        if (XAngle % 360 == 0 && ZAngle % 360 == 90) newSide = 2;
        if (XAngle % 360 == 0 && ZAngle % 360 == 180) newSide = 6;
        if (XAngle % 360 == 0 && ZAngle % 360 == 270) newSide = 5;

        if (XAngle % 360 == 90) newSide = 4;

        if (XAngle % 360 == 180 && ZAngle % 360 == 0) newSide = 5;
        if (XAngle % 360 == 180 && ZAngle % 360 == 90) newSide = 6;
        if (XAngle % 360 == 180 && ZAngle % 360 == 180) newSide = 1;
        if (XAngle % 360 == 180 && ZAngle % 360 == 270) newSide = 2;

        if (XAngle % 360 == 270) newSide = 3;


        return newSide;
    }

    // Update is called once per frame
    void Update()
    {
        if (!diceTurning) return; 
        if (diceRotateCounter % diceRotateChecker == 0)
        {
            int random = Random.Range(0, 2);
            

            if (random == 0)
                transform.Rotate(-90, 0, 0); // * Random(123)
                
            else
            {
                transform.Rotate(0, 0, 90); // * Random(123)
                diceRotateCounter = 0;
            }
        }
        diceRotateCounter++;
        
    }

}
