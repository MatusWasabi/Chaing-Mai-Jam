using UnityEngine;
using UnityEngine.UI;

public class MenuResultDisplay : MonoBehaviour
{
    [SerializeField] private Image[] finishedOrders;

    private int orderCount = 0;

    private void Awake()
    {
        foreach (var order in finishedOrders)
        {
            order.sprite = null;
        }
    }

    private void Start()
    {
        CombinationBar.OnMenuCreated += HandleOrderFinished;
    }

    private void HandleOrderFinished(Sprite sprite)
    {
        finishedOrders[orderCount].sprite = sprite;
        orderCount++;
    }

    private void OnDestroy()
    {
        CombinationBar.OnMenuCreated -= HandleOrderFinished;
    }
}
