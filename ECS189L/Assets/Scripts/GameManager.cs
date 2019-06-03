using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Instance
    private static GameManager instance = null;

    //Spawners
    private GameObject playerSpawner;
    private GameObject zombieSpawner;

    //Prefabs
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] public GameObject zombiePrefab;

    //Game state
    private enum GameState
    {
        titleScreen,
        playing,
        gameOver
    }
    GameState gamestate;

    //Number of players
    private int numPlayers;

    private GameManager()
    {

    }

    //Called before start
    private void Awake()
    {
        Initialize();
    }

    //Initialize
    private void Initialize()
    {
        //Set instance to this if null, otherwise destroy this
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gamestate = GameState.titleScreen;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started!");
        startGame(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Return game manager instance (create one if it doesn't exist)
    public static GameManager getInstance()
    {
        if(instance == null)
        {
            instance = new GameManager();
        }

        return instance;
    }

    //Start the game
    public void startGame(int numPlayers)
    {
        createSpawners();
        startGameInitialization(numPlayers);
        setGameState(GameState.playing);
    }

    //Initialize variables on game start
    private void startGameInitialization(int numPlayers)
    {
        this.numPlayers = numPlayers;
    }

    //Create spawners
    private void createSpawners()
    {
        playerSpawner = new GameObject();
        playerSpawner.AddComponent<PlayerSpawner>();

        var spawner = playerSpawner.GetComponent<PlayerSpawner>();
        spawner.setPrefab(playerPrefab);
        spawner.spawnPlayer();
    }

    //Change game state
    private void setGameState(GameState state)
    {
        gamestate = state;
    }

    
}
