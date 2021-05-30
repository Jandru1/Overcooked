using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HoldData
{
   private static int puntos = 0;
   private static int LastLevel;
    // Start is called before the first frame update
   public static void setpoints(int value)
    {
        puntos = value;
    }
    public static int getpoints()
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
