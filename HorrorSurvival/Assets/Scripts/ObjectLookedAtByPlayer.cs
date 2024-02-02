using UnityEngine;

public class TestObject : MonoBehaviour, iGazeReceiver
{
    private bool isGazingUpon;

    [SerializeField] private GameObject UIText = null;
    [SerializeField] private int timeToShowUI = 1;

    void Update()
    {
        if (isGazingUpon)
        {
            UIText.SetActive(true);
        }
        else if (!isGazingUpon)
        {
            UIText.SetActive(false);
        }
    }

    public void GazingUpon()
    {
        isGazingUpon = true;
    }

    public void NotGazingUpon()
    {
        isGazingUpon = false;
    }
}
