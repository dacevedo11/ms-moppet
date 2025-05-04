using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceToJump : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DisableAfterSeconds(4f));
    }

    IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
