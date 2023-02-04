using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        COINS,
        DIAMONDS,
        JUMP,
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXByType (VFXType type, Vector2 position)
    {
        foreach (var i in vfxSetup)
        {
            if (i.vfxType == type)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 2f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}
