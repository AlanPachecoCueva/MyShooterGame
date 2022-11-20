using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJSON : MonoBehaviour
{

    public static Score data;
    
    
    /*void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            
            //Datos a guardar, se incrustan dentro de newData tipo Score
            Score newData = new Score();
            newData.score = 20;
            newData.player = "Alan";
            newData.date = "17/11/2022 : 17:25";

            saveJSON(newData, pathData, nameFileData);
        }

        if(Input.GetKeyDown("space")){
            List<Score> dataFound = ObtenerListaScores<Score>(pathData, nameFileData);
            foreach (var data in dataFound)
            {
                Debug.Log(data.toString());
            }
        }
    }*/


    public void saveJSON<T>(T data){
        string pathData = Application.persistentDataPath + "/Scores/";
        string nameFileData = "scores.txt";

        //Define la ruta donnde se guardará el archivo
        //string fullPath = Application.persistentDataPath + "/" + path + "/";

        //Devuelve true o false dependiendo de si el directorio/carpeta existe o no
        bool checkFolderExit = Directory.Exists(pathData);

        //Si el directorio/carpeta no existe entonces se crea
        if(!checkFolderExit){
            Directory.CreateDirectory(pathData);
        }

        //Pasamos el objeto data con la información necesaria a formato json
        string json = JsonUtility.ToJson(data);

        //Lee el archivo y observa si hay información previa existente
        var dataFound = LoadData<Score>();

        //Si no hay texto guardado
        if(dataFound == null){
            //Ingresa el texto como el primero de todos
            File.WriteAllText(pathData+nameFileData, json);
        }else{
            //Si existe contenido quiere decir que debe agregar el nuevo json al final
            File.AppendAllText(pathData+nameFileData, " | "+json);
        }

        Debug.Log("Save data ok: "+pathData);
    }

    public static string LoadData<T>(){
        string pathData = Application.persistentDataPath + "/Scores/";
        string nameFileData = "scores.txt";
        //Define la ruta total en donde se encuentra el objeto json
        //string fullPath = Application.persistentDataPath + "/" + path + "/" + fileName + ".txt";

        //Si existe
        if(File.Exists(pathData+nameFileData)){
            //Recupera la información guardada en el texto
            string textJson = File.ReadAllText(pathData+nameFileData);

            //Devuelve ese texto
            return textJson;
        }else{
            //Si no existe retorna null
            Debug.Log("not file found on load data");
            return default;
        }
    } 

    public static List<Score> ObtenerListaScores<T>(){
        string pathData = Application.persistentDataPath + "/Scores/";
        string nameFileData = "scores.txt";

        //Lista que almacena todos los scores (objetos) registrados en el archivo
        List<Score> listOfScores = new List<Score>();

        //Recupera los datos puros guardados en el txt
        var dataFound = LoadData<Score>();

        //Si no hay texto guardado
        if(dataFound == null){
            listOfScores = null;
            Debug.Log("There are no Scores to show");
        }else{

            //Si sí hay texto guardado

            //Esta lista tiene cada uno de los json de score por separado
            string[] listJSONS = dataFound.Split('|');

            //Este foreach recupera cada json individual y lo transforma a su objeto score
            foreach (var sub in listJSONS)
            {
                //Convertir objeto json a objeto Score
                Score scoreAux = JsonUtility.FromJson<Score>(sub);

                //Se añade a la lista
                listOfScores.Add(scoreAux);
            }
            Debug.Log("Scores saved");
        }
        return listOfScores;
    } 
}
