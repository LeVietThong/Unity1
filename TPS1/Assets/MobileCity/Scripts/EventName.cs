using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventName
{
    public static string PauseReceiveInput = "PauseReceiveInput";
    public static string ResumeReceiveInput = "ResumeReceiveInput";
    public static string LockCamera = "LockCamera";
    public static string UnlockCamera = "UnlockCamera";
    public static string ObjectDeselected = "ObjectDeselected";
    public static string ObjectDeselectedPlayer = "ObjectDeselectedPlayer";
    public static string ObjectSelected = "ObjectSelected";
    public static string PlayerSelected = "PlayerSelected";
    public static string PlayerDeSelected = "PlayerDeSelected";
    
    // chat
    public static string ReceiveChatGlobal = "ReceiveChatGlobal";
    public static string ReceiveChatPrivate = "ReceiveChatPrivate";
    public static string ReceiveChatRoom = "ReceiveChatRoom";
    public static string ChangeUserStatus = "ChangeUserStatus";
    public static string OpenChatPrivate = "OpenChatPrivate";
    public static string AddMessageChatGlobal = "AddMessageChatGlobal";
    

    // sync
    public static string ReceiveSyncData = "ReceiveSyncData";


    public static string OnLoadedScene = "OnLoadedScene";
    public static string OnMovedTargetByNavMesh = "OnMovedTargetByNavMesh";

    public static string UpdateMainGameChat = "UpdateMainGameChat";

    public static string NewGift = "NewGift";

    #region Friend Realtime
    public static string OtherAcceptAddFriend = "OtherAcceptAddFriend";
    public static string OtherAddFriend = "OtherAddFriend";
    public static string OtherCancelAddFriend = "OtherCancelAddFriend";
    public static string OtherDeclineAddFriend = "OtherDeclineAddFriend";
    public static string OtherUnfriend = "OtherUnfriend";
    public static string SelfUnfriend = "SelfUnfriend";
    #endregion

    #region Avatar Realtime
    public static string RealtimeAvatar = "RealtimeAvatar";
    #endregion

    #region Quest
    public static string MaybeCompleteOneQuest = "MaybeCompleteOneQuest";
    #endregion

    #region Chat
    public const string ShowInfoPlayerPopup = "ShowInfoPlayerPopup";
    #endregion

    #region Addressable

    public static string PreLoadProgressEvent = "PreLoadProgressEvent";
    public static string PreloadCompletionEvent = "PreloadCompletionEvent";
    public static string PreloadCompletionEventFake = "FakePreloadCompletionEventFake";
    
    public static string MapLoadDone = "MapLoadDone";

    #endregion

    #region BrainWar
    public static string BrainWar_SelectAnswer = "BrainWar_SelectAnswer";
    public static string BrainWar_AnswerRight = "BrainWar_AnswerRight";
    #endregion
}
