using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    private Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        hpText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        hpText.text = "99";
    }
}
