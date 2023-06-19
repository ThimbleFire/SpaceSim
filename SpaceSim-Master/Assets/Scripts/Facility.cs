using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Facility : MonoBehaviour {

    public enum EType {
        Undefined,
        Toilet, 
        Fridge, 
        Sink, 
        Engine,
        Turbine,
        Navigations, 
        LifeSupport, 
        CaptainsChair,
        NPC //Medic associates NPCs are a facility that needs repairing
    };
    
    public EType Type = EType.Undefined;
    public bool Broken = false;
    [HideInInspector]
    public Vector3Int Coordinates = Vector3Int.zero;
    public Vector2Int Size = Vector2Int.zero;
    // temporarily removed. Use transform.position instead
    //public Vector3 WorldPosition { get; set; } = Vector3.zero;
    
    /// <summary> When an NPC starts an interaction, roll to see whether facility breaks </summary>
    public virtual void InteractStart() => GameTime.OnTck += GameTime_OnTick;
    public virtual void InteractEnd() => GameTime.OnTck -= GameTime_OnTick;
    
    protected virtual void GameTime_OnTick() {
        if(! Broken)
            DamageRoll();
    }
    
    /// <summary> While engaged, every tick there's a 1 in 256 chance the facility will break.
    /// We might change this in the future so skilled crew damage facilities less often. </summary>
    private void DamageRoll() {
        int r = Random.Range(0, 255);
        if(r <= 0)
            Broken = true;
    }

    public bool Contains(Vector3Int coordinates) {
        for( int y = 0; y > -Size.y; y-- )
            for( int x = 0; x < Size.x; x++ ) {
                if(Coordinates.x + x == coordinates.x && 
                   Coordinates.y + y == coordinates.y)
                    return true;
            }
        return false;
    }

    public void UnoccupyPathfind() {
        for( int y = 0; y > -Size.y; y-- )
            for( int x = 0; x < Size.x; x++ )
                AlwaysEast.Pathfind.Unoccupy( Coordinates + new Vector3Int( x, y, 0 ) );
    }
}

public class Facilities
{
    public static bool PlacementMode { get; set; } = false;

    private static List<Facility> FacilityList = new List<Facility>();

    public static Facility Add( GameObject prefab ) {
        Facility f = GameObject.Instantiate(prefab).GetComponent<Facility>();
        FacilityList.Add( f );
        return f;
    }
    public static void Add( GameObject prefab, Vector3 worldPosition, Vector3Int coordinates ) {
        Vector3 offset = new Vector3(0.04f, 0.04f);
        Facility f = GameObject.Instantiate(prefab, worldPosition + offset, Quaternion.identity).GetComponent<Facility>();
        f.Coordinates = coordinates;
        FacilityList.Add( f );
    }
    public static Facility Get( Vector3Int coordinates ) {
        return FacilityList.FindAll( x => x.Coordinates == coordinates )?[0];
    }
    public static Facility Get( Facility.EType t ) {
        return FacilityList.FindAll( x => x.Type == t )?[0];
    }
    public static void Sort() => FacilityList.Sort();

    /// <summary> Remove the facility from the game and unoccupy the tiles it's using.</summary>
    public static void Remove( Vector3Int coordinates ) {

        Facility toDestroy = null;

        for( int i = 0; i < FacilityList.Count; i++ ) {
            if( FacilityList[i].Contains( coordinates ) ) {
                FacilityList[i].UnoccupyPathfind();
                toDestroy = FacilityList[i];
                break;
            }
        }

        FacilityList.Remove( toDestroy );
        GameObject.Destroy( toDestroy.gameObject );
    }
}