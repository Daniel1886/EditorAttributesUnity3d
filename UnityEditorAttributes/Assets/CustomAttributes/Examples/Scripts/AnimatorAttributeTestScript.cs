using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAttributeTestScript : MonoBehaviour
{
    [AnimatorAnim]
    [SerializeField]
    private string moveLeftAnimation;
    [AnimatorAnim("childAnimator2")]
    [SerializeField]
    string moveUpAnimation;
    [Space]
    [SerializeField] Animator childAnimator1;
    [Space]
    [SerializeField] Animator childAnimator2;
    void Start()
    {
             
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
