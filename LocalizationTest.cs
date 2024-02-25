using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.PropertyVariants;
using UnityEngine.Localization.Settings;
using System.Globalization;

public class LocalizationTest : MonoBehaviour
{
    [SerializeField] GameObjectLocalizer gameObjectLocalizer = null;
    [SerializeField] LocalizeStringEvent localizeStringEvent = null;
    [SerializeField] LocalizationStrings localizationStrings1 = null;
    [SerializeField] LocalizationStrings localizationStrings2 = null;


    [SerializeField] LocalizeStringEvent localizeStringEvent2 = null;

    [SerializeField] LocalizationValueInt localizationValueInt = null;

    int time = 1;

    // Start is called before the first frame update
    void Start()
    {
        localizationStrings1.str = "ttttttt";
        localizationStrings2.str = "1,000";

        localizationValueInt.value = time;
    }

    public void ClickPlus()
    {
        time++;
        localizationValueInt.value = time;
        localizeStringEvent2.RefreshString();
    }

    public void ClickMinus()
    {
        if (time == 1)
            return;

        time--;
        localizationValueInt.value = time;

        localizeStringEvent2.RefreshString();
    }


    public void ClickSecond()
    {
        if (localizeStringEvent2.StringReference["time"] is LocalizedString nested)
        {
            nested.TableEntryReference = "second";
        }
    }


    public void ClickHour()
    {
        if (localizeStringEvent2.StringReference["time"] is LocalizedString nested)
        {
            nested.TableEntryReference = "hour";
        }
    }

    public void ClickMin()
    {
        if (localizeStringEvent2.StringReference["time"] is LocalizedString nested)
        {
            nested.TableEntryReference = "min";
        }
    }

    public void Click001()
    {
        localizeStringEvent.StringReference.TableEntryReference = "error-001";
        
        //localizeStringEvent.StringReference.SetReference("LocalizationString_Lobby", "build_fix_01");

        Debug.Log(LocalizationSettings.StringDatabase.GetTable("LocalizationString_Lobby").GetEntry("build_fix_01").GetLocalizedString());
    }

    public void Click002()
    {
        localizeStringEvent.StringReference.TableEntryReference = "error-002";

        localizeStringEvent.StringReference.GetLocalizedString();
    }

    public void Click003()
    {
        if (localizeStringEvent.StringReference["goods"] is LocalizedString nested)
        {
            nested.TableEntryReference = "goods-001";
        }
    }

    public void Click004()
    {
        if (localizeStringEvent.StringReference["goods"] is LocalizedString nested)
        {
            nested.TableEntryReference = "goods-002";
        }
    }
}