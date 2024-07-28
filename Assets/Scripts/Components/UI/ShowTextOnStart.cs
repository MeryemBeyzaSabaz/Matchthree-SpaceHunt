using UnityEngine;
using TMPro; 
using System.Collections;

public class ShowTextOnStart : MonoBehaviour
{
    public TextMeshProUGUI startText; // 
    public Animator textAnimator;

    void Start()
    {
        textAnimator.SetTrigger("ShowText");
        StartCoroutine(HideTextAfterDelay(2.0f)); 
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        startText.gameObject.SetActive(false);
    }
}