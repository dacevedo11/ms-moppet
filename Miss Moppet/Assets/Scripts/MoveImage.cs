using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float duration = 1f;

    void Start()
    {
        LeanTween.moveX(gameObject, targetTransform.position.x, duration);
    }
}
