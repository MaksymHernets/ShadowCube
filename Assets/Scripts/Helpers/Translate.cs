using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers
{
    [Serializable]
    public class ClassDictinaory
    {
        public string Key;
        public string Val;

        public ClassDictinaory() { }

        public ClassDictinaory(string key, string val) { Key = key; Val = val; }
    }

    [Serializable]
    public class Translate
    {
        public string name;

        public List<ClassDictinaory> elements;

        //static public Dictionary<string, string> lists = new Dictionary<string, string>() {
        //{ "RUS", "Русский" },
        //{ "ENG", "English"} ,
        //{ "JAP" , "日本人" },
        //{ "CHI" , "漢語" },
        //{ "ISP" , "Español" },
        //{ "GER", "Deutsch" },
        //{ "FRE" ,"Français" }
        //};

        //public enum Launcher
        //{
        //    Rus = "Русский",
        //    Eng = ""
        //}

        [NonSerialized]
        private static string pathToTranslate = @"\Saves\Translate\";

		//public static List<ClassDictinaory> GetDictionaryTranslate(string nameScene, string launcher)
		//{
		//	var path = Application.dataPath + pathToTranslate + nameScene + ".json";
		//	var result = FileJsonExtension.GetObjectsFromJsonFile<Translate>(path);
		//	var elements = result.Where(w => w.name == launcher).FirstOrDefault().elements;
		//	return elements;
		//}

		public static void SetDictionaryTranslate(string nameScene, List<Translate> translates)
        {
            var path = Application.dataPath + pathToTranslate + nameScene + ".json";
            //FileJsonExtension.SetObjectsFromJsonFile(path, translates.Select(w => (object)w).ToList() );
        }

        public static void ToTranslate(List<ClassDictinaory> elements)
        {
            foreach (var item in elements)
            {
                GameObject.Find(item.Key).GetComponentInChildren<Text>().text = item.Val;
            }
        }
    }
}
