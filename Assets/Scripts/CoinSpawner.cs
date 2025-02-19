
using UnityEngine;
using System.Collections.Generic; // Para usar listas

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab de la moneda
    public Transform[] waypoints; // Array de waypoints

    public int coinsPerWaypoint = 5; // Número de monedas por waypoint

    void Start() {
        SpawnCoins();
    }

    void SpawnCoins() {
        foreach (Transform waypoint in waypoints) {
            for (int i = 0; i < coinsPerWaypoint; i++) {

                // Generar una posición aleatoria cerca del waypoint
                Vector3 randomOffset = GenerateRandomOffset();

                Vector3 spawnPosition = waypoint.position + randomOffset;
                spawnPosition.y = -1.88f; // Distancia fija en Y es decir, la altura de la moneda

                // Instanciar la moneda
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private Vector3 GenerateRandomOffset() {
        return new Vector3(
            Random.Range(-10f,30f), 
            0f,
            Random.Range(-10f, 15f)
        );
    }
}