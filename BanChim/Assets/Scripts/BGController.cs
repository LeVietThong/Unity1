using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : Singleton<BGController>
{
    public Sprite[] sprites;
    public SpriteRenderer bgImage;
    public override void Awake()
    {
        MakeSingleton(false); //ko luu du lieu BGController khi load sang scene moi
    }

    private void Start()
    {
        ChangeSprite();
    }

    public void ChangeSprite() //thay doi hinh anh
    {
        if(bgImage != null && sprites !=null && sprites.Length > 0)
        {
            int randomIdx = Random.Range(0, sprites.Length); //lay ngau nhien

            if (sprites[randomIdx] != null )
            {
                bgImage.sprite = sprites[randomIdx];
            }
        }
    }
}
