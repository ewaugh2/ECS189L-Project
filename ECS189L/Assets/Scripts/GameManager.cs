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
    private List<GameObject> players = new List<GameObject>();
    private List<GameObject> playersUi = new List<GameObject>();

    //Prefabs
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] public GameObject playerUi;
    [SerializeField] public GameObject zombiePrefab;

    //Tags
    private string zombiePortalTag = "ZombiePortal";

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
        startGame((int)SharedInfo.CrossSceneInformation[0] - '0');
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
        createSpawners(numPlayers);
        startGameInitialization(numPlayers);
        setGameState(GameState.playing);
    }

    //Initialize variables on game start
    private void startGameInitialization(int numPlayers)
    {
        this.numPlayers = numPlayers;
    }

    //Create spawners
    private void createSpawners(int numPlayers)
    {
        createPlayerSpawners(numPlayers);
        createZombieSpawners();
    }

    private void createPlayerSpawners(int numPlayers)
    {
        playerSpawner = new GameObject();
        playerSpawner.AddComponent<PlayerSpawner>();
        var spawner = playerSpawner.GetComponent<PlayerSpawner>();
        spawner.setPrefab(playerPrefab, playerUi);
        for (int i = 0; i < numPlayers; i++)
        {
            spawner.spawnPlayer();
        }
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name == "Player(Clone)")
            {
                players.Add(go);
            }
            if (go.name == "PlayerUi(Clone)")
            {
                playersUi.Add(go);
            }
        }
        var map = GameObject.Find("Map");
        if (numPlayers == 2)
        {
            players[0].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
            players[1].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
            playersUi[1].transform.position = map.transform.localPosition - new Vector3(-580, -20, 0);
        }
        else if (numPlayers == 3)
        {
            players[0].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            players[1].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
            players[2].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
            playersUi[1].transform.position = map.transform.localPosition - new Vector3(-580, -20, 0);
            playersUi[2].transform.position = map.transform.localPosition - new Vector3(135, 320, 0);
        }
        else if (numPlayers == 4)
        {
            players[0].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            players[1].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            players[2].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
            players[3].transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            playersUi[1].transform.position = map.transform.localPosition - new Vector3(-580, -20, 0);
            playersUi[2].transform.position = map.transform.localPosition - new Vector3(135, 320, 0);
            playersUi[3].transform.position = map.transform.localPosition - new Vector3(-580, 320, 0);
        }
    }

    private void createZombieSpawners()
    {
        var zombiePortals = GameObject.FindGameObjectsWithTag(zombiePortalTag);

        foreach(GameObject zombieportal in zombiePortals)
        {
            zombieportal.AddComponent<ZombieSpawner>();
            var zombiespawner = zombieportal.GetComponent<ZombieSpawner>();
            zombiespawner.setPrefab(zombiePrefab);
        }
    }

    //Change game state
    private void setGameState(GameState state)
    {
        gamestate = state;
    }


}
