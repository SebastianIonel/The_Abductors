using UnityEngine;
using UnityEngine.UI;

public class SpriteChangerShip : MonoBehaviour
{
    public Image circuit;


    // Start is called before the first frame update
    void Start()
    {
        circuit.gameObject.SetActive(false);
    }

    public void DisplayPuzzle()
    {
        // Make sure the sprite is visible
        circuit.gameObject.SetActive(true);
    }

    public void HidePuzzle()
    {
        circuit.gameObject.SetActive(false);
    }

    public bool IsPuzzleActive()
    {
        return circuit.gameObject.activeSelf;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
