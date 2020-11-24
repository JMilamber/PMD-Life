using System.Linq;
using UnityEditor;
using UnityEngine;

public class NewTileMakingScript : MonoBehaviour
{

    public Texture2D SheetToDecode;

    public int numberOf3ColumnSets;

    private SpriteProcessor sProc = new SpriteProcessor();

    private Sprite[] sprites = new Sprite[2000];


    public void SliceAndAdd() {

        sProc.OnPostprocessTexture(SheetToDecode);
        sProc.OnPostprocessSprites(SheetToDecode, sprites);
        
    }

    public void CreateRuleTiles() {

    }
    

}
