﻿namespace Caveman.Setting
{
    public class Settings
    {
        public const int MaxCountPlayers = 10;
        public const int Br = 10;
        public const float BoundaryEndMap = 10;
        public const int TimeRespawnPlayer = 1;
        public const int RotateStoneParameter = 10; 

        public static int RoundTime = 50;
        public static int TimeRespawnWeapon = 14;
        public static int BotsCount = 4;
        public static int InitialLyingWeapons = 10;
        public static float SpeedStone = 4f;
        public static float SpeedPlayer = 2.5f;
        public static int TimeThrowStone = 3;
        public static int MaxCountWeapons = 4;
        public static float HeightCamera = 1;

        //мощность множества - посмотреть перевод
        public const int PoolCountLyingStones = 30;
        public const int PoolCountDeathImages = 9;
        //todo объединить два пула
        public const int PoolCountHandStones = 30;
        public const int PoolCountSplashStones = 30;
        
        public const string AnimRunF = "run_f";
        public const string AnimRunB = "run_b";
        public const string AnimThrowF = "throw_f";
        public const string AnimThrowB = "throw_b";
        public const string AnimStayB = "stay_b";
        public const string AnimStayF = "stay_f";
        public const string AnimPickup = "pickup";
    }
}