using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class AnimatorAnimAttribute : PropertyAttribute
{
    public string animatorPropertyName;

    public AnimatorAnimAttribute()
    {
        
    }
    public AnimatorAnimAttribute(string animatorPropertyName)
    {
        this.animatorPropertyName = animatorPropertyName;
    }
}
