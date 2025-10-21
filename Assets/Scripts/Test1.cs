using UnityEngine;

public class Test1 : MonoBehaviour, IUpdatable
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
        Debug.Log("Test1 업데이트 됨");
        Time.timeScale = 0f;
    }
}
