using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class MapController : MonoBehaviour {

    [SerializeField] Transform wallPrefab;
    [SerializeField] Transform groundPrefab;
    [SerializeField] Transform startPointPrefab;
    [SerializeField] Transform endPointPrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject opponentPrefabX;
    [SerializeField] GameObject opponentPrefabY;
    private Transform temp;
    private GameObject go;
    public static Vector3 originalPosition;

    public bool playerPresent = false;
    private GameObject player;
    private GameObject opponentX;
    private GameObject opponentY;
    public static int count = 0;

    public const string WALL = "X";
    public const string GROUND = "O";
    public const string START = "S";
    public const string END = "E";
    public const string OPPONENTX = "Z";
    public const string OPPONENTY = "Y";

    private string[] level = new string[5];

    public void Init()
    {
        level[0] = "Level1.txt";
        level[1] = "Level2.txt";
        level[2] = "Level3.txt";
        level[3] = "Level4.txt";
        level[4] = "Level5.txt";
        go = new GameObject("InstanceContainer");
        go.transform.parent = GameObject.Find("MapController").transform;
        playerPresent = false;
        LevelLoad();
    }

	void Start () {
        Init();
    }

    string[][] ReadFile(string mapFile)
    {
        string text = System.IO.File.ReadAllText(mapFile);
        string[] lines = Regex.Split(text, "\r\n");
        int rows = lines.Length;

        string[][] levelData = new string[rows][];
        for(int i=0;i<rows;i++)
        {
            string[] eachStringInRow = Regex.Split(lines[i], " ");
            levelData[i] = eachStringInRow;
        }

        return levelData;
    }

    public void LevelLoad()
    {
        string[][] levelData = ReadFile("D:/Assignment Unity 2/StealthGame/StealthGame/Assets/LevelText/"
            + level[count]);
        for (int x = 0; x < levelData.Length; x++)
        {
            for (int y = 0; y < levelData[0].Length; y++)
            {
                switch (levelData[x][y])
                {
                    case WALL:
                        temp = Instantiate(wallPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        temp.parent = go.transform;
                        break;
                    case START:
                        originalPosition = new Vector3(y, -x, -0.8f);
                        temp = Instantiate(startPointPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        temp.parent = go.transform;
                        if (playerPresent == false)
                        {
                            player = Instantiate(playerPrefab, new Vector3(y, -x, -0.8f),
                                Quaternion.identity);
                            playerPresent = true;
                            player.transform.parent = go.transform;
                        }
                        break;
                    case OPPONENTX:
                        temp = Instantiate(groundPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        temp.parent = go.transform;
                        opponentX = Instantiate(opponentPrefabX, new Vector3(y, -x, -0.8f), 
                            Quaternion.identity);
                        opponentX.transform.parent = go.transform;
                        break;
                    case OPPONENTY:
                        temp = Instantiate(groundPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        temp.parent = go.transform;
                        opponentY = Instantiate(opponentPrefabY, new Vector3(y, -x, -0.8f), 
                            Quaternion.identity);
                        opponentY.transform.parent = go.transform;
                        break;
                    case GROUND:
                        temp = Instantiate(groundPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        temp.parent = go.transform;
                        break;
                    case END:
                        temp = Instantiate(endPointPrefab, new Vector3(y, -x, 0f), Quaternion.identity);
                        temp.parent = go.transform;
                        break;
                }
            }
        }
    }
}
