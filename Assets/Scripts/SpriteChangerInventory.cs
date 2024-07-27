using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChangerInventory : MonoBehaviour
{
    public Image targetImage; // The Image component on the Canvas
    // private Sprite newSprite; // The new Sprite to be added

    void Start()
    {
        if (targetImage == null)
        {
            Debug.LogError("Target Image is not assigned.");
        }

       
    }

    // Call this method to change the sprite
    public void ChangeSprite(GameObject resistanceObj)
    {
        if (targetImage != null)
        {
            // add for every resistance a sprite
            Resistance newSprite = resistanceObj.GetComponent<Resistance>();
            targetImage.sprite = newSprite.sprite;
        }
    }
}
