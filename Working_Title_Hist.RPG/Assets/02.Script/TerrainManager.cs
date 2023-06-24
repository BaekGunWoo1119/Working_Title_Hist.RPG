using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public GameObject terrainPrefab; // ���� ������
    public float terrainSize = 10f; // ������ ũ��
    public Transform character; // ĳ������ Transform ������Ʈ

    private float spawnDistance = 100f; // ������ ������ �Ÿ�
    private Vector3 previousCharacterPosition; // ���� �����ӿ����� ĳ���� ��ġ
    private float terrainGenerationInterval = 5f; // ���� ���� ����
    private float timeSinceLastTerrainGeneration; // ������ ���� ���� ���� ��� �ð�
    private void Start()
    {
        character = GameObject.FindWithTag("Player").transform;
        SpawnTerrain();
        previousCharacterPosition = character.position;
        // �ʱ� ��� �ð� ����
        timeSinceLastTerrainGeneration = 0f;
    }

    private void Update()
    {
        // ��� �ð� ������Ʈ
        timeSinceLastTerrainGeneration += Time.deltaTime;
        if (timeSinceLastTerrainGeneration >= terrainGenerationInterval) {
            Debug.Log("Spawn");
            // ĳ���Ͱ� ���� �Ÿ��� �̵��ϸ� ������ �����մϴ�.
                SpawnTerrain();
            timeSinceLastTerrainGeneration = 0f;
        }

        // ���� ĳ���� ��ġ ������Ʈ
        previousCharacterPosition = character.position;
    }

    private bool IsCharacterMovingBackward()
    {
        return character.position.z < previousCharacterPosition.z;
    }

    private void SpawnTerrain()
    {
        // ���ο� ������ �����ϰ� ��ġ�� �����մϴ�.
        GameObject terrain = Instantiate(terrainPrefab);
        terrain.transform.SetParent(transform);

        // ���� ������ ���� ��� �����մϴ�.
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        // ���ο� ������ ��ġ�� �����մϴ�.
        Vector3 newTerrainPosition = GetNewTerrainPosition();

        // ������ ��ġ�� ������Ʈ�մϴ�.
        terrain.transform.position = newTerrainPosition;

        // ���ο� ������ �� ��ġ�� ������Ʈ�մϴ�.
        spawnDistance = newTerrainPosition.z + terrainSize;
    }

    private bool IsCharacterCloseToEdge()
    {
        float distanceToEdge = Mathf.Abs(spawnDistance - previousCharacterPosition.z);
        return distanceToEdge <= terrainSize;
    }
    private Vector3 GetNewTerrainPosition()
    {
        // ���� ��ġ�κ����� �������� ����մϴ�.
        float offsetX = character.position.x % terrainSize;
        float offsetZ = character.position.z % terrainSize;

        // ���ο� ������ ��ġ�� �����մϴ�.
        Vector3 newTerrainPosition = new Vector3(
            Mathf.Floor(character.position.x / terrainSize) * terrainSize + offsetX,
            0f,
            Mathf.Floor(character.position.z / terrainSize) * terrainSize + offsetZ
        );

        return newTerrainPosition;
    }
}