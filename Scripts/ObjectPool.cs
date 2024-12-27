using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using System.Linq;


public class ObjectPool<T> where T: MonoBehaviour
{
    public static ObjectPool<T> instance {
        get{
            if(_instance == null){
                _instance = new ObjectPool<T>();
            }
            else{
                Debug.Log("!!!");
            }
            return _instance;
        }
    }
    public int queueCount{
        get{
            return objectQueue.Count;
        }
    }
    private static ObjectPool<T> _instance = null;
    private GameObject prefab;
    private Queue<T> objectQueue;
    public void InitObjectPool(GameObject _prefab){
        prefab = _prefab;
        objectQueue = new Queue<T>();
    }
    public T Spawn(Vector3 position, Quaternion quaternion){
        if(prefab == null){
            Debug.Log("no prefab");
            return default(T);
        }
        if(queueCount<=0){
            GameObject g = Object.Instantiate(prefab,position,quaternion);
            T t = g.GetComponent<T>();
            if(t == null){
                Debug.Log("prefab not found");
            }
            objectQueue.Enqueue(t);
        }
        T obj = objectQueue.Dequeue();
        obj.gameObject.transform.position = position;
        obj.gameObject.transform.rotation = quaternion;
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void Recycle(T obj){
        if (obj == null)
        {
            Debug.LogError("Trying to recycle a null object!");
            return;
        }
        try{
            objectQueue.Enqueue(obj);
        }
        catch(System.Exception ex){
            Debug.Log(ex);
        }
        obj.gameObject.SetActive(false);
    }
}