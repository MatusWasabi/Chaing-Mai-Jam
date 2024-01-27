using UnityEngine;
using UnityEngine.UI;

public class ChoiceObject : MonoBehaviour
{ 
    [SerializeField] private CombinationBar combinationBar;
    private Sprite _sprite;

    private void Awake()
    {
        _sprite = gameObject.GetComponent<Image>().sprite;
    }

    public void AddToCombinationSlot()
    {
        combinationBar.AddToSlot(gameObject.name, gameObject.GetComponent<Image>().sprite);
    }
    
    
}
