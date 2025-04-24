using System.Collections;
using System.Linq;
using UnityEngine;

public class AnimationToRagdoll2 : MonoBehaviour
{
    [SerializeField] Collider myCollider;
    [SerializeField] float respawnTime = 4f;
    public Rigidbody[] rigidbodies;
    bool bIsRagdoll = false;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        ToggleRagdoll(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Colisao detectada com: {collision.gameObject.name} - bisRagdoll: {bIsRagdoll}");

        //So ativa ragdoll se AINDA estiver animando
        if (collision.gameObject.CompareTag("Projectile") && !bIsRagdoll)
        {
            Debug.Log("Colidiu com projetil");
            ToggleRagdoll(false);
            StartCoroutine(GetBackUp());
        }
    }

    //Levantar
    private IEnumerator GetBackUp()
    {
        yield return new WaitForSeconds(respawnTime);
        animator.Play("Ladder_Up_End_InPlace");
        ToggleRagdoll(true);
    }

    void ToggleRagdoll(bool bisAnimating)
    {
        bIsRagdoll = !bisAnimating;
        myCollider.enabled = bisAnimating;

        foreach (Rigidbody ragdollBone in rigidbodies)
        {
            //Debug.Log($"{ragdollBone.name} isKinematic = {ragdollBone.isKinematic}");
            ragdollBone.isKinematic = bisAnimating;
        }

        GetComponent<Animator>().enabled = bisAnimating;
        if (bisAnimating)
        {
            Animation();
        }
    }

    void Animation()
    {
        
        animator.SetTrigger("Walk");

    }
}
