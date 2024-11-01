using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimatorController
{
    private Animator _animator;

    private List<AnimationClip> _animations;

    public CharacterAnimatorController(Animator animator, Enum states)
    {
        _animator = animator;

        _animations = new List<AnimationClip>();

        foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
        {
            _animations.Add(clip);
        }

        List<string> animationNames = new List<string>();

        foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
        {
            animationNames.Add(clip.name);
        }

        for (int i = 0; i < states.GetType().GetEnumNames().Length; i++)
        {
            if (animationNames.Contains(states.GetType().GetEnumName(i)) == false)
                Debug.LogWarning($"Need to Add Animation {states.GetType().GetEnumName(i)} to {_animator.name}");
        }
    }

    public void SetAnimation(string name)
    {
        if(_animations.Find((x) => x.name == name))
            _animator.Play(name);
        else
            Debug.LogWarning($"No Animation {name} in Animator {_animator.name}");
    }
}
