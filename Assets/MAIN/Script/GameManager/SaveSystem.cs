using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.SceneManagement;

public static class SaveSystem {

    public static void SaveGame(GameManager gameManager) {

        BinaryFormatter formatter = new BinaryFormatter();                      // A formatter to allow file serialization.
        string path = Application.persistentDataPath + "/player.progress";      // The path where the file should be saved.
        FileStream stream = new FileStream(path, FileMode.Create);              // Create new file.

        try {
            GameData data = new GameData(gameManager);                          // Create the data to be saved.
            formatter.Serialize(stream, data);                                  // Serialize data in the defined filestream.
        } catch (Exception e) {
            Debug.LogError("Exception thrown: " + e);
        }

        stream.Close();

    }

    public static GameData LoadGame () {

        string path = Application.persistentDataPath + "/player.progress";

        if (File.Exists(path)) {
            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);            // Open file if it exists.

            try {

                GameData data = formatter.Deserialize(stream) as GameData;      // Deserialize data as a gamedata type.
                stream.Close();
                return data;
            } catch (Exception e) {
                Debug.LogError("Exception thrown: " + e);
                return null;
            }

        } else {
            return null;
        }
    }

    public static void NewGame() {

        string path = Application.persistentDataPath + "/player.progress";

        if (File.Exists(path)) {
            File.Delete(path);
        }

        SceneManager.LoadScene(1);
    }

}
