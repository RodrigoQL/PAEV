using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Crashable : MonoBehaviour {

    public CrashableType CrashableType;
    public int Health;
    public int damageModifier;
    public float damageMultiplier;

    public int DealDamage() {
        float damageReturn = 0;
        switch (CrashableType) {
            case CrashableType.Standard:
                damageReturn = Health / 2;
                break;
            case CrashableType.Explosive:
                damageReturn = Health * 2;
                break;
            case CrashableType.Penetrating:
                damageReturn = Health;
                break;
            case CrashableType.Ship:
                damageReturn = Health;
                break;
        }
        damageReturn = ( damageReturn * damageMultiplier ) + damageModifier;
        return ( int )damageReturn;
    }

    protected void ReceiveDamage(Crashable crashable) {
        Health -= crashable.DealDamage();
        if (Health<=0) {
            DestroySelf();
        }
    }

    protected abstract void DestroySelf();
}

public enum CrashableType{
    Ship, Explosive, Penetrating, Standard
}
