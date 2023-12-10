using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float gravity = 19.62f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private AndroidControls jump;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource loseSound;

    private CharacterController character;
    private Vector3 direction;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;


#if UNITY_ANDROID
            if(jump.isClicked) {
                direction = Vector3.up * jumpForce;
                jumpSound.Play();
            }
#endif
#if PLATFORM_STANDALONE
            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
                jumpSound.Play();
            }
#endif
            
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.gameOver();
            loseSound.Play();
        }
    }
}
