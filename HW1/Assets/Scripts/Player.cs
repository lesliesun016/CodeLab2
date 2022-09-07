using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject ui;

    private int turn = 0; // 0 - yellow, 1 - red; by default, yellow starts first
    private bool winner = false;

    private void OnMouseDown()
    {
        if (!winner)
        {
            int column = GetComponent<CheckMouse>().getColumn();
            if (column <= 3 & column >= -3)
            {
                GetComponent<CheckBroadIndex>().insertCircle(column, turn);
                winner = GetComponent<CheckBroadIndex>().checkWinner(turn);

                if (winner)
                {
                    if (turn == 0)
                    {
                        ui.GetComponent<Text>().text = "yellow wins!!!";
                        ui.GetComponent<Text>().color = new Color(1, 0.73f, 0);
                    } else
                    {
                        ui.GetComponent<Text>().text = "red wins!!!";
                        ui.GetComponent<Text>().color = Color.red;
                    }
                } else
                {
                    if (turn == 0)
                    {
                        turn = 1;
                        ui.GetComponent<Text>().text = "red's turn";
                        ui.GetComponent<Text>().color = Color.red;
                    }
                    else
                    {
                        turn = 0;
                        ui.GetComponent<Text>().text = "yellow's turn";
                        ui.GetComponent<Text>().color = new Color(1, 0.73f, 0);
                    }
                }
                
            }
        }
    }
}
