using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager<T> where T : Entity {

    public List<T> entities = new List<T>();

    public List<T> All() {
        return entities;
    }

    public void Add(T t) {
        entities.Add(t);
    }

    public void Remove(T t) {
        entities.Remove(t);
    }

    public void Update() {
        for (var i = entities.Count - 1; i >= 0; --i) {
            var isOutside = WorldHelper.IsOutside(entities[i].transform.position);
            if (isOutside) {
                entities[i].SwitchState(EEntityState.DEAD);
            }

            var isLive = entities[i].IsLive();
            var isBusy = entities[i].IsBusy();
            if (!isLive && !isBusy) {
                Object.Destroy(entities[i].gameObject);
                entities.RemoveAt(i);
            }
        }
    }
}
