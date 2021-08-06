using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject TextRecord;
    private TextMeshProUGUI Record;
    private int recordValue;
    private string path;
    private void Start()
    {
        path = Application.persistentDataPath + "/Record.data";
        if (File.Exists(path))
        {
            StreamReader input = new StreamReader(path);
            recordValue = Int32.Parse(input.ReadLine());
        }
        Record = TextRecord.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Record.text = "Ваш рекорд " + Convert.ToString(recordValue);
    }

    public void PlayPressed()
    {
        SceneManager.LoadScene("main");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
   

}