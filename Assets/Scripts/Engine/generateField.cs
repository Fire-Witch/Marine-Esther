using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class generateField : MonoBehaviour
{
    public GameObject[] roomObj;

    private float playerX, playerY, roomX, roomY;

    Random rdm = new Random();

    void Start()
    {
        var roomScene = Instantiate(roomObj[0]);
        roomScene.name = "roomC";
        roomScene.transform.position = new Vector3(0, 0, 0);

        var roomsToAdd = new Dictionary<string, float[]>()
        {
            ["roomN"] = new float[] { roomX, roomY + (float)12, 0 },
            ["roomO"] = new float[] { roomX - (float)12, roomY, 0 },
            ["roomS"] = new float[] { roomX, roomY - (float)12, 0 },
            ["roomE"] = new float[] { roomX + (float)12, roomY, 0 },
            ["roomNE"] = new float[] { roomX + (float)12, roomY + (float)12, 0 },
            ["roomES"] = new float[] { roomX + (float)12, roomY - (float)12, 0 },
            ["roomSO"] = new float[] { roomX - (float)12, roomY - (float)12, 0 },
            ["roomON"] = new float[] { roomX - (float)12, roomY + (float)12, 0 },
            ["roomNN"] = new float[] { roomX, roomY + (float)12 * 2, 0 },
            ["roomOO"] = new float[] { roomX - (float)12 * 2, roomY, 0 },
            ["roomSS"] = new float[] { roomX, roomY - (float)12 * 2, 0 },
            ["roomEE"] = new float[] { roomX + (float)12 * 2, roomY, 0 }
        };

        InstantiateRooms(roomsToAdd);
    }

    void Update()
    {
        playerX = GameObject.Find("Player").transform.position.x;
        playerY = GameObject.Find("Player").transform.position.y;

        roomX = GameObject.Find("roomC").transform.position.x;
        roomY = GameObject.Find("roomC").transform.position.y;

        //Est
        if (playerX > roomX + 4.5)
        {
            DestroyRooms(new string[] { "roomN", "roomO", "roomS", "roomNN", "roomOO", "roomSS", "roomSO", "roomON" });

            RenameRooms(new string[] { "roomC", "roomE", "roomEE", "roomNE", "roomES" }, new string[] { "roomO", "roomC", "roomE", "roomN", "roomS" });

            roomX = GameObject.Find("roomC").transform.position.x;
            roomY = GameObject.Find("roomC").transform.position.y;

            var roomsToAdd = new Dictionary<string, float[]>()
            {
                ["roomNN"] = new float[] { roomX, roomY + (float)12 * 2, 0 },
                ["roomOO"] = new float[] { roomX - (float)12 * 2, roomY, 0 },
                ["roomSS"] = new float[] { roomX, roomY - (float)12 * 2, 0 },
                ["roomEE"] = new float[] { roomX + (float)12 * 2, roomY, 0 },
                ["roomNE"] = new float[] { roomX + (float)12, roomY + (float)12, 0 },
                ["roomES"] = new float[] { roomX + (float)12, roomY - (float)12, 0 },
                ["roomSO"] = new float[] { roomX - (float)12, roomY - (float)12, 0 },
                ["roomON"] = new float[] { roomX - (float)12, roomY + (float)12, 0 }
            };

            InstantiateRooms(roomsToAdd);
        }
        //Ouest
        else if (playerX < roomX - 8.5)
        {
            DestroyRooms(new string[] { "roomN", "roomE", "roomS", "roomNN", "roomEE", "roomSS", "roomNE", "roomES" });

            RenameRooms(new string[] { "roomC", "roomO", "roomOO", "roomSO", "roomON" }, new string[] { "roomE", "roomC", "roomO", "roomS", "roomN" });

            roomX = GameObject.Find("roomC").transform.position.x;
            roomY = GameObject.Find("roomC").transform.position.y;

            var roomsToAdd = new Dictionary<string, float[]>()
            {
                ["roomNN"] = new float[] { roomX, roomY + (float)12 * 2, 0 },
                ["roomOO"] = new float[] { roomX - (float)12 * 2, roomY, 0 },
                ["roomSS"] = new float[] { roomX, roomY - (float)12 * 2, 0 },
                ["roomEE"] = new float[] { roomX + (float)12 * 2, roomY, 0 },
                ["roomNE"] = new float[] { roomX + (float)12, roomY + (float)12, 0 },
                ["roomES"] = new float[] { roomX + (float)12, roomY - (float)12, 0 },
                ["roomSO"] = new float[] { roomX - (float)12, roomY - (float)12, 0 },
                ["roomON"] = new float[] { roomX - (float)12, roomY + (float)12, 0 }
            };

            InstantiateRooms(roomsToAdd);
        }
        //Nord
        else if (playerY > roomY + 6.5)
        {
            DestroyRooms(new string[] { "roomO", "roomE", "roomS", "roomOO", "roomEE", "roomSS", "roomES", "roomSO" });

            RenameRooms(new string[] { "roomC", "roomN", "roomNN", "roomON", "roomNE" }, new string[] { "roomS", "roomC", "roomN", "roomO", "roomE" });

            roomX = GameObject.Find("roomC").transform.position.x;
            roomY = GameObject.Find("roomC").transform.position.y;

            var roomsToAdd = new Dictionary<string, float[]>()
            {
                ["roomNN"] = new float[] { roomX, roomY + (float)12 * 2, 0 },
                ["roomOO"] = new float[] { roomX - (float)12 * 2, roomY, 0 },
                ["roomSS"] = new float[] { roomX, roomY - (float)12 * 2, 0 },
                ["roomEE"] = new float[] { roomX + (float)12 * 2, roomY, 0 },
                ["roomNE"] = new float[] { roomX + (float)12, roomY + (float)12, 0 },
                ["roomES"] = new float[] { roomX + (float)12, roomY - (float)12, 0 },
                ["roomSO"] = new float[] { roomX - (float)12, roomY - (float)12, 0 },
                ["roomON"] = new float[] { roomX - (float)12, roomY + (float)12, 0 }
            };

            InstantiateRooms(roomsToAdd);
        }
        //Sud
        else if (playerY < roomY - 6.5)
        {
            DestroyRooms(new string[] { "roomO", "roomE", "roomN", "roomOO", "roomEE", "roomNN", "roomNE", "roomON" });

            RenameRooms(new string[] { "roomC", "roomS", "roomSS", "roomSO", "roomES" }, new string[] { "roomN", "roomC", "roomS", "roomO", "roomE" });

            roomX = GameObject.Find("roomC").transform.position.x;
            roomY = GameObject.Find("roomC").transform.position.y;

            var roomsToAdd = new Dictionary<string, float[]>()
            {
                ["roomNN"] = new float[] { roomX, roomY + (float)12 * 2, 0 },
                ["roomOO"] = new float[] { roomX - (float)12 * 2, roomY, 0 },
                ["roomSS"] = new float[] { roomX, roomY - (float)12 * 2, 0 },
                ["roomEE"] = new float[] { roomX + (float)12 * 2, roomY, 0 },
                ["roomNE"] = new float[] { roomX + (float)12, roomY + (float)12, 0 },
                ["roomES"] = new float[] { roomX + (float)12, roomY - (float)12, 0 },
                ["roomSO"] = new float[] { roomX - (float)12, roomY - (float)12, 0 },
                ["roomON"] = new float[] { roomX - (float)12, roomY + (float)12, 0 }
            };

            InstantiateRooms(roomsToAdd);
        }
    }

    public void DestroyRooms(string[] rooms)
    {
        foreach(string room in rooms)
        {
            Destroy(GameObject.Find(room));
        }
    }

    public void RenameRooms(string[] roomsToRename, string[] newRoomsName)
    {
        for(int i = 0; i < roomsToRename.Count(); i++)
        {
            GameObject.Find(roomsToRename[i]).name = newRoomsName[i];
        }
    }

    public void InstantiateRooms(Dictionary<string, float[]> rooms)
    {
        GameObject roomScene;

        foreach (KeyValuePair<string, float[]> room in rooms)
        {
            roomScene = Instantiate(roomObj[Random.Range(0, roomObj.Count())]);
            roomScene.name = room.Key;
            roomScene.transform.position = new Vector3(room.Value[0], room.Value[1], room.Value[2]);
        }
    }
}
