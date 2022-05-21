using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    //Close the game.
    public void Close()
    {
        Application.Quit();
        Debug.Log("Closed");
    }
}
