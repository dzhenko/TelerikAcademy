package com.example.androidfragment;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class ProductActivity extends Fragment {
	TextView tv1, tv2;

	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		View rootView = inflater.inflate(R.layout.fragment_product, container,
				false);

		tv1 = (TextView) rootView.findViewById(R.id.textView1);
		tv2 = (TextView) rootView.findViewById(R.id.textView2);

		Bundle bundle = this.getArguments();
		
		tv1.setText("Product: " + bundle.getString("product"));
		tv2.setText("Category: " + bundle.getString("category"));
		return rootView;
	}
}
