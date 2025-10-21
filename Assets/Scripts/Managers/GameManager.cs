using UnityEngine;

public class GameManager : MonoBehaviour, IUpdatable
{
    public UpdatePriority Priority => UpdatePriority.GameLogic;

    private void OnEnable()
    {
        UpdateManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.UnRegister(this);
    }

    public void OnUpdate()
    {
        Debug.Log("GameManager 업데이트 됨");
    }
}
