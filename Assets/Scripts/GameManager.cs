using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RandomScenary boardScript;
    private int level = 3;


    void Awake()
    {
        
        boardScript.SetupScene(level);
    }
}
