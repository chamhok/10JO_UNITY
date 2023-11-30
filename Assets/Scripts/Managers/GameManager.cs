using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;

    public float stageLapseTime;

    /// <summary>
    /// player 객체 참조 <br/>
    /// 추후에 자료형을 플레아어 클래스로 바꿔야함.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// stage에 생성된 monster들을 담을 리스트 <br/>
    /// 추후에 자료형을 몬스터들의 최상위 클래스로 바꿔야함.
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
                // Data Manager면 몰라도 얘는 생성할 필요 없을 듯?
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
