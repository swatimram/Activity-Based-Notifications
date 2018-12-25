package com.example.gcmclient;

import java.io.IOException;

import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.gcm.GoogleCloudMessaging;
public class MainActivity extends Activity {

	Button btnRegId;
    GoogleCloudMessaging gcm;
    String regid;
    String PROJECT_NUMBER = "968912281773";  
    
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnRegId = (Button) findViewById(R.id.btnGetRegId);	
        btnRegId.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View arg0) {
				// TODO Auto-generated method stub
				getRegId();
			}
		});
    }
    
    public void getRegId(){
        new AsyncTask<Void, Void, String>() {
            @Override
            protected String doInBackground(Void... params) {
                try {
                    if (gcm == null) {
                        gcm = GoogleCloudMessaging.getInstance(getApplicationContext());
                    }
                    regid = gcm.register(PROJECT_NUMBER);
            
                } catch (IOException ex) {
                   
                }
                return regid;
            }

            @Override
            protected void onPostExecute(String msg) {
                
            	Intent intent = new Intent(Intent.ACTION_SENDTO); // it's not ACTION_SEND
            	intent.setType("text/plain");
            	intent.putExtra(Intent.EXTRA_SUBJECT, "Device Id");
            	intent.putExtra(Intent.EXTRA_TEXT, msg);
            	intent.setData(Uri.parse("mailto:mail.9845115777@gmail.com")); // or just "mailto:" for blank
            	intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK); // this will make such that when user returns to your app, your app is displayed, instead of the email app.
            	startActivity(intent);
            	Toast.makeText( getApplicationContext(), "Device Registered and sending ID to authority", Toast.LENGTH_LONG).show();
            }
        }.execute(null, null, null);
    }
    

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.activity_main, menu);
        return true;
    }
    
}
