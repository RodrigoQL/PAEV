﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Crashable : Moving {

    public CrashableType CrashableType;
    public int TotalHealth;
    public int DamageModifier = 0;
    public float DamageMultiplier = 1;
    public GameObject Explosion;

    protected int currentHealth;

    protected override void Start() {
        base.Start();
        currentHealth = TotalHealth;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        Crashable impactObject = collision.gameObject.GetComponent<Crashable>();
        if (impactObject != null) {
            ReceiveDamage( impactObject );
        }
    }
    public int DealDamage() {
        float damageReturn = 0;
        switch (CrashableType) {
            case CrashableType.Standard:
                damageReturn = TotalHealth / 2;
                break;
            case CrashableType.Explosive:
                damageReturn = TotalHealth * 4;
                break;
            case CrashableType.Penetrating:
                damageReturn = TotalHealth * 2;
                break;
            case CrashableType.Ship:
                damageReturn = TotalHealth;
                break;
            case CrashableType.Asteroid:
                damageReturn = TotalHealth / 50;
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
    Ship, Explosive, Penetrating, Standard, Asteroid
}
