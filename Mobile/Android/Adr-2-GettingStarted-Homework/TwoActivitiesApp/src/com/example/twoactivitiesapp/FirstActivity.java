package com.example.twoactivitiesapp;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class FirstActivity extends Activity {
    
    public static final String EXTRA_NAME = "com.example.twoactivitiesapp.NAME";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first);
        
        Button btn = (Button)findViewById(R.id.btn);
        final EditText nameText = (EditText)findViewById(R.id.name);
        
        btn.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				Intent in = new Intent(FirstActivity.this, SecondActivity.class);
				String message = nameText.getText().toString();
				in.putExtra(EXTRA_NAME, message);
				startActivity(in);
			}
		});
    }
}
