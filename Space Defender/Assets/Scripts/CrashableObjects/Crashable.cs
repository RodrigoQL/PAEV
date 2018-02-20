using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Crashable : MonoBehaviour {

    public CrashableType CrashableType;
    public int TotalHealth;
    public int DamageModifier = 0;
    public float DamageMultiplier = 1;
    public GameObject Explosion;

    protected int currentHealth;

    public int DealDamage() {
        float damageReturn = 0;
        switch (CrashableType) {
            case CrashableType.Standard:
                damageReturn = TotalHealth / 2;
                break;
            case CrashableType.Explosive:
                damageReturn = TotalHealth * 2;
                break;
            case CrashableType.Penetrating:
                damageReturn = TotalHealth;
                break;
            case CrashableType.Ship:
                damageReturn = TotalHealth;
                break;
        }
        damageReturn = ( damageReturn * DamageMultiplier ) + DamageModifier;
        return ( int )damageReturn;
    }

    protected void ReceiveDamage(Crashable crashable) {
        if (CrashableType == CrashableType.Explosive) {
            currentHealth = 0;
        }
        else {
            currentHealth -= crashable.DealDamage();
        }

        if (currentHealth <= 0) {
            DestroySelf();
        }
    }

    protected abstract void DestroySelf();
}

public enum CrashableType{
    Ship, Explosive, Penetrating, Standard
}
