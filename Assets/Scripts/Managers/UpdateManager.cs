using System.Collections.Generic;
using UnityEngine;

public interface IUpdatable
{
    /// <summary>
    /// 업데이트 우선순위
    /// </summary>
    UpdatePriority Priority { get; }

    /// <summary>
    /// 매 프레임 호출되는 업데이트 메서드
    /// </summary>
    void OnUpdate();
}

public enum UpdatePriority
{
    Core = 0,
    GameLogic = 1,
    UI = 2
}

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager Instance { get; private set; }

    private readonly List<IUpdatable> updatables = new List<IUpdatable>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 업데이트 매니저에 객체 등록
    /// </summary>
    /// <param name="obj">등록할 IUpdatable 객체</param>
    public void Register(IUpdatable obj)
    {
        // 중복 등록 방지
        if (!updatables.Contains(obj))
        {
            updatables.Add(obj);
            updatables.Sort((a, b) => a.Priority.CompareTo(b.Priority));
        }
    }

    /// <summary>
    /// 업데이트 매니저에서 객체 등록 해제
    /// </summary>
    /// <param name="obj">등록 해제할 IUpdatable 객체</param>
    public void UnRegister(IUpdatable obj)
    {
        updatables.Remove(obj);
    }

    private void Update()
    {
        foreach (var updatable in updatables)
        {
            updatable.OnUpdate();
        }
    }
}

