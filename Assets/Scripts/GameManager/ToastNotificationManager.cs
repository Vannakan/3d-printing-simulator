using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToastNotificationManager : MonoBehaviour
{
    public static ToastNotificationManager Instance;
    public GameObject ToastNotificationGO;
    public Queue<string> Buffer = new();

    void Start()
    {
        StartCoroutine(Display());
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Create(string text)
    {
        Buffer.Enqueue(text);
    }

    private void SpawnToast(string text)
    {
        var go = Instantiate(ToastNotificationGO, transform);
        go.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    IEnumerator Display()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (Buffer.Count <= 0) continue;
            SpawnToast(Buffer.Dequeue());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            Create(DateTime.Now.ToString());
        }
    }
}
