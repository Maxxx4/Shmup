using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private Animator animator;
    [SerializeField] AudioSource explosionSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //If the animation is not playing, destroy the object
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("explosionAnimation"))
        {
            explosionSound.Play();
            Destroy(gameObject);
        }
    }
}
