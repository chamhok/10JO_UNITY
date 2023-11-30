using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;

    public float stageLapseTime;

    /// <summary>
    /// player ��ü ���� <br/>
    /// ���Ŀ� �ڷ����� �÷��̾� Ŭ������ �ٲ����.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// stage�� ������ monster���� ���� ����Ʈ <br/>
    /// ���Ŀ� �ڷ����� ���͵��� �ֻ��� Ŭ������ �ٲ����.
    /// </summary>
    public List<GameObject> monsters;

    /// <summary>
    /// stage�� ������ item���� ���� ����Ʈ <br/>
    /// ���Ŀ� �ڷ����� dropable item���� ���� Ŭ������ �ٲ����.
    /// </summary>
    public List<GameObject> items;

    [Header("Events")]
    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;
    public UnityEvent OnStageClear;
    public UnityEvent OnStageFail;

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

    private GameManager() { }

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
    }

    protected virtual void Start()
    {
        Time.timeScale = 1f;
        OnGameStart?.Invoke();
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
