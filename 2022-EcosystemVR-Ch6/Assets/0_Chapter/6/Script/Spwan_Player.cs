using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan_Player : MonoBehaviour
{
    public GameObject PC, VR;
    public GameObject ModelParent_PC, ModelParent_VR;
    public GameObject CharactorController_PC, CharactorController_VR,XROrigin;
    public GameObject Model;
    public GameObject[] spawnpoints;
    Vector3 SpawnOffset;

    private void Start()
    {
        SpawnOffset = Vector3.zero;
        PC.transform.position = spawnpoints[0].transform.position;
        VR.transform.position = spawnpoints[0].transform.position;
        CharacterController_Collision component = GetComponent<CharacterController_Collision>();
        if (GlobalSet.playMode == GlobalSet.PlayMode.PC)
        {
            Model.transform.SetParent(ModelParent_PC.transform);
            CopyValues<CharacterController_Collision>(component, CharactorController_PC.AddComponent<CharacterController_Collision>());
            
        }
        if (GlobalSet.playMode == GlobalSet.PlayMode.VR)
        {
            Model.transform.SetParent(ModelParent_VR.transform);
            CopyValues<CharacterController_Collision>(component, CharactorController_VR.AddComponent<CharacterController_Collision>());
        }
    }
    void CopyValues<T>(T from, T to)
    {
        var json = JsonUtility.ToJson(from);
        JsonUtility.FromJsonOverwrite(json, to);
    }

    public IEnumerator Respawn(int SpawnpointNumber)
    {
        Debug.Log(GlobalSet.playMode);
        if (GlobalSet.playMode == GlobalSet.PlayMode.PC)
        {
            CharactorController_PC.GetComponent<CharacterController>().enabled = false;
            CharactorController_PC.transform.localPosition = spawnpoints[SpawnpointNumber].transform.localPosition + SpawnOffset;
            yield return new WaitForSeconds(1);
            CharactorController_PC.GetComponent<CharacterController>().enabled = true;
        }
        if (GlobalSet.playMode == GlobalSet.PlayMode.VR)
        {
            CharactorController_VR.GetComponent<CharacterController>().enabled = false;
            CharactorController_VR.transform.position = spawnpoints[SpawnpointNumber].transform.position;
            XROrigin.transform.position = spawnpoints[SpawnpointNumber].transform.position + new Vector3(0, -2.25f,0);
            yield return new WaitForSeconds(1);
            CharactorController_VR.GetComponent<CharacterController>().enabled = true;
        }
    }
}
