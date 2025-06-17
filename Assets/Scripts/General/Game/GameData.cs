using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager = new GameManager(gameSettings);
    }
}
