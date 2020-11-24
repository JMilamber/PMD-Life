using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEditorInternal;
using System.IO;

public class SpriteProcessor : AssetPostprocessor
{

    private List<SpriteMetaData> metas;
    private SpriteMetaData meta;

    public void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.spriteImportMode = SpriteImportMode.Multiple;
        textureImporter.mipmapEnabled = false;
        textureImporter.filterMode = FilterMode.Point;

    }

    public void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("Texture2D: (" + texture.width + "x" + texture.height + ")");



        int spriteSize = 24;
        int colCount = texture.width / spriteSize;
        int rowCount = texture.height / spriteSize;

        metas = new List<SpriteMetaData>();
        

        for (int r = 0; r < rowCount; ++r)
        {
            for (int c = 0; c < colCount; ++c)
            {
                meta = new SpriteMetaData();
                meta.rect = new Rect(c * spriteSize, r * spriteSize, spriteSize, spriteSize);
                meta.name = c + "-" + r;
                metas.Add(meta);
            }
        }

        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.spritesheet = metas.ToArray();
    }

    public void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {
        Debug.Log("Sprites: " + sprites.Length);
    }
}