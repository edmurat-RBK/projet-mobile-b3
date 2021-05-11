using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Text;

[XmlRoot("Data")]
public class DataManager : MonoBehaviour
{
    public static DataManager DMInstance;
    public string path;

    XmlSerializer serializer = new XmlSerializer(typeof(Datas));
    Encoding encoding = Encoding.GetEncoding("UTF-8");

    public void Awake()
    {
        DMInstance = this;
        SetPath();
        DontDestroyOnLoad(this.gameObject);
    }

    void SetPath()
    {
        path = Path.Combine(Application.persistentDataPath, "Data.xml");
    }

    public void Save(int highscore,int coins)
    {
        StreamWriter streamWriter = new StreamWriter(path, false);
        Datas data = new Datas { highscore = highscore,coinsCollected = coins};

        serializer.Serialize(streamWriter, data);
    }



    public Datas Load()
    {
        if(File.Exists(path))
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);

            return serializer.Deserialize(fileStream) as Datas;
        }

        return null;
    }
}
