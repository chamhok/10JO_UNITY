using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;

    public float stageLapseTime;

    /// <summary>
    /// player ��ü ���� <br/>
    /// ���Ŀ� �ڷ����� �÷��ƾ� Ŭ������ �ٲ����.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// stage�� ������ monster���� ���� ����Ʈ <br/>
    /// ���Ŀ� �ڷ����� ���͵��� �ֻ��� Ŭ������ �ٲ����.
    /// </summary>
    public List<GameObject> monsters;

    public event Action OnGameOver;
    public event Action OnStageClear;
    public event Action OnStageFail;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Data Manager�� ���� ��� ������ �ʿ� ���� ��?
                throw new NullReferenceException();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
    }

    protected virtual void Start()
    {
        Time.timeScale = 1f;
    }

    protected virtual void Update()
    {
        stageLapseTime += Time.deltaTime;
    }

    public virtual void GameOver(bool isGameClear = false)
    {
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
        if (isGameClear) OnStageClear?.Invoke();
        else OnStageFail?.Invoke();
    }
}
