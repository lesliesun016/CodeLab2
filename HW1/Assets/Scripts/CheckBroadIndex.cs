using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CheckBroadIndex : MonoBehaviour
{
    public Sprite yellow;
    public Sprite red;

    private int[] indices = new int[42];
    private void Start()
    {
        for (int i = 0; i < indices.Length; i++)
        {
            indices[i] = -1;
        }
    }
    public bool insertCircle(int column, int player_code)
    {
        bool inserted = false;

        int i = column + 3;
        while (!inserted & i < indices.Length) {
            if (indices[i] == -1)
            {
                indices[i] = player_code;
                inserted = true;

                GameObject circle = new GameObject("Circle");
                SpriteRenderer renderer = circle.AddComponent<SpriteRenderer>();
                if (player_code == 0)
                {
                    renderer.sprite = yellow;
                    
                } else
                {
                    renderer.sprite = red;
                }
                int row = (int) Mathf.Floor(i / 7) - 3;
                circle.transform.position = new Vector3(column, row, 0);
            } else
            {
                i += 7;
            }
        }
        return inserted;
    }

    public bool checkWinner(int player_code)
    {
        bool result = false;
        // horizontal
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                int pos1 = indices[i * 7 + j];
                int pos2 = indices[i * 7 + j + 1];
                int pos3 = indices[i * 7 + j + 2];
                int pos4 = indices[i * 7 + j + 3];
                if (pos1 == pos2 & pos2 == pos3 & pos3 == pos4 & pos4 == player_code)
                {
                    result = true;
                    break;
                }
            }
        }
        // vertical
        if (!result)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int pos1 = indices[i + j * 7];
                    int pos2 = indices[i + (j + 1) * 7];
                    int pos3 = indices[i + (j + 2) * 7];
                    int pos4 = indices[i + (j + 3) * 7];
                    if (pos1 == pos2 & pos2 == pos3 & pos3 == pos4 & pos4 == player_code)
                    {
                        result = true;
                        break;
                    }
                }
            }
        }
        //diagonal
        if (!result)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int pos1 = indices[i + j * 7];
                    int pos2 = indices[i + j * 7 + 8];
                    int pos3 = indices[i + j * 7 + 8 * 2];
                    int pos4 = indices[i  + j * 7 + 8 * 3];
                    if (pos1 == pos2 & pos2 == pos3 & pos3 == pos4 & pos4 == player_code)
                    {
                        result = true;
                        break;
                    }
                }
            }

            for (int i = 3; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int pos1 = indices[i + j * 7];
                    int pos2 = indices[i + j * 7 + 6];
                    int pos3 = indices[i + j * 7 + 6 * 2];
                    int pos4 = indices[i + j * 7 + 6 * 3];
                    if (pos1 == pos2 & pos2 == pos3 & pos3 == pos4 & pos4 == player_code)
                    {
                        result = true;
                        break;
                    }
                }
            }
        }
        

        return result;
    }
}
