using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }


    public void FadeToLevel()
    {
        print("Start Animation");
        animator.SetBool("switch",true);
        SceneManager.LoadScene("SelectLevel", LoadSceneMode.Single);
    }
}
