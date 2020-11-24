using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMovement : MonoBehaviour
{
    private GameObject player_obj;
    private Player player;
    private GameObject MovePoint;

    private Vector3 new_position;
    private int horizontal = 0;
    private int vertical = 0;
    private bool isMoving = false;
    private float direction;
    private int move = -1;
    private float speed = 2.5f;

    public Transform movePoint;
    private Animator animator;
    public LayerMask wall_Layer;

    // Start is called before the first frame update
    void Start()
    {
        player_obj = GameObject.Find("Player");
        player = player_obj.GetComponent<Player>();
        animator = player_obj.GetComponent<Animator>();

        MovePoint = new GameObject("movePoint");
        MovePoint.transform.position = player_obj.transform.position;
        player_obj.GetComponent<DungeonMovement>().movePoint = MovePoint.transform;

        wall_Layer = player.wall_Layer;

        new_position = player_obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isWalkable(movePoint.position))
        {
            player_obj.transform.position = Vector3.MoveTowards(player_obj.transform.position, movePoint.position, speed * Time.deltaTime);
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
            animator.SetBool("IsMoving", isMoving);
            player.movePlayerCamera(movePoint.position);

        }
        else
        {
            movePoint.position = player_obj.transform.position;
        }


        move++;
        if (Vector3.Distance(player_obj.transform.position, movePoint.position) == 0f && move >= 15)
        {
            isMoving = false;

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                move = 0;
                vertical = 0;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                switch (Input.GetAxisRaw("Horizontal"))
                {
                    case -1:
                        horizontal = -1;
                        break;
                    case 1:
                        horizontal = 1;
                        break;
                    default:
                        break;
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                move = 0;
                horizontal = 0;
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                switch (Input.GetAxisRaw("Vertical"))
                {
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
        }
        else if (Vector3.Distance(player_obj.transform.position, movePoint.position) > 0)
        {
            isMoving = true;
        }
    }
}
