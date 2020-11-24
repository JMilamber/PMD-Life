using UnityEngine;
using CodeMonkey.MonoBehaviours;
using UnityEditor.Animations;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private CameraFollow cameraFollow;
    private Vector3 cameraPosition;
    private float orthoSize = 4f;

    private GameObject player_obj;
    private GameObject MovePoint;
    private Pokemon player;

    private Vector3 new_position;
    private int horizontal = 0;
    private int vertical = 0;
    private bool isMoving = false;
    private float direction;
    private int move = -1;
    private float speed = 2.5f;
    

    private Animator animator;
    public LayerMask wall_Layer;



    // Start is called before the first frame update
    void Start()
    {
        player_obj = GameObject.Find("Player");
        if (SceneManager.GetActiveScene().name == "Test Dungeon")
        {
            player_obj.transform.position = new Vector3(6.5f, -.5f, 0);
            cameraPosition = new Vector3(6.5f, -.5f);
        }
        else
        {
            player_obj.transform.position = new Vector3(.5f, -.5f, 0);
            cameraPosition = new Vector3(.5f, -.5f);
        }
        
        cameraFollow.Setup(() => cameraPosition, () => orthoSize, true, true);

        
        
        player = new Pokemon(player_obj);
        animator = player_obj.AddComponent<Animator>();

        player.set_Pokemon_Number(1);
        player.set_Pokemon_Name("Bulbasaur");
        player.set_Position(player_obj.transform.position);

        if (SceneManager.GetActiveScene().name == "Dungeon") {
            player_obj.AddComponent<DungeonMovement>();
        } else {
            player_obj.AddComponent<OverworldMovement>();
        }


        if (SceneManager.GetActiveScene().name == "Test Dungeon")
        {
            try
            {
                Destroy(player_obj.GetComponent<OverworldMovement>());
            }
            catch (System.Exception)
            {
            }
            player_obj.AddComponent<DungeonMovement>();
        }

            //new_position = player_obj.transform.position;
        switch (player.get_Pokemon_Number())
        {
            case 1:
                animator.runtimeAnimatorController = Resources.Load<AnimatorController>("Animations/Player 1");
                break;
            default:
                animator.runtimeAnimatorController = Resources.Load<AnimatorController>("Animations/Player 1");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q")) {

        }
       
    }

    public bool isWalkable(Vector3 position) {
       if (Physics2D.OverlapCircle(position, .3f, wall_Layer) != null) {
            return false;
       }
       return true;
    }

    public void movePlayerCamera(Vector3 place) {
        cameraPosition = place;
    }
}
