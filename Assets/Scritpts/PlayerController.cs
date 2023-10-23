using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    private Animator playerAnim;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>(); }

    // Update is called once per frame
    public bool isOnGround = true;
    public ParticleSystem dirtParticle; 
    void Update() {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
        dirtParticle.Stop(); 
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, 1.0f); } }

    public ParticleSystem explosionParticle; 
    public bool gameOver = false;

    private void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.CompareTag("Ground")) {
        isOnGround = true;
        dirtParticle.Play();
      } else if (collision.gameObject.CompareTag("Obstacle")) {
             explosionParticle.Play();
             dirtParticle.Stop();
             Debug.Log("Game Over!");
             gameOver = true;
             playerAnim.SetBool("Death_b", true);
             playerAnim.SetInteger("DeathType_int", 1);
             playerAudio.PlayOneShot(crashSound, 1.0f); } } 
} 