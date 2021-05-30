using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

[XmlRoot("Data")]
public class DataManager : MonoBehaviour
{
    public static DataManager DMInstance;
    public string path;
    public string path2;

    XmlSerializer serializer = new XmlSerializer(typeof(Datas));
    XmlSerializer serializer2 = new XmlSerializer(typeof(ShopData));
    Encoding encoding = Encoding.GetEncoding("UTF-8");

    public void Awake()
    {
        if(DMInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DMInstance = this;
        }
        SetPath();
        
        DontDestroyOnLoad(this.gameObject);
    }

    void SetPath()
    {
        path = Path.Combine(Application.persistentDataPath, "Data.xml");
        path2 = Path.Combine(Application.persistentDataPath, "ShopData.xml");
    }

    public void Save(int highscore,int coins,int purpleCoins)
    {
        StreamWriter streamWriter = new StreamWriter(path, false);
        Datas data = new Datas { highscore = highscore,coinsCollected = coins};

        serializer.Serialize(streamWriter, data);
        streamWriter.Close();
    }
    public void ShopSave(int unlockBoost,bool scoreMulti,bool doubleCoins,bool revive,int maxLife,bool startShield,bool tutorial)
    {
        StreamWriter streamWriter = new StreamWriter(path2, false);
        ShopData data = new ShopData {unlockBoost = unlockBoost,scoreMulti = scoreMulti,doubleCoins = doubleCoins,revive=revive,maxLife=maxLife,startShield = startShield,tutorial = tutorial};

        serializer2.Serialize(streamWriter, data);
        streamWriter.Close();
        
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

    public ShopData LoadShop()
    {
        if(File.Exists(path2))
        {
            FileStream fileStream = new FileStream(path2, FileMode.Open);

            return serializer2.Deserialize(fileStream) as ShopData;
        }

        return null;
    }
}
