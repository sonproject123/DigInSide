using System;
using System.Collections.Generic;
using UnityEngine;

public static class Skill {
    private static Dictionary<string, Action<int>> skillCodes = new Dictionary<string, Action<int>>();

    static Skill() {
        skillCodes.Add("Common1LvSkills", Common1LvSkills);
        skillCodes.Add("GoldPlus", GoldPlus);
        skillCodes.Add("AttackPlus", AttackPlus);
        skillCodes.Add("CooldownPlus", CooldownPlus);
        skillCodes.Add("RangePlus", RangePlus);
        skillCodes.Add("DurabilityPlus", DurabilityPlus);
        skillCodes.Add("MoveSpeedPlus", MoveSpeedPlus);
        skillCodes.Add("BombAttackPlus", BombAttackPlus);
        skillCodes.Add("BombRangePlus", BombRangePlus);
        skillCodes.Add("BombCarryPlus", BombCarryPlus);
        skillCodes.Add("BombPricePlus", BombPricePlus);
    }

    public static void SkillLevelUp(int id) {
        string skillCode = JsonManager.Instance.ArtifactDict[id].skillCode;
        skillCodes.TryGetValue(JsonManager.Instance.ArtifactDict[id].skillCode, out Action<int> skillAction);
        skillAction?.Invoke(id);
    }

    private static void Common1LvSkills(int id) {
        if (PlayerStats.Instance.SkillLevels.TryGetValue(id, out int level)) {
            if (level == 0) 
                PlayerStats.Instance.SkillLevels[id] = 1;
        }
    }

    private static void CommonSkillLevelUp(int id, int maxLevel) {
        if (PlayerStats.Instance.SkillLevels.TryGetValue(id, out int level)) {
            if (level < maxLevel)
                PlayerStats.Instance.SkillLevels[id] += 1;
        }
    }

    private static void GoldPlus(int id) {
        int maxLevel = 5;
        float[] values = { 1, 1.5f, 2, 2.5f, 3, 5};

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.GoldGain = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void AttackPlus(int id) {
        int maxLevel = 5;
        float[] values = { 1, 2, 4, 8, 15, 50 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.Attack = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void CooldownPlus(int id) {
        int maxLevel = 5;
        float[] values = { 2, 1.5f, 2, 2.5f, 3, 5 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.Cooldown = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void RangePlus(int id) {
        int maxLevel = 5;

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.AttackObject = PlayerStats.Instance.AttackObjectCodes[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void DurabilityPlus(int id) {
        int maxLevel = 5;
        int[] values = { 100, 150, 200, 300, 500, 1000 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.Durability = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void MoveSpeedPlus(int id) {
        int maxLevel = 5;
        float[] values = { 15, 22.5f, 30, 45, 60, 75 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.Speed = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void BombAttackPlus(int id) {
        int maxLevel = 5;
        float[] values = { 1, 1.5f, 2, 2.5f, 3, 5 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.GoldGain = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void BombRangePlus(int id) {
        int maxLevel = 5;
        float[] values = { 1, 1.5f, 2, 2.5f, 3, 5 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.GoldGain = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void BombCarryPlus(int id) {
        int maxLevel = 5;
        float[] values = { 1, 1.5f, 2, 2.5f, 3, 5 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.GoldGain = values[PlayerStats.Instance.SkillLevels[id]];
    }

    private static void BombPricePlus(int id) {
        int maxLevel = 5;
        float[] values = { 1, 1.5f, 2, 2.5f, 3, 5 };

        CommonSkillLevelUp(id, maxLevel);
        PlayerStats.Instance.GoldGain = values[PlayerStats.Instance.SkillLevels[id]];
    }
}