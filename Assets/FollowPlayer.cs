using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform objToFollow;
    RectTransform rectTransform;
    
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        if (objToFollow != null)
        {
            rectTransform.anchoredPosition = objToFollow.localPosition;
        }
    }
}
