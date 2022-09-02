using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPick : MonoBehaviour
{
    public int SetSprite() {
        return Random.Range(0, 4);
    }
}
