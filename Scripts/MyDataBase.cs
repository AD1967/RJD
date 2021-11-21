using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
static class MyDataBase
{
    private const string fileName = "test.db";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
static MyDataBase()
{
    DBPath = GetDatabasePath();
}

/// <summary> Возвращает путь к БД. Если её нет в нужной папке на Андроиде, то копирует её с исходного apk файла. </summary>
private static string GetDatabasePath()
{
#if UNITY_EDITOR
    return Path.Combine("Assets/StreamingAssets", fileName);
#endif
#if UNITY_STANDALONE
    string filePath = Path.Combine(Application.dataPath, fileName);
    if(!File.Exists(filePath)) UnpackDatabase(filePath);
    return filePath;
#endif
}

/// <summary> Распаковывает базу данных в указанный путь. </summary>
/// <param name="toPath"> Путь в который нужно распаковать базу данных. </param>
private static void UnpackDatabase(string toPath)
{
    string fromPath = Path.Combine("Assets/StreamingAssets", fileName);

    WWW reader = new WWW(fromPath);
    while (!reader.isDone) { }

    File.WriteAllBytes(toPath, reader.bytes);
}
private static void OpenConnection()
{
    connection = new SqliteConnection("Data Source=" + DBPath);
    command = new SqliteCommand(connection);
    connection.Open();
}
public static void CloseConnection()
{
    connection.Close();
    command.Dispose();
}
public static void ExecuteQueryWithoutAnswer(string query)
{
    OpenConnection();
    command.CommandText = query;
    command.ExecuteNonQuery();
    CloseConnection();
}
public static string ExecuteQueryWithAnswer(string query)
{
    OpenConnection();
    command.CommandText = query;
    var answer = command.ExecuteScalar();
    CloseConnection();

    if (answer != null) return answer.ToString();
    else return null;
}
public static bool check(string query){
    OpenConnection();
    command.CommandText = query;
    var answer = command.ExecuteScalar();
    CloseConnection();
    return (answer != null);
}
public static int getlast(){
    OpenConnection();
    command.CommandText = "SELECT user_id FROM user ORDER by user_id DESC;";
    var answer = command.ExecuteScalar();
    CloseConnection();
    return int.Parse(answer.ToString());
}
public static int getlast_id(){
    OpenConnection();
    command.CommandText = "SELECT id FROM post ORDER by 'id' DESC;";
    var answer = command.ExecuteScalar();
    CloseConnection();
    return int.Parse(answer.ToString());
}
public static DataTable GetTable(string query)
{
    OpenConnection();
    SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);
    DataSet DS = new DataSet();
    adapter.Fill(DS);
    adapter.Dispose();

    CloseConnection();
    return DS.Tables[0];
}
}

