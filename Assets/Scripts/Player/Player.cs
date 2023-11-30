using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int maxHp;
    int hp;
    int atk; //���ݷ� ����
    public int speed;//�̵��ӵ� ����
    int level;
    int exp;
    int money;

    public Player()
    {
        maxHp = 100; //�⺻ �ִ� HP
        hp = maxHp;  //�ִ� HP -> �������� ���帶�� �ִ� HP�� �ʱ�ȭ
        atk = 1;     //���ݷ� ����(���� ������ * atk)
        speed = 1;   //�̵��ӵ� ����
        level = 1;   //���� ����(���� ����, ���� Ŭ���� �� �ʱ�ȭ - �������� Ŭ���� �ƴ�)
        exp = 0;     //���� exp(���� ����, ���� Ŭ���� �� �ʱ�ȭ - �������� Ŭ���� �ƴ�)
        money = 0;   //���� gold(����ȭ��, �������ͽ� ��ȭ ȭ�鿡�� ����ϴ� ������ maxHp, atk, speed�� ���������� ����)
                     //�����Ҷ� ���� �ʿ��� money ����
    }       

    public Player(PlayerData playerData)
    {
        maxHp = playerData.maxHp;
        atk = playerData.atk;
        speed = playerData.speed;
        level = playerData.level;
        exp = playerData.currentExp;
        money = playerData.money;
    }
}
