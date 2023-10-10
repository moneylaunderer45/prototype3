using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    private Animator playerAnim;
    void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier; }

// Update is called once per frame
public bool isOnGround = true;
    void Update(){
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
          playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          isOnGround = false;
          playerAnim.SetTrigger("Jump_trig"); } 

    public bool gameOver = false;
    private void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.CompareTag("Ground"))
     {
      isOnGround = true;
     }
     else if (collision.gameObject.CompareTag("Obstacle")) {
      gameOver = true;
      Debug.Log("Game Over!"); } }
} 