using UnityEngine;

public abstract class PlayerAComponent : MonoBehaviour
{
    protected Animator _animator;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    } 
}
