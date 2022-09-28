using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAttributeTestScript : MonoBehaviour
{
    [AnimatorAnim]
    [SerializeField]
    private string moveLeftAnimation;
    [AnimatorAnim]
    [SerializeField]
    string moveUpAnimation;

    [SerializeField] Animator childAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
