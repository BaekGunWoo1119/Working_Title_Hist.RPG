using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject terrainPrefab; // 평지 프리팹
    public float terrainSize = 10f; // 평지의 크기
    public Transform character; // 캐릭터의 Transform 컴포넌트

    private float spawnDistance = 100f; // 평지를 생성할 거리
    private Vector3 previousCharacterPosition; // 이전 프레임에서의 캐릭터 위치
    private float terrainGenerationInterval = 5f; // 평지 생성 간격
    private float timeSinceLastTerrainGeneration; // 마지막 평지 생성 이후 경과 시간
    private void Start()
    {
        character = GameObject.FindWithTag("Player").transform;
        SpawnTerrain();
        previousCharacterPosition = character.position;
        // 초기 경과 시간 설정
        timeSinceLastTerrainGeneration = 0f;
    }

    private void Update()
    {
        // 경과 시간 업데이트
        timeSinceLastTerrainGeneration += Time.deltaTime;
        if (timeSinceLastTerrainGeneration >= terrainGenerationInterval) {
            Debug.Log("Spawn");
            // 캐릭터가 일정 거리를 이동하면 평지를 생성합니다.
                SpawnTerrain();
            timeSinceLastTerrainGeneration = 0f;
        }

        // 이전 캐릭터 위치 업데이트
        previousCharacterPosition = character.position;
    }

    private bool IsCharacterMovingBackward()
    {
        return character.position.z < previousCharacterPosition.z;
    }

    private void SpawnTerrain()
    {
        // 새로운 평지를 생성하고 위치를 조정합니다.
        GameObject terrain = Instantiate(terrainPrefab);
        terrain.transform.SetParent(transform);

        // 이전 평지가 있을 경우 삭제합니다.
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        // 새로운 평지의 위치를 설정합니다.
        Vector3 newTerrainPosition = GetNewTerrainPosition();

        // 평지의 위치를 업데이트합니다.
        terrain.transform.position = newTerrainPosition;

        // 새로운 평지의 끝 위치를 업데이트합니다.
        spawnDistance = newTerrainPosition.z + terrainSize;
    }

    private bool IsCharacterCloseToEdge()
    {
        float distanceToEdge = Mathf.Abs(spawnDistance - previousCharacterPosition.z);
        return distanceToEdge <= terrainSize;
    }
    private Vector3 GetNewTerrainPosition()
    {
        // 기준 위치로부터의 오프셋을 계산합니다.
        float offsetX = character.position.x % terrainSize;
        float offsetZ = character.position.z % terrainSize;

        // 새로운 평지의 위치를 설정합니다.
        Vector3 newTerrainPosition = new Vector3(
            Mathf.Floor(character.position.x / terrainSize) * terrainSize + offsetX,
            0f,
            Mathf.Floor(character.position.z / terrainSize) * terrainSize + offsetZ
        );

        return newTerrainPosition;
    }
}