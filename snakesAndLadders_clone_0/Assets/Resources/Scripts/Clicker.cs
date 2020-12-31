using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    bool highlighted = false;
    Color currentColor;
    public int indexX, indexY;

    gameManager gm;

    private void Start()
    {
        currentColor = GetComponent<SpriteRenderer>().color;
        gm = Camera.main.GetComponent<gameManager>();
    }




    void OnMouseOver()
    {
             
        
            if (Input.GetMouseButtonDown(0))
            {                
                Debug.Log("Horizontal: " + indexX + " " + indexY);                
            }                   


    }

    
}
