﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AGC_Technowizz {
  static public class Core {
    private static string CONFIG = "";
    const string FullErrorMessage = "Plno";
    public static Dictionary<string, int[]> Storage = new Dictionary<string, int[]>();

    public static void Setup(string path = @"./Config.conf")
    {
      // Vytvoření configu
      StreamReader sr = new StreamReader(path);
      foreach (string line in sr.ReadToEnd().Split('\n'))
        if (line.StartsWith("#") || line.Length <= 3) continue;
        else CONFIG += line + "\n";
      sr.Close();

      // Načtení plnosti skladu
      LoadDataFromDatabase();
    }

    public static string GetCarBrandFromContainerCode(string containerCode) {
      /*
       * 
       *  Zde se uskutečňuje požadavek na SAP.
       *  Aplikace potřebuje z kódu palety získat značku auta, konkrétně řetězec o délce dvou nebo tří písmen (např. "TOY" nebo "MS").
       *  Podle značky auta se zjistí zóna, kde by se měla paleta nacházet (soubor Config.conf).
       *  K těmto datům my nemáme přístup, proto pro správnou funkčnost aplikace je potřeba toto implementovat.
       * 
       */

      return new string[] { "PO", "MS", "SK", "BM" }.ElementAt(new Random().Next(4)); // Přepsat!
    }

    public static string GetZoneFromCarBrand(string carBrand) {
      Dictionary<string, string> carZonePairs = new Dictionary<string, string>();

      // Načtení configu
      foreach (string line in CONFIG.Split('\n'))
      {
        if (line.Length > 0)
        {
          string[] splittedLine = line.Split(':');
          carZonePairs.Add(splittedLine[0], splittedLine[1]);
        }
      }

      // Pokud je definováno více zón
      if (carZonePairs[carBrand.ToUpper()].Contains(","))
      {
        string[] zones = carZonePairs[carBrand.ToUpper()].Split(',');
        bool full;
        string zone = "";

        foreach (string _zone in zones)
        {
          zone = _zone;
          full = IsZoneFull(zone);
          if (!full)
          {
            // Alespoň jedna zóna není plná (definováno více zón)
            AddToStorage(zone);
            return zone;
          }
        }
        // Všechny zóny jsou (definováno více zón)
        return $"{FullErrorMessage}-{zone}";
      }

      if (!IsZoneFull(carZonePairs[carBrand.ToUpper()]))
      {
        // Není plná zóna (pouze 1 definována)
        AddToStorage(carZonePairs[carBrand.ToUpper()]);
        return carZonePairs[carBrand.ToUpper()];
      }
      // Je plná zóna (pouze 1 definována)
      return $"{FullErrorMessage}-{carZonePairs[carBrand.ToUpper()]}";
    }

    public static bool IsZoneFull(string zone)
    {
      zone = zone.Trim().ToUpper();

      // Testování plnosti zóny
      if (Storage[zone][0] >= Storage[zone][1]) return true;
      return false;
    }

    private static void AddToStorage(string key)
    {
      key = key.Trim().ToUpper();

      // Přidání do skladu (z důvodu výpočtu plnosti)
      Storage[key][0]++;
    }

    public static void LoadDataFromDatabase(string Cesta_k_souboru = @"./data.csv")
    {
      using (StreamReader sr = new StreamReader(Cesta_k_souboru))
      {
        /*
         * 
         * Zde je zapotřebí výstup z databáze
         * soubor data.csv ve formátu [název zóny];[aktuální stav zóny];[maximalní počet palet v zóně]
         * 
         */

        // Nahrání souboru do plnosti skladu
        while (!sr.EndOfStream)
        {
          string[] items = sr.ReadLine().Split(';');
          if (Storage.ContainsKey(items[0])) 
            Storage[items[0].ToUpper().Trim()] = new int[] { Convert.ToInt32(items[1]), Convert.ToInt32(items[2]) };
          else 
            Storage.Add(items[0].ToUpper().Trim(), new int[] { Convert.ToInt32(items[1]), Convert.ToInt32(items[2]) });
        }
      }
    }
  }
}