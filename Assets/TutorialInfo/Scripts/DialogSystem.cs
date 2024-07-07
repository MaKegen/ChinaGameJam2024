using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class DialogSystem : MonoBehaviour
{
    [Header("UI")]
    public Text textLabel;
    public Image faceImage;
    [Header("text part")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    List<string> textList = new List<string>();
    public bool textFinish;
    [Header("Í·Ïñ")]
    public Sprite faceUser, face01;

    // Start is called before the first frame update
    void Awake()
    {
        GetFileFromFile(textFile);
    }
    private void OnEnable()
    {
        textFinish = false;
        StartCoroutine(SetTalkUI());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q) && textFinish)
        {
            StartCoroutine(SetTalkUI());
        }
    }
    void GetFileFromFile(TextAsset textAsset)
    {
        textList.Clear();
        index = 0;
        var lineData = textFile.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }
    IEnumerator SetTalkUI()
    {
        textFinish = false;
        textLabel.text = "";
        switch (textList[index])
        {
            case "A":
                faceImage.sprite = faceUser;
                index++;
                break;
            case "B":
                faceImage.sprite = face01;
                index++; break;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinish = true;
        index++;

    }
}
