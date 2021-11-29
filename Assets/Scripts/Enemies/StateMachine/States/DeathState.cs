using System.Collections;
using UnityEngine;

public class DeathState : State
{
    [SerializeField] private float _destroyDelay = 10f;

    private static int _animatorDeath = Animator.StringToHash("Death");

    private void Start()
    {
        Animator animator = Entity.GetComponent<Animator>();
        Collider2D collider = Entity.GetComponent<Collider2D>();
        Rigidbody2D rigidBody = Entity.GetComponent<Rigidbody2D>();

        animator.SetTrigger(_animatorDeath);
        rigidBody.isKinematic = true;
        collider.enabled = false;

        StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(_destroyDelay);
        Destroy(Entity.gameObject);
    }
}