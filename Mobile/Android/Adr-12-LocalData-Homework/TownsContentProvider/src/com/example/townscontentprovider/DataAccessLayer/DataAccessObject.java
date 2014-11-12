package com.example.townscontentprovider.DataAccessLayer;

import java.util.List;

import com.example.townscontentprovider.R;

import android.app.ListActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;

public class DataAccessObject extends ListActivity {

    private TownsDataSource datasource;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        datasource = new TownsDataSource(this);
        datasource.open();

        List<Town> values = datasource.getAllTowns();

        // use the SimpleCursorAdapter to show the
        // elements in a ListView
        ArrayAdapter<Town> adapter = new ArrayAdapter<Town>(this,
                android.R.layout.simple_list_item_1, values);
        setListAdapter(adapter);
    }

    // Will be called via the onClick attribute
    // of the buttons in main.xml
    public void onClick(View view) {
        String townName = ((EditText) view.findViewById(R.id.editText1)).getText().toString();
        ((EditText) view.findViewById(R.id.editText1)).setText("");

        @SuppressWarnings("unchecked")
        ArrayAdapter<Town> adapter = (ArrayAdapter<Town>) getListAdapter();
        Town town = datasource.createTown(townName);
        adapter.add(town);
        adapter.notifyDataSetChanged();
    }

    @Override
    protected void onResume() {
        datasource.open();
        super.onResume();
    }

    @Override
    protected void onPause() {
        datasource.close();
        super.onPause();
    }
}

