using System.Collections;
using System.Linq;
using UnityEngine;

public class AnimationToRagdoll : MonoBehaviour
{
    [SerializeField] Collider myCollider;
    [SerializeField] float respawnTime = 10f;
    public Rigidbody[] rigidbodies;
    bool bIsRagdoll = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
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
            RandomAnimation();
        }
    }

    void RandomAnimation()
    {
        int randomNum = Random.Range(0, 2);
        Debug.Log(randomNum);
        Animator animator = GetComponent<Animator>();

        if (randomNum == 0)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
