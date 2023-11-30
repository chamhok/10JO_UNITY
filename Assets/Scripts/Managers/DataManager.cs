using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public PlayerData playerData;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject(nameof(DataManager));
                instance = obj.AddComponent<DataManager>();
                instance.Initialize();
            }
            return instance;
        }
    }

    private DataManager() { }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.Initialize();
        }
    }

    private void OnDestroy()
    {
        Debug.Log($"{name} call {nameof(OnDestroy)}");
        SaveData();
    }

    private void Initialize()
    {
        // ���� �������� �ʱ�ȭ
        if (!LoadData())
        {
            // �ҷ��� �� ���ٸ� �⺻������ ����
            Debug.Log($"{name} call {nameof(LoadData)} is fail. redirect {nameof(CreateDefaultData)}...");
            CreateDefaultData();
        }

        DontDestroyOnLoad(gameObject);
    }

    public bool SaveData()
    {
        try
        {
            // Save data..
            var playerDataJson = JsonUtility.ToJson(playerData);
            PlayerPrefs.SetString(nameof(playerData), playerDataJson);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
        Debug.Log($"{name} call {nameof(SaveData)} is success");
        return true;
    }

    public bool LoadData()
    {
        try
        {
            // Load data..
            var playerDataJson = PlayerPrefs.GetString(nameof(playerData));
            playerData = JsonUtility.FromJson<PlayerData>(playerDataJson);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
        Debug.Log($"{name} call {nameof(LoadData)} is success");
        return true;
    }

    public void CreateDefaultData()
    {
        // ��� �����͸� �⺻������ ����...
        playerData = new();
    }
}

/// <summary>
/// �÷��̾� ĳ���Ϳ� ���õ� ���� �߿� ������ �ʿ��� �� ������ ���⿡ �߰����ֽø� �˴ϴ�.
/// </summary>
[System.Serializable]
public class PlayerData
{
    public int level;
    public float currentExp;
    public int money;

    public PlayerData()
    {
        level = 1;
        currentExp = 0;
        money = 0;
    }
}