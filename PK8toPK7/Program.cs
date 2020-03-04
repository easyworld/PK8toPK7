using PKHeX.Core;
using System;
using System.IO;

namespace PK8toPK7
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("input path please");
                return;
            }
            var path = args[0];
            var fi = new FileInfo(path);

            if (!fi.Exists)
                return;

            if (FileUtil.IsFileTooBig(fi.Length))
            {
                Console.WriteLine("File too big");
                return;
            }
            if (FileUtil.IsFileTooSmall(fi.Length))
            {
                Console.WriteLine("File too small");
                return;
            }
            byte[] input; try { input = File.ReadAllBytes(path); }
            catch (Exception e) { Console.WriteLine("Read error"); return; }
            if (input == null)
                return;
            PK8 pk8 = new PK8(input);
            PK7 pk7 = convert(pk8);
            var data = pk7.DecryptedPartyData;
            File.WriteAllBytes(Path.GetFileNameWithoutExtension(path) + ".pk7", data);

        }

        private static PK7 convert(PK8 pk8)
        {
            PK7 pk7 = new PK7();
            pk7.EncryptionConstant = pk8.EncryptionConstant;
            pk7.Species = pk8.Species;
            pk7.TID = pk8.TID;
            pk7.SID = pk8.SID;
            pk7.EXP = pk8.EXP;
            pk7.PID = pk8.PID;
            pk7.Ability = pk8.Ability;
            pk7.AbilityNumber = pk8.AbilityNumber;
            pk7.Markings = pk8.Markings;
            pk7.Language = pk8.Language;
            pk7.EV_HP = pk8.EV_HP;
            pk7.EV_ATK = pk8.EV_ATK;
            pk7.EV_DEF = pk8.EV_DEF;
            pk7.EV_SPA = pk8.EV_SPA;
            pk7.EV_SPD = pk8.EV_SPD;
            pk7.EV_SPE = pk8.EV_SPE;
            pk7.Move1 = pk8.Move1;
            pk7.Move2 = pk8.Move2;
            pk7.Move3 = pk8.Move3;
            pk7.Move4 = pk8.Move4;
            pk7.Move1_PPUps = pk8.Move1_PPUps;
            pk7.Move2_PPUps = pk8.Move2_PPUps;
            pk7.Move3_PPUps = pk8.Move3_PPUps;
            pk7.Move4_PPUps = pk8.Move4_PPUps;
            pk7.RelearnMove1 = pk8.RelearnMove1;
            pk7.RelearnMove2 = pk8.RelearnMove2;
            pk7.RelearnMove3 = pk8.RelearnMove3;
            pk7.RelearnMove4 = pk8.RelearnMove4;
            pk7.IV_HP = pk8.IV_HP;
            pk7.IV_ATK = pk8.IV_ATK;
            pk7.IV_DEF = pk8.IV_DEF;
            pk7.IV_SPA = pk8.IV_SPA;
            pk7.IV_SPD = pk8.IV_SPD;
            pk7.IV_SPE = pk8.IV_SPE;
            pk7.IsEgg = pk8.IsEgg;
            pk7.IsNicknamed = pk8.IsNicknamed;
            pk7.FatefulEncounter = pk8.FatefulEncounter;
            pk7.Gender = pk8.Gender;
            pk7.AltForm = pk8.AltForm;
            pk7.Nature = pk8.Nature;
            pk7.Nickname = pk8.Nickname;
            pk7.Version = pk8.Version;
            pk7.OT_Name = pk8.OT_Name;
            pk7.MetDate = pk8.MetDate;
            pk7.EggMetDate = pk8.EggMetDate;
            pk7.Met_Location = pk8.Met_Location;
            pk7.Egg_Location = pk8.Egg_Location;
            pk7.Ball = pk8.Ball;
            pk7.Met_Level = pk8.Met_Level;
            pk7.OT_Gender = pk8.OT_Gender;
            pk7.HyperTrainFlags = pk8.HyperTrainFlags;

            // Locale does not transfer. All Zero
            // Country = Country,
            // Region = Region,
            // ConsoleRegion = ConsoleRegion,

            PKMConverter.SetFirstCountryRegion(pk7);

            pk7.OT_Memory = pk8.OT_Memory;
            pk7.OT_TextVar = pk8.OT_TextVar;
            pk7.OT_Feeling = pk8.OT_Feeling;
            pk7.OT_Intensity = pk8.OT_Intensity;

            pk7.PKRS_Strain = pk8.PKRS_Strain;
            pk7.PKRS_Days = pk8.PKRS_Days;
            pk7.CNT_Cool = pk8.CNT_Cool;
            pk7.CNT_Beauty = pk8.CNT_Beauty;
            pk7.CNT_Cute = pk8.CNT_Cute;
            pk7.CNT_Smart = pk8.CNT_Smart;
            pk7.CNT_Tough = pk8.CNT_Tough;
            pk7.CNT_Sheen = pk8.CNT_Sheen;

            pk7.RibbonChampionG3Hoenn = pk8.RibbonChampionG3Hoenn;
            pk7.RibbonChampionSinnoh = pk8.RibbonChampionSinnoh;
            pk7.RibbonEffort = pk8.RibbonEffort;
            pk7.RibbonAlert = pk8.RibbonAlert;
            pk7.RibbonShock = pk8.RibbonShock;
            pk7.RibbonDowncast = pk8.RibbonDowncast;
            pk7.RibbonCareless = pk8.RibbonCareless;
            pk7.RibbonRelax = pk8.RibbonRelax;
            pk7.RibbonSnooze = pk8.RibbonSnooze;
            pk7.RibbonSmile = pk8.RibbonSmile;
            pk7.RibbonGorgeous = pk8.RibbonGorgeous;
            pk7.RibbonRoyal = pk8.RibbonRoyal;
            pk7.RibbonGorgeousRoyal = pk8.RibbonGorgeousRoyal;
            pk7.RibbonArtist = pk8.RibbonArtist;
            pk7.RibbonFootprint = pk8.RibbonFootprint;
            pk7.RibbonRecord = pk8.RibbonRecord;
            pk7.RibbonLegend = pk8.RibbonLegend;
            pk7.RibbonCountry = pk8.RibbonCountry;
            pk7.RibbonNational = pk8.RibbonNational;
            pk7.RibbonEarth = pk8.RibbonEarth;
            pk7.RibbonWorld = pk8.RibbonWorld;
            pk7.RibbonClassic = pk8.RibbonClassic;
            pk7.RibbonPremier = pk8.RibbonPremier;
            pk7.RibbonEvent = pk8.RibbonEvent;
            pk7.RibbonBirthday = pk8.RibbonBirthday;
            pk7.RibbonSpecial = pk8.RibbonSpecial;
            pk7.RibbonSouvenir = pk8.RibbonSouvenir;
            pk7.RibbonWishing = pk8.RibbonWishing;
            pk7.RibbonChampionBattle = pk8.RibbonChampionBattle;
            pk7.RibbonChampionRegional = pk8.RibbonChampionRegional;
            pk7.RibbonChampionNational = pk8.RibbonChampionNational;
            pk7.RibbonChampionWorld = pk8.RibbonChampionWorld;
            pk7.RibbonChampionKalos = pk8.RibbonChampionKalos;
            pk7.RibbonChampionG6Hoenn = pk8.RibbonChampionG6Hoenn;
            pk7.RibbonBestFriends = pk8.RibbonBestFriends;
            pk7.RibbonTraining = pk8.RibbonTraining;
            pk7.RibbonBattlerSkillful = pk8.RibbonBattlerSkillful;
            pk7.RibbonBattlerExpert = pk8.RibbonBattlerExpert;
            pk7.RibbonContestStar = pk8.RibbonContestStar;
            pk7.RibbonMasterCoolness = pk8.RibbonMasterCoolness;
            pk7.RibbonMasterBeauty = pk8.RibbonMasterBeauty;
            pk7.RibbonMasterCuteness = pk8.RibbonMasterCuteness;
            pk7.RibbonMasterCleverness = pk8.RibbonMasterCleverness;
            pk7.RibbonMasterToughness = pk8.RibbonMasterToughness;
            pk7.RibbonCountMemoryContest = pk8.RibbonCountMemoryContest;
            pk7.RibbonCountMemoryBattle = pk8.RibbonCountMemoryBattle;
            pk7.RibbonChampionAlola = pk8.RibbonChampionAlola;
            pk7.RibbonBattleRoyale = pk8.RibbonBattleRoyale;
            pk7.RibbonBattleTreeGreat = pk8.RibbonBattleTreeGreat;
            pk7.RibbonBattleTreeMaster = pk8.RibbonBattleTreeMaster;

            pk7.OT_Friendship = pk8.OT_Friendship;

            // No Ribbons or Markings on transfer.

            pk7.Nature = pk8.StatNature;
            // HeightScalar = 0,
            // WeightScalar = 0,

         

            pk7.HealPP();
            // Fix Checksum
            pk7.RefreshChecksum();
            return pk7;
        }
    }
}
