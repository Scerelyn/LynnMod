using Battle.DiceAttackEffect;
using HarmonyLib;
using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UI;
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

        public static Dictionary<string, Type> CustomEffects = new Dictionary<string, Type>();

        public override void OnInitializeMod()
        {
            base.OnInitializeMod();
            Harmony harmony = new Harmony("LOR.LynnMod");
            MethodInfo method = typeof(Initializer).GetMethod("BookModel_SetXmlInfo");
            harmony.Patch(typeof(BookModel).GetMethod("SetXmlInfo", AccessTools.all), null, new HarmonyMethod(method));
            method = typeof(Initializer).GetMethod("BookModel_GetThumbSprite");
            harmony.Patch(typeof(BookModel).GetMethod("GetThumbSprite", AccessTools.all), new HarmonyMethod(method));
            language = GlobalGameManager.Instance.CurrentOption.language;
            path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

            method = typeof(Initializer).GetMethod("UISettingInvenEquipPageListSlot_SetBooksData");
            harmony.Patch(typeof(UISettingInvenEquipPageListSlot).GetMethod("SetBooksData", AccessTools.all), new HarmonyMethod(method));
            method = typeof(Initializer).GetMethod("UIInvenEquipPageListSlot_SetBooksData");
            harmony.Patch(typeof(UIInvenEquipPageListSlot).GetMethod("SetBooksData", AccessTools.all), new HarmonyMethod(method));
            method = typeof(Initializer).GetMethod("UISpriteDataManager_GetStoryIcon");
            harmony.Patch(typeof(UISpriteDataManager).GetMethod("GetStoryIcon", AccessTools.all), new HarmonyMethod(method));

            method = typeof(Initializer).GetMethod("DiceEffectManager_CreateBehaviourEffect");
            harmony.Patch(typeof(DiceEffectManager).GetMethod("CreateBehaviourEffect", AccessTools.all), new HarmonyMethod(method));

            GetArtWorks(new DirectoryInfo(path + "/ArtWork"));
            GetCustomEffects(new DirectoryInfo(path + "/CustomEffects"));

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

        public static bool BookModel_GetThumbSprite(BookModel __instance, ref Sprite __result)
        {
            if (__instance.BookId.packageId == PackageId)
            {
                int id = __instance.BookId.id;
                switch (id)
                {
                    case 10000001:
                        __result = ArtWorks["Lynn"];
                        return false;
                    case 10000002:
                        __result = ArtWorks["Fel"];
                        return false;
                    case 10000003:
                        __result = ArtWorks["Akao"];
                        return false;
                    case 10000004:
                        __result = ArtWorks["Enbana"];
                        return false;
                    case 10000005:
                        __result = ArtWorks["EnbanaGuard"];
                        return false;
                    case 10000006:
                        __result = ArtWorks["Saeka"];
                        return false;
                    case 10000007:
                        __result = ArtWorks["Gredo"];
                        return false;
                    case 10000008:
                        __result = ArtWorks["Rube"];
                        return false;
                }
            }
            return true;
        }

        public static bool UIInvenEquipPageListSlot_SetBooksData(UISettingInvenEquipPageListSlot __instance, List<BookModel> books, UIStoryKeyData storyKey)
        {
            if (storyKey.workshopId == PackageId)
            {
                Image val = (Image)((object)__instance).GetType().GetField("img_IconGlow", AccessTools.all).GetValue(__instance);
                Image val2 = (Image)((object)__instance).GetType().GetField("img_Icon", AccessTools.all).GetValue(__instance);
                TextMeshProUGUI val3 = (TextMeshProUGUI)((object)__instance).GetType().GetField("txt_StoryName", AccessTools.all).GetValue(__instance);
                UIEquipPageScrollList listRoot = (UIEquipPageScrollList)((object)__instance).GetType().GetField("listRoot", AccessTools.all).GetValue(__instance);
                List<UIOriginEquipPageSlot> list = (List<UIOriginEquipPageSlot>)((object)__instance).GetType().GetField("equipPageSlotList", AccessTools.all).GetValue(__instance);
                if (books.Count >= 0)
                {
                    ((Behaviour)val).enabled = true;
                    ((Behaviour)val2).enabled = true;
                    val2.sprite = ArtWorks["lynnfel_icon"];
                    val.sprite = ArtWorks["lynnfel_icon"];
                    switch (language)
                    {
                        case "en":
                            ((TMP_Text)val3).text = "Lynn Mod";
                            break;
                        default:
                            ((TMP_Text)val3).text = "Lynn Mod";
                            break;
                    }
                }
                __instance.SetFrameColor(UIColorManager.Manager.GetUIColor(UIColor.Default));
                List<BookModel> list2 = new List<BookModel>((List<BookModel>)typeof(UIInvenEquipPageListSlot).GetMethod("ApplyFilterBooksInStory", AccessTools.all).Invoke(__instance, new object[1] { books }));
                __instance.SetEquipPagesData(list2);
                BookModel bookModel = list2.Find((BookModel x) => x == UI.UIController.Instance.CurrentUnit.bookItem);
                if (listRoot.CurrentSelectedBook == null && bookModel != null)
                {
                    listRoot.CurrentSelectedBook = bookModel;
                }
                if (listRoot.CurrentSelectedBook != null)
                {
                    UIOriginEquipPageSlot uIOriginEquipPageSlot = list.Find((UIOriginEquipPageSlot x) => x.BookDataModel == listRoot.CurrentSelectedBook);
                    if (uIOriginEquipPageSlot != null)
                    {
                        uIOriginEquipPageSlot.SetHighlighted(on: true, isClick: true);
                    }
                }
                __instance.SetSlotSize();
                return false;
            }
            return true;
        }

        public static bool UISettingInvenEquipPageListSlot_SetBooksData(UISettingInvenEquipPageListSlot __instance, List<BookModel> books, UIStoryKeyData storyKey)
        {
            if (storyKey.workshopId == PackageId)
            {
                Image val = (Image)((object)__instance).GetType().GetField("img_IconGlow", AccessTools.all).GetValue(__instance);
                Image val2 = (Image)((object)__instance).GetType().GetField("img_Icon", AccessTools.all).GetValue(__instance);
                TextMeshProUGUI val3 = (TextMeshProUGUI)((object)__instance).GetType().GetField("txt_StoryName", AccessTools.all).GetValue(__instance);
                UIEquipPageScrollList listRoot = (UIEquipPageScrollList)((object)__instance).GetType().GetField("listRoot", AccessTools.all).GetValue(__instance);
                List<UIOriginEquipPageSlot> list = (List<UIOriginEquipPageSlot>)((object)__instance).GetType().GetField("equipPageSlotList", AccessTools.all).GetValue(__instance);
                if (books.Count >= 0)
                {
                    ((Behaviour)val).enabled = true;
                    ((Behaviour)val2).enabled = true;
                    val2.sprite = ArtWorks["lynnfel_icon"];
                    val.sprite = ArtWorks["lynnfel_icon"];
                    switch (language)
                    {
                        case "en":
                            ((TMP_Text)val3).text = "Lynn Mod";
                            break;
                        default:
                            ((TMP_Text)val3).text = "Lynn Mod";
                            break;
                    }
                }
                __instance.SetFrameColor(UIColorManager.Manager.GetUIColor(UIColor.Default));
                List<BookModel> list2 = new List<BookModel>((List<BookModel>)typeof(UIInvenEquipPageListSlot).GetMethod("ApplyFilterBooksInStory", AccessTools.all).Invoke(__instance, new object[1] { books }));
                __instance.SetEquipPagesData(list2);
                BookModel bookModel = list2.Find((BookModel x) => x == UI.UIController.Instance.CurrentUnit.bookItem);
                if (listRoot.CurrentSelectedBook == null && bookModel != null)
                {
                    listRoot.CurrentSelectedBook = bookModel;
                }
                if (listRoot.CurrentSelectedBook != null)
                {
                    UIOriginEquipPageSlot uIOriginEquipPageSlot = list.Find((UIOriginEquipPageSlot x) => x.BookDataModel == listRoot.CurrentSelectedBook);
                    if (uIOriginEquipPageSlot != null)
                    {
                        uIOriginEquipPageSlot.SetHighlighted(on: true, isClick: true);
                    }
                }
                __instance.SetSlotSize();
                return false;
            }
            return true;
        }

        public static bool UISpriteDataManager_GetStoryIcon(string story, ref UIIconManager.IconSet __result)
        {
            if (!string.IsNullOrWhiteSpace(story) && ArtWorks.ContainsKey(story))
            {
                __result = new UIIconManager.IconSet
                {
                    type = story,
                    icon = ArtWorks[story],
                    iconGlow = ArtWorks[story]
                };
                return false;
            }
            return true;
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

        public static void GetCustomEffects(DirectoryInfo dir)
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
                Sprite value = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
                ArtWorks[fileNameWithoutExtension + "_FX"] = value;
            }
        }

        public static bool DiceEffectManager_CreateBehaviourEffect(ref DiceAttackEffect __result, string resource, float scaleFactor, BattleUnitView self, BattleUnitView target, float time = 1f)
        {
            if (resource == null)
            {
                __result = null;
                return false;
            }
            if (!CustomEffects.ContainsKey(resource) && resource != string.Empty)
            {
                Type[] types = Assembly.LoadFrom(path + "/LynnMod.dll").GetTypes();
                foreach (Type type in types)
                {
                    if (type.Name == "DiceAttackEffect_" + resource)
                    {
                        Type value = type;
                        CustomEffects[resource] = value;
                        break;
                    }
                }
            }
            if (CustomEffects.ContainsKey(resource))
            {
                Type componentType = CustomEffects[resource];
                DiceAttackEffect diceAttackEffect = new GameObject(resource).AddComponent(componentType) as DiceAttackEffect;
                diceAttackEffect.Initialize(self, target, time);
                diceAttackEffect.SetScale(scaleFactor);
                __result = diceAttackEffect;
                return false;
            }
            return true;
        }
    }
}
