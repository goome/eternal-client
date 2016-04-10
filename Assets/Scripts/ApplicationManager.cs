using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
		NetManager.Instance.Connect("localhost", 8888);
        NetManager.Instance.StartNetThread();
	}
	
	// Update is called once per frame
	void Update () {
        MessageDispatcher.Instance.DispatchMessage();
	}

    void OnApplicationQuit()
    {
        NetManager.Instance.Disconnect();
    }
}
