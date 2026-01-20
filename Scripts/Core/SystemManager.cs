using System;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public static SystemManager Instance;

    public SystemState CurrentState { get; private set; }

    public event Action<SystemState> OnSystemStateChanged;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        SetState(SystemState.Idle);
    }

    public void SetState(SystemState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;
        Debug.Log("🧠 SYSTEM STATE → " + newState);

        OnSystemStateChanged?.Invoke(newState);
    }
}
