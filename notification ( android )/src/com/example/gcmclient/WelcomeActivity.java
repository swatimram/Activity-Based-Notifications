package com.example.gcmclient;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class WelcomeActivity extends Activity implements OnClickListener{
	Button welcomebtn;
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.welcome_activity);
		welcomebtn=(Button)findViewById(R.id.buttonWelcome);
		welcomebtn.setOnClickListener(this);
	}
	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		Intent in=new Intent();
		in.setClass(getApplicationContext(), MainActivity.class);
		startActivity(in);
		this.finish();
	}
	
}
