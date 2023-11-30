/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
        //.. 프립펩들을 보관할 변수
        public GameObject[] prefabs;

        //.. 풀 담당하는 리스트들 
        List<GameObject>[] pools;

        private void Awake()
        {
                pools = new List<GameObject>[prefabs.Length];

                for (int i = 0; i < pools.Length; i++)
                {
                        pools[i] = new List<GameObject>();
                }
        }

        public GameObject Get(int index)
        {
                GameObject select = null;
                // 선택한 풀의 놀고있는(비활성화된) 게임오브젝트 접근


                foreach (GameObject item in pools[index])
                {
                        if (!item.activeSelf)
                        {
                                // 발견하면 select 변수에 할당
                                select = item;
                                select.SetActive(true);
                                break;
                        }
                }
                // 찾지 못하면
                if (!select)
                {
                        // 새롭게 생성하고 select 변수에 할당
                        select = Instantiate(prefabs[index], transform);
                        pools[index].Add(select);
                }

                return select;
        }
}
*/