using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float jumpforce;
    public float gravityModifier;
    void Start() {
     playerRb = GetComponent<Rigidbody>();
     Physics.gravity *= gravityModifier; }

    // Update is called once per frame
    public bool isOnGround = true;
    void Update(){
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
      playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
      isOnGround = false; } }

    private void OnCollisionEnter(Collision collision) {
     isOnGround = true; }
} 