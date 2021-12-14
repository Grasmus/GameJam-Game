using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


enum RoomIndex
{
    Left = 0,
    Right = 1,
    Top = 2,
    Bottom = 3,
    Left_right = 4,
    Top_left = 5,
    Top_right = 6,
    Bottom_left = 7,
    Bottom_right = 8,
    Top_bottom = 9,
    Top_left_right = 10,
    Bottom_left_right = 11,
    Top_bottom_left = 12,
    Top_Bottom_right = 13,
    Main = 14,
    Default = 15
}

public class RoomVariants : MonoBehaviour
{
    private const int N = 6;
    static private int[,] rooms = { 
        { 0, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0 },
        {0,0,2,0,0,0}, 
        {0,0,1,1,1,1}, 
        {0,0,0,0,1,0}, 
        {0,0,0,0,0,0}};

    // Update is called once per frame



    public GameObject[] Rooms;
   

    public GameObject[] SpawnNodes;

    void Start()
    {
        SpawnNodes = GameObject.FindGameObjectsWithTag("SpawnPoint");

        //int RandomStart = Random.Range(0, 35);
        //int RandomRoom = 0;
        //int[] tempXY = { 0, 0 };
        //rooms[2, 2] = 2;
        //List<int[]> initializedRooms = new List<int[]>();
        //int[] XY = { 2, 2};
        //initializedRooms.Add(new int[2]);
        //initializedRooms[initializedRooms.Count - 1][0] = XY[0];
        //initializedRooms[initializedRooms.Count - 1][1] = XY[1];
        //int counter = 1;
        //while (initializedRooms.Count < N)
        //{
        //    if (rooms[XY[0], XY[1]] != 0)
        //    {
        //        Debug.Log(rooms[XY[0], XY[1]]);
        //        RandomRoom = Random.Range(0, 4);
        //        tempXY[0] = XY[0];
        //        tempXY[1] = XY[1];
        //        calcCoord(RandomRoom, XY);
        //        if (isCellNotOccupied(XY[0], XY[1]))
        //        {
        //            //initializedRooms.Add(XY);
        //            initializedRooms.Add(new int[2]);
        //            initializedRooms[initializedRooms.Count - 1][0] = XY[0];
        //            initializedRooms[initializedRooms.Count - 1][1] = XY[1];
        //            counter++;
        //            rooms[XY[0], XY[1]] = 1;
        //            RandomRoom = Random.Range(0, initializedRooms.Count);
        //            XY[0] = initializedRooms[RandomRoom][0];
        //            XY[1] = initializedRooms[RandomRoom][1];
        //        }
        //        else
        //        {
        //            XY[0] = tempXY[0];
        //            XY[1] = tempXY[1];
        //        }

        //    }
        //}
        //string path = "Assets/test.txt";
        //WriteString(rooms, path);
        //ReadString();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (rooms[i, j] != 0)
                {
                    int index;
                    if (whichRoom(i, j) != RoomIndex.Default)
                    {
                        index = (int)whichRoom(i, j);
                        Spawn(index, (i * 6) + j);

                        //Debug.LogError($"{whichRoom(i, j)}");
                    }
                    else
                    {
                        //Debug.LogError($"{RoomIndex.Default}");
                    }
                }
            }

        }

        void Spawn(int index, int SpawnNodeIndex)
        {
            Instantiate(Rooms[index], SpawnNodes[SpawnNodeIndex].transform.position, Rooms[index].transform.rotation);
           // Debug.LogError($"Spawna");

        }

        RoomIndex whichRoom(int i, int j)
        {

            bool left = false, right = false, top = false, bottom = false;
            if (isCellExists(i - 1, j))
            {
                if (rooms[i - 1, j] != 0)
                {
                    top = true;
                }

            }
            if (isCellExists(i, j - 1))
            {
                if (rooms[i, j - 1] != 0)
                {
                    left = true;
                }
            }
            if (isCellExists(i + 1, j))
            {
                if (rooms[i + 1, j] != 0)
                {
                    bottom = true;
                }
            }
            if (isCellExists(i, j + 1))
            {
                if (rooms[i, j + 1] != 0)
                {
                    right = true;
                }
            }


            if (left && right && top && bottom)
            {
                return RoomIndex.Main;
            }
            else if (!left && right && top && bottom)
            {
                return RoomIndex.Top_Bottom_right;
            }
            else if (left && !right && top && bottom)
            {
                return RoomIndex.Top_bottom_left;
            }
            else if (left && right && !top && bottom)
            {
                return RoomIndex.Bottom_left_right;
            }
            else if (left && right && top && !bottom)
            {
                return RoomIndex.Top_left_right;
            }
            else if (!left && !right && top && bottom)
            {
                return RoomIndex.Top_bottom;
            }
            else if (!left && right && !top && bottom)
            {
                return RoomIndex.Bottom_right;
            }
            else if (!left && right && top && !bottom)
            {
                return RoomIndex.Top_right;
            }
            else if (left && !right && !top && bottom)
            {
                return RoomIndex.Bottom_left;
            }
            else if (left && !right && top && !bottom)
            {
                return RoomIndex.Top_left;
            }
            else if (left && right && !top && !bottom)
            {
                return RoomIndex.Left_right;
            }
            else if (left && !right && !top && !bottom)
            {
                return RoomIndex.Left;
            }
            else if (!left && right && !top && !bottom)
            {
                return RoomIndex.Right;
            }
            else if (!left && !right && top && !bottom)
            {
                return RoomIndex.Top;
            }
            else if (!left && !right && !top && bottom)
            {
                return RoomIndex.Bottom;
            }
            else return RoomIndex.Default;

            
        }


        


       
        bool isCellNotOccupied(int x, int y)
        {
            bool res = false;
            if (isCellExists(x, y))
            {
                if (rooms[x, y] == 0) res = true;
                else res = false;
            }
            else res = false;
            //Debug.LogError($"isCellNotOccupied for x: {x} y: {y} res = {res}");
            return res;
        }

        bool isCellExists(int x, int y)
        {
            bool res = false;
            if (x >= 0 && y >= 0 && x < N && y < N) res = true;
            else res = false;
            //Debug.LogError($"isCellExists for x: {x} y: {y} res = {res}");
            return res;
        }

        void calcCoord(int random, int[] XY)
        {
            switch (random)
            {
                case 0:
                    XY[1]--;
                    break;
                case 1:
                    XY[0]++;
                    break;
                case 2:
                    XY[1]++;
                    break;
                case 3:
                    XY[1]--;
                    break;
                default:
                    break;
            }

        }

        //Debug.LogError($"initializedRooms.Count : {initializedRooms.Count}");
    }
}
