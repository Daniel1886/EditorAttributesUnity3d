using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AnimatorAnimAttribute))]
public class AnimatorAnimDrower : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Component myComponent = property.serializedObject.targetObject as Component;
        Animator myAnimator = null;
        string[] clipsNames = new string[0];

        if(myComponent.gameObject.TryGetComponent<Animator>(out Animator animator))
        {
            myAnimator = animator;
        }
        if(myAnimator == null)
        {
            myAnimator = myComponent.GetComponentInChildren<Animator>();
        }
        if(myAnimator != null)
        {
            AnimationClip[] animationClips = myAnimator.runtimeAnimatorController.animationClips;
            clipsNames = new string[animationClips.Length];

            for(int i = 0; i < animationClips.Length; i++)
            {
                clipsNames[i] = animationClips[i].name;
            }
        }

        if (EditorGUI.DropdownButton(position, label, FocusType.Passive))
        {
            GenericMenu menu = new GenericMenu();
            foreach(var clipName in clipsNames)
            {
                menu.AddItem(new GUIContent(clipName), false, SelectValue, clipName);
            }
            menu.DropDown(position);
        }

        void SelectValue(object parameter)
        {
            string stringValue = parameter as string;
            if (!string.IsNullOrEmpty(stringValue))
            {
                property.stringValue = stringValue;
            }          
        }

        EditorUtility.SetDirty(myComponent);

    }
}
