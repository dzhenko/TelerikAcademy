package com.example.twoactivitiesapp;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class SecondActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_second);
		
		Intent intent = getIntent();
		String message = intent.getStringExtra(FirstActivity.EXTRA_NAME);
		
		((TextView)findViewById(R.id.result)).setText("Hello " + message + " !");
	}
}
