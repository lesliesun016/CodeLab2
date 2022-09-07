using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildBroad : MonoBehaviour
{
    public Sprite ring;
    private GameObject[] blocks = new GameObject[42];
    private int column_store = -4;
    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        for (int i = 0; i < 7; i++) {
            for (int j = 0; j < 6; j++) {
                GameObject go = new GameObject("Block");
                SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                renderer.sprite = ring;
                go.transform.position = new Vector3(i - 3, j - 3, 0);
                blocks[index] = go;
                index += 1;
            }
        }
    }

    public void Update()
    {
        int column = GetComponent<CheckMouse>().getColumn();

        if (column != column_store & column <= 3 & column >= -3)
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                GameObject block = blocks[i];
                SpriteRenderer renderer = block.GetComponent<SpriteRenderer>();
                renderer.color = Color.white;
            }
            for (int i = 0; i < 6; i++)
            {
                GameObject block = blocks[(column + 3) * 6 + i];
                SpriteRenderer renderer = block.GetComponent<SpriteRenderer>();
                renderer.color = Color.black;
            }
        }
        
    }

}
