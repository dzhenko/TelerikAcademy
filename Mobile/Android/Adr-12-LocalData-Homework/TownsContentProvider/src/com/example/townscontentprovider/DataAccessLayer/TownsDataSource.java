package com.example.townscontentprovider.DataAccessLayer;

import java.util.ArrayList;
import java.util.List;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;

public class TownsDataSource {
	 // Database fields
    private SQLiteDatabase database;
    private SQLiteHelper dbHelper;
    private String[] allColumns = { SQLiteHelper.COLUMN_ID,
            SQLiteHelper.COLUMN_NAME };

    public TownsDataSource(Context context) {
        dbHelper = new SQLiteHelper(context);
    }

    public void open() throws SQLException {
        database = dbHelper.getWritableDatabase();
    }

    public void close() {
        dbHelper.close();
    }

    public Town createTown(String name) {
        ContentValues values = new ContentValues();
        values.put(SQLiteHelper.COLUMN_NAME, name);
        long insertId = database.insert(SQLiteHelper.TABLE_TOWNS, null,
                values);
        Cursor cursor = database.query(SQLiteHelper.TABLE_TOWNS,
                allColumns, SQLiteHelper.COLUMN_ID + " = " + insertId, null,
                null, null, null);
        cursor.moveToFirst();
        Town newTown = cursorToTown(cursor);
        cursor.close();
        return newTown;
    }

    public void deleteTown(Town town) {
        long id = town.getId();
        System.out.println("Town deleted with id: " + id);
        database.delete(SQLiteHelper.TABLE_TOWNS, SQLiteHelper.COLUMN_ID
                + " = " + id, null);
    }

        public List<Town> getAllTowns() {
        List<Town> towns = new ArrayList<Town>();

        Cursor cursor = database.query(SQLiteHelper.TABLE_TOWNS,
                allColumns, null, null, null, null, null);

        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            Town town = cursorToTown(cursor);
            towns.add(town);
            cursor.moveToNext();
        }
        
        cursor.close();
        return towns;
    }

    private Town cursorToTown(Cursor cursor) {
        Town town = new Town();
        town.setId(cursor.getLong(0));
        town.setName(cursor.getString(1));
        return town;
    }

}
