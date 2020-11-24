using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldMovement : MonoBehaviour
{

    private GameObject player_obj;
    private Player player;
    private GameObject MovePoint;

    private Vector3 new_position;
    private float horizontal = 0;
    private float vertical = 0;
    private Vector2 movement;
    private bool isMoving = false;
    private float direction;
    private int move = -1;
    private float speed = 5f;

    public Transform movePoint;
    private Animator animator;
    public LayerMask wall_Layer;
    public Rigidbody2D rb;


    private void Start()
    {
        player_obj = GameObject.Find("Player");
        player = player_obj.GetComponent<Player>();
        animator = player_obj.GetComponent<Animator>();

        MovePoint = new GameObject("movePoint");
        MovePoint.transform.position = player_obj.transform.position;
        player_obj.GetComponent<OverworldMovement>().movePoint = MovePoint.transform;

        wall_Layer = player.wall_Layer;

        new_position = player_obj.transform.position;
    }

    public void FixedUpdate()
    {
        if (player.isWalkable(movePoint.position))
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
            animator.SetBool("IsMoving", true);
            player.movePlayerCamera(movePoint.position);

        }
        else
        {
            movePoint.position = player_obj.transform.position;
            animator.SetBool("IsMoving", false);
        }
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)) {
            move = 0;
            horizontal = 0;
            vertical = 0;
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            switch (Input.GetAxisRaw("Horizontal")) {
                case -1:
                    horizontal = -1;
                    break;
                case 1:
                    horizontal = 1;
                    break;
                default:
                    break;
            }
            switch(Input.GetAxisRaw("Vertical")) {
                case -1:
                    vertical = -1;
                    break;
                case 1:
                    vertical = 1;
                    break;
                default:
                    break;
            }
        } 
        if (Vector3.Distance(player_obj.transform.position, movePoint.position) == 0) {
            isMoving = false;
            horizontal = 0;
            vertical = 0;
        } else {
            isMoving = true;
            
        }
        
    }
}
