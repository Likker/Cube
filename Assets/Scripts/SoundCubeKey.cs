using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundCubeKey : MonoBehaviour {

    public AudioClip sound;

    void OnCollisionEnter()
    {
        float speed = rigidbody.velocity.magnitude / 10.0f;

        audio.PlayOneShot(sound, speed);
    }
}
