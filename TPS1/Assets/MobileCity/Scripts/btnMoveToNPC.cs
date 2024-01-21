using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class btnMoveToNPC : MonoBehaviour
{
    public GameObject player; 
    public GameObject NPC;
    public Button btnMoveToNPC1; 
    private NavMeshAgent npcNavMeshAgent;

    void Start()
    {
        Button btn = btnMoveToNPC1.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        npcNavMeshAgent = NPC.GetComponent<NavMeshAgent>();
    }

    void OnClick()
    {
        player.transform.position = NPC.transform.position; // Di chuyển nhân vật chính đến vị trí của NPC
        Vector3 npcPosition = NPC.transform.position;
        npcNavMeshAgent.SetDestination(npcPosition);
    }
}
