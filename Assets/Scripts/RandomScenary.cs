using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomScenary : MonoBehaviour
{
    public List<GameObject> environment;
    public List<GameObject> obstacle;
    public List<GameObject> enemies;
    public List<GameObject> coins;
    public int columns = 8;
    public int rows = 11;
    private List<Vector2> gridPositions = new List<Vector2>();  
    private int level = 3;




    public void SetupScene(int level) 
    {
      
        InitialiseList();

        PutEnvironmentAtRandom(environment, 3, 7);

        PutObstacleAtRandom(obstacle, 1, 3);

  
    }

    void InitialiseList()
    {
        gridPositions.Clear(); 

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                Vector2 position = new Vector2(x, y);
                gridPositions.Add(position);
                
            }
        }
    }

    //int gridSize = gridPositions.Count; // Tamaño de la lista
    //int randomIndex = Random.Range(0, gridSize); // Índice aleatoria de la lista entre 0 y el tamaño
    //Vector2 randomPosition = gridPositions[randomIndex]; // Objetenes posción alamacenada en el índice obtenido aleatoriamente
    //gridPositions.RemoveAt(randomIndex);

    Vector2 GetRandomPosition() 
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition; 
    }

    void PutEnvironmentAtRandom(List<GameObject> environment, int minimun, int maximun)
    {
        int objectCount = Random.Range(minimun, maximun + 1);

        
        for (int i = 0; i < objectCount; i++)
        {
            
            Vector2 randomPosition = GetRandomPosition();

            int objectRandomIndex = Random.Range(0, environment.Count);
            
            GameObject objectToSpawn = environment[objectRandomIndex];

            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }

    void PutObstacleAtRandom(List<GameObject> obstacle, int minimun, int maximun)
    {
        int objectCount = Random.Range(minimun, maximun + 1);


        for (int i = 0; i < objectCount; i++)
        {

            Vector2 randomPosition = GetRandomPosition();

            int objectRandomIndex = Random.Range(0, obstacle.Count);

            GameObject objectToSpawn = obstacle[objectRandomIndex];

            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }

}
