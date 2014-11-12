package com.example.gridview;

import java.util.ArrayList;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.GridView;
import android.widget.Toast;

public class MainActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        final ArrayList<String> daysOfWeek = new ArrayList<String>();
        daysOfWeek.add("Monday");
        daysOfWeek.add("Tuesday");
        daysOfWeek.add("Wensday");
        daysOfWeek.add("Thursday");
        daysOfWeek.add("Friday");
        daysOfWeek.add("Saturday");
        daysOfWeek.add("Sunday");
        
        Button btn = (Button)findViewById(R.id.btn);
        final GridView gird = (GridView)findViewById(R.id.grid);
        
        btn.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
                ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>
                	(MainActivity.this ,android.R.layout.simple_list_item_1, daysOfWeek);
                // Set The Adapter
                gird.setAdapter(arrayAdapter); 
			}
		});
        
        gird.setOnItemClickListener(new OnItemClickListener()
        {
            public void onItemClick(AdapterView<?> arg0, View v,int position, long arg3)
            {
                String selectedDay=daysOfWeek.get(position);
                Toast.makeText(getApplicationContext(), "Day selected : "+selectedDay,   Toast.LENGTH_LONG).show();
            }
        });
    }
}
