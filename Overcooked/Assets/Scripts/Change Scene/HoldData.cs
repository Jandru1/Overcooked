using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HoldData
{
   private static float puntos = 0f;
   private static int LastLevel;
   public static void setpoints(float value)
    {
        puntos = value;
    }
    public static float getpoints()
    {
        return puntos;
    }
    public static void setLastLevel(int value)
    {
        LastLevel = value;
    }
    public static int getLevel()
    {
        return LastLevel;
    }
}
