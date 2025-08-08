using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;


namespace babu
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public int width = 10;
        public int height = 10;
        public bool[,] occupied;  //true이면 건물이 지어진 상태, false이면 비어있는 상태
        public bool isBuilding = false;


        public int[,] map;

        TilemapGenerator tilemapGenerator;





        private void Awake()
        {
            Instance = this;
            tilemapGenerator = GameObject.FindObjectOfType<TilemapGenerator>();
            //width = map.GetLength(0);
            //height = map.GetLength(1);
            //occupied = new bool[width, height];
        }

        public void SetMap(int[,] _map)
        {
            map = _map;
            width = map.GetLength(0);
            height = map.GetLength(1);

            tilemapGenerator.SetTileMap();
        }

        void Start()
        {
            
        }



        public bool IsAreaFree(Vector2Int start, Vector2Int size)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    int checkX = start.x + x;
                    int checkY = start.y + y;
                    if (checkX < 0 || checkY < 0 || checkX >= width || checkY >= height)
                        return false;
                    if (occupied[checkX, checkY])
                        return false;
                }
            }
            return true;
        }
        public void OccupyArea(Vector2Int start, Vector2Int size)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0;y < size.y; y++)
                {
                    occupied[start.x + x, start.y + y] = true;
                }
            }
        }

        public void OccupyAreaD(Vector2Int start, Vector2Int size)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    occupied[start.x + x, start.y + y] = false;
                }
            }
        }


    }

    
}