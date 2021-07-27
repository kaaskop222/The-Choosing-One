using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Transform movePoint;
    [SerializeField]
    private LayerMask obstacleMask;

    public Animator animator;

    public bool inCutScene = false;
    public bool inConversation = false;

    void Start() {
        movePoint.parent = null; // Detach partent
    }

    void Update() {
        float movementAmout = speed * Time.deltaTime;

        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);
        
        if(!inCutScene && !inConversation){
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f) {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                    Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                    animator.SetFloat("FaceHor", Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("FaceVert", 0);
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                    Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                    animator.SetFloat("FaceVert", Input.GetAxisRaw("Vertical"));
                    animator.SetFloat("FaceHor", 0);
                }
            }

            animator.SetFloat("Horizontal", (movePoint.position.x - transform.position.x));
            animator.SetFloat("Vertical", (movePoint.position.y - transform.position.y));
            animator.SetFloat("Speed", Vector3.Distance(movePoint.position, transform.position));
        }
    }

    private void Move(Vector3 direction) {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask)) {
            movePoint.position = newPosition;
        }
    }
}
