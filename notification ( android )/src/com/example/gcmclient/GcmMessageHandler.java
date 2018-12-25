package com.example.gcmclient;

import com.google.android.gms.gcm.GoogleCloudMessaging;
import android.app.IntentService;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.app.NotificationCompat;
import android.util.Log;
import android.widget.Toast;

public class GcmMessageHandler extends IntentService {

     String mes;
     private Handler handler;
    public GcmMessageHandler() {
        super("GcmMessageHandler");
    }

    @Override
    public void onCreate() {
        // TODO Auto-generated method stub
        super.onCreate();
        handler = new Handler();
    }
    @Override
    protected void onHandleIntent(Intent intent) {
        Bundle extras = intent.getExtras();

        GoogleCloudMessaging gcm = GoogleCloudMessaging.getInstance(this);
        // The getMessageType() intent parameter must be the intent you received
        // in your BroadcastReceiver.
        String messageType = gcm.getMessageType(intent);

       mes = extras.getString("message");
       showToast();
       Log.i("GCM", "Received : (" +messageType+")  "+extras.getString("title"));

        GcmBroadcastReceiver.completeWakefulIntent(intent);
        
        SharedPreferences pref = getApplicationContext().getSharedPreferences("AlertPref", MODE_PRIVATE); 
        Editor editor = pref.edit();
        editor.putString("gcmmsg", mes );
        editor.commit(); 
    }

    public void showToast(){
        handler.post(new Runnable() {
            public void run() {
                Toast.makeText(getApplicationContext(),mes , Toast.LENGTH_LONG).show();
                Notify("Alert from admin" , mes);
            }
         });
    }
    
    @SuppressWarnings("deprecation")
    private void Notify(String notificationTitle, String notificationMessage) {
     NotificationManager notificationManager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
     @SuppressWarnings("deprecation")
     Notification notification = new Notification(R.drawable.ic_launcher,
       "New Message", System.currentTimeMillis());
     notification.defaults |= Notification.DEFAULT_VIBRATE;
     long[] vibrate = {0,100,200,300};
     notification.vibrate = vibrate;
     notification.defaults |= Notification.DEFAULT_SOUND;
     
      Intent notificationIntent = new Intent(this, ViewService.class);
     PendingIntent pendingIntent = PendingIntent.getActivity(this, 0,
       notificationIntent, 0);

      notification.setLatestEventInfo(this, notificationTitle,
       notificationMessage, pendingIntent);
     notificationManager.notify(9999, notification);
    }
}