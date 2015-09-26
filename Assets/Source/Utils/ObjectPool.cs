﻿using System;
using System.Collections.Generic;
using Caveman.CustomAnimation;
using Caveman.Weapons;
using UnityEngine;

namespace Caveman.Utils
{
    public abstract class ASupportPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public abstract void SetPool(ObjectPool<T> item);
        public string Id;
    }

    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public Func<ObjectPool<EffectBase>> RelatedPool;

        private Stack<T> stack;
        private T prefab;

        private Dictionary<string, T> poolServer;

        public void CreatePool(T prefab, int initialBufferSize, bool multiplayer)
        {
            if (multiplayer)
            {
                poolServer = new Dictionary<string, T>();
            }
            stack = new Stack<T>(initialBufferSize);
            this.prefab = prefab;
            GetActivedCount = initialBufferSize;
        }

        public T New()
        {
            var item = GetItem();
            item.gameObject.SetActive(true);
            GetActivedCount++;
            return item;
        }

        private T GetItem()
        {
            if (stack.Count > 0)
            {
                return stack.Pop();
            }
            var item = Instantiate(prefab);
            if (item.GetComponent<ASupportPool<T>>())
            {
                item.transform.SetParent(transform);
                item.GetComponent<ASupportPool<T>>().SetPool(this);
            }
            if (RelatedPool != null && item.GetComponent<StoneModel>())
            {
                item.GetComponent<StoneModel>().SetPoolSplash(RelatedPool());
            }
            return item;
        }

        public void Store(T obj)
        {
            GetActivedCount--;
            obj.gameObject.SetActive(false);
            obj.gameObject.transform.position = new Vector3(100, 100, 100);
            stack.Push(obj);            
        }

        public T New(string key)
        {
            var item = GetItem();
            while (!string.IsNullOrEmpty(item.GetComponent<ASupportPool<T>>().Id))
            {
                item = GetItem();
            }
            item.GetComponent<ASupportPool<T>>().Id = key;
            item.name = item.name + key;
            poolServer.Add(key, item);
            item.gameObject.SetActive(true);
            return item;
        }

        public void Store(string key)
        {
            T value;
            if (poolServer.TryGetValue(key, out value))
            {
                Store(value);
                poolServer[key].name = "item";
                poolServer.Remove(key);
            }
            else
            {
                Debug.LogWarning(key + " key not found in Dictionary");
            }
        }

        public bool ContainsKey(string key)
        {
            return poolServer.ContainsKey(key);
        }

        public T this[string key]
        {
            get
            {
                return poolServer[key];
            }
        }

        public int GetActivedCount { private set; get; }
    }
}
