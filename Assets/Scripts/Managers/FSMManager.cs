using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMManager<T> {
    protected T character;

    public FSMManager(T character) {
        this.character = character;
    }

    public abstract void OnStateEnter();
    public abstract void OnStateStay();
    public abstract void OnStateExit();
}