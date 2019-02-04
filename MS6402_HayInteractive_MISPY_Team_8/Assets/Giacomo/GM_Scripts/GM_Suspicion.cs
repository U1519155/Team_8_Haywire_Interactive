using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GM_Suspicion
{
    // Suspicion counter
    public static int in_Suspicion = 0;

    // Enable if the specific type of guard is talking
    public static bool bl_GuardTalk = false;

    // If PC is trespassing and guards need to investigate (using a gadget included)
    public static bool bl_PCwanted;
}