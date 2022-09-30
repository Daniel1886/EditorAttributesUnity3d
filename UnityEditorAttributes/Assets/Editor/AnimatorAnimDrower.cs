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
        GUIContent selectedValueDisplay = new GUIContent(property.stringValue);

        AnimatorAnimAttribute propertyValue = attribute as AnimatorAnimAttribute;

        Rect labelPosition = position;
        Rect dropdownPostion = labelPosition;
        dropdownPostion.x = labelPosition.width / 2;

        string[] clipsNames = new string[0];

        myAnimator = GetSibilingPropertyValue<Animator>(property, propertyValue.animatorPropertyName);
        if (myAnimator == null && myComponent.gameObject.TryGetComponent<Animator>(out Animator animator))
        {
            myAnimator = animator;
        }
        if (myAnimator == null)
        {
            myAnimator = myComponent.GetComponentInChildren<Animator>();
        }
        if (myAnimator != null)
        {
            AnimationClip[] animationClips = myAnimator.runtimeAnimatorController.animationClips;
            clipsNames = new string[animationClips.Length];

            for (int i = 0; i < animationClips.Length; i++)
            {
                clipsNames[i] = animationClips[i].name;
            }
        }


        EditorGUI.LabelField(position, property.displayName);
        if (EditorGUI.DropdownButton(dropdownPostion, selectedValueDisplay, FocusType.Passive))
        {
            GenericMenu menu = new GenericMenu();
            foreach (var clipName in clipsNames)
            {
                menu.AddItem(new GUIContent(clipName), false, SelectValue, clipName);
            }
            menu.DropDown(dropdownPostion);
        }


        void SelectValue(object parameter)
        {
            string stringValue = parameter as string;
            if (!string.IsNullOrEmpty(stringValue))
            {
                property.stringValue = stringValue;
                property.serializedObject.ApplyModifiedProperties();
            }
        }


        EditorUtility.SetDirty(myComponent);
    }

    public T GetSibilingPropertyValue<T>(SerializedProperty root, string propertyName)
    {
        if (string.IsNullOrEmpty(propertyName))
           return default;

        SerializedProperty animatorProperty = root.serializedObject.FindProperty(propertyName);
        if (animatorProperty == null)
            return default;

        object animatorComponent = animatorProperty.objectReferenceValue;
        return (T)animatorComponent;

    }
}
