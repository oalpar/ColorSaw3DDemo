using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetector : MonoBehaviour
{
    bool isWon=false;

    void Update()
    {
        if(IsWon()&&!isWon)
        {
            isWon=true;
            GameObject.FindGameObjectsWithTag("UI")[0].GetComponent<UIScript>().LoadWinScreen();
        }
    }
    bool IsWon()
    {
        foreach ( GameObject col in GameObject.FindGameObjectsWithTag("Collection"))
        {
            if(col.gameObject.GetComponent<DeleteUnconnectedNodes>().won==false)
                return false;
        }
        return true;
    }
}
