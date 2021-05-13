using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public Animator animator;
    public void FadeToLevel()
    {
        print("Start Animation");
        StartCoroutine(WaitForFadeOutAnimation());
    }

    public IEnumerator WaitForFadeOutAnimation()
    {
        animator.SetBool("switch",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("SelectLevel", LoadSceneMode.Single);
    }
}
