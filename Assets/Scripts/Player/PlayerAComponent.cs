using UnityEngine;

public abstract class PlayerAComponent : MonoBehaviour
{
    protected Animator _animator;
    protected Rigidbody2D _rb;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    } 
}
