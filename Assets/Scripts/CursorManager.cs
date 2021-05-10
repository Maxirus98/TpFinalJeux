using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public List<Texture2D> texture2Ds;

     void Start()
    {
        DefaultCursor();
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(texture2Ds[0],new Vector2(4,8),CursorMode.ForceSoftware);
    }
    
}

    
    
