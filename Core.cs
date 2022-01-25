using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGC_Technowizz {
  static public class Core {
    private static string CONFIG = "";
    private static readonly int MAX_SIZE = 24;

    public static Dictionary<string, int[]> Storage = new Dictionary<string, int[]>();

    public static void Setup(string path = @"../../Config.conf")
    {
      // Možná zde nahrát a použít data z excelového souboru (pro ukázku programu), který jsme dostali

      System.IO.StreamReader sr = new System.IO.StreamReader(path);

      foreach (string line in sr.ReadToEnd().Split('\n'))
        if (line.StartsWith("#") || line.Length <= 3) continue;
        else CONFIG += line + "\n";

      sr.Close();
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

      foreach (string line in CONFIG.Split('\n'))
      {
        if (line.Length > 0)
        {
          string[] splittedLine = line.Split(':');
          carZonePairs.Add(splittedLine[0], splittedLine[1]);
        }
      }

      if (carZonePairs[carBrand.ToUpper()].Contains(","))
      {
        string[] zones = carZonePairs[carBrand.ToUpper()].Split(',');
        int zoneIndex = 0;
        bool full;
        do
        {
          try
          {
            full = IsZoneFull(zones[zoneIndex]);
          } 
          catch (IndexOutOfRangeException)
          {
            return "FULL";
          }
          if (full) zoneIndex++;
        } while (full);

        AddToStorage(zones[zoneIndex]);
        return zones[zoneIndex];
      }
      AddToStorage(carZonePairs[carBrand.ToUpper()]);
      return carZonePairs[carBrand.ToUpper()];
    }

    public static bool IsZoneFull(string zone)
    {
      try
      {
        if (Storage[zone][0] >= Storage[zone][1]) return true;
      }
      catch (KeyNotFoundException)
      {
        Storage.Add(zone, new int[] { 1, MAX_SIZE });
      }
      return false;
    }

    private static void AddToStorage(string key)
    {
      try
      {
        Storage[key][0]++;
      } 
      catch (KeyNotFoundException)
      {
        Storage.Add(key, new int[] { 0, MAX_SIZE });
      }
    }
  }
}
