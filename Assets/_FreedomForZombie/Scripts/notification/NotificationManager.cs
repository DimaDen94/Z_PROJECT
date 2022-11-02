using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    // Start is called before the first frame update
#if UNITY_ANDROID
    void Start()
    {
        //??????? ??? ???????????? ???????????
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        //??????????? ?????? ??? ???????????
        var channel = new AndroidNotificationChannel()
        {
            Id = "the_walking_zombie_defense",
            Name = "The Walking Zombie Defense",
            Importance = Importance.Default,
            Description = "Reminder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //???????? ???????????
        var notification = new AndroidNotification();
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";
        notification.Title = "Come back";
        notification.Text = "We need you our lord";
        notification.FireTime = System.DateTime.Now.AddDays(1);

        var id = AndroidNotificationCenter.SendNotification(notification, "the_walking_zombie_defense");

        //???? ??????????? ??? ??????????, ?? ?????????? ?????, ? ?????? ????????
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled) { 
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "the_walking_zombie_defense");
        }
    }
#endif

}
