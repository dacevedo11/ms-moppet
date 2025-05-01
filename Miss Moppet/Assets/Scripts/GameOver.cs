using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float duration;
    [SerializeField] LeanTweenType easeType;

    void Start()
    {
        LeanTween.moveX(gameObject, targetTransform.position.x, duration).setEase(easeType);
    }
    
    
}
