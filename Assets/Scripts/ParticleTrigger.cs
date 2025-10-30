using System.Collections;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{

   public ParticleSystem particleSystemToEmit; // Assign your Particle System in the Inspector
   public bool once = true;
   private Rigidbody rb;
   public AudioSource myAudioSource;
   public AudioClip myClip;

   private void Start()
   {
      var em = particleSystemToEmit.emission;
      em.enabled = false;
      rb = GetComponent<Rigidbody>();
   }



   void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("World") && once)
      {
         var em = particleSystemToEmit.emission;
         em.enabled = true;
         rb.linearVelocity = Vector3.zero;
         rb.useGravity = false;
         gameObject.GetComponent<Renderer>().enabled = false;
         particleSystemToEmit.Play();
         once = false;
         myAudioSource.PlayOneShot(myClip);
         StartCoroutine(WaitForParticleSystemCompletion());
         Destroy(other.gameObject);
      }
   }
   IEnumerator WaitForParticleSystemCompletion()
   {
      while (particleSystemToEmit.isPlaying)
      {
         yield return null;
      }
      Debug.Log("Particle system animation is done!");

      Destroy(gameObject);

   }
}