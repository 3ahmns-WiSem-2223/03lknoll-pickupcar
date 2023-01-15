using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpielManager : MonoBehaviour
{
    bool Packetaufheben;
    private int packetAnzahl;
    [SerializeField] TextMeshProUGUI punkteAnzahl;
    [SerializeField] GameObject verlorenText;
    [SerializeField] GameObject gewonnenText;
    //[SerializeField] GameObject gewonnenTextAnzahl;
    [SerializeField] GameObject wiederholenButton;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float timeValue = 90;
    GameObject AktuellesPaket;
    bool won = false;
    bool lost = false;


    private void Start()
    {
        gewonnenText.SetActive(false);
        verlorenText.SetActive(false);
        wiederholenButton.SetActive(false);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    private void Update()
    {
        if(timeValue > 0)
        {
        timeValue -= Time.deltaTime;
        }
        if (timeValue < 0 && !won)
        {
            lost = true;
            verlorenText.SetActive(true);
            wiederholenButton.SetActive(true);
        }
        
        if (packetAnzahl == 10 && !lost)
        {
            won = true;
            gewonnenText.SetActive(true);
            //gewonnenTextAnzahl.SetActive(true);
            wiederholenButton.SetActive(true);
        }
        var ts = TimeSpan.FromSeconds(timeValue);
        timeText.text = "Timer : " + string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("karton") && Packetaufheben == false)
        {
            Packetaufheben = true;
            AktuellesPaket = collision.gameObject;
            AktuellesPaket.SetActive(false);
        }
        if (collision.gameObject.CompareTag("haus") && Packetaufheben == true)
        {
            packetAnzahl++;
            //punkteAnzahl.text = packetAnzahl.ToString;
            AktuellesPaket.gameObject.transform.position = new Vector2(-9.66f,2.7f);
            AktuellesPaket.gameObject.SetActive(true);
            AktuellesPaket.GetComponent<BoxCollider2D>().enabled = false;
            Packetaufheben = false;
            Debug.Log(packetAnzahl);
        }
    }
}
