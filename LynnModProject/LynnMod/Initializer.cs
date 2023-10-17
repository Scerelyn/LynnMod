﻿using HarmonyLib;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Ruina
{
    public class Initializer : ModInitializer
    {
        public static string PackageId = "Lynn Mod";

        public static string path;

        public static string language;

        public static Dictionary<string, Sprite> ArtWorks = new Dictionary<string, Sprite>();

        public override void OnInitializeMod()
        {
            base.OnInitializeMod();
            Harmony harmony = new Harmony("LOR.LynnMod");
            MethodInfo method = typeof(Initializer).GetMethod("BookModel_SetXmlInfo");
            harmony.Patch(typeof(BookModel).GetMethod("SetXmlInfo", AccessTools.all), null, new HarmonyMethod(method));
            language = GlobalGameManager.Instance.CurrentOption.language;
            path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            GetArtWorks(new DirectoryInfo(path + "/ArtWork"));
        }

        public static void BookModel_SetXmlInfo(BookModel __instance, BookXmlInfo ____classInfo, ref List<DiceCardXmlInfo> ____onlyCards)
        {
            if (!(__instance.BookId.packageId == PackageId))
            {
                return;
            }
            foreach (int item in ____classInfo.EquipEffect.OnlyCard)
            {
                DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId(PackageId, item));
                ____onlyCards.Add(cardItem);
            }
        }

        public static void GetArtWorks(DirectoryInfo dir)
        {
            if (dir.GetDirectories().Length != 0)
            {
                DirectoryInfo[] directories = dir.GetDirectories();
                for (int i = 0; i < directories.Length; i++)
                {
                    GetArtWorks(directories[i]);
                }
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo fileInfo in files)
            {
                Texture2D texture2D = new Texture2D(2, 2);
                texture2D.LoadImage(File.ReadAllBytes(fileInfo.FullName));
                Sprite value = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f));
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                ArtWorks[fileNameWithoutExtension] = value;
            }
        }
    }
}
