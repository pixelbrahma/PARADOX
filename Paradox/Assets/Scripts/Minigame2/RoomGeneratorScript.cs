using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneratorScript : MonoBehaviour {

    [SerializeField] private Transform minigame2;

    public GameObject[] availableObjects;
    public List<GameObject> objects;

    public float objectMinDistance = 5.0f;
    public float objectMaxDistance = 10.0f;

    public float objectMinY = -1.4f;
    public float objectMaxY = 1.4f;

    public float objectMinRotation = -45.0f;
    public float objectMaxRotation = 45.0f;

    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    private float screenWidthPoints;

	void Start () {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthPoints = height * Camera.main.aspect;
    }
	
    void Update()
    {

    }

	void FixedUpdate () {
        GenerateRoom();
        GenerateObject();
	}
    
    void AddRoom(float farthestRoomEndX)
    {
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
        room.transform.SetParent(minigame2);

        float roomWidth = room.transform.Find("Floor").localScale.x;
        float roomCenter = farthestRoomEndX + roomWidth * 0.5f;
        room.transform.position = new Vector3(roomCenter, 0, 0);
        currentRooms.Add(room);
    }

    void GenerateRoom()
    {
        List<GameObject> roomsToRemove = new List<GameObject>();
        bool addRooms = true;
        float playerX = transform.position.x;
        float removeRoomX = playerX - screenWidthPoints;
        float addRoomX = playerX + screenWidthPoints;
        float farthestRoomEndX = 7.2f;

        foreach (var room in currentRooms)
        { 
            RoomCheck(roomsToRemove, ref addRooms, removeRoomX, addRoomX, ref farthestRoomEndX, room);
        }
        foreach (var room in roomsToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        } 

        if (addRooms)
            AddRoom(farthestRoomEndX);
    }

    private static void RoomCheck(List<GameObject> roomsToRemove, ref bool addRooms, float removeRoomX, float addRoomX, ref float farthestRoomEndX, GameObject room)
    {
        float roomWidth = getRoomWidth(room);
        float roomStartX = room.transform.position.x - (roomWidth * 0.5f);
        float roomEndX = roomStartX + roomWidth;

        if (roomStartX > addRoomX)
            addRooms = false;

        if (roomEndX < removeRoomX)
            roomsToRemove.Add(room);

        farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
    }

    public static float getRoomWidth(GameObject room)
    {
        return room.transform.Find("Floor").localScale.x;
    }

    void AddObject(float lastObjectX)
    {
        int randomIndex = Random.Range(0, availableObjects.Length);
        GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);
        obj.transform.SetParent(minigame2);
        float objectPositionX = lastObjectX + Random.Range(objectMinDistance, objectMaxDistance);
        float randomY = Random.Range(objectMinY, objectMaxY);
        obj.transform.position = new Vector3(objectPositionX, randomY, 0);
        float rotation = Random.Range(objectMinRotation, objectMaxRotation);
        obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
        objects.Add(obj);
    }

    void GenerateObject()
    {
        float mouseX = transform.position.x;
        float removeObjectX = mouseX - screenWidthPoints;
        float addObjectX = mouseX + screenWidthPoints;
        float farthestObjectX = 0;

        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach(var obj in objects)
        {
            float objX = obj.transform.position.x;
            farthestObjectX = Mathf.Max(farthestObjectX, objX);
            if (objX < removeObjectX)
                objectsToRemove.Add(obj);
        }

        foreach(var obj in objectsToRemove)
        {
            objects.Remove(obj);
            Destroy(obj);
        }

        if (farthestObjectX < addObjectX)
            AddObject(farthestObjectX);
    }
}
