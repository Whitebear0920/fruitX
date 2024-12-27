using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Principal;
using System.Linq;
using Unity.VisualScripting;

public class FallItemManager : MonoBehaviour
{
    public GameObject[] fallItems;
    public float interval;
    //private ObjectPool<FallItem> fallItemPool;
    public static Dictionary<int,ObjectPool<FallItem>> fallItemPool = new Dictionary<int, ObjectPool<FallItem>>();
    //private ObjectPool<FallItem>[] pool = new ObjectPool<FallItem>[5];
    IEnumerator SpawnFallItem(){
        while(true){
            int r = Random.Range(0,fallItems.Length);
            FallItem  fallItem = fallItemPool[r].Spawn(new Vector3(Random.Range(-1.8f,1.8f),6f,0f),Quaternion.identity);
            fallItem.index = r;
            yield return new WaitForSeconds(interval);
        }
        
    }
    void Start()
    {
        initPool();
        StartCoroutine(SpawnFallItem());
    }
    private void initPool(){
        for(int i =0;i<fallItems.Length;i++){
            //pool[i] = new ObjectPool<FallItem>();
            //pool[i].InitObjectPool(fallItems[i]);
            //fallItemPool.Add(i,pool[i]);
            var pool = new ObjectPool<FallItem>();
            pool.InitObjectPool(fallItems[i]);
            fallItemPool.Add(i,pool);
            List<FallItem> l = new();
            for(int j=0;j<5;j++){
                var fallItem = fallItemPool[i].Spawn(Vector3.zero,Quaternion.identity);
                fallItem.index = i;
                l.Add(fallItem);
                fallItem.gameObject.SetActive(false);
                Debug.Log("here");
            }
            for(int j=0;j<5;j++){
                fallItemPool[i].Recycle(l[j]);
                Debug.Log("here");
            }
        }
        Debug.Log("done");
    }
}