using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class WritingEvent : MonoBehaviour {

    public Text text;
    public Image backgroundText;
    public float timerBetweenLetter = 0.1f;
    public float timerBeforeDisappear = 4.0f;
    public float timeWaitEndSentence = 2.0f;

    
    private ArrayList xmlValue = new ArrayList();
    private float tbl = -40.0f;
    private string sentence = " ";
    private int iterator = 0;
    private XmlDocument xmlDoc;
    private XmlNode rootNode;

    private static WritingEvent _instance;

    public static WritingEvent instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<WritingEvent>();

                DontDestroyOnLoad(_instance.gameObject);
            }
            return (_instance);
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);

            this.initXML();
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void initXML ()
    {
        tbl = timerBetweenLetter;
        TextAsset temp = Resources.Load("Dialog") as TextAsset;
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(temp.text);

        if (xmlDoc == null)
        {
            Debug.LogError("No XML script file for the level " + Application.loadedLevelName);
        }
        else
            rootNode = xmlDoc.FirstChild;
    }

    void Start()
    {
        backgroundText.CrossFadeAlpha(0.0f, 0.0f, true);
    }

	// Update is called once per frame
	void Update () {
        if (sentence != "")
        {
            if (iterator < sentence.Length && tbl <= 0.0f)
            {
                text.text += sentence[iterator];
                char c = sentence[iterator];
                if ("?.!,".IndexOf(c) != -1)
                    tbl = 10.0f * timerBetweenLetter;
                else
                    tbl = timerBetweenLetter;
                iterator += 1;
            }
            else if (iterator >= sentence.Length)
            {
                text.CrossFadeAlpha(0.0f, timerBeforeDisappear, true);
                backgroundText.CrossFadeAlpha(0.0f, timerBeforeDisappear, true);
            }
            tbl -= Time.deltaTime;
        }
	}

    public void setText(string xmlVal)
    {
        xmlValue.Add(xmlVal);
        StartCoroutine("nextSentence");
    }

    IEnumerator nextSentence()
    {
        while ((iterator < sentence.Length) || (tbl > -timeWaitEndSentence))
            yield return 0;
        sentence = "";
        foreach (XmlNode node in rootNode.ChildNodes)
        {
            if (node.Name == (string)xmlValue[0])
                sentence = node.InnerText;
        }
        if (sentence != "")
        {
            iterator = 0;
            text.text = "";
            tbl = timerBetweenLetter;
            text.CrossFadeAlpha(1.0f, 0.0f, true);
            backgroundText.CrossFadeAlpha(1.0f, 0.0f, true);
        }
        xmlValue.RemoveAt(0);
    }
}
