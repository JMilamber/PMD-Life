using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
class NewTileMakingScriptEditor : MonoBehaviour
{
    public bool SliceAndAdd; //"run" or "generate" for example
    public bool CreateRuleTiles; //supports multiple buttons

    private NewTileMakingScript NTMS;

    private void Start()
    {
        NTMS = GameObject.Find("Dungeon Grid").GetComponent<NewTileMakingScript>();
    }

    void Update()
    {
        if (SliceAndAdd)
            ButtonSliceAndAdd();
        else if (CreateRuleTiles)
            ButtonCreateRuleTiles();
        SliceAndAdd = false;
        CreateRuleTiles = false;
    }

    public void ButtonSliceAndAdd()
    {
        NTMS.SliceAndAdd();
    }

    public void ButtonCreateRuleTiles()
    {
        //DoStuff
    }
}
