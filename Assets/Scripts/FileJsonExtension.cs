using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    static class FileJsonExtension
    {
        public static List<string> GetLinesFromJsonFile(string fileName)
        {
            var lists = new List<string>();

            if (File.Exists(fileName))
            {
                var jsonStrings = File.ReadAllLines(fileName);

                foreach (var item in jsonStrings.Where(w => (w != "[") && (w != "]")).Select(w => w))
                {
                    lists.Add(item.TrimEnd(','));
                }
            }
            return lists;
        }

        public static T GetObjectFromJsonFile<T>(string path)
        {
            var jsonStrings = File.ReadAllLines(path);
            if ( ( jsonStrings != null ) && ( jsonStrings.Length != 0 ) )
            {
                
            }
            return JsonUtility.FromJson<T>(jsonStrings.First());
        }

        public static void SetObjectFromJsonFile(string path, object Object)
        {
            if (!File.Exists(path)) { File.Create(path); }
            string json = JsonUtility.ToJson(Object);
            File.WriteAllText(path, json);
        }

        public static void SetObjectsFromJsonFile(string path, List<object> objects)
        {
            if (!File.Exists(path)) { File.Create(path); }
            string json = "[\n";
            foreach (var item in objects)
            {
                json += JsonUtility.ToJson(item) + ",\n";
            }
            json = json.TrimEnd(',');
            json += "]";
            File.WriteAllText(path, json);
        }

        public static void AddObjectFromJsonFile(string path, object newObjects)
        {
            AddObjectFromJsonFile(path, new List<object>() { newObjects });
        }

        public static void AddObjectFromJsonFile(string path, List<object> newObjects)
        {
            var oldObjects = GetObjectsFromJsonFile<object>(path);
            oldObjects.AddRange(newObjects);
            SetObjectsFromJsonFile(path, oldObjects);
        }

        public static List<T> GetObjectsFromJsonFile<T>(string path)
        {
            List<T> objects = new List<T>();
            foreach (var item in GetLinesFromJsonFile(path))
            {
                objects.Add(JsonUtility.FromJson<T>(item));
            }
            return objects;
        }
    }
}
