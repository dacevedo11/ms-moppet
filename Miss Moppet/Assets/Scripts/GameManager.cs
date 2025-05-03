using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas gameOverCanvas;
    
    public void ShowGameOver(float delay)
    {
        StartCoroutine(ShowCanvasAfterDelay(delay));
    }

    private IEnumerator ShowCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverCanvas.gameObject.SetActive(true);
    }
}
