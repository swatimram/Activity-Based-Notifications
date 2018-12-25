package com.example.gcmclient;

import android.os.Bundle;
import android.app.Activity;
import android.content.SharedPreferences;
import android.text.Html;
import android.text.method.LinkMovementMethod;
import android.view.Menu;
import android.widget.TextView;

public class ViewService extends Activity {

	TextView Text1;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_view_service);
	  Text1 = ( TextView)findViewById( R.id.textView1);
	  SharedPreferences pref = getApplicationContext().getSharedPreferences("AlertPref", MODE_PRIVATE); 
      String pubid = pref.getString("gcmmsg", null);
      pubid = pubid.split("-")[1];
      Text1.setText(
    	        Html.fromHtml(
    	            "<a href=\"http://njsempire.com/psn/SubscriberViewPublishContent.aspx?PublishContentId=" + pubid + "\">Click here</a>"));
    	    Text1.setMovementMethod(LinkMovementMethod.getInstance());
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.activity_view_service, menu);
		return true;
	}

}
