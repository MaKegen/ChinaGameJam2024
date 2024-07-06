using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject[] tetrominoPrefabs;
    [SerializeField] Transform tetrominoSpawnerTransform;
    private void Awake() {
        Instance = this;
        SpawnTetromino();
    }
    public void SpawnTetromino() => Instantiate(tetrominoPrefabs[Random.Range(0, tetrominoPrefabs.Length)], tetrominoSpawnerTransform.position, Quaternion.identity);
}
