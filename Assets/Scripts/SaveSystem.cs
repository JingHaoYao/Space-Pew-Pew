using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void saveData(CheckPoints checkpoints)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savadata.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData savingData = new SaveData(checkpoints);

        formatter.Serialize(stream, savingData);
        stream.Close();
    }

    public static SaveData loadData()
    {
        string path = Application.persistentDataPath + "/savadata.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData savedData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return savedData;
        }
        else
        {
            return null;
        }
    }

}
